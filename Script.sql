--create database CalcularHorasExtrasPrueba

--drop DATABASE CalcularHorasExtrasPrueba
use CalcularHorasExtrasPrueba
create table funcionarios (
rut varchar(15),
nombre varchar(50),
sueldo int,
primary key (rut)
);

insert into funcionarios (rut,nombre,sueldo) values ('14610310-3','Juan Perez',450000);
insert into funcionarios (rut,nombre,sueldo) values ('15083548-8','Carlos Araya',550000);
insert into funcionarios (rut,nombre,sueldo) values ('11981846-k','Francisco Bosco',550300);
insert into funcionarios (rut,nombre,sueldo) values ('10006604-1','Carlos Caszeli',550500);
insert into funcionarios (rut,nombre,sueldo) values ('12813232-5','Pedro Días',890000);


create table dias (
mes int,
dias int,
nombre_mes varchar(20),
primary key (mes) );

insert into dias values (1,31,'Enero');
insert into dias values (2,28,'Febrero');
insert into dias values (3,31,'Marzo');
insert into dias values (4,30,'Abril');
insert into dias values (5,31,'Mayo');
insert into dias values (6,30,'Junio');
insert into dias values (7,31,'Julio');
insert into dias values (8,31,'Agosto');
insert into dias values (9,30,'Septiembre');
insert into dias values (10,31,'Octubre');
insert into dias values (11,30,'Noviembre');
insert into dias values (12,31,'Diciembre');



create table registro (rut VARCHAR(15) NOT NULL,fecha DATETIME NOT NULL );


insert into registro (rut,fecha) values ('14610310-3','2022-03-10 09:00:00:000');
insert into registro (rut,fecha) values ('15083548-8','2022-03-10 09:00:00:000');
insert into registro (rut,fecha) values ('11981846-k','2022-03-10 09:05:00:000');
insert into registro (rut,fecha) values ('10006604-1','2022-03-10 09:00:00:000');
insert into registro (rut,fecha) values ('12813232-5','2022-03-10 09:00:00:000');
insert into registro (rut,fecha) values ('14610310-3','2022-03-10 18:00:00:000');
insert into registro (rut,fecha) values ('15083548-8','2022-03-10 18:10:00:000');
insert into registro (rut,fecha) values ('11981846-k','2022-03-10 19:05:00:000');
insert into registro (rut,fecha) values ('10006604-1','2022-03-10 18:04:00:000');
insert into registro (rut,fecha) values ('12813232-5','2022-03-10 18:04:00:000');
insert into registro (rut,fecha) values ('14610310-3','2022-04-10 09:00:00:000');
insert into registro (rut,fecha) values ('15083548-8','2022-04-10 09:00:00:000');
insert into registro (rut,fecha) values ('11981846-k','2022-04-10 09:00:00:000');
insert into registro (rut,fecha) values ('10006604-1','2022-04-10 09:00:00:000');
insert into registro (rut,fecha) values ('12813232-5','2022-04-10 09:00:00:000');
insert into registro (rut,fecha) values ('14610310-3','2022-04-10 19:30:00:000');
insert into registro (rut,fecha) values ('15083548-8','2022-04-10 18:10:00:000');
insert into registro (rut,fecha) values ('11981846-k','2022-04-10 20:05:00:000');
insert into registro (rut,fecha) values ('10006604-1','2022-04-10 18:04:00:000');
insert into registro (rut,fecha) values ('12813232-5','2022-04-10 18:04:00:000');
insert into registro (rut,fecha) values ('14610310-3','2022-05-10 09:00:00:000');
insert into registro (rut,fecha) values ('15083548-8','2022-05-10 09:00:00:000');
insert into registro (rut,fecha) values ('11981846-k','2022-05-10 09:00:00:000');
insert into registro (rut,fecha) values ('10006604-1','2022-05-10 09:00:00:000');
insert into registro (rut,fecha) values ('12813232-5','2022-05-10 09:00:00:000');
insert into registro (rut,fecha) values ('14610310-3','2022-05-10 19:00:00:000');
insert into registro (rut,fecha) values ('15083548-8','2022-05-10 18:10:00:000');
insert into registro (rut,fecha) values ('11981846-k','2022-05-10 19:05:00:000');
insert into registro (rut,fecha) values ('10006604-1','2022-05-10 18:04:00:000');
insert into registro (rut,fecha) values ('12813232-5','2022-05-10 18:04:00:000');
insert into registro (rut,fecha) values ('14610310-3','2022-06-10 09:00:00:000');
insert into registro (rut,fecha) values ('15083548-8','2022-06-10 09:00:00:000');
insert into registro (rut,fecha) values ('11981846-k','2022-06-10 09:00:00:000');
insert into registro (rut,fecha) values ('10006604-1','2022-06-10 09:00:00:000');
insert into registro (rut,fecha) values ('12813232-5','2022-06-10 09:00:00:000');
insert into registro (rut,fecha) values ('14610310-3','2022-06-10 20:05:00:000');
insert into registro (rut,fecha) values ('15083548-8','2022-06-10 18:10:00:000');
insert into registro (rut,fecha) values ('11981846-k','2022-06-10 19:30:00:000');
insert into registro (rut,fecha) values ('10006604-1','2022-06-10 18:04:00:000');
insert into registro (rut,fecha) values ('12813232-5','2022-06-10 18:04:00:000');
insert into registro (rut,fecha) values ('14610310-3','2022-07-10 09:00:00:000');
insert into registro (rut,fecha) values ('15083548-8','2022-07-10 09:00:00:000');
insert into registro (rut,fecha) values ('11981846-k','2022-07-10 09:00:00:000');
insert into registro (rut,fecha) values ('10006604-1','2022-07-10 09:00:00:000');
insert into registro (rut,fecha) values ('12813232-5','2022-07-10 09:00:00:000');
insert into registro (rut,fecha) values ('14610310-3','2022-07-10 21:00:00:000');
insert into registro (rut,fecha) values ('15083548-8','2022-07-10 18:10:00:000');
insert into registro (rut,fecha) values ('11981846-k','2022-07-10 20:45:00:000');
insert into registro (rut,fecha) values ('10006604-1','2022-07-10 18:04:00:000');
insert into registro (rut,fecha) values ('12813232-5','2022-07-10 18:04:00:000');



SELECT * FROM funcionarios