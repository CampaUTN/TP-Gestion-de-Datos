USE GD2C2016;
GO

/* Eliminacion de los objetos preexistentes */

IF OBJECT_ID('GEDDES.RolXfuncionalidad','U') IS NOT NULL
    DROP TABLE GEDDES.RolXfuncionalidad;

IF OBJECT_ID('GEDDES.Funcionalidades','U') IS NOT NULL
    DROP TABLE GEDDES.Funcionalidades;

IF OBJECT_ID('GEDDES.RolXUsuario','U') IS NOT NULL
    DROP TABLE GEDDES.RolXUsuario;

IF OBJECT_ID('GEDDES.Roles','U') IS NOT NULL
    DROP TABLE GEDDES.Roles;

IF OBJECT_ID('GEDDES.Administradores','U') IS NOT NULL
    DROP TABLE GEDDES.Administradores;
   
IF OBJECT_ID('GEDDES.EspecialidadXProfesional','U') IS NOT NULL
    DROP TABLE GEDDES.EspecialidadXProfesional;

IF OBJECT_ID('GEDDES.CancelacionesTurnos','U') IS NOT NULL
    DROP TABLE GEDDES.CancelacionesTurnos;
    
IF OBJECT_ID('GEDDES.Bonos','U') IS NOT NULL
    DROP TABLE GEDDES.Bonos;
    
IF OBJECT_ID('GEDDES.ComprasBonos','U') IS NOT NULL
    DROP TABLE GEDDES.ComprasBonos;
    
IF OBJECT_ID('GEDDES.Consultas','U') IS NOT NULL
    DROP TABLE GEDDES.Consultas;

IF OBJECT_ID('GEDDES.Turnos','U') IS NOT NULL
    DROP TABLE GEDDES.Turnos;

IF OBJECT_ID('GEDDES.HistorialAfiliado','U') IS NOT NULL
    DROP TABLE GEDDES.HistorialAfiliado;

IF OBJECT_ID('GEDDES.Afiliados','U') IS NOT NULL
    DROP TABLE GEDDES.Afiliados;
	
IF OBJECT_ID('GEDDES.TipoCancelacion','U') IS NOT NULL
    DROP TABLE GEDDES.TipoCancelacion;
	
IF OBJECT_ID('GEDDES.Planes','U') IS NOT NULL
    DROP TABLE GEDDES.Planes;

IF OBJECT_ID('GEDDES.Horarios','U') IS NOT NULL
    DROP TABLE GEDDES.Horarios;

IF OBJECT_ID('GEDDES.Especialidades','U') IS NOT NULL
    DROP TABLE GEDDES.Especialidades;
	
IF OBJECT_ID('GEDDES.Profesionales','U') IS NOT NULL
    DROP TABLE GEDDES.Profesionales;

IF OBJECT_ID('GEDDES.TipoEspecialidad','U') IS NOT NULL
    DROP TABLE GEDDES.TipoEspecialidad;

IF OBJECT_ID('GEDDES.Usuarios','U') IS NOT NULL
    DROP TABLE GEDDES.Usuarios;

    

/* DROP PROCEDURES! */
  
IF OBJECT_ID('GEDDES.Login_procedure ') IS NOT NULL
    DROP PROCEDURE GEDDES.Login_procedure 

IF OBJECT_ID('GEDDES.getFuncionalidadXRol') IS NOT NULL
    DROP PROCEDURE GEDDES.getFuncionalidadXRol
	
IF OBJECT_ID('GEDDES.getRolesUsuario') IS NOT NULL
    DROP PROCEDURE GEDDES.getRolesUsuario 

IF OBJECT_ID('GEDDES.getPlanes') IS NOT NULL
    DROP PROCEDURE GEDDES.getPlanes

IF OBJECT_ID('GEDDES.ingresarUsuario') IS NOT NULL
    DROP PROCEDURE GEDDES.ingresarUsuario

IF OBJECT_ID('GEDDES.ingresarAfiliado') IS NOT NULL
    DROP PROCEDURE GEDDES.ingresarAfiliado

IF OBJECT_ID('GEDDES.agregarFamiliar') IS NOT NULL
 DROP PROCEDURE GEDDES.agregarFamiliar

IF OBJECT_ID('GEDDES.modificarAfiliado') IS NOT NULL
 DROP PROCEDURE GEDDES.modificarAfiliado

 IF OBJECT_ID('GEDDES.registrarMotivo') IS NOT NULL
DROP PROCEDURE GEDDES.registrarMotivo

IF OBJECT_ID('GEDDES.darDeBaja') IS NOT NULL
 DROP PROCEDURE GEDDES.darDeBaja 

IF OBJECT_ID('GEDDES.eliminarAfiliado') IS NOT NULL
 DROP PROCEDURE GEDDES.eliminarAfiliado

IF OBJECT_ID('GEDDES.registrarConsulta') IS NOT NULL
    DROP PROCEDURE GEDDES.registrarConsulta

IF OBJECT_ID('GEDDES.registrarResultadoConsulta') IS NOT NULL
    DROP PROCEDURE GEDDES.registrarResultadoConsulta 

IF OBJECT_ID('GEDDES.cancelar_dia_agenda') IS NOT NULL
    DROP PROCEDURE GEDDES.cancelar_dia_agenda 

IF OBJECT_ID('GEDDES.cancelar_turno_afiliado') IS NOT NULL
    DROP PROCEDURE GEDDES.cancelar_turno_afiliado 

