USE GD2C2016;
GO

/* Eliminación de los objetos preexistentes */

IF OBJECT_ID('CLINICA.Usuarios','U') IS NOT NULL
    DROP TABLE CLINICA.Usuarios;

IF OBJECT_ID('CLINICA.RolXUsuario','U') IS NOT NULL
    DROP TABLE CLINICA.RolXUsuario;

IF OBJECT_ID('CLINICA.Roles','U') IS NOT NULL
    DROP TABLE CLINICA.Roles;

IF OBJECT_ID('CLINICA.FuncionalidadXRol','U') IS NOT NULL
    DROP TABLE CLINICA.FuncionalidadXRol;

IF OBJECT_ID('CLINICA.Funcionalidades','U') IS NOT NULL
    DROP TABLE CLINICA.Funcionalidades;

IF OBJECT_ID('CLINICA.Administradores','U') IS NOT NULL
    DROP TABLE CLINICA.Administradores;
    
IF OBJECT_ID('CLINICA.Profesionales','U') IS NOT NULL
    DROP TABLE CLINICA.Profesionales;
    
IF OBJECT_ID('CLINICA.EspecialidadXProfesional','U') IS NOT NULL
    DROP TABLE CLINICA.EspecialidadXProfesional;
    
IF OBJECT_ID('CLINICA.Especialidades','U') IS NOT NULL
    DROP TABLE CLINICA.Especialidades;
    
IF OBJECT_ID('CLINICA.TipoEspecialidades','U') IS NOT NULL
    DROP TABLE CLINICA.TipoEspecialidades;
    
IF OBJECT_ID('CLINICA.HistorialAfiliados','U') IS NOT NULL
    DROP TABLE CLINICA.HistorialAfiliados;

IF OBJECT_ID('CLINICA.Horarios','U') IS NOT NULL
    DROP TABLE CLINICA.Horarios;

IF OBJECT_ID('CLINICA.Afiliados','U') IS NOT NULL
    DROP TABLE CLINICA.Afiliados;

IF OBJECT_ID('CLINICA.Planes','U') IS NOT NULL
    DROP TABLE CLINICA.Planes;

IF OBJECT_ID('CLINICA.Turnos','U') IS NOT NULL
    DROP TABLE CLINICA.Turnos;

IF OBJECT_ID('CLINICA.CancelacionesTurnos','U') IS NOT NULL
    DROP TABLE CLINICA.CancelacionesTurnos;
    
IF OBJECT_ID('CLINICA.TipoCancelaciones','U') IS NOT NULL
    DROP TABLE CLINICA.TipoCancelaciones;
    
IF OBJECT_ID('CLINICA.Bonos','U') IS NOT NULL
    DROP TABLE CLINICA.Bonos;
    
IF OBJECT_ID('CLINICA.ComprasBonos','U') IS NOT NULL
    DROP TABLE CLINICA.ComprasBonos;
    
IF OBJECT_ID('CLINICA.Consultas','U') IS NOT NULL
    DROP TABLE CLINICA.Consultas;





 /* TODO: PONER LOS NUESTROS 

/* DROP PROCEDURES! */

IF OBJECT_ID('CLINICA._algo_') IS NOT NULL
    DROP PROCEDURE CLINICA._algo_

    
/* DROP FUNCTIONS! */

IF (OBJECT_ID ('CLINICA._algo_') IS NOT NULL)
  DROP FUNCTION CLINICA._algo_




  */



/* DROP SCHEMA */

IF EXISTS (SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'CLINICA')
    DROP SCHEMA CLINICA
GO



/* Creación del esquema */

CREATE SCHEMA CLINICA-- AUTHORIZATION gd;
GO



/* Creación de las tablas */

CREATE TABLE CLINICA.Usuarios(
    usua_id INT IDENTITY PRIMARY KEY,
    usua_username VARCHAR(20) NOT NULL,
  	usua_password VARCHAR(20) NOT NULL,
  	usua_intentos TINYINT,
    usua_nombre VARCHAR(225),
    usua_apellido VARCHAR(225),
  	usua_tipoDoc VARCHAR(20),
    usua_nroDoc INT,
  	usua_direccion VARCHAR(50),
  	usua_telefono VARCHAR(50),
  	usua_fechaNacimiento DATETIME,
  	usua_sexo VARCHAR(15),
  	usua_mail VARCHAR(50));

CREATE TABLE CLINICA.Roles(
    role_id INT IDENTITY NOT NULL,
    role_nombre VARCHAR(225),
  	role_habilitato TINYINT,
    PRIMARY KEY (role_id));

CREATE TABLE CLINICA.RolXusuario(
    usua_id INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Usuarios(usua_id),
    role_id INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Roles(role_id),
    PRIMARY KEY (usua_id, role_id));

CREATE TABLE CLINICA.Funcionalidades(
		func_id INT NOT NULL IDENTITY PRIMARY KEY,
  	func_nombre VARCHAR(225) NOT NULL);

CREATE TABLE CLINICA.RolXfuncionalidad(
    role_id INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Roles(role_id),
    func_id INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Funcionalidades(func_id),
    PRIMARY KEY (role_id, func_id));
  
CREATE TABLE CLINICA.Administradores(
		admi_id INT NOT NULL IDENTITY PRIMARY KEY,
  	admi_usuario INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Usuarios(usua_id));
  
CREATE TABLE CLINICA.Profesionales(
		prof_id INT NOT NULL IDENTITY PRIMARY KEY,
  	prof_usuario INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Usuarios(usua_id),
  	prof_matricula VARCHAR(12));
  
CREATE TABLE CLINICA.TiposEspecialidades(
    tipo_id INT PRIMARY KEY,
    tipo_nombre VARCHAR(225));

CREATE TABLE CLINICA.Especialidades(
    espe_id INT PRIMARY KEY,
  	espe_nombre VARCHAR(256) NOT NULL,
    espe_tipo INT NOT NULL FOREIGN KEY REFERENCES CLINICA.TiposEspecialidades(tipo_id));

CREATE TABLE CLINICA.Horarios(
		hora_id INT NOT NULL IDENTITY PRIMARY KEY,
  	hora_profesional INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Profesionales(prof_id), 
    hora_especialidad INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Especialidades(espe_id), 
    hora_fecha DATE NOT NULL,
    hora_inicio TIME NOT NULL);

CREATE TABLE CLINICA.EspecialidadXProfesional(
		espe_id INT FOREIGN KEY REFERENCES CLINICA.Especialidades(espe_id),
  	prof_id INT FOREIGN KEY REFERENCES CLINICA.Profesionales(prof_id),
  	PRIMARY KEY (espe_id, prof_id));

CREATE TABLE CLINICA.Planes(
		plan_id INT PRIMARY KEY IDENTITY NOT NULL,
  	plan_nombre VARCHAR(225) NOT NULL,
  	plan_precioBono FLOAT NOT NULL);   

CREATE TABLE CLINICA.Afiliados(
    afil_id INT IDENTITY PRIMARY KEY,
    afil_usuario INT FOREIGN KEY REFERENCES CLINICA.Usuarios(usua_id),
    afil_plan INT FOREIGN KEY REFERENCES CLINICA.Planes(plan_id),
  	afil_estadoCivil VARCHAR(20),
  	afil_cantidadHijos INT);
  
CREATE TABLE CLINICA.TiposCancelacion(
		tipo_id INT PRIMARY KEY IDENTITY,
  	tipo_detalle VARCHAR(256));

	

CREATE TABLE CLINICA.Turnos(
		turn_id INT NOT NULL IDENTITY PRIMARY KEY,
  	turn_afiliado INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Afiliados(afil_id), 
    turn_hora INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Horarios(hora_id), 
    turn_activo TINYINT NOT NULL);
	
CREATE TABLE CLINICA.CancelacionesTurnos(
		canc_id INT PRIMARY KEY IDENTITY,
  	canc_turno INT FOREIGN KEY REFERENCES CLINICA.Turnos(turn_id),
		canc_tipo INT FOREIGN KEY REFERENCES CLINICA.TiposCancelacion(tipo_id),
  	canc_detalle VARCHAR(225));  
  
CREATE TABLE CLINICA.HistorialAfiliado(
		hist_id INT NOT NULL IDENTITY PRIMARY KEY,
  	hist_profesional INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Profesionales(prof_id), 
    hist_especialidad INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Especialidades(espe_id));
	
CREATE TABLE CLINICA.Consultas(
		cons_id INT IDENTITY PRIMARY KEY NOT NULL,
  	cons_turno INT FOREIGN KEY REFERENCES CLINICA.Turnos(turn_id), -- nullable
    cons_fechaHoraConsulta DATETIME, -- nullable
    cons_fueConcretada TINYINT, -- nullable
    cons_sintomas VARCHAR(256), -- nullable
    cons_diagnostico VARCHAR(512)); -- nullable
	
CREATE TABLE CLINICA.Bonos(
  	bono_id INT NOT NULL IDENTITY PRIMARY KEY,
  	bono_afilCompra INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Afiliados(afil_id),
  	bono_nroConsulta INT FOREIGN KEY REFERENCES CLINICA.Consultas(cons_id),  -- nullable
  	bono_plan INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Planes(plan_id),
  	bono_afilUsado INT FOREIGN KEY REFERENCES CLINICA.Afiliados(afil_id));
  
CREATE TABLE CLINICA.ComprasBonos(
		comp_id INT NOT NULL IDENTITY PRIMARY KEY,
  	comp_afil INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Afiliados(afil_id), 
    comp_cantidad INT NOT NULL ,
		comp_precioFinal FLOAT NOT NULL);




/* Migración de datos desde la tabla maestra */

/* SELECT * INTO CLINICA.Inconsistencias FROM gd_esquema.Maestra WHERE 1 = 2 */

 /*
CREATE INDEX CLINICA ON CLINICA.Contacto (mail);

CREATE INDEX I_Cliente ON CLINICA.Cliente (cli_nombre, cli_apellido);

CREATE UNIQUE INDEX I_Empresa ON CLINICA.Empresa (emp_razon_soc, emp_cuit);

CREATE INDEX I_Publicacion ON CLINICA.Publicacion (cod_rubro, descripcion);

*/ /* TODO: PONER NUESTROS INDICES SEGUN Q USEMOS MAS */

INSERT INTO CLINICA.Roles
VALUES ('Afiliado', 1),
       ('Administrativo', 1),
       ('Profesional', 1);
  
DECLARE @hash VARBINARY(225)
SELECT @hash = HASHBYTES('SHA2_256', 'w23e');
  
--Administrativo
INSERT INTO CLINICA.Usuarios(usua_username, usua_password, intentos)
VALUES ('admin', @hash, 0);

--Afiliados. Funciona
  /* TODO: ver q username/pass tienen los usuarios q se migran de la base vieja */
INSERT INTO CLINICA.Usuario(usua_nroDoc,usua_intentos,usua_nombre,usua_apellido,usua_tipoDoc,usua_direccion,usua_telefono,usua_fechaNacimiento,usua_sexo,usua_mail)
  SELECT DISTINCT m.Paciente_Dni, 0,m.Paciente_Nombre, m.Paciente_Apellido, 'DNI', m.Paciente_Direccion, m.Paciente_Telefono, null, null, m.Paciente_Mail
  FROM gd_esquema.Maestra m
  WHERE m.Paciente_Dni IS NOT NULL
  ORDER BY m.Paciente_Dni

