# 🏋️‍♂️ Sistema de Gestión Integral para Club Deportivo (CLUB67)
> **Análisis Funcional, Modelado de Software UML y Arquitectura en 3 Capas (.NET C# & MySQL)**  
> **Autora:** Sabrina Belén Mamaniz  
> **Especialidad:** Analista Funcional / Modelado de Sistemas / Data & Software  

[![Tecnología](https://img.shields.io/badge/Tecnolog%C3%ADa-.NET%20%7C%20C%23-blue?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![Base de Datos](https://img.shields.io/badge/Base%20de%20Datos-MySQL%208.0-orange?style=flat-square&logo=mysql)](https://www.mysql.com/)
[![Arquitectura](https://img.shields.io/badge/Arquitectura-3%20Capas%20%7C%20Singleton%20%7C%20Repository-success?style=flat-square)](#)
[![Estándar](https://img.shields.io/badge/Modelado-UML%202.0%20%7C%20IEEE%20830-purple?style=flat-square)](#)

---

## 📌 1. Descripción del Proyecto y Caso de Negocio

Este proyecto documenta y estructura el **análisis funcional, relevamiento de procesos y diseño de software** para la informatización de un **Club Deportivo y Gimnasio**. 

El sistema resuelve la problemática clásica de las instituciones deportivas: descontrol en los pagos recurrentes, falta de seguimiento en los vencimientos diarios, falta de trazabilidad en los aptos físicos de los socios y desorden en el cobro de actividades para usuarios no asociados.

### 🎯 Objetivos de Negocio Alcanzados:
* **Control estricto de cobranzas y membresías:** Diferenciación operativa entre **Socios** (cuota mensual recurrente con cálculo de 30 días acumulativos) y **No Socios** (pases eventuales por jornada y actividad).
* **Cumplimiento normativo y salud:** Obligatoriedad de certificado médico de **Apto Físico** como validación bloqueante para el alta de cualquier usuario, integrado al módulo de **Ficha Médica y Nutrición** con escala de carga física de esfuerzo permitida (1 a 5).
* **Control de acceso e inhabilitación por mora:** Bloqueo automatizado de acceso al club al cumplirse la fecha límite de pago, habilitando la reactivación inmediata una vez regularizada la cuota.
* **Trazabilidad operativa:** Fichaje horario de asistencia para el plantel docente y control de cupos por disciplina deportiva (Crossfit, Spinning, Musculación, Natación).

---

## 🏗️ 2. Arquitectura de Software

La solución fue diseñada siguiendo una **Arquitectura en 3 Capas desacopladas**, implementando patrones de diseño reconocidos en la industria:

* **Capa de Presentación (UI):** Interfaces construidas en WinForms con validaciones en tiempo real (`ErrorProvider`) y navegación fluida orientada a la experiencia de usuario (`UX/UI`).
* **Capa de Negocio (BLL):** Clases del dominio con lógica de negocio encapsulada. Implementación de **Singleton** en la clase administradora `Club` para centralizar la sesión y cachés maestras, y **Herencia / Polimorfismo** en las jerarquías de `Cliente` y `Pago`.
* **Capa de Datos (DAL):** Implementación del **Patrón Repository** y clase de conexión `Conectividad.cs`, ejecutando consultas parametrizadas contra **MySQL Server** para blindar el sistema contra inyecciones SQL.

---

## 📐 3. Diagramas de Modelado y Diseño (UML)

### 3.1 Diagrama de Casos de Uso del Sistema
Representa los límites del sistema, los actores y las relaciones de inclusión (`<<include>>`) y extensión condicional (`<<extend>>`):

```mermaid
flowchart LR
    subgraph Actores
        Admin["👤 Administrativo<br/>(Actor Primario)"]
        Socio["👤 Socio"]
        NoSocio["👤 No Socio"]
        Prof["👤 Profesor"]
        Med["👤 Médico / Nutricionista"]
    end

    subgraph Sistema ["Sistema de Gestión — Club Deportivo"]
        CU01(["CU-01: Inscripción al Club"])
        CU02(["CU-02: Registrar Pago Mensual"])
        CU03(["CU-03: Emitir Carnet"])
        CU04(["CU-04: Seleccionar Actividad"])
        CU05(["CU-05: Registrar Pago Actividad"])
        CU06(["CU-06: Consultar Vencimientos"])
        CU07(["CU-07: Actualizar Ficha Médica"])
        CU08(["CU-08: Registrar Asistencia Docente"])
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

### 3.2 Diagrama de Clases (Estructura Estática del Dominio)
Estructura orientada a objetos con tipos de datos, visibilidad, relaciones de asociación, composición y herencia:

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

### 3.3 Diagrama de Flujo y Actividades: Proceso de Inscripción
Muestra la interacción y delegación de responsabilidades mediante marcos (*swimlanes*):

```mermaid
flowchart TD
    subgraph Cliente
        A1([Inicio]) --> A2[Presenta DNI y Apto Físico]
    end

    subgraph Administrativo
        A2 --> B1[Abre formulario de registro]
        B1 --> B2[Ingresa DNI y datos de contacto]
        B4{¿DNI Duplicado?} -- Sí --> B5[Informa error y solicita corrección]
        B5 --> B2
        B4 -- No --> B6{¿Tipo de Cliente?}
        B6 -- Socio --> B7[Cobra cuota de inscripción]
        B6 -- No Socio --> B8[Registra perfil eventual]
        B7 --> B9[Entrega carnet impreso]
        B9 --> B10([Fin de Registro])
        B8 --> B10
    end

    subgraph Sistema
        B2 --> C1[Verifica unicidad en Base de Datos]
        C1 --> B4
        B7 --> C2[Guarda Pago y calcula Vencimiento +30 días]
        C2 --> C3[Genera carnet digital y código alfanumérico]
        C3 --> B9
    end
```

---

## 🗄️ 4. Modelo de Datos Relacional (MySQL)

El modelo fue normalizado hasta **Tercera Forma Normal (3FN)** para asegurar integridad referencial y evitar anomalías de inserción, borrado y modificación:

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

El script SQL completo y ejecutable con constraints y seed data se encuentra disponible en:  
👉 [`database/schema.sql`](database/schema.sql)

---

## 📋 5. Reglas de Negocio Implementadas

| Regla de Negocio | Definición Funcional e Implementación Técnica |
| :--- | :--- |
| **RN-01: Apto Físico Excluyente** | Ningún cliente puede completar la inscripción ni realizar actividades sin tildar la presentación de su certificado médico legal. |
| **RN-02: Cálculo de Vencimiento de Cuota** | El ciclo de facturación es de 30 días continuos. Si un socio moroso abona fuera de término, los 30 días se computan a partir de la fecha de su vencimiento anterior para evitar salteo de períodos. |
| **RN-03: Emisión de Carnet Exclusivo** | El carnet solo se emite a miembros registrados como `Socio` que posean su cuota en estado `Vigente = true`. Los `No Socios` operan con tickets diarios. |
| **RN-04: Restricciones de Financiación** | La opción de cobro en 3 o 6 cuotas se habilita únicamente cuando el medio de pago seleccionado es `Tarjeta de Crédito`. |
| **RN-05: Control de Carga Física Nutricional** | La escala de esfuerzo físico en la ficha médica está estrictamente restringida por restricción `CHECK` entre los valores enteros 1 a 5. |

---

## 📂 6. Estructura del Repositorio

```text
├── database/
│   └── schema.sql                    # Script DDL/DML de creación de base de datos MySQL y Seed Data
├── docs/
│   ├── especificacion_casos_de_uso.md # Relevamiento funcional detallado (CU-01 a CU-08 y Contratos)
│   └── arquitectura_y_diseno_oo.md   # Explicación de arquitectura en 3 capas, Singleton y Secuencia
└── README.md                         # Memoria técnica principal del proyecto
```

---

## 🚀 7. Instrucciones de Despliegue y Puesta en Marcha

1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/SabriiAC/gestion_club_deportivo.git
   cd gestion_club_deportivo
   ```
2. **Crear e inicializar la Base de Datos:**
   * Abrir MySQL Workbench o terminal:
   ```sql
   source database/schema.sql;
   ```
3. **Configurar la cadena de conexión:**
   * Abrir la solución en **Visual Studio 2022**.
   * En `Conectividad.cs`, verificar los parámetros de conexión:
   ```csharp
   private string cadenaConexion = "Server=localhost;Database=club_deportivo_db;Uid=root;Pwd=tu_password;";
   ```
4. **Compilar y Ejecutar:** Presionar `F5` para iniciar el entorno en modo debug.

---

## 👩‍💻 Sobre la Autora
**Sabrina Belén Mamaniz**  
*Estudiante avanzada de la Tecnicatura Superior en Desarrollo de Software (IFTS N° 29, CABA).*  
*Certificada en Google Data Analytics.*  
*Locutora Nacional (UNLaM).*  

* 💼 LinkedIn: [linkedin.com/in/sabrina-mamaniz](https://www.linkedin.com/in/sabrina-mamaniz/)  
* 🐙 GitHub: [github.com/SabriiAC](https://github.com/SabriiAC)  
* 📧 Correo: [sabrinamamaniz00@gmail.com](mailto:sabrinamamaniz00@gmail.com)
