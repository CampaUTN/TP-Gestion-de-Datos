USE GD2C2016;
GO
/* Eliminación de los objetos preexistentes */

IF OBJECT_ID('CLINICA.RolXfuncionalidad','U') IS NOT NULL
    DROP TABLE CLINICA.RolXfuncionalidad;

IF OBJECT_ID('CLINICA.Funcionalidades','U') IS NOT NULL
    DROP TABLE CLINICA.Funcionalidades;

IF OBJECT_ID('CLINICA.RolXUsuario','U') IS NOT NULL
    DROP TABLE CLINICA.RolXUsuario;

IF OBJECT_ID('CLINICA.Roles','U') IS NOT NULL
    DROP TABLE CLINICA.Roles;

IF OBJECT_ID('CLINICA.Administradores','U') IS NOT NULL
    DROP TABLE CLINICA.Administradores;
   
IF OBJECT_ID('CLINICA.EspecialidadXProfesional','U') IS NOT NULL
    DROP TABLE CLINICA.EspecialidadXProfesional;

IF OBJECT_ID('CLINICA.CancelacionesTurnos','U') IS NOT NULL
    DROP TABLE CLINICA.CancelacionesTurnos;
    
IF OBJECT_ID('CLINICA.Bonos','U') IS NOT NULL
    DROP TABLE CLINICA.Bonos;
    
IF OBJECT_ID('CLINICA.ComprasBonos','U') IS NOT NULL
    DROP TABLE CLINICA.ComprasBonos;
    
IF OBJECT_ID('CLINICA.Consultas','U') IS NOT NULL
    DROP TABLE CLINICA.Consultas;

IF OBJECT_ID('CLINICA.Turnos','U') IS NOT NULL
    DROP TABLE CLINICA.Turnos;

IF OBJECT_ID('CLINICA.Afiliados','U') IS NOT NULL
    DROP TABLE CLINICA.Afiliados;
	
IF OBJECT_ID('CLINICA.TipoCancelacion','U') IS NOT NULL
    DROP TABLE CLINICA.TipoCancelacion;
	
IF OBJECT_ID('CLINICA.Planes','U') IS NOT NULL
    DROP TABLE CLINICA.Planes;

IF OBJECT_ID('CLINICA.Horarios','U') IS NOT NULL
    DROP TABLE CLINICA.Horarios;

IF OBJECT_ID('CLINICA.HistorialAfiliado','U') IS NOT NULL
    DROP TABLE CLINICA.HistorialAfiliado;

IF OBJECT_ID('CLINICA.Especialidades','U') IS NOT NULL
    DROP TABLE CLINICA.Especialidades;
	
IF OBJECT_ID('CLINICA.Profesionales','U') IS NOT NULL
    DROP TABLE CLINICA.Profesionales;

IF OBJECT_ID('CLINICA.TipoEspecialidad','U') IS NOT NULL
    DROP TABLE CLINICA.TipoEspecialidad;

IF OBJECT_ID('CLINICA.Usuarios','U') IS NOT NULL
    DROP TABLE CLINICA.Usuarios;








    
/* DROP FUNCTIONS! */

IF (OBJECT_ID ('CLINICA._algo_') IS NOT NULL)
  DROP FUNCTION CLINICA._algo_

/* DROP PROCEDURES! */
  
IF OBJECT_ID('CLINICA.Login_procedure ') IS NOT NULL
    DROP PROCEDURE CLINICA.Login_procedure 

/* DROP SCHEMA */

IF EXISTS (SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'CLINICA')
    DROP SCHEMA CLINICA
GO


/* Creación del esquema */

CREATE SCHEMA CLINICA AUTHORIZATION gd
GO

/* Creación de las tablas */

