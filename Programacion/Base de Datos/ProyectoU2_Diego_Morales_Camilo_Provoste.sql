-- Proyecto de Unidad 2 para Base de Datos sección B
-- Profesor: Cristian Vidal
-- Hecho por Diego Morales y Camilo Provoste

create database ProyectoU2;
use ProyectoU2;
-- Nota: Se tuvo que corregir las tablas de relación que no correspondían y fueron incluidas en el modelo relacional, para lo que fueron creadas llaves foraneas.

-- Necesario para la liberad de updates y deletes
SET SQL_SAFE_UPDATES = 0;

create table Doctor(
	ID varchar(20) primary key,
    Nombre varchar(20) not null,
    Especialización varchar (30) not null,
    Horario_de_atención varchar(20),
    Rut varchar(12) not null,
    Número_de_casa int not null,
    Calle varchar(20) not null,
    Ciudad varchar(20) not null
);

create table Enfermero(
	ID varchar(20) primary key,
    Nombre varchar(20) not null,
	Rut varchar(12) not null,
    Horario_de_atención varchar(20),
    Número_de_casa int not null,
    Calle varchar(20) not null,
    Ciudad varchar(20) not null
);

create table NúmeroDeTelefonoEnfermero(
	ID varchar(20) not null,
    NúmeroDeTelefono varchar(15) not null,
    
    foreign key (ID) references Enfermero(ID) on delete cascade on update cascade,
    primary key (ID)
);

create table Paramedico(
	ID varchar(20) primary key,
    Nombre varchar(20) not null,
    Rut varchar(12) not null,
    Horario_de_atención varchar(20),
    Certificación varchar (30) not null,
    Número_de_casa int not null,
    Calle varchar(20) not null,
    Ciudad varchar(20) not null
);

create table NúmeroTelefonoParamedico(
	ID varchar(20) not null,
    NúmeroDeTelefono varchar(15) not null,
    
    foreign key (ID) references Paramedico(ID) on delete cascade on update cascade,
    primary key (ID)
);

create table Sala(
	Código varchar(10) primary key,
    Tipo varchar(20) not null,
    Capacidad_de_pacientes int not null,
    Nombre_de_paciente varchar(20) not null,
    Fecha date,
    Hora_de_entrada time,
    Hora_de_salida time,
    Diagnóstico varchar(20),
    Tratamiento varchar(20)
);

create table Farmacia(
	ID varchar(20) primary key,
    Horario_de_atencion varchar(20),
    Ubicacion varchar(30) not null,
    Capacidad_de_stock int,
    Lista_de_medicamentos varchar(200)
);

create table NúmeroDeTelefonoDeFarmacia(
	ID varchar(20) primary key,
    NúmeroDeTelefono varchar(15) not null,
    foreign key(ID) references Farmacia(ID) on delete cascade on update cascade
);

create table Recepcionista(
	Rut varchar(12) primary key,
    Departamento_médico varchar(20),
    Horario varchar(20),
    Primer_nombre varchar(20) not null,
    Primer_apellido varchar(20) not null,
    Segundo_apellido varchar(20)
);

create table NúmeroDeTelefonoDeRecepcionista(	
	Rut varchar(20) primary key,
    NúmeroDeTelefono varchar(15) not null,
    foreign key(Rut) references Recepcionista(Rut) on delete cascade on update cascade
);

create table Ambulancia(			
	Patente varchar(6) primary key,
    Marca varchar(20),
    Modelo varchar(20),
    Ubicación_actual varchar(20),
    Disponibilidad bool not null,
    Hora_de_llamada time,
    Día_de_llamada int,
    Mes_de_llamada int,
    Año_de_llamada int
);

create table Conduce(
	IDParamedico varchar(20) not null,
    Patente varchar(6) not null,
    
    foreign key(IDParamedico) references Paramedico(ID) on delete cascade on update cascade,
    foreign key(Patente) references Ambulancia(Patente) on delete cascade on update cascade,
    primary key(IDParamedico, Patente)
);

create table Paciente(
	Rut varchar(12) primary key,
    Nombre varchar(20) not null,
    Pago int not null,
    Problema varchar(30) not null,
    Historia_clínica varchar(30),
    Número_de_casa int,
    Calle varchar(20),
    Ciudad varchar(20) not null,
    CódigoSala varchar(10) not null,
    Patente varchar(6) not null,
    
    foreign key(CódigoSala) references Sala(Código) on delete cascade on update cascade,
    foreign key(Patente) references Ambulancia(Patente) on delete cascade on update cascade
);

create table NúmeroDeTelefonoDePaciente(
	Rut varchar(20) primary key,
    NúmeroDeTelefono varchar(15) not null,
    foreign key(Rut) references Paciente(Rut) on delete cascade on update cascade
);