--Profesionales. Funciona
INSERT INTO CLINICA.Usuario(usua_nroDoc, usua_intentos, usua_nombre, usua_apellido, usua_tipoDoc, usua_direccion, usua_telefono, usua_fechaNacimiento, usua_password, usua_mail, usua_sexo)
	SELECT  DISTINCT m.Medico_Dni, 0, m.Medico_Nombre, m.Medico_Apellido, 'DNI', m.Medico_Direccion, m.Medico_Telefono ,m.Medico_Fecha_Nac,  @hash, m.Medico_Mail, NULL 
	FROM gd_esquema.Maestra m
	WHERE m.Medico_Dni IS NOT NULL 
  ORDER BY m.Medico_Dni


--Planes. Funciona
INSERT INTO CLINICA.Planes(plan_id,plan_nombre,plan_precioBono)
	SELECT DISTINCT m.Plan_Med_Codigo,m.Plan_Med_Descripcion, m.Plan_Med_Precio_Bono_Consulta
	FROM gd_esquema.Maestra m
	WHERE m.Plan_Med_Codigo IS NOT NULL 
  ORDER BY m.Plan_Med_Codigo
    
  --Tipo Especialidad. Funciona
INSERT INTO CLINICA.TipoEspecialidad(tipo_id, tipo_nombre)
	SELECT DISTINCT m.Tipo_Especialidad_Codigo, m.Tipo_Especialidad_Descripcion 
	FROM gd_esquema.Maestra m
	WHERE m.Tipo_Especialidad_Codigo IS NOT NULL 
  ORDER BY m.Tipo_Especialidad_Codigo
  
  
  -- Especialidad. Funciona
INSERT INTO CLINICA.Especialidad(espe_id, espe_tipo, espe_nombre)
  SELECT DISTINCT m.Especialidad_Codigo, m.Tipo_Especialidad_Codigo, m.Especialidad_Descripcion
  FROM gd_esquema.Maestra m
  WHERE m.Especialidad_Codigo IS NOT NULL
  ORDER BY m.Especialidad_Codigo  
    
    -- Turnos. Funciona
INSERT INTO CLINICA.Turnos(turn_id, turn_afiliado, turn_hora, turn_activo)
	SELECT DISTINCT m.Turno_Numero, (SELECT top 1 afil_id
                                   FROM CLINICA.Afiliados
                                   			join CLINICA.Usuario on (afil_usuario = usua_id)
                                   WHERE usua_dni = m.Paciente_Dni), m.Turno_Fecha, 1 -- asumimos que todos los turnos de la base estan activos (no cancelados).
	FROM gd_esquema.Maestra m
	WHERE m.Turno_Numero IS NOT NULL 
  ORDER BY m.Turno_Numero
  
  	-- Consultas. Funciona. Suponemos que todas se concretaron y el tipo nunca dio el presente y se fue antes de que lo atiendan (caso de concretada=0).
INSERT INTO CLINICA.Consultas(cons_id, cons_turno, cons_fechaHoraConsulta, cons_fueConcretada, cons_sintomas, cons_diagnostico)
	SELECT DISTINCT m.Turno_Numero, m.Bono_Consulta_Numero, m.Bono_Consulta_Fecha_Impresion, 1, m.Consulta_Sintomas, m.Consulta_Enfermedades
	FROM gd_esquema.Maestra m
	WHERE m.Turno_Numero IS NOT NULL AND m.Bono_Consulta_Fecha_Impresion IS NOT NULL
  ORDER BY m.Turno_Numero
  
  /*
        ,[Paciente_Apellido]
      ,[Paciente_Dni]
      ,[Paciente_Direccion]
      ,[Paciente_Telefono]
      ,[Paciente_Mail]
      ,[Paciente_Fecha_Nac]
      ,[Plan_Med_Codigo]
      ,[Plan_Med_Descripcion]
      ,[Plan_Med_Precio_Bono_Consulta]
      ,[Plan_Med_Precio_Bono_Farmacia]
      ,[Turno_Numero]
      ,[Turno_Fecha]
      ,[Consulta_Sintomas]
      ,[Consulta_Enfermedades]
      ,[Medico_Nombre]
      ,[Medico_Apellido]
      ,[Medico_Dni]
      ,[Medico_Direccion]
      ,[Medico_Telefono]
      ,[Medico_Mail]
      ,[Medico_Fecha_Nac]
      ,[Especialidad_Codigo]
      ,[Especialidad_Descripcion]
      ,[Tipo_Especialidad_Codigo]
      ,[Tipo_Especialidad_Descripcion]
      ,[Compra_Bono_Fecha]
      ,[Bono_Consulta_Fecha_Impresion]
      ,[Bono_Consulta_Numero] */
  
  -- Funcionalidades
INSERT INTO CLINICA.Funcionalidades(func_nombre)
VALUES ('ABM Rol'),
       ('ABM Usuarios'),
   		 ('ABM Afiliados'),
       ('ABM Profesional'), 
       ('Registrar Agenda Profesional'),
  		 ('Compra de Bonos'),
       ('Pedido de turno'),
       ('Registro de llegada para atencion medica'),
       ('Registro de resultado para atencion medica'),
       ('Cancelar atencion medica'),
       ('Listado estadistico');
GO 
  
  -- PARA COPIAR

INSERT INTO CLINICA.RolXfunc(role_id, func_id)
SELECT 1, f.role_id FROM CLINICA.Funcionalidad f

INSERT INTO CLINICA.RolXfunc(role_id, func_id)
VALUES (2, 1), (2, 2), (2, 3), (2, 4)
GO

INSERT INTO CLINICA.RolXfunc(role_id, func_id)
VALUES (3, 5)
GO

INSERT INTO CLINICA.RolXfunc(role_id, func_id)
VALUES (4, 5), (4, 6), (4, 7), (4, 8)
GO

INSERT INTO CLINICA.RolXfunc(role_id, func_id)
SELECT role_id, 11 FROM CLINICA.Rol WHERE role_id <> 1

INSERT INTO CLINICA.Contacto(mail, cod_postal, dom_calle, nro_piso, nro_dpto, nro_calle)
SELECT DISTINCT m.Cli_Mail AS mail, m.Cli_Cod_Postal, m.Cli_Dom_Calle, m.Cli_Piso, m.Cli_Depto, m.Cli_Nro_Calle
FROM gd_esquema.Maestra m WHERE m.Cli_Mail IS NOT NULL
UNION ALL
SELECT DISTINCT m.Publ_Empresa_Mail AS mail, m.Publ_Empresa_Cod_Postal, m.Publ_Empresa_Dom_Calle, m.Publ_Empresa_Piso,
m.Publ_Empresa_Depto, m.Publ_Empresa_Nro_Calle FROM gd_esquema.Maestra m WHERE m.Publ_Empresa_Mail IS NOT NULL
ORDER BY mail
GO


/* Inserto el usuario admin */

INSERT INTO CLINICA.RolXUsuario(cod_rol, cod_us)
VALUES (1, (SELECT cod_us FROM CLINICA.Usuario WHERE username = 'admin'))

INSERT INTO CLINICA.Rubro(rubro_desc_corta, rubro_desc_larga)
SELECT DISTINCT m.Publicacion_Rubro_Descripcion, m.Publicacion_Rubro_Descripcion FROM gd_esquema.Maestra m
GO

INSERT INTO CLINICA.Calificacion(cod_calif, calif_ant_estrellas, calif_desc, calif_estrellas)
SELECT DISTINCT m.Calificacion_Codigo, m.Calificacion_Cant_Estrellas,m.Calificacion_Descripcion,
             case m.Calificacion_Cant_Estrellas
             when 1 then 1 when 2 then 1 when 3 then 2  when 4 then 2  when 5 then 3 when 6 then 3
             when 7 then 4 when 8 then 4 when 9 then 5  when 10 then 5 end as calificacion
FROM gd_esquema.Maestra m WHERE m.Calificacion_Codigo IS NOT NULL
GO

INSERT INTO CLINICA.Visibilidad(cod_visi, visi_desc, comision_pub, comision_vta, comision_envio)
SELECT DISTINCT m.Publicacion_Visibilidad_Cod, m.Publicacion_Visibilidad_Desc,
                m.Publicacion_Visibilidad_Precio, m.Publicacion_Visibilidad_Porcentaje,
				CASE WHEN m.Publicacion_Visibilidad_Desc = 'Gratis' THEN 0 ELSE 0.05 END
FROM gd_esquema.Maestra m
GO

INSERT INTO CLINICA.Tipo(descripcion)
SELECT DISTINCT m.Publicacion_Tipo FROM gd_esquema.Maestra m
GO

INSERT INTO CLINICA.Estado_publ(descripcion)
VALUES ('Activada'),
	   ('Pausada'),
	   ('Borrador'),
	   ('Finalizada');
GO

INSERT INTO CLINICA.Publicacion (cod_pub, cod_us, cod_rubro, cod_visi, descripcion, stock, fecha_ini,
                                fecha_fin, precio, estado, cod_tipo, envio)
SELECT DISTINCT m.Publicacion_Cod, u.cod_us, r.cod_rubro, v.cod_visi, m.Publicacion_Descripcion,
                m.Publicacion_Stock, m.Publicacion_Fecha, m.Publicacion_Fecha_Venc, m.Publicacion_Precio,
                CASE WHEN t.cod_tipo = 1 THEN 1 ELSE 4 END, t.cod_tipo, 0
FROM gd_esquema.Maestra m, CLINICA.Usuario u, CLINICA.Rubro r, CLINICA.Visibilidad v, CLINICA.Tipo t
WHERE u.username = (SELECT CAST(m.Publ_Cli_Dni AS NVARCHAR(225))) AND t.descripcion = m.Publicacion_Tipo
      AND r.rubro_desc_corta = m.Publicacion_Rubro_Descripcion AND v.cod_visi = m.Publicacion_Visibilidad_Cod
UNION ALL
SELECT DISTINCT m.Publicacion_Cod, u.cod_us, r.cod_rubro, v.cod_visi, m.Publicacion_Descripcion,
                m.Publicacion_Stock, m.Publicacion_Fecha, m.Publicacion_Fecha_Venc, m.Publicacion_Precio,
                CASE WHEN t.cod_tipo = 1 THEN 1 ELSE 4 END, t.cod_tipo, 0
FROM gd_esquema.Maestra m, CLINICA.Usuario u, CLINICA.Rubro r, CLINICA.Visibilidad v, CLINICA.Tipo t
WHERE u.username = m.Publ_Empresa_Cuit AND t.descripcion = m.Publicacion_Tipo
      AND r.rubro_desc_corta = m.Publicacion_Rubro_Descripcion AND v.cod_visi = m.Publicacion_Visibilidad_Cod
ORDER BY m.Publicacion_Cod
GO

INSERT INTO CLINICA.Factura(nro_fact, cod_pub, cod_us, fecha, total, forma_pago)
SELECT DISTINCT m.Factura_Nro, p.cod_pub, p.cod_us, m.Factura_Fecha, m.Factura_Total, m.Forma_Pago_Desc
FROM gd_esquema.Maestra m, CLINICA.Publicacion p WHERE p.cod_pub = m.Publicacion_Cod AND m.Factura_Nro IS NOT NULL
GO

INSERT INTO CLINICA.Tipo_fact(descripcion)
VALUES('Visibilidad'),
	  ('Compra Inmediata'),
	  ('Subasta'),
	  ('Envio');
GO

INSERT INTO CLINICA.Detalle(nro_fact, item_desc, cantidad, importe)
SELECT f.nro_fact, (CASE
	  WHEN M.Item_Factura_Monto IN (SELECT V.comision_pub FROM CLINICA.Visibilidad V) 
	  AND M.Item_Factura_Cantidad = 1 
	  AND M.Item_Factura_Monto <> M.Publicacion_Visibilidad_Porcentaje * M.Publicacion_Precio THEN 1
	  WHEN M.Publicacion_Tipo = 'Subasta' THEN 3 
	  WHEN M.Publicacion_Tipo = 'Compra Inmediata' THEN 2 END),
	  m.Item_Factura_Cantidad, m.Item_Factura_Monto
