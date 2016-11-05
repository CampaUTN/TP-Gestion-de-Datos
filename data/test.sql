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

    


/* DROP FUNCTIONS! 
IF (OBJECT_ID ('CLINICA._algo_') IS NOT NULL)
  DROP FUNCTION CLINICA._algo_
  */


/* DROP PROCEDURES! */
  
IF OBJECT_ID('CLINICA.Login_procedure ') IS NOT NULL
    DROP PROCEDURE CLINICA.Login_procedure 

IF OBJECT_ID('CLINICA.getFuncionalidadXRol') IS NOT NULL
    DROP PROCEDURE CLINICA.getFuncionalidadXRol
	
IF OBJECT_ID('CLINICA.getRolesUsuario') IS NOT NULL
    DROP PROCEDURE CLINICA.getRolesUsuario 

IF OBJECT_ID('CLINICA.getPlanes') IS NOT NULL
    DROP PROCEDURE CLINICA.getPlanes

IF OBJECT_ID('CLINICA.ingresarUsuario') IS NOT NULL
    DROP PROCEDURE CLINICA.ingresarUsuario

IF OBJECT_ID('CLINICA.ingresarAfiliado') IS NOT NULL
    DROP PROCEDURE CLINICA.ingresarAfiliado

IF OBJECT_ID('CLINICA.agregarFamiliar') IS NOT NULL
 DROP PROCEDURE CLINICA.agregarFamiliar

IF OBJECT_ID('CLINICA.modificarAfiliado') IS NOT NULL
 DROP PROCEDURE CLINICA.modificarAfiliado

IF OBJECT_ID('CLINICA.darDeBaja') IS NOT NULL
 DROP PROCEDURE CLINICA.darDeBaja 

IF OBJECT_ID('CLINICA.eliminarAfiliado') IS NOT NULL
 DROP PROCEDURE CLINICA.eliminarAfiliado

IF OBJECT_ID('CLINICA.registrarConsulta') IS NOT NULL
    DROP PROCEDURE CLINICA.registrarConsulta

/* DROP TRIGGERS */
IF (OBJECT_ID ('CLINICA.verificarUsuario') IS NOT NULL)
  DROP FUNCTION CLINICA.verificarUsuario

 IF (OBJECT_ID ('CLINICA.LimiteHoras') IS NOT NULL)
  DROP FUNCTION CLINICA.verificarUsuario

IF (OBJECT_ID ('CLINICA.tieneFamilia') IS NOT NULL)
  DROP FUNCTION CLINICA.tieneFamilia

IF OBJECT_ID('CLINICA.triggerElimTurnos') IS NOT NULL
	DROP TRIGGER CLINICA.triggerElimTurnos

IF OBJECT_ID('CLINICA.triggerElimUsua') IS NOT NULL
	DROP TRIGGER CLINICA.triggerEliminarUser

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
  	usua_password VARBINARY(500), --  255 TODO: inventar users y pass
  	usua_intentos TINYINT DEFAULT 3,
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
  	role_habilitado TINYINT,
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
    afil_id INT IDENTITY(101,100) PRIMARY KEY,
    afil_usuario BIGINT FOREIGN KEY REFERENCES CLINICA.Usuarios(usua_id),
    afil_plan INT FOREIGN KEY REFERENCES CLINICA.Planes(plan_id),
  	afil_estadoCivil VARCHAR(20),
  	afil_cantidadHijos INT DEFAULT 0);

/*
CREATE TABLE CLINICA.Turnos(
	turn_id INT NOT NULL PRIMARY KEY,
  	turn_afiliado INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Afiliados(afil_id), 
    turn_hora INT NOT NULL FOREIGN KEY REFERENCES CLINICA.Horarios(hora_id), 
    turn_activo TINYINT NOT NULL);
 */
 CREATE TABLE CLINICA.Turnos(
	turn_id INT NOT NULL PRIMARY KEY IDENTITY,
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
	cons_id INT PRIMARY KEY IDENTITY NOT NULL,
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
	comp_precioFinal DECIMAL(12,2) NOT NULL,
	comp_fechaCompra DATETIME);


