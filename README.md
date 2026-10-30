# Sistema de Gestión para Club Deportivo (CLUB67)
> Trabajo Integrador de Modelado de Software y Desarrollo Orientado a Objetos (.NET C# y MySQL)  


[![Tecnología](https://img.shields.io/badge/.NET-C%23-blue?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![Base de Datos](https://img.shields.io/badge/MySQL-8.0-orange?style=flat-square&logo=mysql)](https://www.mysql.com/)
[![Patrones](https://img.shields.io/badge/Arquitectura-3%20Capas%20%7C%20Singleton%20%7C%20Repository-success?style=flat-square)](#)
[![Modelado](https://img.shields.io/badge/UML-Casos%20de%20Uso%20%7C%20Clases%20%7C%20Secuencia-purple?style=flat-square)](#)

---

## Origen y Contexto del Proyecto

Desarrollé este proyecto como Trabajo Práctico Integrador para las materias **Modelado y Diseño de Software** y **Desarrollo de Software Orientado a Objeto** del IFTS N° 29. 

El objetivo era modelar e implementar el circuito operativo de un club deportivo barrial: administración de socios, cobro de aranceles, control de accesos por cuota al día, relevación de la consulta de nutrición y registro de ingreso del personal. 

En vez de limitarme a una interfaz visual simple, encaré el proyecto desde la ingeniería de software: primero relevé los procesos y reglas del negocio, después modelé la solución con diagramas UML formales y finalmente construí la arquitectura en capas conectada a MySQL.

---

## Decisiones de Negocio y Reglas que Implementé

Cuando analicé el funcionamiento del club, identifiqué cinco reglas clave que debían reflejarse en el sistema:

1. **Diferenciación entre Socios y No Socios:** Los socios pagan una cuota mensual recurrente que les permite acceder a las instalaciones. Los no socios solo abonan un pase diario para la actividad puntual que eligen en el día.
2. **Cálculo de vencimientos a 30 días continuos:** Si un socio se atrasa y paga fuera de término, los 30 días no se cuentan desde el día del pago, sino a partir de la fecha de su vencimiento anterior. De esta manera, el club evita que un socio saltee períodos impagos.
3. **Apto físico obligatorio:** Ningún cliente puede completar su registro ni participar en actividades sin presentar el certificado médico. En el sistema, la validación del apto bloquea el guardado si no está tildada la recepción del documento.
4. **Carnet exclusivo para socios al día:** El carnet con identificador único solo se genera para socios con cuota vigente. 
5. **Financiación con tarjeta:** El cobro en 3 o 6 cuotas se restringe únicamente al medio de pago tarjeta de crédito.

---

## Arquitectura del Software

Organicé el código en tres capas separadas para que cada componente tenga una única responsabilidad:

* **Capa de Presentación (UI):** Formularios de escritorio en WinForms (C#) con validaciones en tiempo real para evitar campos vacíos o formatos inválidos.
* **Capa de Negocio (BLL):** Clases del dominio con las reglas del club. Utilicé el patrón creacional **Singleton** en la clase `Club` para mantener una única instancia administradora en memoria con las listas maestras, y apliqué herencia tanto en clientes (`Cliente` -> `Socio` / `NoSocio`) como en pagos (`Pago` -> `PagoMensual` / `PagoActividad`).
* **Capa de Datos (DAL):** Apliqué el patrón **Repository** mediante clases específicas de acceso a datos (`ClienteDatos.cs`, `PagoDatos.cs`, etc.) y una clase central `Conectividad.cs`. Todas las consultas contra MySQL utilizan parámetros para evitar inyecciones SQL.

---

## Diagramas del Sistema (UML)

### Casos de Uso
El siguiente diagrama resume los límites del sistema, los actores que intervienen y las relaciones entre operaciones:

<img width="1307" height="659" alt="image" src="https://github.com/user-attachments/assets/8c34ed47-4401-4428-8c5d-26a5d5cbc507" />



---

### Diagrama de Clases del Dominio
Muestra la jerarquía de herencia, métodos y multiplicidades del sistema:

```mermaid
classDiagram
    direction TB

    class Club {
        -string nombre
        -List~Cliente~ listaClientes
        -List~Actividad~ listaActividades
        -List~Profesor~ listaProfesores
        -List~Pago~ listaPagos
        +buscarSocioPorDni(dni: string) Socio
        +obtenerSociosProximosAVencer() List~Socio~
    }

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

    class Carnet {
        -string numeroCarnet
        -DateTime fechaEmision
        -string estadoCarnet
        +imprimirCarnet() void
    }

    class FichaMedica {
        -int nroFicha
        -string tratamientoNutricional
        -int cargaFisicaPermitida
        -DateTime fechaUltimaConsulta
        +registrarDiagnostico(diag: string, carga: int) void
    }

    class Actividad {
        -int idActividad
        -string nombre
        -string horario
        -int cupoMaximo
        -decimal precio
        +consultarDisponibilidad() bool
    }

    class Profesor {
        -int idProfesor
        -string nombre
        -string apellido
        -string dni
        -string telefono
        -string direccion
        -decimal sueldo
    }

    class AsistenciaProfesor {
        -int idAsistencia
        -DateTime fecha
        -TimeSpan horaIngreso
        +registrarIngreso() bool
    }

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
        -int cuotas
        +generarComprobante() Comprobante
    }

    class PagoActividad {
        -int idActividad
        +emitirTicketDiario() Ticket
    }

    Cliente <|-- Socio
    Cliente <|-- NoSocio
    Pago <|-- PagoMensual
    Pago <|-- PagoActividad

    Club "1" *-- "*" Cliente
    Club "1" *-- "*" Pago
    Club "1" *-- "*" Actividad
    Club "1" *-- "*" Profesor

    Socio "1" --> "1" Carnet : posee
    Socio "1" --> "0..1" FichaMedica : tiene
    Socio "1" --> "*" PagoMensual : abona
    NoSocio "1" --> "*" PagoActividad : abona
    PagoActividad "*" --> "1" Actividad : corresponde
    Profesor "1" --> "*" AsistenciaProfesor : registra
```

---

### Flujo de Actividades: Inscripción al Club
Proceso dividido en carriles para delimitar responsabilidades entre el cliente, el administrativo y el sistema:

```mermaid
flowchart TD
    subgraph Admin ["Carril: Administrativo (Operador UI)"]
        A1([Inicio]) --> A2[Abre formulario de inscripción]
        A2 --> A3[Ingresa DNI del cliente]
        
        A4[Visualiza alerta: 'DNI ya registrado'] --> A4_1{¿Desea corregir DNI?}
        A4_1 -- Sí: Error de tipeo --> A3
        A4_1 -- No: Cliente ya registrado --> A8([Fin: Trámite cancelado])
        
        A5[Completa datos personales y tilda Apto Físico] --> A6[Presiona botón 'Guardar']
        
        A7[Visualiza bloqueo: Certificado médico obligatorio] --> A8
        
        A9{¿Desea emitir carnet ahora?} -- Sí --> A10[Presiona 'Sí: Emitir carnet']
        A9 -- No --> A11[Presiona 'No: Omite emisión inmediata']
        
        A13[Recibe carnet impreso y lo entrega al socio] --> A12([Fin: Inscripción Exitosa])
        A11 --> A12
    end

    subgraph Sys ["Carril: Sistema (.NET WinForms & MySQL)"]
        A3 --> S1[Consulta existencia de DNI en MySQL]
        S1 --> S2{¿DNI ya registrado?}
        
        S2 -- Sí --> A4
        S2 -- No: DNI disponible --> A5
        
        A6 --> S3{¿Apto físico tildado?}
        S3 -- No --> A7
        S3 -- Sí --> S4[Inserta nuevo registro en tabla Clientes]
        
        S4 --> S5{¿Tipo de cliente?}
        S5 -- Socio --> A9
        S5 -- No Socio --> S6[Habilita registro para compras eventuales]
        S6 --> A12

        A10 --> S7[Genera identificador único y envía reporte a impresora]
        S7 --> A13
    end
```

---

## Base de Datos (MySQL)

Diseñé la estructura relacional normalizada en 3FN con claves foráneas e índices en DNI y fechas de vencimiento:

```mermaid
erDiagram
    CLIENTES ||--o| SOCIOS : "es un"
    CLIENTES ||--o| NO_SOCIOS : "es un"
    CLIENTES ||--o{ PAGOS : "realiza"
    SOCIOS ||--o| CARNETS : "posee"
    SOCIOS ||--o| FICHAS_MEDICAS : "tiene"
    ACTIVIDADES ||--o{ PAGOS : "corresponde a"
    PROFESORES ||--o{ ASISTENCIAS_PROFESORES : "fichan"

    CLIENTES {
        int id_cliente PK
        string dni UK
        string nombre
        string apellido
        string telefono
        string direccion
        boolean apto_fisico
        enum tipo_cliente
        date fecha_inscripcion
    }

    SOCIOS {
        int id_socio PK
        int id_cliente FK
        boolean vigente
        date fecha_vencimiento
        boolean carnet_emitido
    }

    NO_SOCIOS {
        int id_no_socio PK
        int id_cliente FK
        boolean vigente
    }

    PAGOS {
        int id_pago PK
        int id_cliente FK
        decimal monto
        datetime fecha_pago
        enum medio_de_pago
        enum tipo_pago
        int cuotas
        int id_actividad FK
        string comprobante_numero UK
    }

    ACTIVIDADES {
        int id_actividad PK
        string nombre
        string horario
        int cupo_maximo
        decimal precio
        boolean activo
    }

    CARNETS {
        int id_carnet PK
        int id_socio FK
        string numero_carnet UK
        date fecha_emision
        enum estado_carnet
    }

    FICHAS_MEDICAS {
        int id_ficha PK
        int id_socio FK
        text tratamiento_nutricional
        tinyint carga_fisica_permitida
        date fecha_ultima_consulta
    }

    PROFESORES {
        int id_profesor PK
        string dni UK
        string nombre
        string apellido
        string especialidad
        decimal sueldo
    }

    ASISTENCIAS_PROFESORES {
        int id_asistencia PK
        int id_profesor FK
        date fecha
        time hora_ingreso
        time hora_egreso
    }
```

El script SQL completo para recrear las tablas y cargar datos de prueba está en [`database/schema.sql`](database/schema.sql).

---

## Estructura de la Documentación

```text
├── database/
│   └── schema.sql                    # Script DDL/DML de creación de tablas y datos iniciales en MySQL
├── docs/
│   ├── especificacion_casos_de_uso.md # Relevamiento detallado de casos de uso (CU-01 al CU-08) y contratos
│   └── arquitectura_y_diseno_oo.md   # Explicación de la arquitectura en 3 capas, Singleton y secuencia
└── README.md                         # Este documento
```

---



---

##  Manual de Usuario

Podes ver el funcionamiento operativo de cada módulo de la aplicación con sus pantallas y flujos detallados:

👉 **[Abrir Manual de Usuario (PDF)](MANUAL%20DE%20USUARIO.pdf)**