create table DAtiendeP(
	RutPaciente varchar(12) not null,
	IDDoctor varchar(20) not null,
    
    foreign key(RutPaciente) references Paciente(Rut) on delete cascade on update cascade,
    foreign key(IDDoctor) references Doctor(ID) on delete cascade on update cascade,
    primary key(RutPaciente, IDdoctor)
);

create table EAtiendeP(
	RutPaciente varchar(12) not null,
    IDEnfermero varchar(20) not null,
    
    foreign key(RutPaciente) references Paciente(Rut) on delete cascade on update cascade,
    foreign key(IDEnfermero) references Enfermero(ID) on delete cascade on update cascade,
    primary key(RutPaciente,IDEnfermero) 
);

create table EAsisteD(
	IDEnfermero varchar(20) not null,
    IDDoctor varchar(20) not null,
    
    foreign key(IDEnfermero) references Enfermero(ID) on delete cascade on update cascade,
    foreign key(IDDoctor) references Doctor(ID) on delete cascade on update cascade,
    primary key(IDEnfermero, IDDoctor) 
);

create table PAtiendeP(
	RutPaciente varchar(12) not null,
    IDParamedico varchar(20) not null,
    
    foreign key(RutPaciente) references Paciente(Rut) on delete cascade on update cascade,
    foreign key(IDParamedico) references Paramedico(ID) on delete cascade on update cascade,
    primary key(RutPaciente,IDParamedico) 
);

create table Medicamento(
	Código_en_bodega varchar(10) primary key,
    Nombre varchar(30) not null,
    Fecha_de_caducidad date not null,
    Instrucciones_de_uso varchar(100),
    Integredientes varchar(400) not null,
    Fórmula_farmaceutica varchar(20),
    IDFarmacia varchar(20) not null,
    IDDoctor varchar(20) not null,
    
    foreign key (IDFarmacia) references Farmacia(ID) on delete cascade on update cascade,
    foreign key (IDDoctor) references Doctor(ID) on delete cascade on update cascade
);

create table Cita_medica(
	ID varchar(20) primary key,
    Motivo varchar(20) not null,
    Pago int not null,
    Departamento_medico varchar(20),
    Día int not null,
    Mes int not null,
    Año int not null,
	RutPaciente varchar(12) not null,
    CódigoSala varchar(10) not null,
    RutRecepcionista varchar(12) not null,
    IDDoctor varchar(20) not null,
    
    foreign key(RutPaciente) references Paciente(Rut) on delete cascade on update cascade,
    foreign key(CódigoSala) references Sala(Código) on delete cascade on update cascade,
    foreign key(RutRecepcionista) references Recepcionista(Rut) on delete cascade on update cascade,
    foreign key(IDDoctor) references Doctor(ID) on delete cascade on update cascade
);

-- Doctor
insert into Doctor(ID,Nombre,Especialización,Horario_de_atención,Rut,Número_de_casa,Calle,Ciudad) values("123","Juan Carlos Bodoque","Neurocirujano","12:00-13:00","11",02,"AAA","loquendocity");
insert into Doctor(ID,Nombre,Especialización,Horario_de_atención,Rut,Número_de_casa,Calle,Ciudad) values("113","William Birkin","Medico General","12:00-00:00","12",675,"BBB","Racoon City");
insert into Doctor(ID,Nombre,Especialización,Horario_de_atención,Rut,Número_de_casa,Calle,Ciudad) values("143","Maki Gero","Medico General","06:00-18:00","13",657,"CCC","Ciudad Capital");
insert into Doctor(ID,Nombre,Especialización,Horario_de_atención,Rut,Número_de_casa,Calle,Ciudad) values("153","Joseph Conrad","Medico General","12:00-19:00","14",3453,"DDD","Ginsei");
insert into Doctor(ID,Nombre,Especialización,Horario_de_atención,Rut,Número_de_casa,Calle,Ciudad) values("163","James Marcus","Cardiología Clínica","07:30-15:30","15",123,"EEE","Silent Hill");

update Doctor
	set Nombre = 'Alejandro Martinez'
		where ID = '143';
update Doctor
	set Horario_de_atención = '16:00-02:00'
		where ID = '113';
update Doctor
	set Número_de_casa = 224
		where ID = '163';

delete from Doctor
	where Nombre = 'Joseph Conrad';