/* DROP FUNCTION */
IF (OBJECT_ID ('GEDDES.verificarUsuario') IS NOT NULL)
  DROP FUNCTION GEDDES.verificarUsuario

 IF (OBJECT_ID ('GEDDES.fecha') IS NOT NULL)
 DROP FUNCTION  GEDDES.fecha

 IF (OBJECT_ID ('GEDDES.LimiteHoras') IS NOT NULL)
  DROP FUNCTION GEDDES.verificarUsuario

IF (OBJECT_ID ('GEDDES.tieneFamilia') IS NOT NULL)
  DROP FUNCTION GEDDES.tieneFamilia

IF (OBJECT_ID ('GEDDES.RemoverTildes') IS NOT NULL)
  DROP FUNCTION GEDDES.RemoverTildes 

/* DROP TRIGGER */
IF OBJECT_ID('GEDDES.triggerElimTurnos') IS NOT NULL
	DROP TRIGGER GEDDES.triggerElimTurnos

IF OBJECT_ID('GEDDES.triggerElimUsua') IS NOT NULL
	DROP TRIGGER GEDDES.triggerEliminarUser

IF OBJECT_ID('GEDDES.LimiteHoras') IS NOT NULL
	DROP TRIGGER GEDDES.LimiteHoras
	
IF OBJECT_ID('GEDDES.verificarBaja') IS NOT NULL	
	DROP TRIGGER GEDDES.verificarBaja

/* DROP SCHEMA */

IF EXISTS (SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'GEDDES')
    DROP SCHEMA GEDDES
GO


/* Creacion del esquema */

CREATE SCHEMA GEDDES AUTHORIZATION gd
GO

/* Creacion de las tablas */