FROM  gd_esquema.Maestra m, CLINICA.Factura f WHERE m.Factura_Nro = f.nro_fact
ORDER BY f.nro_fact
GO

INSERT INTO CLINICA.Oferta(cod_pub, cod_us, monto_of, fecha_of)
SELECT DISTINCT p.cod_pub, p.cod_us, m.Oferta_Monto, m.Oferta_Fecha
FROM gd_esquema.Maestra m, CLINICA.Publicacion p
WHERE p.cod_pub = m.Publicacion_Cod AND m.Oferta_Monto IS NOT NULL ORDER BY p.cod_pub
GO

INSERT INTO CLINICA.Tipo_doc(documento, descripcion)
VALUES ('DNI', 'Documento Nacional de Identidad'),
	   ('LE', 'Libreta de Enrolamiento'),
	   ('LC', 'Libreta Cívica');
GO

INSERT INTO CLINICA.Cliente(cod_us, cod_contacto, cli_nombre, cli_apellido, cli_num_doc, cli_fecha_Nac, cli_tipo_doc)
SELECT DISTINCT u.cod_us, c.cod_contacto, m.Cli_Nombre, m.Cli_Apeliido, m.Cli_Dni, m.Cli_Fecha_Nac, 1
FROM gd_esquema.Maestra m, CLINICA.Usuario u, CLINICA.Contacto c
WHERE u.username = (SELECT CAST(m.Cli_Dni AS NVARCHAR(225))) AND c.mail = m.Cli_Mail
GO

INSERT INTO CLINICA.Empresa(cod_us, cod_contacto, emp_razon_soc, emp_cuit)
SELECT DISTINCT u.cod_us, c.cod_contacto, m.Publ_Empresa_Razon_Social, m.Publ_Empresa_Cuit
FROM gd_esquema.Maestra m, CLINICA.Usuario u, CLINICA.Contacto c
WHERE m.Publ_Empresa_Cuit = u.username AND c.mail = m.Publ_Empresa_Mail
GO

INSERT INTO CLINICA.RolXus(cod_rol, cod_us)
SELECT 3, u.cod_us FROM CLINICA.Usuario u WHERE u.cod_us IN (SELECT e.cod_us FROM CLINICA.Empresa e)
UNION ALL
SELECT 4, u.cod_us FROM CLINICA.Usuario u WHERE u.cod_us IN (SELECT c.cod_us FROM CLINICA.Cliente c)
UNION ALL
SELECT 2, u.cod_us FROM CLINICA.Usuario u WHERE u.cod_us = 2
GO

CREATE TRIGGER CLINICA.tr_update_calif
ON CLINICA.Compra
AFTER UPDATE, INSERT
AS BEGIN

    DECLARE @datos_prom TABLE (cod_us INT, vtas INT, prom NUMERIC(18, 2))
    DECLARE @total INT, @i INT = 0, @cod_us INT, @prom NUMERIC(18, 2), @vtas INT

    INSERT INTO @datos_prom
    SELECT p.cod_us, COUNT(*), AVG(c.calif_estrellas) AS promedio
    FROM  CLINICA.Publicacion p, CLINICA.Compra cm, CLINICA.Calificacion c
    WHERE p.cod_pub= cm.cod_pub AND cm.cod_calif = c.cod_calif
    AND p.cod_us IN (SELECT p.cod_us FROM inserted i, CLINICA.Publicacion p WHERE p.cod_pub = i.cod_pub)
    GROUP BY p.cod_us ORDER BY p.cod_us

    SELECT @total= COUNT(*) FROM @datos_prom

    WHILE (@i < @total) 
	BEGIN
       SELECT  @cod_us = dt.cod_us, @prom= dt.prom, @vtas = dt.vtas
       FROM @datos_prom dt ORDER BY dt.cod_us offset @i ROWS
       FETCH NEXT 1 ROWS only

       IF EXISTS (SELECT * FROM CLINICA.Empresa e WHERE e.cod_us= @cod_us)
          UPDATE CLINICA.Empresa SET emp_calificacion = @prom, emp_ventas = @vtas WHERE cod_us= @cod_us
       ELSE
          UPDATE CLINICA.Cliente SET cli_calificacion = @prom, cli_ventas = @vtas  WHERE cod_us= @cod_us

       SET @i = @i + 1
    END
END
GO


INSERT INTO CLINICA.Compra(cod_pub, cod_us, cod_calif, fecha_compra, cantidad, monto_compra)
SELECT m.Publicacion_Cod, cl.cod_us,m.Calificacion_Codigo, m.Compra_Fecha, 
       m.Compra_Cantidad, m.Compra_Cantidad * m.Publicacion_Precio
FROM gd_esquema.Maestra m, CLINICA.Cliente cl 
WHERE m.Publicacion_Tipo = 'Compra Inmediata' AND m.Calificacion_Codigo IS NOT NULL AND cl.cli_num_doc = m.Cli_Dni 
UNION ALL
SELECT m.Publicacion_Cod, cli.cod_us, m.Calificacion_Codigo, m.Compra_Fecha, m.Compra_Cantidad,
       (SELECT MAX(O.monto_of) FROM CLINICA.Oferta O WHERE O.cod_pub = m.Publicacion_Cod) 
from gd_esquema.Maestra m, CLINICA.Cliente cli 
where m.Publicacion_Tipo = 'Subasta' AND m.Calificacion_Codigo IS NOT NULL AND cli.cli_num_doc = m.Cli_Dni
ORDER BY m.Publicacion_Cod
GO

UPDATE CLINICA.Publicacion
   SET estado = 4
 WHERE EXISTS (SELECT C.cod_compra
                 FROM CLINICA.Compra C
				WHERE C.cod_pub = cod_pub
				  AND cod_tipo = 1)
GO

CREATE FUNCTION CLINICA.Emp_Categ (@emp_cuit NVARCHAR(225) )
    RETURNS INT
    BEGIN

        DECLARE @categoria NVARCHAR(225), @cod_rubro INT

        SELECT @categoria = d.Publicacion_Rubro_Descripcion
          FROM (SELECT TOP 1 m.Publicacion_Rubro_Descripcion , COUNT(*) AS cant
                FROM gd_esquema.Maestra m
                WHERE @emp_cuit = m.Publ_Empresa_Cuit
                GROUP BY m.Publ_Empresa_Cuit, m.Publicacion_Rubro_Descripcion
                ORDER BY cant DESC ) d

        SELECT @cod_rubro = r.cod_rubro FROM CLINICA.Rubro r WHERE r.rubro_desc_corta = @categoria

        RETURN @cod_rubro
    END
GO

UPDATE CLINICA.Empresa SET emp_rubro = CLINICA.Emp_Categ(e.emp_cuit)
FROM CLINICA.Empresa e WHERE emp_cuit = e.emp_cuit
GO

/* Creación de funciones y procedures para que trabajen los aplicativos clientes */

CREATE PROCEDURE CLINICA.calificar_vta (@cod_compra INT, @username NVARCHAR(255), @estrellas INT, @detalle NVARCHAR(225)) AS BEGIN
    BEGIN TRY
        BEGIN TRAN t1
          DECLARE @cod_calif INT, @errorInCalif INT, @errorUpCompra INT
          SELECT @cod_calif= MAX(c.cod_calif) + 1 FROM CLINICA.Calificacion c

          INSERT INTO CLINICA.Calificacion (cod_calif,calif_desc,calif_estrellas)
          VALUES (@cod_calif, @detalle, @estrellas)
          SET @errorInCalif = @@ERROR

          UPDATE CLINICA.Compra SET cod_calif= @cod_calif WHERE cod_compra = @cod_compra
          SET @errorUpCompra = @@error

        COMMIT TRAN t1
    END TRY

    BEGIN CATCH

       ROLLBACK TRANSACTION t1

       IF @errorInCalif <> 0
           RAISERROR ('No se pudo guardar la calificacion', 16, 1)

       IF @errorUpCompra <> 0
          RAISERROR ('No se pudo calificar la compra ', 16, 1)

    END CATCH

    RETURN 1
END
GO

CREATE PROCEDURE CLINICA.consulta_factura (@razon_social nvarchar(50), @tipo int, @fechai date, @fechaf date,
                                           @importei numeric(18,2), @importef numeric(18,2), @descripcion nvarchar(225),
                                           @pagina INT, @cantidad_resultados_por_pagina INT, @tipo_doc nvarchar(225))
AS
DECLARE @cod_us INT
DECLARE @table TABLE(cantidad_rows int,
       nro_fact numeric(18,0),
       cod_det int,
       cod_us int,
       cod_pub numeric(18,0),
       fecha datetime,

       total numeric(18,2), 
       forma_pago nvarchar(225),
       item_desc int,
       cantidad numeric(18,0),
       importe numeric(18,2))
DECLARE @count INT
DECLARE @tipo_doc2 INT = (SELECT t.cod_doc FROM CLINICA.Tipo_doc t WHERE t.documento = @tipo_doc)
IF (@importei = 0)
    SET @importei = 0.1
IF (@tipo = 0 AND @razon_social <> '')
	   SET @cod_us = (SELECT TOP 1 cod_us FROM CLINICA.CLIENTE WHERE cli_num_doc = CONVERT(numeric(18), @razon_social))
ELSE IF (@tipo = 1 AND @razon_social <> '')
	   SET @cod_us = (SELECT TOP 1 cod_us FROM CLINICA.Empresa WHERE emp_cuit = @razon_social)
IF (@razon_social = '')
  BEGIN
    INSERT INTO @table
    SELECT null AS cantidad_rows,
       f.nro_fact AS Nro_Factura,
       d.cod_det AS Codigo_Detalle,
       f.cod_us AS Codigo_Vendedor,
       f.cod_pub AS Codigo_Publicacion,
       f.fecha,
       f.total, 
       f.forma_pago,
       d.item_desc AS detalle_factura,
       d.cantidad,
       d.importe AS importe_item
  FROM CLINICA.Factura f
  LEFT JOIN CLINICA.Detalle d
  ON f.nro_fact = d.nro_fact
  WHERE ((@fechai IS NULL) OR (@fechai <= f.fecha)) AND ((@fechaf IS NULL) OR (@fechaf >= f.fecha)) AND (@importei <= f.total) AND (@importef >= f.total) AND EXISTS (select T.cod_tipo_fact from CLINICA.Tipo_fact T WHERE T.descripcion LIKE '%' + @descripcion + '%' AND D.item_desc = T.cod_tipo_fact) AND EXISTS (select C.cod_us from CLINICA.Cliente C WHERE f.cod_us = C.cod_us AND C.cli_tipo_doc = @tipo_doc2)
  END
ELSE
  BEGIN
    INSERT INTO @table
    SELECT  null AS cantidad_rows,
       f.nro_fact AS Nro_Factura,
	   d.cod_det AS Codigo_Detalle,
	   f.cod_us AS Codigo_Vendedor,
	   f.cod_pub AS Codigo_Publicacion,
	   f.fecha,
	   f.total, 
	   f.forma_pago,
	   d.item_desc AS detalle_factura,
	   d.cantidad,
	   d.importe AS importe_item
    FROM CLINICA.Factura f
    LEFT JOIN CLINICA.Detalle d
    ON f.nro_fact = d.nro_fact
    WHERE f.cod_us = @cod_us AND ((@fechai IS NULL) OR (@fechai <= f.fecha)) AND ((@fechaf IS NULL) OR (@fechaf >= f.fecha)) AND (@importei <= f.total) AND (@importef >= f.total)
  END
  SET @count = (SELECT COUNT(*) FROM @table)
  UPDATE @table SET cantidad_rows = @count
  SELECT * FROM @table
  ORDER BY nro_fact
  OFFSET @pagina * @cantidad_resultados_por_pagina ROWS
   FETCH NEXT @cantidad_resultados_por_pagina ROWS ONLY