-- Enfermero
insert into Enfermero(ID,Nombre,Horario_de_atención,Rut,Número_de_casa,Calle,Ciudad) values("129","Mario Hugo","12:00-13:00","5",03,"BBB","loquendocity");
insert into NúmeroDeTelefonoEnfermero values("129","21123456");
insert into Enfermero(ID,Nombre,Horario_de_atención,Rut,Número_de_casa,Calle,Ciudad) values("816","Lisa Garland","14:00-20:00","6",567,"CCC","Silent Hill");
insert into NúmeroDeTelefonoEnfermero values("816","34567898");
insert into Enfermero(ID,Nombre,Horario_de_atención,Rut,Número_de_casa,Calle,Ciudad) values("701","Monica Santos","11:00-19:30","7",2356,"DDD","San Bernardo");
insert into NúmeroDeTelefonoEnfermero values("701","98765458");
insert into Enfermero(ID,Nombre,Horario_de_atención,Rut,Número_de_casa,Calle,Ciudad) values("346","Marivelle Sanchez","10:00-17:30","8",8070,"EEE","Cumpeo");
insert into NúmeroDeTelefonoEnfermero values("346","2395868607");
insert into Enfermero(ID,Nombre,Horario_de_atención,Rut,Número_de_casa,Calle,Ciudad) values("937","Hugo Chavez","09:00-21:00","9",57465,"FFF","Racoon City");
insert into NúmeroDeTelefonoEnfermero values("937","923874823459");

update Enfermero
	set Nombre = 'Carlos Santana'
		where ID = '816';
update Enfermero
	set Horario_de_atención = '13:00-18:00'
		where ID = '129';
update Enfermero
	set Número_de_casa = 148
		where ID = '346';

delete from Enfermero
	where ID = '937';

update NúmeroDeTelefonoEnfermero
	set NúmeroDeTelefono = '839012830'
		where ID = '701';
update NúmeroDeTelefonoEnfermero
	set NúmeroDeTelefono = '2138710923'
		where ID = '346';
update NúmeroDeTelefonoEnfermero
	set ID = '129'
		where NúmeroDeTelefono = '923874823459';
        
delete from NúmeroDeTelefonoEnfermero
	where NúmeroDeTelefono = 923874823459;

-- Paramedico
insert into Paramedico(ID,Nombre,Rut,Horario_de_atención,Certificación,Número_de_casa,Calle,Ciudad) values("01","Alexia","001","07:00-17:50","Basico",11,"1000","Monopoly");
insert into NúmeroTelefonoParamedico values("01","23477777777");
insert into Paramedico(ID,Nombre,Rut,Horario_de_atención,Certificación,Número_de_casa,Calle,Ciudad) values("02","Albert","002","08:00-18:50","Avanzado",22,"1100","loquendocity");
insert into NúmeroTelefonoParamedico values("02","12414111111");
insert into Paramedico(ID,Nombre,Rut,Horario_de_atención,Certificación,Número_de_casa,Calle,Ciudad) values("03","Nina","003","09:00-19:50","Competente",33,"1200","Tangamandapio");
insert into NúmeroTelefonoParamedico values("03","74875948888");
insert into Paramedico(ID,Nombre,Rut,Horario_de_atención,Certificación,Número_de_casa,Calle,Ciudad) values("04","Claire","004","10:00-20:00","Profesional",44,"1300","Racoon City");
insert into NúmeroTelefonoParamedico values("04","56780000000");
insert into Paramedico(ID,Nombre,Rut,Horario_de_atención,Certificación,Número_de_casa,Calle,Ciudad) values("05","Jill","005","11:00-21:00","Experto",55,"1400","Racoon City");
insert into NúmeroTelefonoParamedico values("05","76787999999");

Update Paramedico
	set Nombre = 'Gabriela'
		where ID = '03';
Update Paramedico
	set Certificación = 'Experto'
		where ID = '01';
Update Paramedico
	set Calle = 'Agustinas'
		where ID = '04';

delete from Paramedico
	where Nombre = 'Jill';

Update NúmeroTelefonoParamedico
	set NúmeroDeTelefono = '1232567'
		where ID = '02';
Update NúmeroTelefonoParamedico
	set NúmeroDeTelefono = '9482'
		where ID = '01';
Update NúmeroTelefonoParamedico
	set NúmeroDeTelefono = '67290183'
		where ID = '04';

delete from NúmeroTelefonoParamedico
	where ID = '03';

-- Sala
insert into Sala(Código,Tipo, Capacidad_de_pacientes,Nombre_de_paciente,Fecha,Hora_de_entrada,Hora_de_salida,Diagnóstico,Tratamiento) values("111","Urgencias",30,"James Sunderland","2002-11-13","08:32:07","23:00:01","Problema cardíaco","Antihipertensivo");
insert into Sala(Código,Tipo, Capacidad_de_pacientes,Nombre_de_paciente,Fecha,Hora_de_entrada,Hora_de_salida,Diagnóstico,Tratamiento) values("112","Sala de espera",150,"Mariano Banano","2022-12-14","09:10:30","00:00:02","infeccion","jarabe medisol");
insert into Sala(Código,Tipo, Capacidad_de_pacientes,Nombre_de_paciente,Fecha,Hora_de_entrada,Hora_de_salida,Diagnóstico,Tratamiento) values("113","Sala de espera",250,"Heather Mason","2021-10-16","10:20:02","15:10:10","Embarazo","Gonadotropinas");
insert into Sala(Código,Tipo, Capacidad_de_pacientes,Nombre_de_paciente,Fecha,Hora_de_entrada,Hora_de_salida,Diagnóstico,Tratamiento) values("114","Sala de espera",20,"Angela Orosco","2001-09-20","08:15:05","15:00:15","Estres Laboral","Licencia de descanso");
insert into Sala(Código,Tipo, Capacidad_de_pacientes,Nombre_de_paciente,Fecha,Hora_de_entrada,Hora_de_salida,Diagnóstico,Tratamiento) values("115","Sala de Cirugia",10,"Tulio Triviño","2023-11-11","06:00:10","12:00:11","Conmoción cerebral","Rehabilitación");