CREATE TABLE GEDDES.Usuarios(
    usua_id BIGINT PRIMARY KEY,
    usua_username VARCHAR(20),
  	usua_password VARBINARY(500),
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

CREATE TABLE GEDDES.Roles(
    role_id INT IDENTITY NOT NULL,
    role_nombre VARCHAR(225),
  	role_habilitado TINYINT,
    PRIMARY KEY (role_id));


CREATE TABLE GEDDES.RolXusuario(
    usua_id BIGINT NOT NULL FOREIGN KEY REFERENCES GEDDES.Usuarios(usua_id),
    role_id INT NOT NULL FOREIGN KEY REFERENCES GEDDES.Roles(role_id),
    PRIMARY KEY (usua_id, role_id));
    

CREATE TABLE GEDDES.Funcionalidades(
	func_id INT NOT NULL IDENTITY PRIMARY KEY,
  	func_nombre VARCHAR(225) NOT NULL );
  
CREATE TABLE GEDDES.RolXfuncionalidad(
    role_id INT NOT NULL FOREIGN KEY REFERENCES GEDDES.Roles(role_id),
    func_id INT NOT NULL FOREIGN KEY REFERENCES GEDDES.Funcionalidades(func_id),
    PRIMARY KEY (role_id, func_id));

CREATE TABLE GEDDES.Administradores(
	admi_id INT NOT NULL IDENTITY PRIMARY KEY,
  	admi_usuario BIGINT NOT NULL FOREIGN KEY REFERENCES GEDDES.Usuarios(usua_id));
  
CREATE TABLE GEDDES.Profesionales(
	prof_id INT NOT NULL PRIMARY KEY, -- viene a ser el DNI 
  	prof_usuario BIGINT NOT NULL FOREIGN KEY REFERENCES GEDDES.Usuarios(usua_id),
  	prof_matricula VARCHAR(12));
  
CREATE TABLE GEDDES.TipoEspecialidad(
    tipo_id INT PRIMARY KEY,
    tipo_nombre VARCHAR(225));

CREATE TABLE GEDDES.Especialidades(
    espe_id INT PRIMARY KEY,
  	espe_nombre VARCHAR(256) NOT NULL,
    espe_tipo INT NOT NULL FOREIGN KEY REFERENCES GEDDES.TipoEspecialidad(tipo_id));

CREATE TABLE GEDDES.Horarios(
	hora_id INT NOT NULL IDENTITY PRIMARY KEY,
  	hora_profesional INT NOT NULL FOREIGN KEY REFERENCES GEDDES.Profesionales(prof_id), 
    hora_especialidad INT NOT NULL FOREIGN KEY REFERENCES GEDDES.Especialidades(espe_id), 
    hora_fecha DATE NOT NULL,
    hora_inicio TIME NOT NULL,
	hora_activo TINYINT NOT NULL);
  
CREATE TABLE GEDDES.EspecialidadXProfesional(
	espe_id INT FOREIGN KEY REFERENCES GEDDES.Especialidades(espe_id),
  	prof_id INT FOREIGN KEY REFERENCES GEDDES.Profesionales(prof_id),
  	PRIMARY KEY (espe_id, prof_id));

CREATE TABLE GEDDES.Planes(
	plan_id INT PRIMARY KEY NOT NULL,
  	plan_nombre VARCHAR(225) NOT NULL,
  	plan_precioBono DECIMAL(12,2) NOT NULL);   

CREATE TABLE GEDDES.Afiliados(
    afil_id INT IDENTITY(101,100) PRIMARY KEY,
    afil_usuario BIGINT FOREIGN KEY REFERENCES GEDDES.Usuarios(usua_id),
    afil_plan INT FOREIGN KEY REFERENCES GEDDES.Planes(plan_id),
  	afil_estadoCivil VARCHAR(20),
  	afil_cantidadHijos INT DEFAULT 0);

 CREATE TABLE GEDDES.Turnos(
	turn_id INT NOT NULL PRIMARY KEY IDENTITY,
  	turn_afiliado INT NOT NULL FOREIGN KEY REFERENCES GEDDES.Afiliados(afil_id), 
    turn_hora INT FOREIGN KEY REFERENCES GEDDES.Horarios(hora_id), 
    turn_activo TINYINT NOT NULL);

CREATE TABLE GEDDES.TipoCancelacion(
	tipo_id INT PRIMARY KEY IDENTITY,
  	tipo_detalle VARCHAR(256));

CREATE TABLE GEDDES.CancelacionesTurnos(
	canc_id INT PRIMARY KEY IDENTITY,
  	canc_turno INT FOREIGN KEY REFERENCES GEDDES.Turnos(turn_id),
	canc_tipo INT FOREIGN KEY REFERENCES GEDDES.TipoCancelacion(tipo_id),
  	canc_detalle VARCHAR(225));  
  
CREATE TABLE GEDDES.HistorialAfiliado(
	hist_id INT NOT NULL IDENTITY PRIMARY KEY,
	hist_afil INT NOT NULL FOREIGN KEY REFERENCES GEDDES.Afiliados(afil_id),
  	hist_motivo VARCHAR(225),
	hist_fecha DATE NOT NULL);

CREATE TABLE GEDDES.Consultas(
	cons_id INT PRIMARY KEY IDENTITY NOT NULL,
  	cons_turno INT FOREIGN KEY REFERENCES GEDDES.Turnos(turn_id), -- nullable
    cons_fechaHoraConsulta DATETIME, -- nullable
    cons_fueConcretada TINYINT, -- nullable
    cons_sintomas VARCHAR(256), -- nullable
    cons_diagnostico VARCHAR(512)); -- nullable

CREATE TABLE GEDDES.Bonos(
  	bono_id INT NOT NULL IDENTITY PRIMARY KEY,
  	bono_afilCompra INT NOT NULL FOREIGN KEY REFERENCES GEDDES.Afiliados(afil_id),
  	bono_nroConsulta INT FOREIGN KEY REFERENCES GEDDES.Consultas(cons_id),  -- nullable
  	bono_plan INT NOT NULL FOREIGN KEY REFERENCES GEDDES.Planes(plan_id),
  	bono_afilUsado INT FOREIGN KEY REFERENCES GEDDES.Afiliados(afil_id));
  
CREATE TABLE GEDDES.ComprasBonos( 
	comp_id INT NOT NULL IDENTITY PRIMARY KEY,
  	comp_afil INT NOT NULL FOREIGN KEY REFERENCES GEDDES.Afiliados(afil_id), 
    comp_cantidad INT NOT NULL ,
	comp_precioFinal DECIMAL(12,2) NOT NULL,
	comp_fechaCompra DATETIME);



CREATE INDEX I_Username ON GEDDES.Usuarios(usua_username);
CREATE INDEX I_Horario ON GEDDES.Horarios(hora_fecha);
CREATE INDEX I_Turno ON GEDDES.Turnos(turn_hora);

USE GD2C2016;
GO

/* Migracion de datos desde la tabla maestra */

USE GD2C2016;
GO
INSERT INTO GEDDES.Roles
VALUES ('Afiliado', 1),
       ('Administrativo', 1),
       ('Profesional', 1);
  
DECLARE @hash VARBINARY(225)
SELECT @hash = HASHBYTES('SHA2_256', 'w23e');
  
--Administrativo
INSERT INTO GEDDES.Usuarios(usua_id,usua_username, usua_password, usua_intentos, usua_tipoDoc, usua_nroDoc)
VALUES (0,'admin', @hash, 3, 'DNI', 36740233);


-- Usuarios desde Afiliados.
INSERT INTO GEDDES.Usuarios(usua_id,usua_username,usua_password,usua_nroDoc,usua_nombre,usua_apellido,usua_tipoDoc,usua_direccion,usua_telefono,usua_fechaNacimiento,usua_sexo,usua_mail)
  SELECT DISTINCT Paciente_Dni*100+1,Paciente_Dni, @hash, Paciente_Dni,Paciente_Nombre, Paciente_Apellido, 'DNI', Paciente_Direccion, Paciente_Telefono, null, null, Paciente_Mail
  FROM gd_esquema.Maestra
  WHERE Paciente_Dni IS NOT NULL


INSERT INTO GEDDES.Usuarios(usua_id,usua_username,usua_password,usua_nroDoc,usua_intentos,usua_nombre,usua_apellido,usua_tipoDoc,usua_direccion,usua_telefono,usua_fechaNacimiento,usua_sexo,usua_mail)
	SELECT DISTINCT Medico_Dni*100+1,Medico_Dni, @hash,Medico_Dni,0, Medico_Nombre, Medico_Apellido, 'DNI',Medico_Direccion, Medico_Telefono, Medico_Fecha_Nac, NULL, Medico_Mail
	FROM gd_esquema.Maestra
	WHERE Medico_Dni IS NOT NULL

	--Planes.
	--Lo pongo arriba de antes porque sino tira error con las FK al no tener los planes cargados
INSERT INTO GEDDES.Planes(plan_id, plan_nombre, plan_precioBono)
	SELECT DISTINCT Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta
	FROM gd_esquema.Maestra
	WHERE Plan_Med_Codigo IS NOT NULL

--Afiliados
INSERT INTO GEDDES.Afiliados(afil_usuario, afil_plan, afil_cantidadHijos,afil_estadoCivil)
	SELECT DISTINCT ((SELECT usua_id FROM GEDDES.Usuarios WHERE usua_nroDoc=Paciente_Dni)),
					Plan_Med_Codigo, 0, NULL
	FROM gd_esquema.Maestra
	WHERE Paciente_Dni IS NOT NULL

-- Profesionales.
INSERT INTO GEDDES.Profesionales(prof_id,prof_matricula,prof_usuario)
	SELECT DISTINCT Medico_Dni, NULL, (SELECT usua_id FROM GEDDES.Usuarios WHERE usua_nroDoc=Medico_Dni)
	FROM gd_esquema.Maestra
	WHERE Medico_Dni IS NOT NULL
    
  --Tipo Especialidad.
INSERT INTO GEDDES.TipoEspecialidad(tipo_id, tipo_nombre)
	SELECT DISTINCT Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion 
	FROM gd_esquema.Maestra 
	WHERE Tipo_Especialidad_Codigo IS NOT NULL 
	ORDER BY Tipo_Especialidad_Codigo
    
  -- Especialidad.
INSERT INTO GEDDES.Especialidades(espe_id, espe_tipo, espe_nombre)
  SELECT DISTINCT Especialidad_Codigo, Tipo_Especialidad_Codigo, Especialidad_Descripcion
  FROM gd_esquema.Maestra
  WHERE Especialidad_Codigo IS NOT NULL
  ORDER BY Especialidad_Codigo  

-- Horarios.
INSERT INTO GEDDES.Horarios(hora_especialidad, hora_fecha, hora_inicio, hora_profesional, hora_activo)
  SELECT Especialidad_Codigo, CONVERT(DATE,Turno_Fecha), CONVERT(TIME,Turno_fecha), Medico_Dni, 1
  FROM gd_esquema.Maestra m
  WHERE Medico_Dni IS NOT NULL
  GROUP BY Turno_Numero, Turno_Fecha, Especialidad_Codigo, Medico_Dni
  
    -- Turnos.
  SET IDENTITY_INSERT GEDDES.Turnos ON 
  INSERT INTO GEDDES.Turnos(turn_id, turn_afiliado, turn_hora, turn_activo)
	SELECT DISTINCT m.Turno_Numero, (SELECT top 1 afil_id
                                   FROM GEDDES.Afiliados
                                   			join GEDDES.Usuarios on (afil_usuario = usua_id)
                                   WHERE usua_nroDoc = m.Paciente_Dni AND usua_nroDoc IS NOT NULL), (SELECT hora_id FROM GEDDES.Horarios WHERE hora_fecha=CONVERT(DATE,Turno_Fecha) AND hora_inicio=CONVERT(TIME,Turno_Fecha) AND Medico_Dni=hora_profesional), 1 -- asumimos que todos los turnos de la base estan activos (no cancelados).
	FROM gd_esquema.Maestra m
	WHERE m.Turno_Numero IS NOT NULL 
  ORDER BY m.Turno_Numero
  SET IDENTITY_INSERT GEDDES.Turnos OFF 
  GO


  	-- Consultas. Suponemos que todas se concretaron y el tipo nunca dio el presente y se fue antes de que lo atiendan (caso de concretada=0).
SET IDENTITY_INSERT GEDDES.Consultas ON
INSERT INTO GEDDES.Consultas(cons_id, cons_turno, cons_fechaHoraConsulta, cons_fueConcretada, cons_sintomas, 
cons_diagnostico)
SELECT DISTINCT m.Bono_Consulta_Numero ,m.Turno_Numero, m.Bono_Consulta_Fecha_Impresion, 1, m.Consulta_Sintomas, m.Consulta_Enfermedades
FROM gd_esquema.Maestra m
WHERE m.Turno_Numero IS NOT NULL AND m.Bono_Consulta_Fecha_Impresion IS NOT NULL AND m.Bono_Consulta_Numero IS NOT NULL
ORDER BY m.Turno_Numero
GO
SET IDENTITY_INSERT GEDDES.Consultas OFF

INSERT INTO GEDDES.Bonos(bono_afilCompra, bono_plan, bono_nroConsulta, bono_afilUsado)
SELECT (SELECT afil_id FROM GEDDES.Usuarios JOIN GEDDES.Afiliados 
	ON usua_id = afil_usuario WHERE m.Paciente_Dni = usua_nroDoc), m.Plan_Med_Codigo, m.Bono_Consulta_Numero, (SELECT afil_id FROM GEDDES.Usuarios JOIN GEDDES.Afiliados 
	ON usua_id = afil_usuario WHERE m.Paciente_Dni = usua_nroDoc) -- Como los de la tabla maestra no tienen familia si o si lo usaron ellos mismo al bono
FROM gd_esquema.Maestra m
WHERE m.Compra_Bono_Fecha IS NOT NULL 
 
	-- Compra bonos. Funciona
INSERT INTO GEDDES.ComprasBonos(comp_afil,comp_cantidad,comp_precioFinal,comp_fechaCompra)
SELECT 
	(SELECT afil_id FROM GEDDES.Usuarios JOIN GEDDES.Afiliados 
	ON usua_id = afil_usuario WHERE m.Paciente_Dni = usua_nroDoc), 1, m.Plan_Med_Precio_Bono_Consulta , m.Compra_Bono_Fecha -- No sabemos el precio del bono en ese momento
FROM gd_esquema.Maestra m
WHERE m.Compra_Bono_Fecha IS NOT NULL

insert into GEDDES.TipoCancelacion values ('Cancelacion por afiliado')
insert into GEDDES.TipoCancelacion values ('Cancelacion por profesional')

	-- Cancelaciones. Si un usuario no gasto el bono pero la fecha del turno paso, entonces cancelo el turno
INSERT INTO GEDDES.CancelacionesTurnos(canc_turno, canc_detalle, canc_tipo)
SELECT m.Turno_Numero, 'Migracion', 1
FROM gd_esquema.Maestra m
WHERE m.Bono_Consulta_Numero IS NULL AND m.Turno_Numero IS NOT NULL AND m.Turno_Fecha < GETDATE()

insert into GEDDES.Afiliados values (0,555558,'Casado',0) --usuario, plan, estado civ, hijos
insert into GEDDES.Administradores values (0)  --usario
insert into GEDDES.Profesionales values (9999,0,null) --prof if, user, algo
update GEDDES.Usuarios set usua_nombre= 'NombreAdmin' where usua_id=0
update GEDDES.Usuarios set usua_apellido= 'ApellidoAdmin' where usua_id=0

---
insert into GEDDES.FUNCIONALIDADES values ('AbmAfiliado') --1
insert into GEDDES.FUNCIONALIDADES values ('AbmEspMedicas') --2
insert into GEDDES.FUNCIONALIDADES values ('AbmPlanes') --3
insert into GEDDES.FUNCIONALIDADES values ('AbmProfesional') --4
insert into GEDDES.FUNCIONALIDADES values ('AbmRol') --5
insert into GEDDES.FUNCIONALIDADES values ('CancelarAtencion') --6
insert into GEDDES.FUNCIONALIDADES values ('CompraBono') --7
insert into GEDDES.FUNCIONALIDADES values ('Listados') --8
insert into GEDDES.FUNCIONALIDADES values ('PedirTurno') --9
insert into GEDDES.FUNCIONALIDADES values ('RegistarAgenda') --10
insert into GEDDES.FUNCIONALIDADES values ('RegistroLlegada') --11
insert into GEDDES.FUNCIONALIDADES values ('RegistroResultado') --12

select * from GEDDES.RolXFuncionalidad

-- role 1: afil role2: admin role3: prof

insert into GEDDES.RolXfuncionalidad values (1,6) -- Afiliado - Cancelar Atencion
insert into GEDDES.RolXfuncionalidad values (1,7) -- Afiliado - CompraBono
insert into GEDDES.RolXfuncionalidad values (1,9) -- Afiliado - PedirTurno

insert into GEDDES.RolXfuncionalidad values (3,6) -- Profesional - Cancelar Atencion 
insert into GEDDES.RolXfuncionalidad values (3,8) -- Profesional - Listados
insert into GEDDES.RolXfuncionalidad values (3,10) -- Profesional - Registrar Agenda
insert into GEDDES.RolXfuncionalidad values (3,12) -- Profesional - Registrar Resultado

insert into GEDDES.RolXfuncionalidad values (2,1) -- Administrativo - Todas
insert into GEDDES.RolXfuncionalidad values (2,2)
insert into GEDDES.RolXfuncionalidad values (2,3) 
insert into GEDDES.RolXfuncionalidad values (2,4) 
insert into GEDDES.RolXfuncionalidad values (2,5) 
insert into GEDDES.RolXfuncionalidad values (2,6)
insert into GEDDES.RolXfuncionalidad values (2,7) 
insert into GEDDES.RolXfuncionalidad values (2,8) 
insert into GEDDES.RolXfuncionalidad values (2,9) 
insert into GEDDES.RolXfuncionalidad values (2,10) 
insert into GEDDES.RolXfuncionalidad values (2,11) 
insert into GEDDES.RolXfuncionalidad values (2,12) 

insert into GEDDES.EspecialidadXProfesional values (10000,9999)
insert into GEDDES.EspecialidadXProfesional values (10001,92746405)
insert into GEDDES.EspecialidadXProfesional values (10004,9999)
insert into GEDDES.EspecialidadXProfesional values (10007,54980698)
insert into GEDDES.EspecialidadXProfesional values (10012,65090855)
insert into GEDDES.EspecialidadXProfesional values (10007,1465925)
insert into GEDDES.EspecialidadXProfesional values (10012,18756896)

insert into GEDDES.Horarios values (9999,10032,'20151013','12:30:00.0000000',1)
insert into GEDDES.Horarios values (9999,10032,'20151014','12:30:00.0000000',1)
insert into GEDDES.Horarios values (9999,10032,'20151015','12:30:00.0000000',1)

-- ASIGNO ROL DE ADMINISTRADOR AL USER Admin
insert into GEDDES.RolXusuario values (0,2)

--ASIGNO A LOS AFILIADOS SU RESPECTIVO ROL (INCLUYENDO ADMIN)
INSERT INTO GEDDES.RolXusuario
SELECT usua_id, 1
FROM GEDDES.Usuarios, GEDDES.Afiliados
WHERE usua_id = afil_usuario

 --ASIGNO A LOS PROFESIONALES SU RESPECTIVO ROL (INCLUYENDO ADMIN)
INSERT INTO GEDDES.RolXusuario
SELECT usua_id, 3
FROM GEDDES.Usuarios, GEDDES.Profesionales
WHERE usua_id = prof_usuario

DECLARE @hash2 VARBINARY(225)
SELECT @hash2 = HASHBYTES('SHA2_256', 'afi');

update GEDDES.Usuarios set usua_username='afiliado' where usua_id=7564290401
update GEDDES.Usuarios set usua_password=@hash2 where usua_id=7564290401

DECLARE @hash3 VARBINARY(225)
SELECT @hash3 = HASHBYTES('SHA2_256', 'prof');

update GEDDES.Usuarios set usua_username='profesional' where usua_id=146592501
update GEDDES.Usuarios set usua_password=@hash3 where usua_id=146592501


/* CREO STORE PROCEDURES */

--PROCEDURE QUE CHEQUEA LOS INTENTOS
USE GD2C2016;
GO

CREATE PROCEDURE GEDDES.Login_procedure(@username VARCHAR(20) , @password VARCHAR(10))
AS
 BEGIN
	DECLARE @intentos TINYINT, @hash VARBINARY(225), @pass VARBINARY(225), @cantidad INT 
	
	SET @intentos = (SELECT usua_intentos FROM GEDDES.Usuarios WHERE usua_username = @username)
    SET @hash = HASHBYTES('SHA2_256',@password); --La que ingreso
	SET @pass = (SELECT usua_password FROM GEDDES.Usuarios WHERE usua_username = @username) -- La real

	IF(@intentos IS NULL) 	--me fijo si esta el usuario
		SET @cantidad = -1

	ELSE IF(@hash <> @pass)  --comparo las contrasenias
			BEGIN
				SET @cantidad = @intentos
				IF(@intentos<> 0)  --verifico la cantidad de ceros. si aun le quedan, hago el update
					UPDATE GEDDES.Usuarios SET usua_intentos = @intentos - 1 WHERE usua_username=@username
			END				
	ELSE
			BEGIN
			SET @cantidad = 4   --Todo bien! Contrasenia correcta!
			UPDATE GEDDES.Usuarios SET usua_intentos = 3 WHERE usua_username=@username

			END
	RETURN @cantidad
 END
GO

USE GD2C2016;
GO
CREATE PROCEDURE GEDDES.getRolesUsuario (@user VARCHAR(15))
AS
 BEGIN
	
	DECLARE @userId BIGINT -- Lo que viene por parametro es el usua_username, necesito el id para comparar con RolXusuario

	SET @userId = (SELECT usua_id FROM GEDDES.Usuarios WHERE usua_username = @user)

	SELECT rxu.role_id, r.role_nombre 
	FROM GEDDES.RolXusuario rxu, GEDDES.Roles r 
	WHERE rxu.usua_id=@userId AND rxu.role_id=r.role_id AND role_habilitado=1

 END
GO

USE GD2C2016;
GO
CREATE PROCEDURE GEDDES.getFuncionalidadXRol (@role_id int) 
AS
 BEGIN

	SELECT rxf.func_id, f.func_nombre
	FROM GEDDES.RolXfuncionalidad rxf, GEDDES.Funcionalidades f
	WHERE rxf.func_id=f.func_id AND rxf.role_id=@role_id

 END
GO

--PROCEDURE QUE DEVUELVE LOS PLANES
USE GD2C2016;
GO
CREATE PROCEDURE GEDDES.getPlanes
AS
	BEGIN 
		SELECT plan_id,plan_nombre
		FROM GEDDES.Planes
	END
GO

--PROCEDURE QUE AGREGA UN USUARIO
USE GD2C2016;
GO

CREATE PROCEDURE GEDDES.ingresarUsuario(
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
	INSERT INTO GEDDES.Usuarios(usua_id, usua_username,usua_password, usua_nombre, usua_apellido, usua_tipoDoc, usua_nroDoc, usua_direccion,
					usua_telefono,usua_fechaNacimiento, usua_sexo, usua_mail)

	VALUES(@nroDoc*100+1,@username,@pass,@nombre,@apellido,@tipoDoc,@nroDoc,@direccion, @telefono,@fechaNacimiento, @sexo, @mail)

	INSERT INTO GEDDES.RolXusuario (usua_id,role_id)
		VALUES (@nroDoc*100+1, 1)

END
GO

--PROCEDURE QUE AGREGA UN AFILIADO
USE GD2C2016;
GO
CREATE PROCEDURE GEDDES.ingresarAfiliado(@usuario BIGINT, @plan INT, @estado VARCHAR(20), @hijos INT)
AS
BEGIN
	INSERT INTO GEDDES.Afiliados(afil_usuario, afil_plan, afil_estadoCivil, afil_cantidadHijos)

	VALUES(@usuario, @plan, @estado, @hijos)	
END
GO

USE GD2C2016;
GO
--PROCEDURE QUE AGREGA UN FAMILIAR DEL AFILIADO
CREATE PROCEDURE GEDDES.agregarFamiliar(@afiliado_raiz INT, @usuario BIGINT, @plan INT, @estado VARCHAR(20), @hijos INT)
AS
BEGIN
	DECLARE @numero_nuevo_afiliado INT
	SET @numero_nuevo_afiliado = (SELECT MAX(CONVERT(INT, RIGHT(STR(afil_id),2)))
								  FROM GEDDES.Afiliados
								  WHERE afil_id = @afiliado_raiz)

	--SET @numero_nuevo_afiliado = CONVERT(INT, RIGHT(STR(@afiliado_raiz),2))

	SET IDENTITY_INSERT GEDDES.Afiliados ON

	INSERT INTO GEDDES.Afiliados(afil_id, afil_usuario, afil_plan, afil_estadoCivil, afil_cantidadHijos)
	VALUES(@afiliado_raiz+ @numero_nuevo_afiliado, @usuario, @plan,@estado,@hijos )

	SET IDENTITY_INSERT GEDDES.Afiliados OFF
END
GO



USE GD2C2016;
GO
--PROCEDURE PARA MODIFICAR AL AFILIADO
CREATE PROCEDURE GEDDES.modificarAfiliado(@username BIGINT,@direccion VARCHAR(255), @telefono DECIMAL(18,0),@plan INT, @estado VARCHAR(20), @hijos INT)
AS 
	BEGIN
		DECLARE @afil INT
		SET @afil = (SELECT afil_id FROM GEDDES.Afiliados WHERE afil_usuario = @username)

		UPDATE GEDDES.Usuarios set usua_direccion = @direccion WHERE usua_id =@username  AND (usua_direccion != @direccion OR usua_direccion IS NULL)
		--UPDATE GEDDES.Afiliados set afil_estadoCivil = @estado WHERE afil_id = @afil AND @estado != afil_estadoCivil

		UPDATE GEDDES.Usuarios set usua_telefono = @telefono WHERE usua_id =@username  AND (usua_telefono != @telefono OR usua_telefono IS NULL)
		
		UPDATE GEDDES.Afiliados set afil_estadoCivil = @estado WHERE afil_usuario = @username  AND (afil_estadoCivil != @estado
				OR afil_estadoCivil IS NULL)

	END
GO


USE GD2C2016;
GO
--PROCEDURE QUE DA DE BAJA!
CREATE PROCEDURE GEDDES.darDeBaja(@user BIGINT)
AS
BEGIN
	DECLARE @intentos INT
	SET @intentos = (SELECT TOP 1 usua_intentos FROM GEDDES.Usuarios WHERE usua_id = @user)
	IF @intentos = 0		
		RAISERROR('El usuario ya ha sido dado de baja anteriormente',16,2)
	ELSE 		
		UPDATE GEDDES.Usuarios
		SET usua_intentos = 0
		WHERE usua_id = @user
END
GO

USE GD2C2016;
GO
CREATE PROCEDURE GEDDES.eliminarAfiliado(@user BIGINT)
AS
BEGIN 
	DECLARE @afil INT

	SET @afil = (SELECT afil_id FROM GEDDES.Afiliados WHERE afil_usuario = @user)

	DELETE FROM GEDDES.HistorialAfiliado
		WHERE hist_afil = @afil

	DELETE FROM GEDDES.ComprasBonos
			WHERE comp_afil = @afil

	DELETE FROM GEDDES.Bonos
			WHERE bono_afilCompra = @afil
				OR bono_afilUsado = @afil
		
	DELETE FROM GEDDES.Turnos
			WHERE turn_afiliado = @afil
	
	DELETE FROM GEDDES.Afiliados
			WHERE afil_id = @afil

	DELETE FROM GEDDES.Usuarios
			WHERE usua_id = @user
		
	END
GO


USE GD2C2016;
GO
CREATE PROCEDURE GEDDES.registrarConsulta(@turno INT, @bono INT, @afil INT)
AS
	BEGIN 
		DECLARE @consulta INT

		INSERT INTO GEDDES.Consultas(cons_turno,cons_fechaHoraConsulta)
		VALUES(@turno, GETDATE());

		SET @consulta = (SELECT TOP 1 cons_id FROM GEDDES.Consultas WHERE cons_turno = @turno)

		UPDATE GEDDES.Bonos
			SET bono_afilUsado = @afil, bono_nroConsulta = @consulta
			WHERE bono_id = @bono


	END
GO

USE GD2C2016;
GO
CREATE PROCEDURE GEDDES.registrarResultadoConsulta(@consulta INT, @concretada TINYINT , @sintomas VARCHAR(256), @diagnostico VARCHAR(512))
AS 
BEGIN
	UPDATE GEDDES.Consultas
		SET cons_fueConcretada = @concretada, cons_sintomas = @sintomas , cons_diagnostico = @diagnostico
		WHERE cons_id = @consulta
END

GO

USE GD2C2016;
GO


CREATE PROCEDURE GEDDES.cancelar_dia_agenda(@profesional INT, @fecha Date,  @tipo INT, @motivo VARCHAR(225))
AS
 BEGIN
	--DECLARE @profesional INT = (select prof_id from GEDDES.Profesionales where prof_usuario = @usuario_id)

	-- Desactivo los turnos
 	UPDATE GEDDES.Turnos
	SET turn_activo = 0
	where turn_hora in (select hora_id from GEDDES.Horarios where hora_profesional = @profesional and hora_fecha = @fecha)

	-- Desactivo los horarios
	UPDATE GEDDES.Horarios
	SET hora_activo = 0
	where hora_id in (select hora_id from GEDDES.Horarios where hora_profesional = @profesional and hora_fecha = @fecha)

	-- Registro cancelaciones
	SET IDENTITY_INSERT GEDDES.CancelacionesTurnos ON
	DECLARE @TURNO INT
	DECLARE ct CURSOR for (select turn_id from GEDDES.Horarios join GEDDES.Turnos on (turn_hora = hora_id) where hora_profesional = @profesional and hora_fecha = @fecha)
	OPEN ct
	FETCH NEXT from ct INTO @turno
		while(@@FETCH_STATUS = 0)
		BEGIN
			INSERT INTO GEDDES.CancelacionesTurnos(canc_id,canc_turno,canc_tipo,canc_detalle) VALUES ((SELECT MAX(canc_id)+1 FROM GEDDES.CancelacionesTurnos),@turno, @tipo,@motivo)
			FETCH NEXT from ct INTO @turno
		END
	CLOSE ct
	DEALLOCATE ct
	SET IDENTITY_INSERT GEDDES.CancelacionesTurnos OFF
 END
GO



USE GD2C2016;
GO
CREATE PROCEDURE GEDDES.cancelar_turno_afiliado(@usuario BIGINT, @turno INT, @tipo INT, @motivo VARCHAR(225))
AS
 BEGIN
    SET IDENTITY_INSERT GEDDES.CancelacionesTurnos ON 
	DECLARE @afiliado INT = (select afil_id from GEDDES.Afiliados where afil_usuario = @usuario)
 	UPDATE GEDDES.Turnos
	SET turn_activo = 0
	where turn_id = @turno and turn_afiliado = @afiliado
	INSERT INTO GEDDES.CancelacionesTurnos(canc_id,canc_turno,canc_tipo,canc_detalle) VALUES ((SELECT MAX(canc_id)+1 FROM GEDDES.CancelacionesTurnos),@turno, @tipo,@motivo)
	SET IDENTITY_INSERT GEDDES.CancelacionesTurnos OFF
 END
GO

USE GD2C2016;
GO
CREATE PROCEDURE GEDDES.registrarMotivo(@afil INT, @motivo VARCHAR(255))
AS
	BEGIN 

	INSERT INTO GEDDES.HistorialAfiliado(hist_afil, hist_motivo, hist_fecha)
	VALUES (@afil,@motivo, CONVERT(DATE, SYSDATETIME()) );

	END
GO


USE GD2C2016;
GO
--FUNCION QUE DEVUELVE SI UN USUARIO TIENE FAMILIA
CREATE FUNCTION GEDDES.tieneFamilia(@usuario_id BIGINT)
RETURNS CHAR(2)
AS
BEGIN
	DECLARE @raiz BIGINT
	SET @raiz = LEFT(@usuario_id,8)
	IF EXISTS(SELECT * FROM GEDDES.Usuarios WHERE usua_id <> @usuario_id AND LEFT(usua_id,8) = @raiz)
		RETURN 'SI'
	RETURN 'NO'
END

GO


USE GD2C2016;
GO
CREATE FUNCTION GEDDES.fecha()
RETURNS CHAR(23)
AS
BEGIN
	return (select CONVERT(DATETIME, CONTEXT_INFO)
		from sys.dm_exec_sessions
		where session_id=@@SPID)
END
GO

 USE GD2C2016;
 GO
CREATE FUNCTION GEDDES.RemoverTildes (@cadena VARCHAR(100) )
RETURNS VARCHAR(100)
AS BEGIN
--Reemplazamos las vocales acentuadas
    RETURN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(@cadena, 'á', 'a'), 'é','e'), 'í', 'i'), 'ó', 'o'), 'ú','u')
 