CREATE TABLE CLINICA.Usuarios(
    usua_id BIGINT PRIMARY KEY,
    usua_username VARCHAR(20),
  	usua_password VARBINARY(255), -- TODO: inventar users y pass
  	usua_intentos TINYINT DEFAULT 0,
    usua_nombre VARCHAR(255),
    usua_apellido VARCHAR(255),
  	usua_tipoDoc VARCHAR(20),
    usua_nroDoc DECIMAL(8,0),
  	usua_direccion VARCHAR(255),
  	usua_telefono DECIMAL(18,0),
  	usua_fechaNacimiento DATETIME,
  	usua_sexo VARCHAR(15),
  	usua_mail VARCHAR(255));

CREATE TABLE CLINICA.Roles(
    role_id INT IDENTITY NOT NULL,
    role_nombre VARCHAR(225),
  	role_habilitato TINYINT,
    PRIMARY KEY (role_id));


CREATE TABLE CLINICA.RolXusuario(
    usua_id BIGINT NOT NULL FOREIGN KEY REFERENCES CLINICA.Usuarios(usua_id),
    role_id INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Roles(role_id),
    PRIMARY KEY (usua_id, role_id));
    

CREATE TABLE CLINICA.Funcionalidades(
	func_id INT NOT NULL IDENTITY PRIMARY KEY,
  	func_nombre VARCHAR(225) NOT NULL );
  
CREATE TABLE CLINICA.RolXfuncionalidad(
    role_id INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Roles(role_id),
    func_id INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Funcionalidades(func_id),
    PRIMARY KEY (role_id, func_id));

CREATE TABLE CLINICA.Administradores(
	admi_id INT NOT NULL IDENTITY PRIMARY KEY,
  	admi_usuario BIGINT NOT NULL FOREIGN KEY REFERENCES CLINICA.Usuarios(usua_id));
  
CREATE TABLE CLINICA.Profesionales(
	prof_id INT NOT NULL PRIMARY KEY, -- viene a ser el DNI 
  	prof_usuario BIGINT NOT NULL FOREIGN KEY REFERENCES CLINICA.Usuarios(usua_id),
  	prof_matricula VARCHAR(12));
  
CREATE TABLE CLINICA.TipoEspecialidad(
    tipo_id INT PRIMARY KEY,
    tipo_nombre VARCHAR(225));

CREATE TABLE CLINICA.Especialidades(
    espe_id INT PRIMARY KEY,
  	espe_nombre VARCHAR(256) NOT NULL,
    espe_tipo INT NOT NULL FOREIGN KEY REFERENCES CLINICA.TipoEspecialidad(tipo_id));

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
	plan_id INT PRIMARY KEY NOT NULL,
  	plan_nombre VARCHAR(225) NOT NULL,
  	plan_precioBono DECIMAL(12,2) NOT NULL);   

CREATE TABLE CLINICA.Afiliados(
    afil_id INT IDENTITY PRIMARY KEY,
    afil_usuario BIGINT FOREIGN KEY REFERENCES CLINICA.Usuarios(usua_id),
    afil_plan INT FOREIGN KEY REFERENCES CLINICA.Planes(plan_id),
  	afil_estadoCivil VARCHAR(20),
  	afil_cantidadHijos INT DEFAULT 0);

CREATE TABLE CLINICA.Turnos(
	turn_id INT NOT NULL PRIMARY KEY,
  	turn_afiliado INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Afiliados(afil_id), 
    turn_hora INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Horarios(hora_id), 
    turn_activo TINYINT NOT NULL);
  
CREATE TABLE CLINICA.TipoCancelacion(
	tipo_id INT PRIMARY KEY IDENTITY,
  	tipo_detalle VARCHAR(256));

CREATE TABLE CLINICA.CancelacionesTurnos(
	canc_id INT PRIMARY KEY IDENTITY,
  	canc_turno INT FOREIGN KEY REFERENCES CLINICA.Turnos(turn_id),
	canc_tipo INT FOREIGN KEY REFERENCES CLINICA.TipoCancelacion(tipo_id),
  	canc_detalle VARCHAR(225));  
  