USE GD2C2016;
GO

/* Migración de datos desde la tabla maestra */

/* SELECT * INTO CLINICA.Inconsistencias FROM gd_esquema.Maestra WHERE 1 = 2 */

 /*
CREATE INDEX CLINICA ON CLINICA.Contacto (mail);
CREATE INDEX I_Cliente ON CLINICA.Cliente (cli_nombre, cli_apellido);
CREATE UNIQUE INDEX I_Empresa ON CLINICA.Empresa (emp_razon_soc, emp_cuit);
CREATE INDEX I_Publicacion ON CLINICA.Publicacion (cod_rubro, descripcion);
*/ /* TODO: PONER NUESTROS INDICES SEGUN Q USEMOS MAS */

USE GD2C2016;
GO
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
INSERT INTO CLINICA.Usuarios(usua_id,usua_nroDoc,usua_nombre,usua_apellido,usua_tipoDoc,usua_direccion,usua_telefono,usua_fechaNacimiento,usua_sexo,usua_mail)
  SELECT DISTINCT Paciente_Dni*100+1, Paciente_Dni,Paciente_Nombre, Paciente_Apellido, 'DNI', Paciente_Direccion, Paciente_Telefono, null, null, Paciente_Mail
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
	/* 
INSERT INTO CLINICA.Turnos(turn_id, turn_afiliado, turn_hora, turn_activo)
	SELECT DISTINCT m.Turno_Numero, (SELECT top 1 afil_id
                                   FROM CLINICA.Afiliados
                                   			join CLINICA.Usuarios on (afil_usuario = usua_id)
                                   WHERE usua_nroDoc = m.Paciente_Dni AND usua_nroDoc IS NOT NULL), (SELECT hora_id FROM CLINICA.Horarios WHERE hora_fecha=CONVERT(DATE,Turno_Fecha) AND hora_inicio=CONVERT(TIME,Turno_Fecha) AND Medico_Dni=hora_profesional), 1 -- asumimos que todos los turnos de la base estan activos (no cancelados).
	FROM gd_esquema.Maestra m
	WHERE m.Turno_Numero IS NOT NULL 
  ORDER BY m.Turno_Numero
  */
  -- PRUEBO ALGO

  SET IDENTITY_INSERT CLINICA.Turnos ON 
  INSERT INTO CLINICA.Turnos(turn_id, turn_afiliado, turn_hora, turn_activo)
	SELECT DISTINCT m.Turno_Numero, (SELECT top 1 afil_id
                                   FROM CLINICA.Afiliados
                                   			join CLINICA.Usuarios on (afil_usuario = usua_id)
                                   WHERE usua_nroDoc = m.Paciente_Dni AND usua_nroDoc IS NOT NULL), (SELECT hora_id FROM CLINICA.Horarios WHERE hora_fecha=CONVERT(DATE,Turno_Fecha) AND hora_inicio=CONVERT(TIME,Turno_Fecha) AND Medico_Dni=hora_profesional), 1 -- asumimos que todos los turnos de la base estan activos (no cancelados).
	FROM gd_esquema.Maestra m
	WHERE m.Turno_Numero IS NOT NULL 
  ORDER BY m.Turno_Numero
  SET IDENTITY_INSERT CLINICA.Turnos OFF 
  GO


  	-- Consultas. Funciona. Suponemos que todas se concretaron y el tipo nunca dio el presente y se fue antes de que lo atiendan (caso de concretada=0).