END
GO


/* CREO TRIGGERS */
--TRIGGER QUE VERIFICA EL USUARIO
USE GD2C2016;
GO

CREATE TRIGGER GEDDES.verificarUsuario ON GEDDES.Usuarios INSTEAD OF INSERT 
AS
	BEGIN
		IF EXISTS (SELECT* FROM GEDDES.Usuarios u, inserted i WHERE u.usua_username = i.usua_username)		 
			RAISERROR('El usuario ya esta ocupado. Escriba otro nombre de usuario y vuelva a intentarlo',16,2)
		ELSE		 
			INSERT INTO GEDDES.Usuarios 
			SELECT * FROM inserted
	END 
GO


USE GD2C2016;
GO
--TRIGGER DE LA AGENDA PROFESIONAL
CREATE TRIGGER LimiteHoras ON GEDDES.Horarios INSTEAD OF INSERT
AS
BEGIN

	DECLARE @prof_id INT = (select hora_profesional from inserted)

	IF (SELECT top 1 count(*)/2
		FROM (
			(select * -- lo nuevo
			from inserted I
			where I.hora_profesional = @prof_id
				and CAST(I.hora_fecha AS DATE) >= CAST(GEDDES.fecha() AS DATE)
			)
			UNION
			(select * -- lo que ya estaba cargado
			from GEDDES.Horarios E
			where E.hora_profesional = @prof_id
				  AND E.hora_activo = 1
				  AND CAST(E.hora_fecha AS DATE) >= CAST(GEDDES.fecha() AS DATE)
			)
		) AS tabla
		group by datepart(WEEK,tabla.hora_fecha)
		order by count(*) DESC
	) >= 48
		RAISERROR('En al menos una semana, se supera el limite de 48 horas semanales por profesional.',16,1)
	ELSE
		IF (select isnull(count(*),0)
			from GEDDES.Horarios H join inserted I on (H.hora_fecha = I.hora_fecha AND H.hora_inicio = I.hora_inicio
													   AND H.hora_especialidad = I.hora_especialidad
													   AND H.hora_profesional = I.hora_profesional)
			where H.hora_profesional = @prof_id
				  AND H.hora_activo = 1) >0
			RAISERROR('El profesional ya atiende en ese dia, hora y fecha con esa especialidad.',16,7)
		ELSE
			INSERT INTO Horarios(hora_profesional,hora_especialidad,hora_fecha,hora_inicio,hora_activo) select hora_profesional, hora_especialidad, hora_fecha, hora_inicio, hora_activo from inserted
END
GO


CREATE TRIGGER GEDDES.triggerElimTurnos ON GEDDES.Turnos INSTEAD OF DELETE
AS
	BEGIN 
		DELETE FROM GEDDES.CancelacionesTurnos
			WHERE canc_turno IN (SELECT d.turn_id FROM deleted d)

		DELETE FROM GEDDES.Consultas
			WHERE cons_turno IN (SELECT d.turn_id FROM deleted d)

		DELETE FROM GEDDES.Turnos
			WHERE turn_id IN (SELECT d.turn_id FROM deleted d)

	END	
GO


USE GD2C2016;
GO
CREATE TRIGGER GEDDES.triggerEliminarUser ON GEDDES.Usuarios INSTEAD OF DELETE
AS
	BEGIN
		
		DELETE FROM GEDDES.RolXusuario
			WHERE usua_id IN (SELECT d.usua_id FROM deleted d)

		DELETE FROM GEDDES.Usuarios
			WHERE usua_id IN (SELECT d.usua_id FROM deleted d)
	
	END
GO