CREATE TABLE CLINICA.HistorialAfiliado(
	hist_id INT NOT NULL IDENTITY PRIMARY KEY,
  	hist_profesional INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Profesionales(prof_id), 
    hist_especialidad INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Especialidades(espe_id));

CREATE TABLE CLINICA.Consultas(
	cons_id INT PRIMARY KEY NOT NULL,
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
	comp_precioFinal DECIMAL(12,2) NOT NULL);


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
INSERT INTO CLINICA.Usuarios(usua_id,usua_username, usua_password, usua_intentos)
VALUES (0,'admin', @hash, 3);

-- Usuarios desde Afiliados. Funciona
  /* TODO: ver q username/pass tienen los usuarios q se migran de la base vieja */
INSERT INTO CLINICA.Usuarios(usua_id,usua_nroDoc,usua_intentos,usua_nombre,usua_apellido,usua_tipoDoc,usua_direccion,usua_telefono,usua_fechaNacimiento,usua_sexo,usua_mail)
  SELECT DISTINCT Paciente_Dni*100+1, Paciente_Dni, 0,Paciente_Nombre, Paciente_Apellido, 'DNI', Paciente_Direccion, Paciente_Telefono, null, null, Paciente_Mail
  FROM gd_esquema.Maestra
  WHERE Paciente_Dni IS NOT NULL

-- Usuarios desde Profesionales. Funciona
INSERT INTO CLINICA.Usuarios(usua_id,usua_nroDoc,usua_intentos,usua_nombre,usua_apellido,usua_tipoDoc,usua_direccion,usua_telefono,usua_fechaNacimiento,usua_sexo,usua_mail)
	SELECT DISTINCT Medico_Dni*100+1, Medico_Dni,0, Medico_Nombre, Medico_Apellido, 'DNI',Medico_Direccion, Medico_Telefono, Medico_Fecha_Nac, NULL, Medico_Mail
	FROM gd_esquema.Maestra
	WHERE Medico_Dni IS NOT NULL

	--Planes. Funciona
	--Lo pongo arriba de antes porque sino tira error con las FK al no tener los planes cargados
INSERT INTO CLINICA.Planes(plan_id, plan_nombre, plan_precioBono)
	SELECT DISTINCT Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta
	FROM gd_esquema.Maestra
	WHERE Plan_Med_Codigo IS NOT NULL

--Afiliados. TODO: Ver tema del ID
INSERT INTO CLINICA.Afiliados(afil_usuario, afil_plan, afil_cantidadHijos,afil_estadoCivil)  -- TODO: hacer bien
	SELECT DISTINCT ((SELECT usua_id FROM CLINICA.Usuarios WHERE usua_nroDoc=Paciente_Dni)),
					Plan_Med_Codigo, 0, NULL
	FROM gd_esquema.Maestra
	WHERE Paciente_Dni IS NOT NULL

-- Profesionales. Funciona
INSERT INTO CLINICA.Profesionales(prof_id,prof_matricula,prof_usuario)
	SELECT DISTINCT Medico_Dni, NULL, (SELECT usua_id FROM CLINICA.Usuarios WHERE usua_nroDoc=Medico_Dni)
	FROM gd_esquema.Maestra
	WHERE Medico_Dni IS NOT NULL
    
  --Tipo Especialidad. Funciona
INSERT INTO CLINICA.TipoEspecialidad(tipo_id, tipo_nombre)
	SELECT DISTINCT Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion 
	FROM gd_esquema.Maestra 
	WHERE Tipo_Especialidad_Codigo IS NOT NULL 
	ORDER BY Tipo_Especialidad_Codigo
    
  -- Especialidad. Funciona
INSERT INTO CLINICA.Especialidades(espe_id, espe_tipo, espe_nombre)
  SELECT DISTINCT Especialidad_Codigo, Tipo_Especialidad_Codigo, Especialidad_Descripcion
  FROM gd_esquema.Maestra
  WHERE Especialidad_Codigo IS NOT NULL
  ORDER BY Especialidad_Codigo  

