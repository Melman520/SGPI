create database SGPI
go
use SGPI
go
create table documento(
IDDoc int primary key identity(1,1),
TipoDocumento varchar(30)
)
go
create table genero(
IDGenero int primary key identity(1,1),
Genero varchar(30)
)
go
create table rol(
IDRol int primary key identity(1,1),
Rol varchar(50)
)
go
create table programa(
IDPrograma int primary key,
Programa varchar(100)
)
go
create table usuario(
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
foreign key (IDGenero) references genero(IDGenero),
foreign key (IDRol) references rol(IDRol),
foreign key (IDPrograma) references programa(IDPrograma),
foreign key (IDDoc) references documento(IDDoc)
)
go
create table pagos(
IDPago int primary key identity(1,1),
ValorPago int,
Fecha date,
Estado bit
)
go
create table estudiante(
IDEstudiante int primary key identity(1,1),
Archivo varchar(500),
IDPago int,
IDUsuario int,
Egresado bit,
foreign key (IDUsuario) references usuario(IDUsuario),
foreign key (IDPago) references pagos(IDPago)
)
go
create table entrevista(
IDEntrevista int primary key identity(1,1),
IDUsuario int,
IDEstudiante int,
fecha date,
foreign key (IDUsuario) references usuario(IDUsuario),
foreign key (IDEstudiante) references estudiante (IDEstudiante)
)
go
create table tipoHomologacion(
IDTipoHomologacion int primary key identity(1,1),
TipoHomologacion varchar(100)
)
go
create table Asignatura(
IDAsignatura int primary key identity(1,1),
Nombre varchar (30),
Codigo varchar (150),
IDPrograma int,
Nivel int,
Creditos int,
foreign key (IDPrograma) references programa (IDPrograma)
)
go
create table Programacion(
IDProgramacion int primary key identity(1,1),
PeriodoAcademico varchar(30),
IDPrograma int,
FechaProgramacion datetime,
sala varchar (30),
IDAsignatura int,
IDUsuario  int,
foreign key (IDPrograma) references programa(IDPrograma),
foreign key (IDAsignatura) references asignatura(IDAsignatura),
foreign key (IDUsuario) references usuario (IDUsuario)
)
go
create table homologacion(
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
foreign key (IDEstudiante) references estudiante(IDEstudiante),
foreign key (IDPrograma) references programa(IDPrograma),
foreign key (IDTipoHomologacion) references tipoHomologacion(IDTipoHomologacion),
foreign key (IDAsignatura) references asignatura(IDAsignatura)
)
go
insert into programa (IDPrograma, Programa) values (102735,'Especializacion seguridad de la informacion')
insert into programa (IDPrograma, Programa) values (106409,'Maestría en Gestión del Riesgo y Medio Ambiente')
insert into programa (IDPrograma, Programa) values (105966,'Maestría en Gestión de Tecnología de la Información')

insert into genero (Genero) values ('Masculino')
insert into genero (Genero) values ('Femenino')
insert into genero (Genero) values ('Otro')