GO

 CREATE PROCEDURE CLINICA.list_vendedor_mayorCantProdSinVta (@anio int, @nro_trim int, @cod_visi int, @mes int)
AS BEGIN
    BEGIN TRY
	   BEGIN TRAN t1
		  
		  DECLARE @mes_i int, @mes_f int 
		  
		  DECLARE @datos TABLE (Anio int, Mes int, Codigo_Visibilidad int, Codigo_Vendedor int, Cantidad int)

		  set @mes_f = @nro_trim * 3
		  set @mes_i = @mes_f-2

		  if @mes is not null and @mes_i <= @mes and @mes <= @mes_f 
		  begin
			 set @mes_i = @mes
			 set @mes_f = @mes
		  end

		  if @mes is not null and not(@mes between @mes_i and @mes_f) 
		  begin
			 raiserror('El mes ingresado no pertenece al trimestre seleccionado', 20, -1)
		  end

				insert into @datos
				select top 5 year(p.fecha_ini) as anio,
				       month(p.fecha_ini) as mes,
					  p.cod_visi as visi, 
					  p.cod_us as vendedor, 
					  COUNT(p.stock) as cantidad  
				from CLINICA.Publicacion p
				where (month(p.fecha_ini)= @mes or month(p.fecha_ini) between @mes_i and @mes_f)
				      and (@cod_visi is null or p.cod_visi = @cod_visi)
					 and year(p.fecha_ini) = @anio
					 and p.estado <> 4
				group by year(p.fecha_ini),month(p.fecha_ini), p.cod_visi, p.cod_us
				order by cantidad desc

		  select d.Anio, d.Mes, v.visi_desc, d.Codigo_Vendedor, d.Cantidad, 
			    e.emp_razon_soc, emp_cuit, emp_calificacion,
			    c.cli_apellido, c.cli_nombre, c.cli_num_doc,c.cli_calificacion
		  from @datos d 
			  left join CLINICA.Empresa e 
			  on e.cod_us = d.Codigo_Vendedor 
			  left join CLINICA.Cliente c 
			  on c.cod_us=d.Codigo_Vendedor
			  left join CLINICA.Visibilidad v
			  on v.cod_visi= d.Codigo_Visibilidad
		  order by Mes asc, Codigo_Visibilidad 
  

	   COMMIT TRAN t1
	END TRY

	BEGIN CATCH

	    ROLLBACK TRANSACTION t1

	    DECLARE @ErrorMessage NVARCHAR(4000);
	    DECLARE @ErrorSeverity INT;
	    DECLARE @ErrorState INT;

	    SELECT 

         @ErrorMessage = ERROR_MESSAGE(),
         @ErrorSeverity = ERROR_SEVERITY(),
         @ErrorState = ERROR_STATE();

	    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);

	END CATCH

	RETURN 1
END
GO

CREATE PROCEDURE CLINICA.list_cli_mayorCantProdCompr (@anio int, @nro_trim int, @cod_rubro int)
AS BEGIN
    begin try
	  
-- MUY IMPORTANTE!!!!-- >Al momento de facturar una subasta, hacer el insert en compras---> NO BORAR ESTE COMENTARIO!!!
	   
	   DECLARE @datos_cli TABLE (anio int, mes int, rubro nvarchar(225) , codigo_cliente int, cantidad_comprada int)
	   DECLARE @mes_f int, @mes_i int

	   set @mes_f = @nro_trim * 3 
	   set @mes_i = @mes_f-2


	   insert into @datos_cli
	   select top 5
	          year(c.fecha_compra) as anio,
			month(c.fecha_compra) as mes, 
			r.rubro_desc_corta as rubro, 
			c.cod_us as codigo_cliente, 
			COUNT(c.cantidad) as cantidad  
	   from CLINICA.Compra c, CLINICA.Publicacion p, CLINICA.Rubro r
	   where c.cod_pub=p.cod_pub and 
		    p.cod_rubro = r.cod_rubro and 
		    r.cod_rubro = @cod_rubro and
		    year(c.fecha_compra) = @anio and
		    month(c.fecha_compra) between @mes_i and @mes_f
	   group by year(c.fecha_compra),month(c.fecha_compra), r.rubro_desc_corta, c.cod_us
	   order by cantidad desc


	   select dc.*, c.cli_apellido, c.cli_nombre, c.cli_num_doc,c.cli_calificacion
	   from @datos_cli dc 
	        left join 
		   CLINICA.Cliente c 
		   on dc.codigo_cliente = c.cod_us
	   order by anio desc, mes asc, cantidad_comprada desc


  
    end try
    begin catch

	   DECLARE @ErrorMessage NVARCHAR(4000);
	   DECLARE @ErrorSeverity INT;
	   DECLARE @ErrorState INT;
	   
        SET @ErrorMessage = ERROR_MESSAGE()
        SET @ErrorSeverity = ERROR_SEVERITY()
        SET @ErrorState = ERROR_STATE();

	   RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState);

    end catch
   END
GO

CREATE PROCEDURE CLINICA.list_vend_mayorCantFact (@anio int, @nro_trim int, @mes int)
AS BEGIN
    begin try

	   DECLARE @datos_vendCantFact TABLE (anio int, mes int, codigo_vendedor int, cantidad_facturas int)
	   DECLARE @mes_f int, @mes_i int

	   set @mes_f = @nro_trim * 3 
	   set @mes_i = @mes_f-2

	   if @mes is not null and @mes_i <= @mes and @mes <= @mes_f 
	   begin
		  set @mes_i = @mes
		  set @mes_f = @mes
	   end

	   if @mes is not null and not(@mes between @mes_i and @mes_f) 
	   begin
		  raiserror('El mes ingresado no pertenece al trimestre seleccionado', 20, -1)
	   end


	   insert into @datos_vendCantFact
	   select top 5
	          year(f.fecha) as anio,
			month(f.fecha) as mes,
			f.cod_us as codigo_vendedor, 
			COUNT(*) as cantidad  
	   from  CLINICA.Factura f
	   where  year(f.fecha) = @anio and
		    (month(f.fecha)= @mes or month(f.fecha) between @mes_i and @mes_f)
	   group by year(f.fecha),month(f.fecha), f.cod_us
	   order by  cantidad desc


	   select d.Anio, d.Mes, d.codigo_vendedor, d.cantidad_facturas, 
			e.emp_razon_soc, emp_cuit, emp_calificacion,
			c.cli_apellido, c.cli_nombre, c.cli_num_doc,c.cli_calificacion
	   from @datos_vendCantFact d 
		   left join CLINICA.Empresa e 
		   on e.cod_us = d.Codigo_Vendedor 
		   left join CLINICA.Cliente c 
		   on c.cod_us=d.Codigo_Vendedor
	   order by anio desc, mes asc, cantidad_facturas desc

  
    end try
    begin catch

	   DECLARE @ErrorMessage NVARCHAR(4000);
	   DECLARE @ErrorSeverity INT;
	   DECLARE @ErrorState INT;
	   
        SET @ErrorMessage = ERROR_MESSAGE()
        SET @ErrorSeverity = ERROR_SEVERITY()
        SET @ErrorState = ERROR_STATE();

	   RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState);

    end catch
   END
GO

CREATE PROCEDURE CLINICA.list_vend_mayorMontoFact (@anio int, @nro_trim int, @mes int)
AS BEGIN
    begin try

	   DECLARE @datos_vendMontoFact TABLE (anio int, mes int, codigo_vendedor int, monto_facturado int)
	   DECLARE @mes_f int, @mes_i int

	   set @mes_f = @nro_trim * 3
	   set @mes_i = @mes_f-2

	   if @mes is not null and @mes_i <= @mes and @mes <= @mes_f 
	   begin
		  set @mes_i = @mes
		  set @mes_f = @mes
	   end

	   if @mes is not null and not(@mes between @mes_i and @mes_f) 
	   begin
		  raiserror('El mes ingresado no pertenece al trimestre seleccionado', 20, -1)
	   end


	   insert into @datos_vendMontoFact
	   select top 5
	          year(f.fecha) as anio,
			month(f.fecha) as mes,
			f.cod_us as codigo_vendedor, 
			SUM(f.total) as monto  
	   from  CLINICA.Factura f
	   where  year(f.fecha) = @anio and
		    (month(f.fecha)= @mes or month(f.fecha) between @mes_i and @mes_f)
	   group by year(f.fecha),month(f.fecha), f.cod_us
	   order by  monto desc

	   

	   select d.Anio, d.Mes, d.codigo_vendedor, d.monto_facturado, 
			e.emp_razon_soc, emp_cuit, emp_calificacion,
			c.cli_apellido, c.cli_nombre, c.cli_num_doc,c.cli_calificacion
	   from @datos_vendMontoFact d 
		   left join CLINICA.Empresa e 
		   on e.cod_us = d.Codigo_Vendedor 
		   left join CLINICA.Cliente c 
		   on c.cod_us=d.Codigo_Vendedor
        order by anio desc, mes asc, monto_facturado desc
  
    end try
    begin catch

	   DECLARE @ErrorMessage NVARCHAR(4000);
	   DECLARE @ErrorSeverity INT;
	   DECLARE @ErrorState INT;
	   
        SET @ErrorMessage = ERROR_MESSAGE()
        SET @ErrorSeverity = ERROR_SEVERITY()
        SET @ErrorState = ERROR_STATE();

	   RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState);

    end catch
   END
GO

CREATE PROCEDURE CLINICA.listados (@anio int, @nro_trim int, @tipoListado int, @cod_visi int, @mes int, @cod_rubro int)
AS BEGIN

if @tipoListado = 0
    exec CLINICA.list_vendedor_mayorCantProdSinVta @anio, @nro_trim, @cod_visi, @mes 
if @tipoListado = 1
    exec CLINICA.list_cli_mayorCantProdCompr @anio, @nro_trim, @cod_rubro 
if @tipoListado = 2
    exec CLINICA.list_vend_mayorCantFact @anio, @nro_trim, @mes 
if @tipoListado = 3
    exec CLINICA.list_vend_mayorMontoFact @anio, @nro_trim, @mes 

END
GO