-- Horarios. Funciona
INSERT INTO CLINICA.Horarios(hora_especialidad, hora_fecha, hora_inicio, hora_profesional)
  SELECT Especialidad_Codigo, CONVERT(DATE,Turno_Fecha), CONVERT(TIME,Turno_fecha), Medico_Dni
  FROM gd_esquema.Maestra m
  WHERE Medico_Dni IS NOT NULL
  GROUP BY Turno_Numero, Turno_Fecha, Especialidad_Codigo, Medico_Dni
  
    -- Turnos. Funciona
INSERT INTO CLINICA.Turnos(turn_id, turn_afiliado, turn_hora, turn_activo)
	SELECT DISTINCT m.Turno_Numero, (SELECT top 1 afil_id
                                   FROM CLINICA.Afiliados
                                   			join CLINICA.Usuarios on (afil_usuario = usua_id)
                                   WHERE usua_nroDoc = m.Paciente_Dni AND usua_nroDoc IS NOT NULL), (SELECT hora_id FROM CLINICA.Horarios WHERE hora_fecha=CONVERT(DATE,Turno_Fecha) AND hora_inicio=CONVERT(TIME,Turno_Fecha) AND Medico_Dni=hora_profesional), 1 -- asumimos que todos los turnos de la base estan activos (no cancelados).
	FROM gd_esquema.Maestra m
	WHERE m.Turno_Numero IS NOT NULL 
  ORDER BY m.Turno_Numero
  
  	-- Consultas. Funciona. Suponemos que todas se concretaron y el tipo nunca dio el presente y se fue antes de que lo atiendan (caso de concretada=0).
INSERT INTO CLINICA.Consultas(cons_id, cons_turno, cons_fechaHoraConsulta, cons_fueConcretada, cons_sintomas, cons_diagnostico)
	SELECT DISTINCT m.Turno_Numero, m.Bono_Consulta_Numero, m.Bono_Consulta_Fecha_Impresion, 1, m.Consulta_Sintomas, m.Consulta_Enfermedades
	FROM gd_esquema.Maestra m
	WHERE m.Turno_Numero IS NOT NULL AND m.Bono_Consulta_Fecha_Impresion IS NOT NULL AND m.Bono_Consulta_Numero IS NOT NULL
  ORDER BY m.Turno_Numero











/* CREO STORE PROCEDURES */
USE GD2C2016;
GO

--PROCEDURE QUE CHEQUEA LOS INTENTOS
CREATE PROCEDURE CLINICA.Login_procedure(@username VARCHAR(20) , @password NVARCHAR(10))
AS
 BEGIN
	DECLARE @intentos TINYINT, @hash VARBINARY(225), @pass VARBINARY(225), @cantidad INT
	
	SET @intentos = (SELECT usua_intentos FROM CLINICA.Usuarios WHERE usua_username = @username)
    SET @hash = HASHBYTES('SHA2_256',@password);
	SET @pass = (SELECT usua_password FROM CLINICA.Usuarios WHERE usua_username = @username)


	IF(@intentos IS NULL) 	--me fijo si esta el usuario
		SET @cantidad = -1

	ELSE IF(@pass <> @hash)  --comparo las contrasenias
			BEGIN
				SET @cantidad = @intentos
				IF(@intentos<> 0)  --verifico la cantidad de ceros. si aun le quedan, hago el update
					UPDATE CLINICA.Usuarios SET usua_intentos = @intentos - 1 WHERE usua_username=@username
			END				
		  ELSE IF(@pass = @hash)
			BEGIN
			SET @cantidad = 4   --Todo bien! Contrasenia correcta!
			UPDATE CLINICA.Usuarios SET usua_intentos = 3 WHERE usua_username=@username
			END
	RETURN @cantidad
 END
GO