Update Sala
	set Capacidad_de_pacientes = '75'
		where Código = '115';
Update Sala
	set Hora_de_salida = '15:00:02'
		where Código = '112';
Update Sala
	set Diagnóstico = 'Gripe'
		where Código = '114';

delete from Sala
	where Tipo = 'Sala de espera' and Capacidad_de_pacientes = 250;

-- Farmacia
insert into Farmacia(ID,Horario_de_atencion,Ubicacion,Capacidad_de_stock,Lista_de_medicamentos) values("201","06:00-00:00","DelPerro",300,"Captopril,Ovitrelle, Sumatriptán, Abrilar, Dhiquitolina, Desinoxil, Vatadina, Pixiniclonidil, Adenos, Vravos....");
insert into NúmeroDeTelefonoDeFarmacia values("201","1231213");
insert into Farmacia(ID,Horario_de_atencion,Ubicacion,Capacidad_de_stock,Lista_de_medicamentos) values("202","06:00-22:00","1000",500,"Captopril, Sumatriptán, Diazepam, Abrilar, Viagra, Vinitolina, Bonaxiniricoxis, Musipinichin, Vatadina, Malesa....");
insert into NúmeroDeTelefonoDeFarmacia values("202","32513441");
insert into Farmacia(ID,Horario_de_atencion,Ubicacion,Capacidad_de_stock,Lista_de_medicamentos) values("203","06:00-23:00","BBB",150,"Ovitrelle, Sumatriptán, Diazepam, Abrilar, Chiquinixa, Amoxixilina, Gorgotina, Globulina, Naxidinas, Entropinas....");
insert into NúmeroDeTelefonoDeFarmacia values("203","1241214 ");
insert into Farmacia(ID,Horario_de_atencion,Ubicacion,Capacidad_de_stock,Lista_de_medicamentos) values("204","06:00-19:00","CCC",90,"Captopril, Ovitrelle, Sumatriptán, Diazepam, Amoxixilina, Bion4, Adidininotina, Frashzteuz, Brankz, Sheturin, Suerin, Lininotinas....");
insert into NúmeroDeTelefonoDeFarmacia values("204","45142412");
insert into Farmacia(ID,Horario_de_atencion,Ubicacion,Capacidad_de_stock,Lista_de_medicamentos) values("205","06:00-01:00","Hospital de loquendocity",1500,"Captopril, Ovitrelle, Sumatriptán, Diazepam, Abrilar, Dixinotinininina, Aspirina, Aspiradoranina, Sheturin, Lininotinas, Entropinas, Vinitolina, Bonaxiniricoxis, Musipinichin, Vatadina, Enonaninas....");
insert into NúmeroDeTelefonoDeFarmacia values("205","14114412");

Update Farmacia
	set Capacidad_de_stock = 120
		where ID = '204';
Update Farmacia
	set Horario_de_atencion = '17:00-19:00'
		where ID = 202;
Update Farmacia
	set Ubicacion = 'Plaza de armas'
		where ID = '201';

delete from Farmacia
	where Ubicacion = 'CCC';

Update NúmeroDeTelefonoDeFarmacia
	set NúmeroDeTelefono = '218301'
		where ID = '201';
Update NúmeroDeTelefonoDeFarmacia
	set NúmeroDeTelefono = '1280371'
		where ID = '202';
Update NúmeroDeTelefonoDeFarmacia
	set NúmeroDeTelefono = '14114412'
		where ID = '203';

delete from NúmeroDeTelefonoDeFarmacia
	where NúmeroDeTelefono = '205';

-- Recepcionista y su número de telefono
insert into Recepcionista values('320','Cardiología','09:00-16:00','Matías','Peñaloza','Avila');
insert into NúmeroDeTelefonoDeRecepcionista values('320','135');
insert into Recepcionista values('321','General','10:00-17:00','Matías','Mendez','Guitierrez');
insert into NúmeroDeTelefonoDeRecepcionista values('321','1235');
insert into Recepcionista values('322','General','09:00-13:00','Felipe','Mendez','Oliva');
insert into NúmeroDeTelefonoDeRecepcionista values('322','1345');
insert into Recepcionista values('323','Neurología','09:00-18:00','Hugo','Veloso','Cancino');
insert into NúmeroDeTelefonoDeRecepcionista values('323','1535');
insert into Recepcionista values('324','General','09:00-17:00','Benjamín','Salazar','Fernandez');
insert into NúmeroDeTelefonoDeRecepcionista values('324','1635');