CREATE PROCEDURE CLINICA.facturar_venta(@codigo_publicacion INT, @fecha DATETIME, @cantidad INT) AS BEGIN
/* Factura una venta, teniendo en cuenta si tiene o no envio
   Devuelve el numero de factura o -1 si ocurre un error */
  BEGIN TRY
    BEGIN TRANSACTION
		DECLARE @ret INT
		DECLARE @nuevo_numero_factura NUMERIC(18, 0)
		DECLARE @comision_venta NUMERIC(18, 2)
		DECLARE @comision_envio NUMERIC(18, 2)
		
		SET @comision_envio = 0  -- Por defecto, no se le cobra el envio
		SET @ret = -1  -- Cuando se haga realmente todo, seteo esta variable al numero de factura
		
		SELECT @nuevo_numero_factura = MAX(F.nro_fact) + 1 FROM CLINICA.Factura F
			
		/* Calculo la comision de venta */
		SELECT @comision_venta = V.comision_vta * P.precio * @cantidad
		FROM CLINICA.Publicacion P, CLINICA.Visibilidad V
		WHERE P.cod_pub = @codigo_publicacion AND P.cod_visi = V.cod_visi
	
		/* Calculo la comision por envio, si la publicaion la tuviera */ 
		SELECT @comision_envio = V.comision_envio * P.precio * @cantidad
		FROM CLINICA.Publicacion P, CLINICA.Visibilidad V
		WHERE P.cod_pub = @codigo_publicacion AND P.envio = 1 AND V.cod_visi = P.cod_visi

		/* Creo una nueva factura asociada */
		INSERT CLINICA.Factura(nro_fact, cod_pub, fecha, forma_pago, total, cod_us)
		VALUES(@nuevo_numero_factura, @codigo_publicacion, @fecha,
		'Efectivo', @comision_envio + @comision_venta, 
		(SELECT P.cod_us FROM CLINICA.Publicacion P WHERE P.cod_pub = @codigo_publicacion))

		/* Inserto los detalles de la factura */
		INSERT CLINICA.Detalle(nro_fact, item_desc, cantidad, importe)
		VALUES(@nuevo_numero_factura, 
		(SELECT CASE WHEN P.cod_tipo = 1 THEN 2 ELSE 3 END FROM CLINICA.Publicacion P WHERE P.cod_pub = @codigo_publicacion), 
		@cantidad, 
		@comision_venta)

		IF 2 = (SELECT P.cod_tipo FROM CLINICA.Publicacion P WHERE P.cod_pub = @codigo_publicacion)  
		BEGIN
			DECLARE @cod_us INT
			DECLARE @monto INT

			SELECT @cod_us = O.cod_us, @monto = O.monto_of FROM CLINICA.Oferta O WHERE O.cod_pub = @codigo_publicacion AND 
			O.monto_of = (SELECT MAX(O.monto_of) FROM CLINICA.Oferta O WHERE O.cod_pub = @codigo_publicacion)
			
			INSERT INTO CLINICA.Compra(cod_pub, cod_us, fecha_compra, cantidad, monto_compra)
			VALUES (@codigo_publicacion, @cod_us, @fecha, @cantidad, @monto)
		END

		IF @comision_envio > 0
			INSERT CLINICA.Detalle(nro_fact, item_desc, cantidad, importe)
			VALUES(@nuevo_numero_factura, 4, @cantidad, @comision_envio)

    COMMIT TRANSACTION
    SET @ret = @nuevo_numero_factura
  END TRY

  BEGIN CATCH
    ROLLBACK TRANSACTION
  END CATCH

  SELECT @ret
END
GO

CREATE PROCEDURE CLINICA.finalizar_subastas(@fecha DATETIME) AS BEGIN
/* Finaliza las subastas que tienen como fecha de final una anterior a la
   fecha pasada como parametro */
  DECLARE @codigo INT
  DECLARE subastas_finalizadas CURSOR FOR (SELECT P.cod_pub FROM CLINICA.Publicacion P
                                           WHERE CONVERT(DATE, P.fecha_fin) < CONVERT(DATE, @fecha)
                                           AND P.cod_tipo = 2 AND P.estado <> 4)
  OPEN subastas_finalizadas
  FETCH NEXT FROM subastas_finalizadas INTO @codigo

  /* Facturo la venta de cada subasta que paso a finalizada */
  WHILE @@FETCH_STATUS = 0 BEGIN
    BEGIN TRY
      /* Para que el cambio de estado y la facturacion se hagan de manera atomica */
      BEGIN TRANSACTION
        /* Facturacion */
        EXEC CLINICA.facturar_venta @codigo, @fecha, 1

        /* Cambio de estado */
        UPDATE CLINICA.Publicacion SET estado = 4 WHERE cod_pub=@codigo

        FETCH NEXT FROM subastas_finalizadas INTO @codigo
      COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
    END CATCH
  END

  CLOSE subastas_finalizadas
  DEALLOCATE subastas_finalizadas
END
GO

CREATE PROCEDURE CLINICA.facturar_publicacion(@codigo_publicacion INT, @fecha DATETIME) AS BEGIN
/* Factura la comision por publicar de una publicacion. Devuelve el numero de factura o -1 */
  BEGIN TRY
    BEGIN TRANSACTION
    DECLARE @ret INT
    DECLARE @codigo_usuario INT
    DECLARE @nuevo_numero_factura NUMERIC(18, 0) = (SELECT MAX(F.nro_fact) + 1 FROM CLINICA.Factura F)
    DECLARE @comision NUMERIC(18, 2)
    SET @ret = -1

    /* Busco el codigo de usuario */
    SELECT @codigo_usuario = cod_us FROM CLINICA.Publicacion
    WHERE cod_pub = @codigo_publicacion

    /* Calculo la comision de publicacion */
    SELECT @comision = V.comision_pub
    FROM CLINICA.Publicacion P, CLINICA.Visibilidad V 
	WHERE P.cod_pub = @codigo_publicacion AND P.cod_visi = V.cod_visi

    /* Creo una nueva factura asociada */
    INSERT CLINICA.Factura(nro_fact, cod_pub, fecha, forma_pago, total, cod_us)
    VALUES(@nuevo_numero_factura, @codigo_publicacion, @fecha,
           'Efectivo', @comision, (SELECT P.cod_us
                                   FROM CLINICA.Publicacion P
                                   WHERE P.cod_pub = @codigo_publicacion))

    /* Inserto los detalles de la factura */
    INSERT CLINICA.Detalle(nro_fact, item_desc, cantidad, importe)
    VALUES(@nuevo_numero_factura, 1, 1, @comision)

    COMMIT TRANSACTION
    SET @ret = @nuevo_numero_factura
  END TRY

  BEGIN CATCH
    ROLLBACK TRANSACTION
  END CATCH

  SELECT @ret
END
GO

CREATE PROCEDURE CLINICA.alta_vis(@descripcion NVARCHAR(225), @comision_pub NUMERIC(18, 2),
                                  @comision_vta NUMERIC(18, 2), @comision_envio NUMERIC(18, 2))
AS BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            DECLARE @cod_visi NUMERIC(18, 0)

            IF NOT EXISTS (SELECT * FROM CLINICA.Visibilidad v WHERE v.visi_desc = @descripcion)
            BEGIN
                SELECT @cod_visi = MAX(v.cod_visi) + 1 FROM CLINICA.Visibilidad v

                INSERT INTO CLINICA.Visibilidad(cod_visi, visi_desc, comision_pub, comision_vta, comision_envio)
                VALUES (@cod_visi, @descripcion, @comision_pub, @comision_vta, @comision_envio)
            END
            ELSE
                RAISERROR('', 16, 1)
        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION

        IF EXISTS (SELECT * FROM CLINICA.Visibilidad v WHERE v.visi_desc = @descripcion)
        BEGIN
            PRINT 'La visibilidad ya existe.'
            RETURN -1
        END
    END CATCH

    RETURN 1
END
GO

CREATE PROCEDURE CLINICA.mod_vis(@cod_visi NUMERIC(18, 0), @descripcion NVARCHAR(225), @comision_pub NUMERIC(18, 2),
                                 @comision_vta NUMERIC(18, 2), @comision_envio NUMERIC(18, 2))
AS BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            IF EXISTS (SELECT * FROM CLINICA.Visibilidad v WHERE v.cod_visi = @cod_visi)
            BEGIN
                IF NOT EXISTS (SELECT * FROM CLINICA.Visibilidad v WHERE v.visi_desc = @descripcion AND v.cod_visi <> @cod_visi)
                BEGIN
                    UPDATE CLINICA.Visibilidad SET visi_desc = @descripcion, comision_pub = @comision_pub,
                    comision_vta = @comision_vta, comision_envio = @comision_envio WHERE cod_visi = @cod_visi
                END
                ELSE
                    RAISERROR('', 16, 1)
            END
            ELSE
                RAISERROR('', 16, 1)
        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION

        IF NOT EXISTS (SELECT * FROM CLINICA.Visibilidad v WHERE v.cod_visi = @cod_visi)
        BEGIN
            PRINT 'La visibilidad a modificar no existe.'
            RETURN -1
        END

        IF EXISTS (SELECT * FROM CLINICA.Visibilidad v WHERE v.visi_desc = @descripcion)
        BEGIN
            PRINT 'Hay otra visibilidad con la misma descripcion.'
            RETURN -2
        END
    END CATCH

    RETURN 1
END
GO

CREATE PROCEDURE CLINICA.generar_publicacion(@descripcion NVARCHAR(225), @stock NUMERIC(18, 0),
                                             @precio NUMERIC(18, 2), @rubro NVARCHAR(225),
                                             @usuario NVARCHAR(225), @visi NVARCHAR(225), @estado NVARCHAR(225),
                                             @tipo NVARCHAR(225), @fecha_venc DATETIME, @envio BIT, @fecha DATETIME)
AS BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            DECLARE @cod_pub INT
            DECLARE @cod_us INT
            DECLARE @cod_visi INT
            DECLARE @h BIT

            SELECT @cod_us = u.cod_us, @h = u.habilitado FROM CLINICA.Usuario u WHERE u.username = @usuario

            IF @h = 1
            BEGIN
                SELECT @cod_pub = MAX(p.cod_pub) + 1 FROM CLINICA.Publicacion p

                IF NOT EXISTS (SELECT p.cod_us FROM CLINICA.Publicacion p WHERE p.cod_us = @cod_us) AND @cod_us > 97
                BEGIN
                    SELECT @cod_visi = v.cod_visi FROM CLINICA.Visibilidad v WHERE v.visi_desc = 'Gratis'
                END
                ELSE
                    SELECT @cod_visi = v.cod_visi FROM CLINICA.Visibilidad v WHERE v.visi_desc = @visi

                INSERT INTO CLINICA.Publicacion (cod_pub, cod_us, cod_rubro, cod_visi, descripcion, stock,
                                                fecha_ini, fecha_fin, precio, estado, cod_tipo, envio)
                SELECT @cod_pub, @cod_us, r.cod_rubro, @cod_visi, @descripcion, @stock, @fecha,
                CASE WHEN @tipo = 'Subasta' THEN @fecha_venc WHEN @tipo = 'Compra Inmediata' THEN NULL END,
                @precio, e.cod_estado, t.cod_tipo, @envio
                FROM CLINICA.Rubro r, CLINICA.Tipo t, CLINICA.Estado_publ e 
				WHERE r.rubro_desc_corta = @rubro AND t.descripcion = @tipo AND e.descripcion = @estado
            END
            ELSE
                RAISERROR('', 16, 1)
        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION

        IF @h <> 1
        BEGIN
            PRINT 'El usuario esta inhabilitado.'
            SELECT -1
        END
    END CATCH

    SELECT @cod_pub
END
GO

