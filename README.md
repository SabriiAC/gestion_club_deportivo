# Sistema de Gestión para Club Deportivo (CLUB67)
> Trabajo Integrador de Modelado de Software y Arquitectura en 3 Capas (.NET C# y MySQL)  


[![Tecnología](https://img.shields.io/badge/.NET-C%23-blue?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![Base de Datos](https://img.shields.io/badge/MySQL-8.0-orange?style=flat-square&logo=mysql)](https://www.mysql.com/)
[![Patrones](https://img.shields.io/badge/Arquitectura-3%20Capas%20%7C%20Singleton%20%7C%20Repository-success?style=flat-square)](#)
[![Modelado](https://img.shields.io/badge/UML-Casos%20de%20Uso%20%7C%20Clases%20%7C%20Secuencia-purple?style=flat-square)](#)

---

## Origen y Contexto del Proyecto

Desarrollé este proyecto como Trabajo Práctico Integrador para las materias **Modelado y Diseño de Software** y **Taller de Programación** del IFTS N° 29. 

El objetivo era modelar e implementar el circuito operativo de un club deportivo barrial: administración de socios, cobro de aranceles, control de accesos por cuota al día, turnos de nutrición y registro del personal docente. 

En vez de limitarme a una interfaz visual simple, encaré el proyecto desde la ingeniería de software: primero relevé los procesos y reglas del negocio, después modelé la solución con diagramas UML formales y finalmente construí la arquitectura en capas conectada a MySQL.

---

## Decisiones de Negocio y Reglas que Implementé

Cuando analicé el funcionamiento del club, identifiqué cinco reglas clave que debían reflejarse en el sistema:

1. **Diferenciación entre Socios y No Socios:** Los socios pagan una cuota mensual recurrente que les permite acceder a las instalaciones. Los no socios solo abonan un pase diario para la actividad puntual que eligen en el día.
2. **Cálculo de vencimientos a 30 días continuos:** Si un socio se atrasa y paga fuera de término, los 30 días no se cuentan desde el día del pago, sino a partir de la fecha de su vencimiento anterior. De esta manera, el club evita que un socio saltee períodos impagos.
3. **Apto físico obligatorio:** Ningún cliente puede completar su registro ni participar en actividades sin presentar el certificado médico. En el sistema, la validación del apto bloquea el guardado si no está tildada la recepción del documento.
4. **Carnet exclusivo para socios al día:** El carnet con identificador único solo se genera para socios con cuota vigente. Si el socio queda inhabilitado por mora, el sistema impide la emisión de duplicados hasta regularizar el pago.
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

```mermaid
flowchart LR
    subgraph Actores
        Admin["Administrativo<br/>(Actor Principal)"]
        Socio["Socio"]
        NoSocio["No Socio"]
        Prof["Profesor"]
        Med["Médico / Nutricionista"]
    end

    subgraph Sistema ["Sistema de Gestión Club Deportivo"]
        CU01(["Inscripción al Club"])
        CU02(["Registrar Pago Mensual"])
        CU03(["Emitir Carnet"])
        CU04(["Seleccionar Actividad"])
        CU05(["Registrar Pago Actividad"])
        CU06(["Consultar Vencimientos"])
        CU07(["Actualizar Ficha Médica"])
        CU08(["Registrar Asistencia Docente"])
    end

    Admin --> CU01
    Admin --> CU02
    Admin --> CU05
    Admin --> CU06
    
    CU01 -.->|"<<include>>"| CU02
    CU01 -.->|"<<extend>>"| CU03
    
    Socio --> CU04
    NoSocio --> CU04
    
    Prof --> CU08
    Med --> CU07
```

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
    subgraph Cliente
        A1([Inicio]) --> A2[Presenta DNI y certificado médico]
    end

    subgraph Administrativo
        A2 --> B1[Abre formulario de registro]
        B1 --> B2[Ingresa datos personales y de contacto]
        B4{¿DNI ya registrado?} -- Sí --> B5[Informa error y solicita verificar datos]
        B5 --> B2
        B4 -- No --> B6{¿Tipo de cliente?}
        B6 -- Socio --> B7[Registra cobro de primera mensualidad]
        B6 -- No Socio --> B8[Registra cliente eventual]
        B7 --> B9[Entrega carnet impreso]
        B9 --> B10([Fin del trámite])
        B8 --> B10
    end

    subgraph Sistema
        B2 --> C1[Consulta tabla clientes en MySQL]
        C1 --> B4
        B7 --> C2[Inserta pago y calcula vencimiento a 30 días]
        C2 --> C3[Genera número de carnet único]
        C3 --> B9
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

## Cómo Probar el Proyecto Localmente

1. **Clonar este repositorio:**
   ```bash
   git clone https://github.com/SabriiAC/gestion_club_deportivo.git
   cd gestion_club_deportivo
   ```
2. **Crear la base de datos en MySQL:**
   * Abrí MySQL Workbench o una terminal de MySQL y ejecutá:
   ```sql
   source database/schema.sql;
   ```
3. **Configurar la conexión en Visual Studio:**
   * Abrí la solución en Visual Studio 2022.
   * En `Conectividad.cs`, ajustá los datos de tu servidor local:
   ```csharp
   private string cadenaConexion = "Server=localhost;Database=club_deportivo_db;Uid=root;Pwd=tu_password;";
   ```
4. **Ejecutar:** Compilá la solución y presiona F5 para correr la aplicación.

---

## Sobre Mí
Soy **Sabrina Belén Mamaniz**, estudiante avanzada de la Tecnicatura Superior en Desarrollo de Software en el IFTS N° 29 (CABA), certificada en Google Data Analytics y Locutora Nacional egresada de la UNLaM.

* LinkedIn: [linkedin.com/in/sabrina-mamaniz](https://www.linkedin.com/in/sabrina-mamaniz/)
* GitHub: [github.com/SabriiAC](https://github.com/SabriiAC)
* Correo: [sabrinamamaniz00@gmail.com](mailto:sabrinamamaniz00@gmail.com)
