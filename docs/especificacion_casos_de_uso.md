# Especificación Formal de Casos de Uso y Contratos de Operación
**Sistema de Gestión Integral — Club Deportivo (CLUB67)**  
*Documento de Ingeniería de Requerimientos y Modelado de Software*  
*Autora:* **Sabrina Belén Mamaniz**  

---

## 1. Matriz General de Casos de Uso

| ID | Nombre del Caso de Uso | Actor Primario | Actores Secundarios | Tipo / Relación |
| :--- | :--- | :--- | :--- | :--- |
| **CU-01** | Inscripción al Club | Administrativo | Socio / No Socio | Core / Include: CU-02, Extend: CU-03 |
| **CU-02** | Registrar Pago Mensual | Administrativo | Socio | Core / Include por CU-01 |
| **CU-03** | Emitir Carnet de Socio | Administrativo | Socio | Extensión condicional de CU-01 |
| **CU-04** | Seleccionar Actividad | Socio / No Socio | Administrativo | Operativo |
| **CU-05** | Registrar Pago de Actividad | Administrativo | No Socio | Core / Include por selección |
| **CU-06** | Consultar Socios con Vencimiento | Administrativo | Socio | Control & Auditoría |
| **CU-07** | Actualizar Ficha Médica | Médico / Nutricionista | Socio | Servicio de Salud |
| **CU-08** | Registrar Asistencia de Profesor | Profesor | Administrativo | Operativo / RRHH |

---

## 2. Especificación Detallada de Casos de Uso

### CU-01 — Inscripción al Club
* **ID:** CU-01
* **Nombre:** Inscripción al Club
* **Actor Primario:** Administrativo
* **Actor Secundario:** Socio / No Socio
* **Descripción:** El administrativo registra un nuevo cliente en el sistema. El cliente debe presentar DNI y certificado de apto físico obligatorio. Según la modalidad requerida, se clasifica como Socio (membresía mensual recurrente) o No Socio (pase diario por actividad).
* **Precondiciones:**
  1. El cliente debe presentar DNI y certificado de Apto Físico vigente.
  2. El DNI no debe existir previamente en el padrón de clientes.
* **Postcondiciones:**
  1. Se crea el registro del cliente en la base de datos relacional.
  2. Si es Socio: Se procesa el cobro de la primera mensualidad (`<<include>> CU-02`), se calcula fecha de vencimiento a 30 días, se emite carnet (`<<extend>> CU-03`) y pasa a estado `Vigente`.
  3. Si es No Socio: Se genera el perfil de cliente eventual habilitado para contratar actividades individuales.
* **Prioridad:** Alta (Crítica).
* **Flujo Normal:**
  1. El administrativo solicita DNI y certificado de Apto Físico al interesado.
  2. El cliente presenta la documentación en regla.
  3. El administrativo abre el formulario de alta de clientes (`Inscripcion.cs`).
  4. El administrativo ingresa: Nombre, Apellido, DNI, Teléfono y Dirección.
  5. El sistema valida formato y comprueba que el DNI no se encuentre duplicado.
  6. El sistema confirma disponibilidad de registro.
  7. El administrativo tilda la presentación del Apto Físico y selecciona el tipo de cliente (`Socio` o `No Socio`).
  8. *Bifurcación Socio:*
     - Se invoca `CU-02 (Registrar Pago Mensual)`.
     - El sistema asienta el pago, calcula la fecha de vencimiento (`Fecha Actual + 30 días`) y setea estado `Vigente = true`.
     - Se invoca `CU-03 (Emitir Carnet)` imprimiendo la credencial con código identificador.
     - El administrativo hace entrega del carnet físico.
  9. *Bifurcación No Socio:*
     - El sistema registra el legajo de cliente eventual sin generar obligación de cuota recurrente.
* **Flujos Alternativos:**
  * **FA-1 (DNI Duplicado):** En el paso 5, si el sistema detecta el DNI en base de datos, muestra alerta: *"El cliente ya se encuentra registrado"*, ofreciendo consultar su estado o actualizar datos.
* **Excepciones:**
  * **EX-1 (Falta de Apto Físico):** Si el cliente no presenta el certificado médico, el sistema bloquea el botón de confirmación (`btnSave.Enabled = false`) y el administrativo informa que es condición excluyente por normativa sanitaria. Fin del caso de uso.

---

### CU-02 — Registrar Pago Mensual
* **ID:** CU-02
* **Nombre:** Registrar Pago Mensual
* **Actor Primario:** Administrativo
* **Actor Secundario:** Socio
* **Descripción:** Permite cobrar y acreditar la cuota mensual de un socio registrado, actualizando su período de vigencia y emitiendo el comprobante correspondiente.
* **Precondiciones:** El socio debe existir en el sistema.
* **Postcondiciones:**
  1. Se genera un registro inmutable en la tabla de pagos con número de comprobante único.
  2. Se recalculan los 30 días de vigencia: si estaba vencido, los 30 días se computan desde el día siguiente a su vencimiento previo para mantener la continuidad del ejercicio.
  3. El socio pasa o se mantiene en estado `Vigente = true`.