CREATE PROCEDURE CLINICA.cambiar_estado_publ(@usuario NVARCHAR(225), @cod_pub NUMERIC(18, 0), @nuevo_estado NVARCHAR(225), @fecha DATETIME)
AS BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            DECLARE @estado INT
            DECLARE @tipo NVARCHAR(225)
            DECLARE @cod_us NVARCHAR(225)
            DECLARE @h BIT
            DECLARE @ret INT = -1

			DECLARE @cod_estado INT = (SELECT E.cod_estado FROM CLINICA.Estado_publ E WHERE @nuevo_estado = E.descripcion)

            SELECT @estado = p.estado, @tipo = t.descripcion, @cod_us = u.username, @h = u.habilitado
            FROM CLINICA.Publicacion p, CLINICA.Usuario u, CLINICA.Tipo t
            WHERE p.cod_pub = @cod_pub AND p.cod_us = u.cod_us AND p.cod_tipo = t.cod_tipo

            IF @usuario = @cod_us AND @h = 1
            BEGIN
                IF (@nuevo_estado <> 'Finalizado' AND @tipo = 'Subasta') OR @tipo = 'Compra Inmediata'
                BEGIN
                    IF @estado <> 4
                    BEGIN
                        IF @estado <> @cod_estado
                        BEGIN
                            UPDATE CLINICA.Publicacion SET estado = @cod_estado WHERE cod_pub = @cod_pub
                            IF @nuevo_estado = 'Activada' and not exists (select f.nro_fact from CLINICA.Factura f where f.cod_pub = @cod_pub)
					   BEGIN
                             
                              EXEC @ret = CLINICA.facturar_publicacion @cod_pub, @fecha 
                            END
                        END
                        ELSE
                            RAISERROR('', 16, 1)
                    END
                    ELSE
                        RAISERROR('', 16, 1)
                END
                ELSE
                    RAISERROR('', 16, 1)
            END
            ELSE
                RAISERROR('', 16, 1)

        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION

        IF @usuario <> @cod_us OR @h <> 1
        BEGIN
            PRINT 'La publicacion que se quiere modificar no le corresponde al usuario ingresado o esta inhabilitado.'
            SELECT -1
        END

        IF @nuevo_estado = 'Finalizado' AND @tipo = 'Subasta'
        BEGIN
            PRINT 'Las subastas no pueden cambiarse a finalizadas, el sistema lo hace automaticamente.'
            SELECT -2
        END

        IF @estado = @cod_estado
        BEGIN
            PRINT 'La publicacion ya tiene el estado por el que se desea cambiar.'
            SELECT -3
        END

        IF @estado = 4
        BEGIN
            PRINT 'No se puede cambiar el estado de una publicacion finalizada.'
            SELECT -4
        END

    END CATCH

    SELECT @ret
END
GO

CREATE PROCEDURE CLINICA.usuario_con_calif_pendientes(@usuario NVARCHAR(225))
AS BEGIN
	DECLARE @cod_us INT = (SELECT u.cod_us FROM CLINICA.Usuario u WHERE u.username = @usuario)
	DECLARE @calif_pedientes INT = (SELECT COUNT(*) FROM CLINICA.Compra c WHERE c.cod_us = @cod_us AND c.cod_calif IS NULL)
	
	IF @calif_pedientes <= 3
	SELECT 0
	
	SELECT 1 
END
GO

CREATE PROCEDURE CLINICA.comprar_ofertar(@cod_pub NUMERIC(18, 0), @usuario NVARCHAR(225),
                                         @cantidad NUMERIC(18, 0), @mont_of NUMERIC(18, 2), @fecha DATETIME)
AS BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            DECLARE @usuario2 NVARCHAR(225)
            DECLARE @cod_us INT
            DECLARE @monto_actual NUMERIC(18, 2)
            DECLARE @tipo NVARCHAR(225)
            DECLARE @h BIT
            DECLARE @ret INT

            IF EXISTS (SELECT p.cod_pub FROM CLINICA.Publicacion p WHERE p.cod_pub = @cod_pub AND p.estado <> 4)
            BEGIN
                IF @cantidad <= (SELECT p.stock FROM CLINICA.Publicacion p WHERE p.cod_pub = @cod_pub)
                BEGIN
                    SELECT @usuario2 = u.username, @h = u.habilitado FROM CLINICA.Publicacion p, CLINICA.Usuario u
                    WHERE p.cod_pub = @cod_pub AND p.cod_us = u.cod_us

                    IF @usuario <> @usuario2 AND @h = 1 
                    BEGIN
						SELECT @cod_us = u.cod_us FROM CLINICA.Usuario u WHERE u.username = @usuario
						SELECT @tipo = t.descripcion FROM CLINICA.Publicacion p, CLINICA.Tipo t
						WHERE p.cod_pub = @cod_pub AND p.cod_tipo = t.cod_tipo

						IF 'Compra Inmediata' = @tipo
						BEGIN
							INSERT INTO CLINICA.Compra(cod_pub, cod_us, fecha_compra, cantidad, monto_compra)
							VALUES (@cod_pub, @cod_us, @fecha, @cantidad, @mont_of)

							UPDATE CLINICA.Publicacion SET stock = stock - @cantidad WHERE cod_pub = @cod_pub
							EXEC @ret = CLINICA.facturar_venta @cod_pub, @fecha, @cantidad
						END
						ELSE BEGIN
							SELECT @monto_actual = (CASE WHEN MAX(o.monto_of) IS NOT NULL THEN MAX(o.monto_of)
														 WHEN MAX(o.monto_of) IS NULL THEN 0 END)
							FROM CLINICA.Oferta o WHERE o.cod_pub = @cod_pub

							IF @monto_actual < FLOOR(@mont_of)
							BEGIN
								INSERT INTO CLINICA.Oferta(cod_pub, cod_us, fecha_of, monto_of)
								VALUES (@cod_pub, @cod_us, @fecha, @mont_of)

								UPDATE CLINICA.Publicacion SET precio = @mont_of WHERE cod_pub = @cod_pub

								SET @ret = 0
							END 
							ELSE RAISERROR('', 16, 1)
						END
					END
					ELSE RAISERROR('', 16, 1)

                END
                ELSE RAISERROR('', 16, 1)

            END
            ELSE RAISERROR('', 16, 1)

        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION

        IF NOT EXISTS (SELECT p.cod_pub FROM CLINICA.Publicacion p WHERE p.cod_pub = @cod_pub AND p.estado <> 4)
        BEGIN
            PRINT 'La publicacion no existe o ha finalizado .'
            RETURN -1
        END

        IF @cantidad > (SELECT p.stock FROM CLINICA.Publicacion p WHERE p.cod_pub = @cod_pub)
        BEGIN
            PRINT 'El stock es insuficiente.'
            RETURN -2
        END

        IF @usuario = @usuario2 OR @h <> 1
        BEGIN
            PRINT 'Un vendedor no puede auto-comprarse o auto-ofrecerse. O esta inhabilitado el usuario.'
            SELECT -3
        END

        IF @monto_actual >= @mont_of
        BEGIN
            PRINT 'El monto ofrecido es insuficiente.'
            RETURN -4
        END
    END CATCH

    SELECT @ret
END
GO

CREATE TRIGGER CLINICA.tr_finalizar_pub_compra_au
ON CLINICA.Publicacion
AFTER UPDATE
AS BEGIN
    IF UPDATE (stock)
    BEGIN
        UPDATE CLINICA.Publicacion SET estado = 4 WHERE stock = 0
    END
END
GO

CREATE PROCEDURE CLINICA.login (@userName NVARCHAR(255), @password VARCHAR(255)) AS BEGIN
  /* Devuelve una fila por cada rol que el usuario posea con:
    - Si el login fue exitoso o no (BIT)
    - Código de rol (INT)
    - Nombre de rol (NVARCHAR)
    - Cantidad de intentos fallidos (INT)
    - Si el usuario está habilitado o no (BIT)
  */
  DECLARE @ret BIT
  DECLARE @cantidad_intentos_fallidos INT

  SELECT @ret=COUNT(*), @cantidad_intentos_fallidos=MAX(intentos)
    FROM CLINICA.Usuario
   WHERE username = @userName
     AND pass_word = HASHBYTES('SHA2_256', @password)
     AND habilitado = 1

  IF @ret = 0 BEGIN
    --Agrego un login fallido
    UPDATE CLINICA.Usuario
       SET intentos = intentos + 1
     WHERE username = @userName
    --Deshabilito al usuario si ya tiene 3 logins fallidos
    UPDATE CLINICA.Usuario
       SET habilitado = 0
     WHERE username = @userName
       AND intentos = 3
  END
  ELSE
    UPDATE CLINICA.Usuario
       SET intentos = 0
     WHERE username = @userName

  --Devuelvo los roles asignados al usuario intentando loguearse
  -- o nada, si el login no fue exitoso
  SELECT @ret AS login_valido,
         RxU.cod_rol, R.nombre,
         U.habilitado, U.intentos
    FROM CLINICA.RolXus RxU, CLINICA.ROl R, CLINICA.Usuario U
   WHERE RxU.cod_rol = R.cod_rol
     AND U.username = @userName
     AND U.cod_us = RxU.cod_us
END
GO

CREATE PROCEDURE CLINICA.listar_empresas (@razon_social NVARCHAR(255), @cuit NVARCHAR(50), @mail NVARCHAR(50)) AS BEGIN
  SELECT *
    FROM CLINICA.Empresa E, CLINICA.Contacto C
   WHERE E.cod_contacto = C.cod_contacto
     AND ((E.emp_cuit = @cuit) OR (@cuit LIKE ''))
     AND ((E.emp_razon_soc LIKE '%' + @razon_social + '%' ) OR (@razon_social LIKE ''))
     AND ((C.mail LIKE '%' + @mail + '%') OR (@mail LIKE ''))
END
GO

CREATE PROCEDURE CLINICA.listar_clientes (@nombre NVARCHAR(255), @apellido NVARCHAR(255),
                                          @dni NUMERIC(18, 0), @email NVARCHAR(50), @tipo_doc INT) AS BEGIN
  SELECT *
    FROM CLINICA.Cliente Cl, CLINICA.Contacto Co
   WHERE Cl.cod_contacto = Co.cod_contacto
     AND ((@nombre LIKE '') OR (Cl.cli_nombre LIKE '%' + @nombre + '%'))
     AND ((@apellido LIKE '') OR (Cl.cli_apellido LIKE '%' +  @apellido + '%'))
     AND ((@email LIKE '') OR (Co.mail LIKE '%' +  @email + '%'))
     AND ((@dni = 0) OR (Cl.cli_num_doc = @dni)) AND ((@tipo_doc = 0) OR (Cl.cli_tipo_doc = @tipo_doc))
END
GO

CREATE PROCEDURE CLINICA.obtener_roles AS BEGIN
  SELECT *
    FROM CLINICA.Rol
   WHERE habilitado = 1
END
GO

CREATE PROCEDURE CLINICA.obtener_roles_para_modificar (@username NVARCHAR(255)) AS BEGIN
  /* Devuelve todos los roles para el administrador general y todos los roles no administrativos
     para el que no lo sea */
  SELECT *
    FROM CLINICA.Rol
  WHERE (cod_rol NOT IN (1, 2)) OR 1 = (SELECT R.cod_rol
                                          FROM CLINICA.Usuario U, CLINICA.RolXus R
                                         WHERE U.username = @username
                                           AND R.cod_us = U.cod_us)
END
GO

CREATE PROCEDURE CLINICA.obtener_usuario (@codigo  INT) AS BEGIN
  SELECT U.cod_us, U.fecha_creacion, U.habilitado, U.username
    FROM CLINICA.Usuario U
   WHERE  U.cod_us = @codigo
END
GO

CREATE PROCEDURE CLINICA.obtener_cliente (@codigo  INT) AS BEGIN
  SELECT Cl.*, Co.*, U.habilitado
    FROM CLINICA.Cliente Cl, CLINICA.Contacto Co, CLINICA.Usuario U
   WHERE  Cl.cod_contacto = Co.cod_contacto
     AND  Cl.cod_us = @codigo
     AND  U.cod_us = @codigo
END
GO

CREATE PROCEDURE CLINICA.obtener_empresa (@codigo  INT) AS BEGIN
  SELECT E.*, C.*, U.habilitado
    FROM CLINICA.Empresa E, CLINICA.Contacto C, CLINICA.Usuario U
   WHERE  E.cod_contacto = C.cod_contacto
     AND  E.cod_us = @codigo
     AND  U.cod_us = @codigo
END
GO