Update Recepcionista
	set Primer_Nombre = 'Alonso'
		where Rut = '324';
Update Recepcionista
	set Departamento_médico = 'Neurología'
		where Rut = '321';
Update Recepcionista
	set Horario = '14:00-19:00'
		where Rut = '322';

delete from Recepcionista
	where Primer_Apellido = 'Mendez' and Segundo_Apellido = 'Oliva';

Update NúmeroDeTelefonoDeRecepcionista
	set NúmeroDeTelefono = '59574907'
		where Rut = '320';
Update NúmeroDeTelefonoDeRecepcionista
	set NúmeroDeTelefono = '49872907'
		where Rut = '324';
Update NúmeroDeTelefonoDeRecepcionista
	set Rut = '323'
		where NúmeroDeTelefono = '1345';

delete from NúmeroDeTelefonoDeRecepcionista
	where Rut = '323' and NúmeroDeTelefono = '1345';

-- Ambulancia
insert into Ambulancia values('BBBB10','Ford','F-350','Garage',True,'06:01:00',01,01,2021);
insert into Ambulancia values('GTBC25','Ford','F-450','Garage',True,'03:17:43',04,10,2020);
insert into Ambulancia values('HBLB30','Ford','G-610','Parque',False,'17:5:35',10,05,2023);
insert into Ambulancia values('JR5903','Ford','B-950','Garage',True,'20:56:03',19,07,2019);
insert into Ambulancia values('GZTH57','Ford','D-540','Plaza',False,'06:01:00',29,01,2023);

Update Ambulancia
	set Ubicación_actual = 'Plaza de armas'
		where Patente = 'HBLB30';
Update Ambulancia
	set Día_de_llamada = 19
		where Patente = 'GZTH57';
Update Ambulancia
	set Modelo = 'XY-140'
		where Patente = 'GTBC25';
        
delete from Ambulancia
	where Modelo = 'XY-140';

-- Conduce
insert into Conduce values('01','BBBB10');
insert into Conduce values('02','GTBC25');
insert into Conduce values('03','HBLB30');
insert into Conduce values('04','JR5903');
insert into Conduce values('05','GZTH57');

Update Conduce
	set IDParamedico = '05'
		where Patente = 'HBLB30';
Update Conduce
	set IDParamedico = '03'
		where Patente = 'GTBC25';
Update Conduce
	set IDParamedico = '02'
		where Patente = 'GZTH57';

delete from Conduce
	where Patente = 'GZTH57';

-- Pacientes y numero de telefono de pacientes
insert into Paciente(Rut,Nombre,Pago,Problema,Historia_clínica,Número_de_casa,Calle,Ciudad,CódigoSala, Patente) values("15","Tulio Triviño",2000000,"Trauma Craneal","retraso mental severo",13,"DelPerro","loquendocity","115","BBBB10");
insert into NúmeroDeTelefonoDePaciente values("15","9834");
insert into Paciente(Rut,Nombre,Pago,Problema,Historia_clínica,Número_de_casa,Calle,Ciudad,CódigoSala, Patente) values("14","Mariano Banano",20000,"Tos","Alergia al jarabe citanol",987,"calle 7","loquendocity","112","GTBC25");
insert into NúmeroDeTelefonoDePaciente values("14","234");
insert into Paciente(Rut,Nombre,Pago,Problema,Historia_clínica,Número_de_casa,Calle,Ciudad,CódigoSala, Patente) values("13","Angela Orosco",0,"Migraña","problemas psiquiatricos",797,"NY.Law","Silent Hill","114","HBLB30");
insert into NúmeroDeTelefonoDePaciente values("13","2345");
insert into Paciente(Rut,Nombre,Pago,Problema,Historia_clínica,Número_de_casa,Calle,Ciudad,CódigoSala, Patente) values("69","James Sunderland",600,"Paro cardiaco","Problemas cardiacos heredados",661,"Alquemira","Silent Hill","111","JR5903");
insert into NúmeroDeTelefonoDePaciente values("69","8765");
insert into Paciente(Rut,Nombre,Pago,Problema,Historia_clínica,Número_de_casa,Calle,Ciudad,CódigoSala, Patente) values("11","Heather Mason",0,"Dolor de estomago","Problemas psiquiatricos",662,"RavenHeaven","Silent Hill","113","GZTH57");
insert into NúmeroDeTelefonoDePaciente values("11","345678");

