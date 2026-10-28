# Arquitectura de Software y Diseño Orientado a Objetos
**Sistema de Gestión — Club Deportivo (CLUB67)**  
*Documento de Diseño Técnico y Arquitectura de Sistemas*  
*Autora:* **Sabrina Belén Mamaniz**  

---

## 1. Patrón Arquitectónico en Tres Capas (3-Tier Layered Architecture)

El sistema implementa una arquitectura desacoplada en tres capas para garantizar mantenibilidad, testeo independiente y clara separación de responsabilidades:

```
┌────────────────────────────────────────────────────────┐
│           1. CAPA DE PRESENTACIÓN (UI)                 │
│  WinForms (.NET / C#)                                  │
│  Login.cs, Home.cs, Inscripcion.cs, Pago.cs,           │
│  Profesor.cs, ServicioNutricion.cs                     │
└──────────────────────────┬─────────────────────────────┘
                           │ (Peticiones de UI / DTOs)
                           ▼
┌────────────────────────────────────────────────────────┐
│             2. CAPA DE NEGOCIO (BLL)                   │
│  Reglas de Dominio, Validaciones y Modelos POO         │
│  Club.cs (Singleton), Cliente.cs, Socio.cs,            │
│  NoSocio.cs, Pago.cs, Carnet.cs, FichaMedica.cs        │
└──────────────────────────┬─────────────────────────────┘
                           │ (Llamadas a repositorios)
                           ▼
┌────────────────────────────────────────────────────────┐
│              3. CAPA DE DATOS (DAL)                    │
│  Persistencia & Conectividad (MySQL 8.0)               │
│  Conectividad.cs, ClienteDatos.cs, PagoDatos.cs,       │
│  ProfesorDatos.cs, FichaMedicaDatos.cs                 │
└────────────────────────────────────────────────────────┘
```

### Detalle de Responsabilidades por Capa:
1. **Capa de Presentación:** Captura eventos de usuario, valida entradas a nivel tipográfico/campos vacíos (`ErrorProvider`), invoca métodos de la capa de negocio y renderiza retroalimentación visual al administrativo.
2. **Capa de Negocio:** Encapsula la lógica de dominio (cálculo de vigencia de 30 días, reglas de inhabilitación por mora, validación de apto físico, emisión condicional de carnets y cálculo de comisiones/cuotas con tarjeta).
3. **Capa de Datos:** Gestiona la apertura y cierre de conexiones mediante `MySqlConnection`, ejecuta consultas parametrizadas para prevenir inyecciones SQL (`SQL Injection`) y mapea los resultados (`DataReaders`) hacia objetos del dominio.

---

## 2. Patrones de Diseño Implementados

### 2.1 Patrón Creacional: Singleton (`Club.cs`)
* **Propósito:** Garantizar que exista una **única instancia** en memoria durante todo el ciclo de vida de la aplicación para centralizar el acceso a la configuración del club, sesiones de usuario y cachés de listas maestras (actividades y docentes).
* **Implementación:**
  - Constructor privado para impedir instanciación externa directa.
  - Atributo estático `private static Club _instancia`.
  - Propiedad de acceso global `public static Club Instancia` con inicialización controlada (*lazy initialization* o inicialización estática segura para entornos multi-hilo).

### 2.2 Patrón Estructural / Acceso a Datos: Repository Pattern
* **Propósito:** Mediar entre la capa de dominio y la capa de mapeo de datos, actuando como una colección en memoria de objetos de dominio.
* **Beneficio:** Si en el futuro se migra el motor de base de datos de MySQL a PostgreSQL o SQL Server, únicamente se reemplazan las clases de la carpeta `Datos/` sin alterar una sola línea de código en la capa de negocio ni en los formularios.

### 2.3 Herencia y Polimorfismo en el Modelo de Dominio