SET IDENTITY_INSERT CLINICA.Consultas ON
INSERT INTO CLINICA.Consultas(cons_id, cons_turno, cons_fechaHoraConsulta, cons_fueConcretada, cons_sintomas, 
cons_diagnostico)
SELECT DISTINCT m.Bono_Consulta_Numero ,m.Turno_Numero, m.Bono_Consulta_Fecha_Impresion, 1, m.Consulta_Sintomas, m.Consulta_Enfermedades
FROM gd_esquema.Maestra m
WHERE m.Turno_Numero IS NOT NULL AND m.Bono_Consulta_Fecha_Impresion IS NOT NULL AND m.Bono_Consulta_Numero IS NOT NULL
ORDER BY m.Turno_Numero
GO

INSERT INTO CLINICA.Bonos(bono_afilCompra, bono_plan, bono_nroConsulta, bono_afilUsado)
SELECT (SELECT afil_id FROM CLINICA.Usuarios JOIN CLINICA.Afiliados 
	ON usua_id = afil_usuario WHERE m.Paciente_Dni = usua_nroDoc), m.Plan_Med_Codigo, m.Bono_Consulta_Numero, (SELECT afil_id FROM CLINICA.Usuarios JOIN CLINICA.Afiliados 
	ON usua_id = afil_usuario WHERE m.Paciente_Dni = usua_nroDoc) -- Como los de la tabla maestra no tienen familia si o si lo usaron ellos mismo al bono
FROM gd_esquema.Maestra m
WHERE m.Compra_Bono_Fecha IS NOT NULL 

	-- Compra bonos. Funciona
INSERT INTO CLINICA.ComprasBonos(comp_afil,comp_cantidad,comp_precioFinal,comp_fechaCompra)
SELECT 
	(SELECT afil_id FROM CLINICA.Usuarios JOIN CLINICA.Afiliados 
	ON usua_id = afil_usuario WHERE m.Paciente_Dni = usua_nroDoc), 1, m.Plan_Med_Precio_Bono_Consulta , m.Compra_Bono_Fecha -- No sabemos el precio del bono en ese momento
FROM gd_esquema.Maestra m
WHERE m.Compra_Bono_Fecha IS NOT NULL

insert into CLINICA.TipoCancelacion values ('Cancelación Afiliado')
insert into CLINICA.TipoCancelacion values ('Cancelación Médico')

	-- Cancelaciones. Funciona -- Si un usuario no gasto el bono pero la fecha del turno paso => cancelo el turno
INSERT INTO CLINICA.CancelacionesTurnos(canc_turno, canc_detalle, canc_tipo)
SELECT m.Turno_Numero, 'Migración', 1
FROM gd_esquema.Maestra m
WHERE m.Bono_Consulta_Numero IS NULL AND m.Turno_Numero IS NOT NULL AND m.Turno_Fecha < GETDATE() -- TODO: Cambiar a la fecha del sistema

  -- Para que el admin tenga todos los roles y poder testear
insert into CLINICA.RolXusuario values (0,1)
insert into CLINICA.RolXusuario values (0,2)
insert into CLINICA.RolXusuario values (0,3)

insert into CLINICA.Afiliados values (0,555558,'Casado',3) --usuario, plan, estado civ, hijos
insert into CLINICA.Administradores values (0)  --usario
insert into CLINICA.Profesionales values (9999,0,null) --prof if, user, algo
update CLINICA.Usuarios set usua_nombre= 'NombreAdmin' where usua_id=0
update CLINICA.Usuarios set usua_apellido= 'ApellidoAdmin' where usua_id=0
---


insert into CLINICA.FUNCIONALIDADES values ('AbmAfiliado') --1
insert into CLINICA.FUNCIONALIDADES values ('AbmEspMedicas') --2
insert into CLINICA.FUNCIONALIDADES values ('AbmPlanes') --3
insert into CLINICA.FUNCIONALIDADES values ('AbmProfesional') --4
insert into CLINICA.FUNCIONALIDADES values ('AbmRol') --5
insert into CLINICA.FUNCIONALIDADES values ('CancelarAtencion') --6
insert into CLINICA.FUNCIONALIDADES values ('CompraBono') --7
insert into CLINICA.FUNCIONALIDADES values ('Listados') --8
insert into CLINICA.FUNCIONALIDADES values ('PedirTurno') --9
insert into CLINICA.FUNCIONALIDADES values ('RegistarAgenda') --10
insert into CLINICA.FUNCIONALIDADES values ('RegistroLlegada') --11
insert into CLINICA.FUNCIONALIDADES values ('RegistroResultado') --12