* **Flujo Normal:**
  1. El administrativo solicita el DNI del socio.
  2. Ingresa el DNI en el módulo de pagos (`Pago.cs`) y presiona `Buscar`.
  3. El sistema valida existencia y recupera: Nombre, Apellido, Estado (`Vigente` / `Inhabilitado`) y Fecha de Último Vencimiento.
  4. El administrativo selecciona medio de pago (Efectivo, Débito, Crédito o Transferencia).
  5. *Si es Tarjeta de Crédito:* Se habilita el combo de cuotas (1, 3 o 6 pagos).
  6. El administrativo presiona `Confirmar Cobro`.
  7. El sistema almacena la transacción financiera, recalcula la fecha de vigencia y actualiza el estado a `Vigente`.
  8. El sistema genera el comprobante fiscal/ticket digital de pago.
  9. El administrativo entrega el comprobante al socio.
* **Flujos Alternativos:**
  * **FA-1 (Socio Inexistente):** Si no hay coincidencias con el DNI, el sistema emite el mensaje *"Socio no registrado"* y sugiere derivar al módulo de inscripción.

---

### CU-03 — Emitir Carnet de Socio
* **ID:** CU-03
* **Nombre:** Emitir Carnet de Socio
* **Actor Primario:** Administrativo
* **Actor Secundario:** Socio
* **Descripción:** Generación del carnet con código identificador para el socio con cuota al día.
* **Precondiciones:** El socio debe encontrarse registrado y con estado `Vigente = true`. `carnetEmitido = false` (salvo caso de reimpresión por extravío).
* **Postcondiciones:** Se crea el registro del carnet vinculado al socio y se actualiza la bandera `carnetEmitido = true`.
* **Flujo Normal:**
  1. El administrativo solicita la emisión de credencial.
  2. El sistema valida el estado `Vigente` del socio.
  3. El sistema genera un código de carnet alfanumérico único (`CRN-AAAA-XXXX`) e inserta la fecha de emisión.
  4. Se envía a impresión digital o física.
  5. El sistema actualiza `carnetEmitido = true`.
* **Flujos Alternativos:**
  * **FA-1 (Socio Moroso):** Si el socio tiene cuota vencida, el sistema bloquea la emisión: *"No se puede emitir credencial con cuotas pendientes"*.

---

### CU-04 — Seleccionar Actividad
* **ID:** CU-04
* **Nombre:** Seleccionar Actividad
* **Actor Primario:** Socio / No Socio
* **Actor Secundario:** Administrativo
* **Descripción:** Permite a un cliente inscribirse o reservar turno en una disciplina deportiva (Crossfit, Spinning, Musculación, Natación).
* **Precondiciones:**
  - Si es Socio: Cuota mensual al día (`Vigente = true`).
  - Si es No Socio: Pago del pase diario acreditado (`CU-05`).
* **Postcondiciones:** Cupo de la actividad reservado para el cliente en el horario estipulado.
* **Flujo Normal:**
  1. El cliente indica la actividad y horario deseados.
  2. El administrativo selecciona la actividad en el sistema.
  3. El sistema valida disponibilidad de cupos en tiempo real (`cupoActual < cupoMaximo`).
  4. El sistema valida estado habilitado del cliente.
  5. Se confirma la reserva de plaza y se descuenta un cupo disponible.
* **Flujos Alternativos & Excepciones:**
  * **EX-1 (Cupo Agotado):** El sistema notifica *"Cupo completo para este turno"* y permite visualizar horarios alternativos.
  * **EX-2 (Socio Moroso):** El sistema advierte *"Cuota vencida. Regularice su pago en administración para continuar"*.

---

### CU-05 — Registrar Pago de Actividad (No Socios)
* **ID:** CU-05
* **Nombre:** Registrar Pago de Actividad
* **Actor Primario:** Administrativo
* **Actor Secundario:** No Socio
* **Descripción:** Procesa el cobro por pase diario de actividad para clientes eventuales sin membresía mensual.
* **Flujo Normal:**
  1. El administrativo busca al No Socio por DNI.
  2. Selecciona la actividad puntual que realizará en la jornada.
  3. El sistema consulta la cartilla de precios vigentes y calcula el total.
  4. El cliente abona el importe.
  5. El sistema emite un ticket diario de acceso válido exclusivamente por la jornada.

---