update Paciente
	set Ciudad = 'Talca'
		where Rut = '15';
update Paciente
	set Pago = 1500000
		where Rut = '13';
update Paciente
	set Nombre = 'Camilo Provoste'
		where Rut = '11';

delete from Paciente
	where Rut = '69';

update NúmeroDeTelefonoDePaciente
	set NúmeroDeTelefono = '132'
		where Rut = '15';
update NúmeroDeTelefonoDePaciente
	set NúmeroDeTelefono = '451'
		where Rut = '13';
update NúmeroDeTelefonoDePaciente
	set NúmeroDeTelefono = '985'
		where Rut = '69';

delete from NúmeroDeTelefonoDePaciente
	where NúmeroDeTelefono = '2345';

-- Doctor atiende a paciente
insert into DAtiendeP values("15","123");
insert into DAtiendeP values("14","113");
insert into DAtiendeP values("13","143");
insert into DAtiendeP values("69","163");
insert into DAtiendeP values("11","153");

update DAtiendeP
	set RutPaciente = '14'
		where RutPaciente = '13' and IDDoctor = '143';
update DAtiendeP
	set RutPaciente = '13'
		where RutPaciente = '13' and IDDoctor = '113';
update DAtiendeP
	set RutPaciente = '11'
		where RutPaciente = '15' and IDDoctor = '123';

delete from DAtiendeP
	where IDDoctor = '163';

-- Enfermero atiende a paciente
insert into EAtiendeP values("15","129");
insert into EAtiendeP values("14","816");
insert into EAtiendeP values("13","701");
insert into EAtiendeP values("69","346");
insert into EAtiendeP values("11","937");

update EAtiendeP
	set IDEnfermero = '701'
		where RutPaciente = '15';
Update EAtiendeP
	set IDEnfermero = '129'
		where RutPaciente = '13';
Update EAtiendeP
	set RutPaciente = '69'
		where IDEnfermero = '346';

delete from EAtiendeP
	where RutPaciente = '13';

-- Enfermero asiste a doctor
insert into EAsisteD values("129","113");
insert into EAsisteD values("816","123");
insert into EAsisteD values("701","143");
insert into EAsisteD values("346","153");
insert into EAsisteD values("937","163");

Update EAsisteP
	set IDEnfermero = '816'
		where IDDoctor = '113';
Update EAsisteP
	set IDEnfermero = '129'
		where IDDoctor = '123';
Update EAsisteP
	set IDDoctor = '143'
		where IDEnfermero = '937';

delete from EAsisteD
	where IDEnfermero = '816';

-- Paramedico atiende a paciente
insert into PAtiendeP values("15","01");
insert into PAtiendeP values("14","02");
insert into PAtiendeP values("13","03");
insert into PAtiendeP values("69","04");
insert into PAtiendeP values("11","05");

Update PAtiendeP
	set RutPaciente = '15'
		where IDParamedico = '05';
Update PAtiendeP
	set RutPaciente = '11'
		where IDParamedico = '01';
Update PAtiendeP
	set IDParamedico = '04'
		where RutPaciente = '13';

delete from PAtiendeP
	where IDParamedico = '14';

-- Medicamento
insert into Medicamento(Código_en_bodega,Nombre,Fecha_de_caducidad,Instrucciones_de_uso,Integredientes,Fórmula_farmaceutica,IDFarmacia,IDDoctor) values("111","Captopril","2077-11-08","via oral","almidón de maíz sin gluten, celulosa microcristalina, lactosa monohidrato y ácido esteárico.","C9H15NO3S","203","163");
insert into Medicamento(Código_en_bodega,Nombre,Fecha_de_caducidad,Instrucciones_de_uso,Integredientes,Fórmula_farmaceutica,IDFarmacia,IDDoctor) values("444","Ovitrelle","2077-11-08","via inyeccion","coriogonadotropina alfa","hCG2","204","153");
insert into Medicamento(Código_en_bodega,Nombre,Fecha_de_caducidad,Instrucciones_de_uso,Integredientes,Fórmula_farmaceutica,IDFarmacia,IDDoctor) values("222","Sumatriptán","2077-11-08","via inyeccion","lactosa monohidrato, celulosa microcristalina, croscarmelosa sódica, estearato magnésico, óxido de hierro ","C14H21N3O2S","201","143");
insert into Medicamento(Código_en_bodega,Nombre,Fecha_de_caducidad,Instrucciones_de_uso,Integredientes,Fórmula_farmaceutica,IDFarmacia,IDDoctor) values("333","Diazepam","2077-11-08","via oral","almidón de maíz, carmelosa sódica, lactosa monohidrato, povidona y estearato","C16H13ClN2O","205","123");
insert into Medicamento(Código_en_bodega,Nombre,Fecha_de_caducidad,Instrucciones_de_uso,Integredientes,Fórmula_farmaceutica,IDFarmacia,IDDoctor) values("555","Abrilar","2077-11-08","via oral","extracto de Hedera hélix; sorbato de potasio, ácido cítrico anhidro sorbitol, goma de xantan","C12GH56GD3SD","205","113");

 
Update Medicamento
	set Fecha_de_caducidad = '21-11-2023'
		where Código_en_bodega = '444';