select * from CLINICA.RolXFuncionalidad

-- role 1: afil role2: admin role3: prof

insert into CLINICA.RolXfuncionalidad values (1,6) -- Afiliado - Cancelar Atencion
insert into CLINICA.RolXfuncionalidad values (1,7) -- Afiliado - CompraBono
insert into CLINICA.RolXfuncionalidad values (1,9) -- Afiliado - PedirTurno

insert into CLINICA.RolXfuncionalidad values (3,6) -- Profesional - Cancelar Atencion 
insert into CLINICA.RolXfuncionalidad values (3,8) -- Profesional - Listados????? CONFIRMAR
insert into CLINICA.RolXfuncionalidad values (3,10) -- Profesional - Registrar Agenda
insert into CLINICA.RolXfuncionalidad values (3,11) -- Profesional - Registrar Llegada???? CONFIRMAR
insert into CLINICA.RolXfuncionalidad values (3,12) -- Profesional - Registrar Resultado

insert into CLINICA.RolXfuncionalidad values (2,1) -- Administrativo - Todas
insert into CLINICA.RolXfuncionalidad values (2,2)
insert into CLINICA.RolXfuncionalidad values (2,3) 
insert into CLINICA.RolXfuncionalidad values (2,4) 
insert into CLINICA.RolXfuncionalidad values (2,5) 
insert into CLINICA.RolXfuncionalidad values (2,6)
insert into CLINICA.RolXfuncionalidad values (2,7) 
insert into CLINICA.RolXfuncionalidad values (2,8) 
insert into CLINICA.RolXfuncionalidad values (2,9) 
insert into CLINICA.RolXfuncionalidad values (2,10) 
insert into CLINICA.RolXfuncionalidad values (2,11) 
insert into CLINICA.RolXfuncionalidad values (2,12) 

insert into CLINICA.EspecialidadXProfesional values (10000,9999)
insert into CLINICA.EspecialidadXProfesional values (10001,92746405)
insert into CLINICA.EspecialidadXProfesional values (10004,9999)
insert into CLINICA.EspecialidadXProfesional values (10007,54980698)
insert into CLINICA.EspecialidadXProfesional values (10012,65090855)
insert into CLINICA.EspecialidadXProfesional values (10007,1465925)
insert into CLINICA.EspecialidadXProfesional values (10012,18756896)

insert into CLINICA.Horarios values (9999,10032,'20151013','12:30:00.0000000')
insert into CLINICA.Horarios values (9999,10032,'20151014','12:30:00.0000000')
insert into CLINICA.Horarios values (9999,10032,'20151015','12:30:00.0000000')


/* CREO STORE PROCEDURES */

--PROCEDURE QUE CHEQUEA LOS INTENTOS
USE GD2C2016; --ESTO ES PARA QUE NO TE DIGA QUE EL PROCEDURE TIENE QUE SER LA UNICA INSTRUCCION Y BLAH...
GO