CREATE PROCEDURE CLINICA.crear_usuario (@username NVARCHAR(255), @password VARCHAR(255), @codigo_rol TINYINT, @habilitado BIT, @fecha_creacion DATETIME) 
AS BEGIN
  /* Intenta crear un usuario con los datos especificados
     Para eso debe crear una entrada en la tabla Usuario y una en la table RolXus
     Si alguna de las dos inserciones falla, todo se vuelve para atras
     Devuelve el codigo del nuevo usuario o -1 en caso de error */
  BEGIN TRY
	BEGIN TRANSACTION
			
		INSERT INTO CLINICA.Usuario (username, pass_word, habilitado, intentos, fecha_creacion)
		VALUES (@username, HASHBYTES('SHA2_256', @password), @habilitado, 0, @fecha_creacion)

		DECLARE @nuevo_codigo_usuario INT = (SELECT cod_us FROM CLINICA.Usuario WHERE username = @username)

		INSERT INTO CLINICA.RolXus (cod_rol, cod_us)
		VALUES (@codigo_rol, @nuevo_codigo_usuario)

	COMMIT TRANSACTION
    RETURN @nuevo_codigo_usuario
  END TRY
  
  BEGIN CATCH
    ROLLBACK TRANSACTION
    -- No hago nada si hubo un error (el username está duplicado)
    RETURN -1
  END CATCH

END
GO

CREATE PROCEDURE CLINICA.crear_contacto (@telefono NVARCHAR(255),
                                         @mail NVARCHAR(50),
                                         @direccion_calle NVARCHAR(100),
                                         @direccion_numero NUMERIC(18, 0),
                                         @direccion_piso NUMERIC(18, 0),
                                         @numero_departamento NVARCHAR(50),
                                         @localidad NVARCHAR(255),
                                         @codigo_postal NVARCHAR(50)) AS BEGIN

  /* Crea un nuevo contacto y devuelve su codigo */
   
	INSERT INTO CLINICA.Contacto (mail, nro_tel, dom_calle, nro_calle, nro_piso, nro_dpto, localidad, cod_postal)
	VALUES (@mail, @telefono, @direccion_calle, @direccion_numero, @direccion_piso, @numero_departamento, @localidad, @codigo_postal)
	RETURN SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE CLINICA.crear_cliente (@username NVARCHAR(255),
                                        @password VARCHAR(255),
										@fecha_creacion DATETIME,
                                        @codigo_rol TINYINT,
                                        @nombre NVARCHAR(255),
                                        @apellido NVARCHAR(255),
                                        @dni NUMERIC(18, 0),
                                        @telefono NVARCHAR(255),
                                        @mail NVARCHAR(50),
                                        @fecha_nacimiento DATETIME,
                                        @direccion_calle NVARCHAR(100),
                                        @direccion_numero NUMERIC(18, 0),
                                        @direccion_piso NUMERIC(18, 0),
                                        @numero_departamento NVARCHAR(50),
                                        @localidad NVARCHAR(255),
                                        @codigo_postal NVARCHAR(50),
                                        @habilitado BIT,
										@tipo_doc INTEGER) AS BEGIN

  /* Crea un nuevo usuario, un nuevo cliente y un nuevo contacto y los llena con los datos recibidos
     Devuelve el código del nuevo usuario creado o -1 en caso de error
   */
  BEGIN TRY
    BEGIN TRANSACTION
    DECLARE @codigo_usuario INT
    EXEC @codigo_usuario = CLINICA.crear_usuario @username, @password, @codigo_rol, @habilitado, @fecha_creacion

    IF @codigo_usuario = -1
      RAISERROR('El usuario ya existe', 16, 1)  -- Que salte directamente al CATCH

    DECLARE @codigo_contacto INT
    EXEC @codigo_contacto = CLINICA.crear_contacto @telefono, @mail, @direccion_calle, @direccion_numero, @direccion_piso,
                                                             @numero_departamento, @localidad, @codigo_postal

    INSERT INTO CLINICA.Cliente (cod_us, cod_contacto, cli_nombre, cli_apellido, cli_num_doc, cli_fecha_Nac, cli_tipo_doc)
    VALUES (@codigo_usuario, @codigo_contacto, @nombre, @apellido, @dni, @fecha_nacimiento, @tipo_doc)

    COMMIT TRANSACTION
	SELECT @codigo_usuario
  END TRY
  BEGIN CATCH
    ROLLBACK TRANSACTION
	SELECT -1
  END CATCH
END
GO

CREATE PROCEDURE CLINICA.crear_empresa (@username NVARCHAR(255),
                                        @password VARCHAR(255),
                                        @fecha_creacion DATETIME,
										@codigo_rol TINYINT,
                                        @razon_social NVARCHAR(255),
                                        @cuit NVARCHAR(50),
                                        @ciudad NVARCHAR(255),
                                        @telefono NVARCHAR(255),
                                        @mail NVARCHAR(50),
                                        @direccion_calle NVARCHAR(100),
                                        @direccion_numero NUMERIC(18, 0),
                                        @direccion_piso NUMERIC(18, 0),
                                        @numero_departamento NVARCHAR(50),
                                        @localidad NVARCHAR(255),
                                        @codigo_postal NVARCHAR(50),
                                        @habilitado BIT,
								@rubro INTEGER, @nom_contacto NVARCHAR(225)) AS BEGIN

  /* Crea un nuevo usuario, una nueva empresa y un nuevo contacto y los llena con los datos recibidos */
  BEGIN TRY
    BEGIN TRANSACTION
      DECLARE @codigo_usuario INT
      EXEC @codigo_usuario = CLINICA.crear_usuario @username, @password, @codigo_rol, @habilitado, @fecha_creacion

      IF @codigo_usuario = -1
        RAISERROR('El usuario ya existe', 16, 1)  -- Que salte directamente al CATCH

      DECLARE @codigo_contacto INT
      EXEC @codigo_contacto = CLINICA.crear_contacto @telefono, @mail, @direccion_calle, @direccion_numero, @direccion_piso,
                                                     @numero_departamento, @localidad, @codigo_postal

      INSERT INTO CLINICA.Empresa (cod_us, cod_contacto, emp_razon_soc, emp_cuit, emp_ciudad, emp_rubro, emp_nom_contacto)
      VALUES (@codigo_usuario, @codigo_contacto, @razon_social, @cuit, @ciudad, @rubro, @nom_contacto)

      COMMIT TRANSACTION
	  SELECT @codigo_contacto
  END TRY
  BEGIN CATCH
    ROLLBACK TRANSACTION
	SELECT -1
  END CATCH
END
GO

CREATE PROCEDURE CLINICA.modificar_cliente (@codigo INT,
                                            @nombre NVARCHAR(255),
                                            @apellido NVARCHAR(255),
                                            @num_doc NUMERIC(18, 0),
											@tipo_doc INTEGER,
                                            @telefono NVARCHAR(255),
                                            @mail NVARCHAR(50),
                                            @fecha_nacimiento DATETIME,
                                            @direccion_calle NVARCHAR(100),
                                            @direccion_numero NUMERIC(18, 0),
                                            @direccion_piso NUMERIC(18, 0),
                                            @numero_departamento NVARCHAR(50),
                                            @ciudad NVARCHAR(255),
                                            @codigo_postal NVARCHAR(50),
                                            @habilitado BIT) AS BEGIN
  BEGIN TRY
    BEGIN TRANSACTION

    UPDATE CLINICA.Cliente
    SET cli_fecha_Nac = @fecha_nacimiento,
    cli_apellido = @apellido,
    cli_nombre = @nombre,
    cli_num_doc = @num_doc,
	cli_tipo_doc = @tipo_doc
    WHERE cod_us = @codigo

    UPDATE CLINICA.Usuario
       SET habilitado = @habilitado
     WHERE cod_us = @codigo

    UPDATE CLINICA.Contacto
       SET cod_postal = @codigo_postal,
              dom_calle = @direccion_calle,
            nro_calle = @direccion_numero,
              localidad = @ciudad,
             nro_piso = @direccion_piso,
             nro_dpto = @numero_departamento,
              nro_tel = @telefono,
                 mail = @mail
     WHERE cod_contacto = (SELECT cod_contacto
                             FROM CLINICA.Cliente
                            WHERE cod_us = @codigo)
    COMMIT TRANSACTION
    SELECT @codigo
  END TRY
  BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT -1
  END CATCH
END
GO

CREATE PROCEDURE CLINICA.modificar_empresa (@codigo INT,
                                            @razon_social NVARCHAR(255),
                                            @cuit NVARCHAR(50),
                                            @ciudad NVARCHAR(255),
                                            @telefono NVARCHAR(255),
                                            @mail NVARCHAR(50),
                                            @direccion_calle NVARCHAR(100),
                                            @direccion_numero NUMERIC(18, 0),
                                            @direccion_piso NUMERIC(18, 0),
                                            @numero_departamento NVARCHAR(50),
                                            @localidad NVARCHAR(255),
                                            @codigo_postal NVARCHAR(50),
                                            @habilitado BIT,
								    @rubro INTEGER, @nom_contacto NVARCHAR(225)) AS BEGIN
  BEGIN TRY
    BEGIN TRANSACTION
    UPDATE CLINICA.Empresa
       SET emp_razon_soc = @razon_social,
                emp_cuit = @cuit,
              emp_ciudad = @ciudad,
		    emp_rubro = @rubro,
		    emp_nom_contacto = @nom_contacto
     WHERE cod_us = @codigo

    UPDATE CLINICA.Usuario
       SET habilitado = @habilitado
     WHERE cod_us = @codigo

    UPDATE CLINICA.Contacto
       SET cod_postal = @codigo_postal,
            localidad = @localidad,
            dom_calle = @direccion_calle,
            nro_calle = @direccion_numero,
             nro_dpto = @numero_departamento,
             nro_piso = @direccion_piso,
              nro_tel = @telefono,
                 mail = @mail
     WHERE cod_contacto = (SELECT cod_contacto
                             FROM CLINICA.Empresa
                            WHERE emp_cuit = @cuit)

    COMMIT TRANSACTION
    SELECT @codigo
  END TRY
  BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT -1
  END CATCH
END
GO

CREATE FUNCTION CLINICA.existe_usuario (@username NVARCHAR(255)) RETURNS BIT AS BEGIN
  IF EXISTS(SELECT 1
             FROM CLINICA.Usuario
            WHERE username = @username)
    RETURN 1
  RETURN 0
END
GO

CREATE PROCEDURE CLINICA.borrar_rolXus(@cod_rol int) AS BEGIN
delete CLINICA.RolXus where cod_rol = @cod_rol 
END
GO

CREATE PROCEDURE CLINICA.modificar_rol (@cod_rol TINYINT, @nombre NVARCHAR(255), @habilitado BIT) AS BEGIN
  UPDATE CLINICA.Rol
     SET nombre = @nombre,
         habilitado = @habilitado
   WHERE cod_rol = @cod_rol
   IF @habilitado = 0 
     exec CLINICA.borrar_rolXus @cod_rol
END
GO

CREATE PROCEDURE CLINICA.crear_rol (@nombre NVARCHAR(255), @habilitado BIT) AS BEGIN
  INSERT INTO CLINICA.Rol (nombre, habilitado)
  VALUES (@nombre, @habilitado)

  SELECT SCOPE_IDENTITY() AS nuevo_pk
    FROM CLINICA.Rol
END
GO

CREATE PROCEDURE CLINICA.funcionalidades_del_rol (@cod_rol TINYINT) AS BEGIN
  /* Lista las funcionalidades que tiene asignado un rol */
  SELECT F.cod_fun, F.descripcion
    FROM CLINICA.Funcionalidad F, CLINICA.RolXfunc Rf, CLINICA.Rol R
   WHERE Rf.cod_rol = @cod_rol
     AND F.cod_fun = Rf.cod_fun
     AND R.cod_rol = @cod_rol
END
GO