Update Medicamento
	set IDDoctor = '113'
		where Código_en_bodega = '222';
Update Medicamento
	set Nombre = 'Valium'
		where Código_en_bodega = '333';

delete from Medicamento
	where Instrucciones_de_uso = 'via inyeccion';

-- Cita medica
insert into Cita_medica values('1','Trauma Creaneal',2000000,'Neurocirujía',28,01,2004,'15','115','323','123');
insert into Cita_medica values('2','Tos',20000,'General',20,12,2020,'14','112','321','113');
insert into Cita_medica values('3','Migraña',0,'General',13,05,2019,'13','113','324','143');
insert into Cita_medica values('4','Paro cardiaco',600,'Cardiología',18,09,2023,'69','111','320','163');
insert into Cita_medica values('5','Dolor de estomago',0,'General',5,3,2023,'11','114','323','153');

Update Cita_medica
	set Motivo = 'Imnomnia'
		where ID = '5';
Update Cita_medica
	set RutPaciente = '13'
		where ID = '2';
Update Cita_medica
	set Pago = '1500000'
		where ID = '3';
    
delete from Cita_medica
	where RutPaciente = '13' and Pago = '0';

-- select table
select * from Paciente;
select * from NúmeroDeTelefonoDePaciente;
select * from Doctor;
select * from DAtiendeP;
select * from Enfermero;
select * from NúmeroDeTelefonoEnfermero;
select * from EAtiendeP;
select * from EAsisteD;
select * from Paramedico;
select * from NúmeroTelefonoParamedico;
select * from PAtiendeP;
select * from Sala;
select * from Medicamento;
select * from Farmacia;
select * from NúmeroDeTelefonoDeFarmacia;
select * from Recepcionista;
select * from NúmeroDeTelefonoDeRecepcionista;
select * from Cita_medica;
select * from Ambulancia;
select * from Conduce;

-- select simple--

--  el codigo, tipo de sala, capacidad de pacientes y nombre de pacientes cuyo numero de casa esta entre 6 y 7
select Código, Tipo, Capacidad_de_pacientes, Nombre_de_paciente
	from Paciente join Sala
		on Nombre_de_paciente = Nombre
			and Pago < 100000
				and cast(substring(Número_de_casa,1,1)as char) between 6 and 7;

-- el nombre de el enfermero y el doctor que viven en la misma ciudad
select E.Nombre as Ciudad_Enfermero, D.Nombre as Ciudad_Doctor
	from Enfermero E join Doctor D 
		on E.Ciudad = 'loquendocity' and D.Ciudad = 'loquendocity';

-- select anidado--

-- nombre del paciente atendido por el doctor cuyo nombre empiece con M
select P.Nombre from Paciente P 
	where (select R.RutPaciente from DAtiendeP R where R.RutPaciente = P.Rut 
		and ( Select D.ID from Doctor D where D.ID = R.IDDoctor and D.Nombre like'M%'));

-- el modelo de la ambulancia cuyo conductor viva en racoon city
select A.Modelo from Ambulancia A 
	where exists (select C.Patente from Conduce C where C.Patente = A.Patente 
		and (select P.ID from Paramedico P where P.ID = C.IDParamedico and P.Ciudad = 'Racoon City'
			and (select N.ID from NúmeroTelefonoParamedico N where N.ID = P.ID and CAST(N.NúmeroDeTelefono AS CHAR) LIKE '%9')));

-- select agregacion--

-- promedio de la capacidad de almacenamiento de todas las farmacias
select avg(Capacidad_de_stock) as promedio from Farmacia;

-- el nombre de pacientes cuyo pago de consulta fue menor al maximo
select P.Nombre, count(*) as conteo from Paciente P group by P.Nombre having max(P.Pago)<2000000;

-- select de ejemplos

select ID,Nombre, Especialización from ProyectoU2.Doctor;

select Nombre from Paramedico;

select ID,Nombre from Paramedico
where ciudad = "Racoon City"
and número_de_casa > 48;

select Motivo from cita_medica
where año > 2010
and Motivo like "T%";

select * from recepcionista;

select primer_nombre from Recepcionista
where segundo_apellido like "F%";

select * from recepcionista
where rut like "%0%";

select * from Doctor;

select * from doctor
where horario_de_atención not like "12:00%";

select * from paciente;

select * from paciente
where número_de_casa like "66_";

select * from númerodetelefonoenfermero
where id not between 100 and 500;

select * from farmacia
where capacidad_de_stock in (90, 150);