CREATE PROCEDURE CLINICA.Login_procedure(@username VARCHAR(20) , @password VARCHAR(10))
AS
 BEGIN
	DECLARE @intentos TINYINT, @hash VARBINARY(225), @pass VARBINARY(225), @cantidad INT 
	
	SET @intentos = (SELECT usua_intentos FROM CLINICA.Usuarios WHERE usua_username = @username)
    SET @hash = HASHBYTES('SHA2_256',@password); --La que ingreso
	SET @pass = (SELECT usua_password FROM CLINICA.Usuarios WHERE usua_username = @username) -- La real

	IF(@intentos IS NULL) 	--me fijo si esta el usuario
		SET @cantidad = -1

	ELSE IF(@hash <> @pass)  --comparo las contrasenias
			BEGIN
				SET @cantidad = @intentos
				IF(@intentos<> 0)  --verifico la cantidad de ceros. si aun le quedan, hago el update
					UPDATE CLINICA.Usuarios SET usua_intentos = @intentos - 1 WHERE usua_username=@username
			END				
	ELSE
			BEGIN
			SET @cantidad = 4   --Todo bien! Contrasenia correcta!
			UPDATE CLINICA.Usuarios SET usua_intentos = 3 WHERE usua_username=@username

			END
	RETURN @cantidad
 END
GO

USE GD2C2016;
GO
CREATE PROCEDURE CLINICA.getRolesUsuario (@user VARCHAR(15))
AS
 BEGIN
	
	DECLARE @userId INT -- Lo que viene por parametro es el usua_username, necesito el id para comparar con RolXusuario

	SET @userId = (SELECT usua_id FROM CLINICA.Usuarios WHERE usua_username = @user)

	SELECT rxu.role_id, r.role_nombre 
	FROM CLINICA.RolXusuario rxu, CLINICA.Roles r 
	WHERE rxu.usua_id=@userId AND rxu.role_id=r.role_id AND role_habilitado=1

 END
GO

USE GD2C2016;
GO
CREATE PROCEDURE CLINICA.getFuncionalidadXRol (@role_id int) 
AS
 BEGIN

	SELECT rxf.func_id, f.func_nombre
	FROM CLINICA.RolXfuncionalidad rxf, CLINICA.Funcionalidades f
	WHERE rxf.func_id=f.func_id AND rxf.role_id=@role_id

 END
GO

--PROCEDURE QUE DEVUELVE LOS PLANES
USE GD2C2016;
GO
CREATE PROCEDURE CLINICA.getPlanes
AS
	BEGIN 
		SELECT plan_id,plan_nombre
		FROM CLINICA.Planes
	END
GO

--PROCEDURE QUE AGREGA UN USUARIO
USE GD2C2016;
GO

CREATE PROCEDURE CLINICA.ingresarUsuario(
    @username VARCHAR(20),
  	@password VARCHAR(10),
    @nombre VARCHAR(255),
    @apellido VARCHAR(255),
  	@tipoDoc VARCHAR(20),
    @nroDoc DECIMAL(8,0),
  	@direccion VARCHAR(255),
  	@telefono DECIMAL(18,0),
  	@fechaNacimiento DATETIME,
  	@sexo VARCHAR(15),
	@mail VARCHAR(255))
AS
BEGIN
    DECLARE @pass VARBINARY(225)
	SET @pass = HASHBYTES('SHA2_256',@password) 
	INSERT INTO CLINICA.Usuarios(usua_id, usua_username,usua_password, usua_nombre, usua_apellido, usua_tipoDoc, usua_nroDoc, usua_direccion,
					usua_telefono,usua_fechaNacimiento, usua_sexo, usua_mail)

	VALUES(@nroDoc*100+1,@username,@pass,@nombre,@apellido,@tipoDoc,@nroDoc,@direccion, @telefono,@fechaNacimiento, @sexo, @mail)

END
GO

--PROCEDURE QUE AGREGA UN AFILIADO
USE GD2C2016;
GO
CREATE PROCEDURE CLINICA.ingresarAfiliado(@usuario BIGINT, @plan INT, @estado VARCHAR(20), @hijos INT)
AS
BEGIN
	INSERT INTO CLINICA.Afiliados(afil_usuario, afil_plan, afil_estadoCivil, afil_cantidadHijos)

	VALUES(@usuario, @plan, @estado, @hijos)	

	--RETURN (SELECT MAX(afil_id) FROM CLINICA.Afiliados)