### CU-06 — Consultar Socios con Vencimiento
* **ID:** CU-06
* **Nombre:** Consultar Socios con Vencimiento
* **Actor Primario:** Administrativo
* **Descripción:** Módulo de auditoría y control diario que lista los socios cuya cuota vence en la fecha o se encuentra ya vencida.
* **Flujo Normal:**
  1. El administrativo accede a la sección de reportes de cobranza.
  2. El sistema ejecuta una consulta relacional comparando `fecha_vencimiento` contra `CURRENT_DATE`.
  3. El sistema devuelve el listado con DNI, Nombre, Apellido, Días de atraso y Teléfono de contacto para gestión de cobranza.

---

### CU-07 — Actualizar Ficha Médica
* **ID:** CU-07
* **Nombre:** Actualizar Ficha Médica
* **Actor Primario:** Médico / Nutricionista
* **Actor Secundario:** Socio
* **Descripción:** Registro de evaluaciones antropométricas, diagnóstico nutricional y graduación de carga física de esfuerzo permitida (escala 1 a 5).
* **Precondiciones:** El socio debe tener legajo activo y turno de consulta asignado.
* **Flujo Normal:**
  1. El profesional de la salud busca al socio en el módulo `ServicioNutricion.cs`.
  2. Ingresa el diagnóstico nutricional y observaciones clínicas.
  3. Selecciona el nivel de carga física tolerada (1 a 5).
  4. Registra peso objetivo e indicaciones especiales.
  5. Guarda los cambios; el sistema actualiza la fecha de última consulta y asocia la ficha al legajo del socio.

---

### CU-08 — Registrar Asistencia del Profesor
* **ID:** CU-08
* **Nombre:** Registrar Asistencia del Profesor
* **Actor Primario:** Profesor
* **Actor Secundario:** Administrativo
* **Descripción:** Fichaje diario de ingreso laboral del personal docente para control operativo y posterior liquidación mensual de sueldos.
* **Flujo Normal:**
  1. El docente ingresa su DNI o ID de Profesor en el módulo de fichaje.
  2. El sistema valida su identidad en el padrón activo.
  3. Se asienta la marca horaria con fecha y hora exacta de entrada.
  4. El sistema emite confirmación visual en pantalla: *"Ingreso registrado con éxito"*.

---

## 3. Contratos de Operaciones del Sistema (Notación Larman)

### Contrato CO-01: `registrarPagoMensual`
* **Operación:** `registrarPagoMensual(idSocio: int, monto: decimal, medioDePago: string, cuotas: int)`
* **Responsabilidad:** Registrar el ingreso financiero, reactivar la vigencia del socio y extender su período de servicio por 30 días continuos.
* **Referencias Cruzadas:** CU-02 (Registrar Pago Mensual).
* **Precondiciones:**
  - Existe una instancia `s` de `Socio` identificada por `idSocio`.
  - `monto` cubre el arancel de la cuota mensual estipulada.
  - `medioDePago` pertenece a los valores admitidos: `['Efectivo', 'TarjetaDebito', 'TarjetaCredito', 'Transferencia']`.
* **Postcondiciones:**
  - Se creó una instancia `p` de `PagoMensual` vinculada a `s`.
  - Se inicializaron los atributos de `p`: `monto = monto`, `medioDePago = medioDePago`, `fechaPago = fechaActual()`, `comprobanteNumero = generarUID()`.
  - Se modificó el atributo `s.vigente = true`.
  - Si `s.fechaVencimiento < fechaActual()` (estaba moroso), se calculó:  
    `s.fechaVencimiento = s.fechaVencimiento + 30 días`.  
    *(Si no estaba vencido, `s.fechaVencimiento = s.fechaVencimiento + 30 días` extendiendo la vigencia futura).*
  - Se emitió un comprobante de pago persistido.

---

### Contrato CO-02: `inscribirSocio`
* **Operación:** `inscribirSocio(dni: string, nombre: string, apellido: string, telefono: string, direccion: string, aptoFisico: bool)`
* **Responsabilidad:** Dar de alta un nuevo cliente con membresía de socio garantizando el cumplimiento normativo de apto médico.
* **Referencias Cruzadas:** CU-01 (Inscripción al Club).
* **Precondiciones:**
  - No existe ningún registro de `Cliente` con el mismo `dni`.
  - Campos obligatorios `dni`, `nombre`, `apellido` no nulos ni vacíos.
  - `aptoFisico == true` (presentó certificado físico).
* **Postcondiciones:**
  - Se creó una instancia `c` de `Cliente` con los datos suministrados y `tipoCliente = 'Socio'`.
  - Se creó una instancia `s` de `Socio` vinculada a `c`.
  - Se asignó `s.vigente = false` transitoriamente hasta percibir la primera mensualidad.
  - Se generó un identificador único `idSocio`.