```mermaid
classDiagram
    class Cliente {
        <<abstract>>
        #int idCliente
        #string nombre
        #string apellido
        #string dni
        #string telefono
        #string direccion
        #bool aptoFisico
        +validarAptoFisico() bool
    }

    class Socio {
        -int idSocio
        -bool vigente
        -DateTime fechaVencimiento
        -bool carnetEmitido
        +registrarPagoMensual() bool
        +actualizarVencimiento(dias: int) void
        +actualizarEstado() void
    }

    class NoSocio {
        -int idNoSocio
        -bool vigente
        +registrarPagoActividad() bool
    }

    Cliente <|-- Socio : Herencia
    Cliente <|-- NoSocio : Herencia

    class Pago {
        <<abstract>>
        #int idPago
        #decimal monto
        #DateTime fechaPago
        #string medioDePago
        +generarComprobante() Comprobante
    }

    class PagoMensual {
        -DateTime fechaVencimientoCalculada
        -int cantidadCuotas
        +generarComprobante() Comprobante
    }

    class PagoActividad {
        -int idActividad
        +emitirTicketDiario() Ticket
    }

    Pago <|-- PagoMensual : Herencia
    Pago <|-- PagoActividad : Herencia
```

---

## 3. Diagrama de Secuencia: Cobro y Acreditación de Cuota Mensual

Modela el flujo de llamadas e interacción temporal entre componentes al registrar un pago:

```mermaid
sequenceDiagram
    autonumber
    actor Admin as Administrativo
    participant UI as FormPago (UI)
    participant Ctrl as Club (BLL Singleton)
    participant Model as Socio (Entidad)
    participant Repo as PagoDatos (DAL)
    participant DB as MySQL Database

    Admin->>UI: Ingresa DNI y pulsa "Buscar"
    UI->>Ctrl: buscarSocioPorDni(dni)
    Ctrl->>Repo: obtenerPorDni(dni)
    Repo->>DB: SELECT * FROM clientes INNER JOIN socios WHERE dni = @dni
    DB-->>Repo: Registro del socio
    Repo-->>Ctrl: Instancia Socio
    Ctrl-->>UI: Datos del socio (Estado, Vencimiento)
    UI-->>Admin: Muestra datos en pantalla

    Admin->>UI: Selecciona medio de pago y pulsa "Confirmar Cobro"
    UI->>Ctrl: registrarPagoMensual(idSocio, monto, medioPago, cuotas)
    Ctrl->>Model: actualizarVencimiento(30)
    Model-->>Ctrl: Vigencia recalculada
    Ctrl->>Repo: guardarPago(idSocio, monto, medioPago, nuevaFecha)
    Repo->>DB: INSERT INTO pagos (...) & UPDATE socios SET fecha_vencimiento = ...
    DB-->>Repo: Transacción confirmada (OK)
    Repo-->>Ctrl: Confirmación de persistencia
    Ctrl->>UI: Comprobante digital generado
    UI-->>Admin: Muestra confirmación e imprime ticket
```

---

## 4. Diagrama de Estados: Ciclo de Vida de la Membresía del Socio

```mermaid
stateDiagram-v2
    [*] --> Inscripto : Alta de Cliente (Presenta Apto Físico)
    Inscripto --> Activo_Vigente : Pago Primera Cuota Mensual (+30 días)
    
    Activo_Vigente --> Activo_Vigente : Pago de Cuota Anticipada (+30 días acumulativos)
    Activo_Vigente --> Inhabilitado_Moroso : Transcurren 30 días sin pago (Fecha > Vencimiento)
    
    Inhabilitado_Moroso --> Inhabilitado_Moroso : Intento de ingreso (Acceso bloqueado en molinete)
    Inhabilitado_Moroso --> Activo_Vigente : Pago en Administración (Vencimiento computado desde fecha de corte previa)
    
    Activo_Vigente --> Baja_Definitiva : Solicitud de baja voluntaria
    Inhabilitado_Moroso --> Baja_Definitiva : Inactividad prolongada (> 6 meses)
    Baja_Definitiva --> [*]
```