END
GO

USE GD2C2016;
GO
--PROCEDURE QUE AGREGA UN FAMILIAR DEL AFILIADO
CREATE PROCEDURE CLINICA.agregarFamiliar(@afiliado_raiz INT, @usuario BIGINT, @plan INT, @estado VARCHAR(20), @hijos INT)
AS
BEGIN
	DECLARE @numero_nuevo_afiliado INT
	SET @numero_nuevo_afiliado = (SELECT MAX(CONVERT(INT, RIGHT(STR(afil_id),2)))
								  FROM CLINICA.Afiliados
								  WHERE afil_id = @afiliado_raiz)

	--SET @numero_nuevo_afiliado = CONVERT(INT, RIGHT(STR(@afiliado_raiz),2))

	SET IDENTITY_INSERT CLINICA.Afiliados ON

	INSERT INTO CLINICA.Afiliados(afil_id, afil_usuario, afil_plan, afil_estadoCivil, afil_cantidadHijos)
	VALUES(@afiliado_raiz+ @numero_nuevo_afiliado, @usuario, @plan,@estado,@hijos )

	SET IDENTITY_INSERT CLINICA.Afiliados OFF
END
GO



USE GD2C2016;
GO
--PROCEDURE PARA MODIFICAR AL AFILIADO
CREATE PROCEDURE CLINICA.modificarAfiliado(@username BIGINT,@direccion VARCHAR(255), @telefono DECIMAL(18,0),@plan INT, @estado VARCHAR(20), @hijos INT)
AS 
	BEGIN
		DECLARE @afil INT
		SET @afil = (SELECT afil_id FROM CLINICA.Afiliados WHERE afil_usuario = @username)

		UPDATE CLINICA.Usuarios set usua_direccion = @direccion WHERE usua_id =@username  AND usua_direccion != @direccion
		--UPDATE CLINICA.Afiliados set afil_estadoCivil = @estado WHERE afil_id = @afil AND @estado != afil_estadoCivil

		UPDATE CLINICA.Usuarios set usua_telefono = @telefono WHERE usua_id =@username  AND usua_telefono != @telefono
		
		UPDATE CLINICA.Afiliados set afil_estadoCivil = @estado WHERE afil_usuario = @username  AND afil_estadoCivil != @estado
				OR afil_estadoCivil IS NULL

	END
GO


USE GD2C2016;
GO
--PROCEDURE QUE DA DE BAJA!
CREATE PROCEDURE CLINICA.darDeBaja(@user BIGINT)
AS
BEGIN
	UPDATE CLINICA.Usuarios
		SET usua_intentos = 0
		WHERE usua_id = @user
END
GO

USE GD2C2016;
GO
CREATE PROCEDURE CLINICA.eliminarAfiliado(@user BIGINT)
AS
BEGIN 
	DECLARE @afil INT

	SET @afil = (SELECT afil_id FROM CLINICA.Afiliados WHERE afil_usuario = @user)
	DELETE FROM CLINICA.ComprasBonos
			WHERE comp_afil = @afil

	DELETE FROM CLINICA.Bonos
			WHERE bono_afilCompra = @afil
				OR bono_afilUsado = @afil
		
	DELETE FROM CLINICA.Turnos
			WHERE turn_afiliado = @afil
	--TODO PASAR A UN TRIGGER 
	DELETE FROM CLINICA.Afiliados
			WHERE afil_id = @afil

	DELETE FROM CLINICA.Usuarios
			WHERE usua_id = @user
		
	END
GO


