create database SGPI
go
use SGPI
go
create table tblDocumento(
IDDoc int primary key identity(1,1),
TipoDocumento varchar(30)
)
go
create table tblGenero(
IDGenero int primary key identity(1,1),
Genero varchar(30)
)
go
create table tblRol(
IDRol int primary key identity(1,1),
Rol varchar(50)
)
go
create table tblPrograma(
IDPrograma int primary key,
Programa varchar(100)
)
go
create table tblUsuario(
IDUsuario int primary key identity(1,1),
numeroDocumento varchar(30),
IDDoc int,
primerNombre varchar(255),
segundoNombre varchar(255),
primerApellido varchar (255),
segundoApellido varchar(255),
IDGenero int,
Email varchar (255),
IDRol int,
Clave varchar(255),
IDPrograma int,
foreign key (IDGenero) references tblGenero(IDGenero),
foreign key (IDRol) references tblRol(IDRol),
foreign key (IDPrograma) references tblPrograma(IDPrograma),
foreign key (IDDoc) references tblDocumento(IDDoc)
)
go
create table tblPagos(
IDPago int primary key identity(1,1),
ValorPago int,
Fecha date,
Estado bit
)
go
create table tblEstudiante(
IDEstudiante int primary key identity(1,1),
Archivo varchar(500),
IDPago int,
IDUsuario int,
Egresado bit,
foreign key (IDUsuario) references tblUsuario(IDUsuario),
foreign key (IDPago) references tblPagos(IDPago)
)
go
create table tblEntrevista(
IDEntrevista int primary key identity(1,1),
IDUsuario int,
IDEstudiante int,
fecha date,
foreign key (IDUsuario) references tblUsuario(IDUsuario),
foreign key (IDEstudiante) references tblEstudiante (IDEstudiante)
)
go
create table tblTipoHomologacion(
IDTipoHomologacion int primary key identity(1,1),
TipoHomologacion varchar(100)
)
go
create table tblAsignatura(
IDAsignatura int primary key identity(1,1),
Nombre varchar (30),
Codigo varchar (150),
IDPrograma int,
Nivel int,
Creditos int,
foreign key (IDPrograma) references tblPrograma (IDPrograma)
)
go
create table tblProgramacion(
IDProgramacion int primary key identity(1,1),
PeriodoAcademico varchar(30),
IDPrograma int,
FechaProgramacion datetime,
sala varchar (30),
IDAsignatura int,
IDUsuario  int,
foreign key (IDPrograma) references tblPrograma(IDPrograma),
foreign key (IDAsignatura) references tblAsignatura(IDAsignatura),
foreign key (IDUsuario) references tblUsuario (IDUsuario)
)
go
create table tblHomologacion(
IDHomologacion int primary key identity(1,1),
IDEstudiante int,
IDPrograma int,
IDTipoHomologacion int,
PerdiodoAcademico varchar(30),
IDAsignatura int,
CodigoHomologacion varchar(30),
NomAsigHomologacion varchar(30),
CreditosHomologacion int,
nota float(53)
foreign key (IDEstudiante) references tblEstudiante(IDEstudiante),
foreign key (IDPrograma) references tblPrograma(IDPrograma),
foreign key (IDTipoHomologacion) references tblTipoHomologacion(IDTipoHomologacion),
foreign key (IDAsignatura) references tblAsignatura(IDAsignatura)
)
go
insert into tblPrograma (IDPrograma, Programa) values (102735,'Especializacion seguridad de la informacion')
insert into tblPrograma (IDPrograma, Programa) values (106409,'Maestría en Gestión del Riesgo y Medio Ambiente')
insert into tblPrograma (IDPrograma, Programa) values (105966,'Maestría en Gestión de Tecnología de la Información')

insert into tblGenero (Genero) values ('Masculino')
insert into tblGenero (Genero) values ('Femenino')
insert into tblGenero (Genero) values ('Otro')

insert into tblDocumento values ('Cedula de Ciudadania')
insert into tblDocumento values ('Cedula de Extranjeria')
insert into tblDocumento values ('Tarjeta de Identidad')
insert into tblDocumento values ('Nit')
insert into tblDocumento values ('Pasaporte')

insert into tblRol values ('Administrador')
insert into tblRol values ('Coordinador')
insert into tblRol values ('Estudiante')


insert into tblUsuario values (1,1,'Mauricio', 'José', 'Amariles', 'Camacho',1,'mauricio.amariles@tdea.edu.co',1,'1',102735)
insert into tblUsuario values (12,1,'Manuel', 'Alexander', 'Valbuena', 'Henao',1,'manuel.valbuena@tdea.edu.co',2,'12',102735)
insert into tblUsuario values (123,1,'Nelson', 'David', 'Alvarez', 'Rincon',1,'nelson.alvarez@correo.tdea.edu.co',3,'123',102735)