select * from farmacia
where capacidad_de_stock not in(90,150,300);

select *from medicamento
where instrucciones_De_uso in("vía oral");

select sum(Pago) from cita_medica;

select count(Marca)from ambulancia;

select count(Nombre) as conteo from Paciente where Pago < 2000000;

select Nombre, Pago from Paciente
where Pago = (select min(Pago) from paciente);

select Nombre, Pago from paciente
where Pago = (select max(Pago) from Paciente);

select count(Nombre) from Paciente 
where Pago = (select min(Pago) from paciente);

select  count(Ciudad), nombre from paciente
where ciudad = "Silent Hill"
group by nombre;

select min(capacidad_de_stock), lista_de_medicamentos from farmacia;

select sum(capacidad_de_stock) as sumatotal from farmacia;

select max(capacidad_de_stock), lista_de_medicamentos from farmacia;

select pago, nombre
from paciente
order by pago desc
limit 1;

select pago, nombre
from paciente
where pago = (select max(pago) from paciente);

select pago, nombre
from paciente
where pago > 0;

select * from cita_medica;

select rutpaciente,códigosala,iddoctor, año
from cita_medica
where año between 2020 and 2024;

select * from ambulancia;

select marca,count(marca) as cantidad
from ambulancia
group by marca;

select nombre, sum(pago) as pagomaximo
from paciente
group by nombre;

select avg(capacidad_de_stock) from farmacia;

select marca, count(*) as cantidad
from ambulancia;

select * from medicamento;

select instrucciones_de_uso, count(*)
from medicamento
group by instrucciones_de_uso;

select instrucciones_de_uso, count(*)
from medicamento
where instrucciones_de_uso = "vía oral";

select departamento_médico, count(*), primer_nombre
from recepcionista
where departamento_médico = "General"
group by primer_nombre;

select departamento_médico, count(*)
from recepcionista
where departamento_médico = "General";

select marca, count(*) as cantidad
from ambulancia
where año_de_llamada = 2023
group by marca;

select * from ambulancia;

select marca, modelo, min(año_de_llamada) as año_minimo
from ambulancia
group by modelo
having min(año_de_llamada) < 2020;

select marca, modelo , max(año_de_llamada) as año_maximo
from ambulancia
group by modelo
having max(año_de_llamada) >= 2023;

select * from cita_medica;

select id,año,count(*)
from cita_medica
group by año
having año < 2023;

select tipo,nombre_de_paciente, capacidad_De_pacientes,count(*)
from sala
group by capacidad_De_pacientes
having capacidad_De_pacientes < 100;

select nombre, pago, max(pago)
from paciente
group by nombre
having max(pago) > 0;

select nombre from doctor
where substring(horario_de_atención,7,8) >= "13" and substring(horario_de_atención,7,8) < "18";

select * from paciente
order by número_de_casa desc;

select nombre from paciente
order by nombre desc;

select Nombre, pago, max(pago) from Paciente
group by nombre
having max(pago) < 2000000;

select nombre, especialización from doctor;

select * from sala;

select * from doctor;

select * from cita_medica;

select * from paciente;

select * from DAtiendeP;

select P.nombre, P.Rut from paciente P
where P.rut in (select DA.Rutpaciente from DAtiendeP DA where DA.Rutpaciente = P.rut
and IDDoctor = 143);

-- Contar la cantidad de pacientes atendidos por cada enfermero
select * from enfermero;

select * from EAtiendeP;

select * from paciente;

select E.ID, E.Nombre, count(E.ID) as cantidad_pacientes
from enfermero E
join EAtiendeP EP
on E.ID = EP.IDEnfermero
join Paciente P on EP.RutPaciente = P.rut
group by E.ID, E.Nombre;

-- Mostrar el nombre del doctor, la fecha de la cita y el motivo para cada cita médica.
select * from cita_medica;
select * from doctor;

select D.Nombre, CM.Día, CM.Mes, CM.Año, CM.Motivo
from Doctor D join Cita_medica CM
where D.ID = IDDoctor;

-- Mostrar los nombres de los doctores que atendieron a pacientes en la sala de tipo "Sala de Cirugia".
select * from doctor;
select * from DAtiendeP;
select * from Sala;
select * from paciente;
select * from cita_medica;

select D.nombre from Doctor D
where exists(select CM.CódigoSala from Cita_medica CM 
join Sala S on CM.CódigoSala = S.Código
where CM.IDDoctor = D.ID and S.Tipo = "Sala de Cirugia");






-- drops
drop table Paciente;
drop table NúmeroDeTelefonoDePaciente;
drop table Doctor;
drop table Enfermero;
drop table Paramedico;
drop table Sala;
drop table Medicamento;
drop table Farmacia;
drop table Recepcionista;
drop table Cita_medica;
drop table Ambulancia;
drop database ProyectoU2; 