USE GD2C2016;
GO
CREATE PROCEDURE CLINICA.registrarConsulta(@turno INT, @bono INT, @afil INT)
AS
	BEGIN 
		DECLARE @consulta INT

		INSERT INTO CLINICA.Consultas(cons_turno,cons_fechaHoraConsulta)
		VALUES(@turno, GETDATE());

		SET @consulta = (SELECT TOP 1 cons_id FROM CLINICA.Consultas WHERE cons_turno = @turno)

		UPDATE CLINICA.Bonos
			SET bono_afilUsado = @afil, bono_nroConsulta = @consulta
			WHERE bono_id = @bono


	END
GO

USE GD2C2016;
GO

--FUNCION QUE DEVUELVE SI UN USUARIO TIENE FAMILIA
CREATE FUNCTION CLINICA.tieneFamilia(@usuario_id BIGINT)
RETURNS CHAR(2)
AS
BEGIN
	DECLARE @raiz BIGINT
	SET @raiz = LEFT(@usuario_id,8)
	IF EXISTS(SELECT * FROM CLINICA.Usuarios WHERE usua_id <> @usuario_id AND LEFT(usua_id,8) = @raiz)
		RETURN 'SI'
	RETURN 'NO'
END

GO
/* CREO TRIGGERS */
--TRIGGER QUE VERIFICA EL USUARIO
USE GD2C2016;
GO

CREATE TRIGGER CLINICA.verificarUsuario ON CLINICA.Usuarios INSTEAD OF INSERT 
AS
	BEGIN
		IF EXISTS (SELECT* FROM CLINICA.Usuarios u, inserted i WHERE u.usua_username = i.usua_username)		 
			RAISERROR('El usuario ya esta ocupado. Escriba otro nombre de usuario y vuelva a intentarlo',16,2)
		ELSE		 
			INSERT INTO CLINICA.Usuarios 
			SELECT * FROM inserted
	END 
GO

USE GD2C2016;
GO
--TRIGGER DE LA AGENDA PROFESIONAL
CREATE TRIGGER LimiteHoras ON CLINICA.Horarios INSTEAD OF INSERT
AS
BEGIN

	DECLARE @prof_id INT = (select hora_profesional from inserted)


	IF (select top 1 count(*)/2
	from Clinica.horarios
	where hora_profesional = @prof_id
	UNION
	select top 1 count(*)/2
	from Clinica.horarios
	where hora_profesional = @prof_id
	group by hora_profesional, datepart(WEEK,hora_fecha)
	order by count(*)/2 DESC) > 48
		RAISERROR('En al menos una semana, se supera el limite de 48 horas semanales por profesional.',16,2)
	ELSE
		BEGIN
		IF(select isnull(count(*),0)
		from CLINICA.Horarios H join inserted I on (H.hora_fecha = I.hora_fecha AND H.hora_inicio = I.hora_inicio)
		where H.hora_profesional = @prof_id) > 0
			RAISERROR('Se quiere uno o mas horarios incopatibles con los existentes (mismo profesional, dia y hora).',16,2)
		ELSE
			INSERT INTO Horarios select * from inserted
		END
END
GO


CREATE TRIGGER CLINICA.triggerElimTurnos ON CLINICA.Turnos INSTEAD OF DELETE
AS
	BEGIN 
		DELETE FROM CLINICA.CancelacionesTurnos
			WHERE canc_turno IN (SELECT d.turn_id FROM deleted d)

		DELETE FROM CLINICA.Consultas
			WHERE cons_turno IN (SELECT d.turn_id FROM deleted d)

		DELETE FROM CLINICA.Turnos
			WHERE turn_id IN (SELECT d.turn_id FROM deleted d)

	END	
GO


USE GD2C2016;
GO
CREATE TRIGGER CLINICA.triggerEliminarUser ON CLINICA.Usuarios INSTEAD OF DELETE
AS
	BEGIN
		
		DELETE FROM CLINICA.RolXusuario
			WHERE usua_id IN (SELECT d.usua_id FROM deleted d)

		DELETE FROM CLINICA.Usuarios
			WHERE usua_id IN (SELECT d.usua_id FROM deleted d)
	
	END
GO