CREATE PROCEDURE CLINICA.agregar_funcionalidad (@cod_rol TINYINT, @cod_fun TINYINT) AS BEGIN
  /* Agrega la funcionalidad descrita por el codigo al rol,
     si es que no lo tenia asignado previamente */
  IF(NOT EXISTS(SELECT 1 FROM CLINICA.RolXfunc WHERE cod_rol = @cod_rol AND cod_fun = @cod_fun)) BEGIN
    INSERT INTO CLINICA.RolXfunc (cod_rol, cod_fun)
    VALUES (@cod_rol, @cod_fun)
  END
END
GO

CREATE PROCEDURE CLINICA.quitar_funcionalidad (@cod_rol TINYINT, @cod_fun TINYINT) AS BEGIN
  DELETE FROM CLINICA.RolXfunc
   WHERE cod_rol = @cod_rol
     AND cod_fun = @cod_fun
END
GO

CREATE PROCEDURE CLINICA.obtener_rubros AS BEGIN
  SELECT *
    FROM CLINICA.Rubro
END
GO

CREATE PROCEDURE CLINICA.obtener_visibilidades AS BEGIN
  SELECT *
    FROM CLINICA.Visibilidad
END
GO

CREATE PROCEDURE CLINICA.listar_publicaciones(@pagina INT, @cantidad_resultados_por_pagina INT,
                                              @descripcion NVARCHAR(255), @rubros NVARCHAR(255), @username NVARCHAR(255)) AS BEGIN
  DECLARE @count INT

  SELECT @count=COUNT(P.cod_pub)
    FROM CLINICA.Publicacion P
   WHERE P.estado = 1
     AND ((@descripcion LIKE '') OR ( P.descripcion LIKE '%' + @descripcion + '%'))
     AND ((@rubros LIKE '') OR ( P.cod_rubro IN (SELECT *
                                                   FROM CLINICA.split(@rubros))))
     AND @username <> (SELECT username
                         FROM CLINICA.Usuario U
                        WHERE U.cod_us = P.cod_us)

  SELECT @count, P.*
    FROM CLINICA.Publicacion P
   WHERE P.estado = 1
     AND ((@descripcion LIKE '') OR ( P.descripcion LIKE '%' + @descripcion + '%'))
     AND ((@rubros LIKE '') OR ( P.cod_rubro IN (SELECT *
                                                   FROM CLINICA.split(@rubros))))
     AND @username <> (SELECT username
                         FROM CLINICA.Usuario U
                        WHERE U.cod_us = P.cod_us)
   ORDER BY CLINICA.calcular_peso_visibilidad(cod_visi) DESC
  OFFSET @pagina * @cantidad_resultados_por_pagina ROWS
   FETCH NEXT @cantidad_resultados_por_pagina ROWS ONLY
END
GO

CREATE FUNCTION CLINICA.calcular_peso_visibilidad(@cod_visi INT) RETURNS INT AS BEGIN
  RETURN (SELECT comision_pub + 2 * comision_vta + comision_envio
            FROM CLINICA.Visibilidad
           WHERE cod_visi = @cod_visi)
END
GO

CREATE FUNCTION CLINICA.split (@commaSeparatedList NVARCHAR(MAX)) RETURNS @t TABLE (val NVARCHAR(MAX)) AS BEGIN
  /* Hack horrible para que dado un string de enteros separados por coma me los devuelva listados */
  DECLARE @xml xml
  SET @xml = N'<root><r>' + REPLACE(@commaSeparatedList, ',', '</r><r>') + '</r></root>'

  INSERT INTO @t(val)
  SELECT r.value('.', 'VARCHAR(MAX)') AS item
    FROM @xml.nodes('//root/r') AS RECORDS(r)

  RETURN
END
GO

CREATE PROCEDURE CLINICA.obtener_factura (@numero NUMERIC) AS BEGIN
  SELECT *
    FROM CLINICA.Factura
   WHERE nro_fact = @numero
END
GO

CREATE PROCEDURE CLINICA.obtener_detalles_factura (@numero NUMERIC) AS BEGIN
  SELECT *
    FROM CLINICA.Detalle
   WHERE nro_fact = @numero
END
GO

CREATE PROCEDURE CLINICA.calificaciones_por_estrellas (@usuario NVARCHAR(255)) AS BEGIN
  /* Devuelve una fila por cada calificacion (1-5) y tipo (1-Compra inmediata, 2-subasta)
     con la cantidad de calificaciones hechas por el usuario a ese tipo de publicacion con esa
     cantidad de estrellas */
    SELECT COUNT(*) AS Cantidad, Ca.calif_estrellas AS Calificacion,  P.cod_tipo AS Tipo
      FROM CLINICA.Compra Co, CLINICA.Calificacion Ca, CLINICA.Publicacion P
     WHERE Co.cod_us = (SELECT cod_us
                          FROM CLINICA.Usuario
                         WHERE username = @usuario)
       AND Ca.cod_calif = Co.cod_calif
       AND P.cod_pub = Co.cod_pub
  GROUP BY Ca.calif_estrellas, P.cod_tipo
END
GO

CREATE PROCEDURE CLINICA.operaciones_sin_calificar (@usuario NVARCHAR(255)) AS BEGIN
  SELECT *  -- TODO: Ver que campos mostramos
    FROM CLINICA.Compra Co, CLINICA.Publicacion P
   WHERE Co.cod_us = (SELECT cod_us
                        FROM CLINICA.Usuario
                       WHERE username = @usuario)
     AND P.cod_pub = Co.cod_pub
     AND NOT EXISTS (SELECT cod_calif
                       FROM CLINICA.Calificacion Ca
                      WHERE Ca.cod_calif = Co.cod_calif)
END
GO

CREATE PROCEDURE CLINICA.ultimas_operaciones_calificadas (@usuario NVARCHAR(255)) AS BEGIN
  SELECT TOP 10 *  --TODO: Ver que campos mostramos
    FROM CLINICA.Compra Co, CLINICA.Calificacion Ca, CLINICA.Publicacion P
   WHERE Co.cod_us = (SELECT cod_us
                        FROM CLINICA.Usuario
                       WHERE username = @usuario)
     AND Ca.cod_calif = Co.cod_calif
     AND P.cod_pub = Co.cod_pub
  ORDER BY Ca.cod_calif  DESC
END
GO

CREATE PROCEDURE CLINICA.obtener_tipos_doc AS BEGIN
SELECT * FROM CLINICA.Tipo_doc
END
GO

CREATE FUNCTION CLINICA.username_to_code(@username NVARCHAR(255)) RETURNS INT AS BEGIN
  /* Como es un patron usado en muchos procedures, esta es una funcion que devuelve
     el codigo de un usuario cuyo username es @username */
  DECLARE @ret INT
  SELECT @ret=cod_us
   FROM CLINICA.Usuario
  WHERE username = @username

  RETURN @ret
END
GO

CREATE PROCEDURE CLINICA.cantidad_publicaciones_calificadas(@username NVARCHAR(255)) AS BEGIN
  DECLARE @code INT = CLINICA.username_to_code(@username)

  SELECT COUNT(cod_compra)
    FROM CLINICA.Compra
   WHERE cod_us = @code
     AND cod_calif IS NOT NULL
END
GO

CREATE PROCEDURE CLINICA.cantidad_publicaciones_sin_calificar(@username NVARCHAR(255)) AS BEGIN
  DECLARE @code INT = CLINICA.username_to_code(@username)

  SELECT COUNT(cod_compra)
    FROM CLINICA.Compra
   WHERE cod_us = @code
     AND cod_calif IS NULL
END
GO

CREATE PROCEDURE CLINICA.promedio_estrellas_dadas(@username NVARCHAR(255)) AS BEGIN
   DECLARE @code INT = CLINICA.username_to_code(@username)

   SELECT ROUND(AVG(calif_estrellas), 2)
     FROM CLINICA.Compra Co, CLINICA.Calificacion Ca
    WHERE Co.cod_us = @code
      AND Co.cod_calif IS NOT NULL
      AND Co.cod_calif = Ca.cod_calif
END
GO

CREATE PROCEDURE CLINICA.publicaciones_por_usuario(@username NVARCHAR(255), @pagina INT, @cantidad_resultados_por_pagina INT) AS BEGIN
   DECLARE @code INT = CLINICA.username_to_code(@username)
   DECLARE @count INT

      SELECT @count=COUNT(cod_pub)
        FROM CLINICA.Publicacion
       WHERE cod_us = @code

      SELECT @count, *
        FROM CLINICA.Publicacion
       WHERE cod_us = @code
    ORDER BY fecha_ini
      OFFSET @pagina * @cantidad_resultados_por_pagina ROWS
  FETCH NEXT @cantidad_resultados_por_pagina ROWS ONLY
END
GO

CREATE PROCEDURE CLINICA.publicaciones_vigentes_por_usuario(@username NVARCHAR(255), @pagina INT, @cantidad_resultados_por_pagina INT) AS BEGIN
   DECLARE @code INT = CLINICA.username_to_code(@username)
   DECLARE @count INT

      SELECT @count=COUNT(cod_pub)
        FROM CLINICA.Publicacion
       WHERE cod_us = @code

      SELECT @count, *
        FROM CLINICA.Publicacion
       WHERE cod_us = @code
         AND estado <> 4
    ORDER BY fecha_ini
      OFFSET @pagina * @cantidad_resultados_por_pagina ROWS
  FETCH NEXT @cantidad_resultados_por_pagina ROWS ONLY
END
GO

CREATE PROCEDURE CLINICA.modificar_borrador(@descripcion NVARCHAR(225), @stock NUMERIC(18, 0), @precio NUMERIC(18, 2),
                                            @rubro NVARCHAR(225), @visi NVARCHAR(225), @tipo NVARCHAR(225),
                                            @fecha_venc DATETIME, @envio BIT, @cod_pub INT) AS BEGIN

  UPDATE CLINICA.Publicacion
     SET descripcion = @descripcion,
         stock = @stock,
         precio = @precio,
         cod_visi = (SELECT V.cod_visi
                       FROM CLINICA.Visibilidad V
                      WHERE V.visi_desc = @visi),
         cod_tipo = (SELECT T.cod_tipo
                       FROM CLINICA.Tipo T
                      WHERE T.descripcion = @tipo),
         cod_rubro = (SELECT R.cod_rubro
                        FROM CLINICA.Rubro R
                       WHERE R.rubro_desc_corta = @rubro),
         fecha_fin = @fecha_venc,
         envio = @envio
   WHERE cod_pub = @cod_pub
END
GO

CREATE PROCEDURE CLINICA.listar_usuarios(@pagina INT, @cantidad_resultados_por_pagina INT) AS BEGIN
    DECLARE @tabla_resultados TABLE(cantidad_resultados INT, cod_us INT, username NVARCHAR(225))
    INSERT INTO @tabla_resultados
    SELECT NULL, cod_us, username FROM CLINICA.Usuario
    DECLARE @cantidad_resultados INT = (SELECT COUNT(*) FROM @tabla_resultados)
    UPDATE @tabla_resultados SET cantidad_resultados = @cantidad_resultados

    SELECT * FROM @tabla_resultados
    ORDER BY cod_us
    OFFSET @pagina * @cantidad_resultados_por_pagina ROWS
    FETCH NEXT @cantidad_resultados_por_pagina ROWS ONLY
END
GO

CREATE PROCEDURE CLINICA.cambiar_password_usuario(@username NVARCHAR(225), @nueva_password VARCHAR(225)) AS BEGIN
UPDATE CLINICA.Usuario SET pass_word = HASHBYTES('SHA2_256', @nueva_password) WHERE username = @username
END
GO


Contact GitHub API Training Shop Blog About
© 2016 GitHub, Inc. Terms Privacy Security Status Help
  
  
  
  