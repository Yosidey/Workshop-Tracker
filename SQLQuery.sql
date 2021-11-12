use Automotriz
go
SELECT ROUTINE_NAME FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE ROUTINE_TYPE = 'PROCEDURE'
   ORDER BY ROUTINE_NAME 
CREATE TABLE Cliente(
ClienteId int not null identity(1,1) primary key,
CNombre varchar(80) not null,
CApellidos varchar(80)not null,
CTelefono varchar(11)not null,
CEmail varchar(50)not null,
CDireccion varchar(150)not null
);

CREATE TABLE Vehiculo( 
VehiculoId int not null identity(1,1) primary key,
ClienteId int not null,
VMarca varchar(60)not null,
VPlaca varchar(60)not null,
VModelo varchar(60)not null,
VAño varchar(10)not null,
VColor varchar(50)not null
);

CREATE TABLE Servicio(
ServicioId int not null  identity(1,1) primary key,
VehiculoId int not null,
EmpleadoId int not null,
SDescripcion varchar(150)not null,
SComentario varchar(150),
SPrecio float not null,
SFecha date not null,
STerminado date, 
SEntregado date
);

CREATE TABLE Empleado(
EmpleadoId int not null  identity(1,1) primary key,
ENombre varchar(80) not null,
EApellidos varchar(80)not null,
ETelefono varchar(11)not null,
EEmail varchar(50)not null,
EDireccion varchar(150)not null, 
EStatus date 
);
--drop database Automotriz

Select CNombre,VehiculoId,VMarca, VPlaca,VModelo,VAño,VColor from Vehiculo
INNER JOIN Cliente
On Vehiculo.ClienteId=Cliente.ClienteId order by Cliente.CNombre ASC;
--Servicios
create proc sp_listar_servicios_Completado
as
select S.ServicioId,V.VPlaca,C.CNombre,S.SDescripcion,E.ENombre,S.SPrecio,S.SFecha,S.SEntregado
from Servicio AS S
INNER JOIN Vehiculo AS V ON S.VehiculoId=V.VehiculoId
INNER JOIN Empleado AS E ON S.EmpleadoID=E.EmpleadoId
INNER JOIN Cliente AS C ON V.ClienteId=C.ClienteId
where  S.SFecha is not NULL and S.STerminado is not NULL and S.SEntregado is not NULL order by S.ServicioId
go
--Nuevos drop proc sp_listar_servicios_Nuevos
create proc sp_listar_servicios_Nuevos
as
select S.ServicioId,V.ClienteId,E.EmpleadoId,V.VehiculoId,
CONCAT( V.VMarca,' ',V.VPlaca) AS marcaVehiculo, S.SPrecio
,S.SDescripcion,S.SComentario,S.SFecha
from Servicio AS S
INNER JOIN Vehiculo AS V ON S.VehiculoId=V.VehiculoId
INNER JOIN Empleado AS E ON S.EmpleadoID=E.EmpleadoId
where S.SFecha is not NULL and S.STerminado is NULL and S.SEntregado is NULL order by S.ServicioId
go
--Terminados drop proc sp_listar_servicios_Terminados
create proc sp_listar_servicios_Terminados
as
select S.ServicioId,
CONCAT( V.VMarca,' ',V.VPlaca) AS marcaVehiculo,
CONCAT( C.CNombre,' ',C.CApellidos) as nombreCompleto,
C.CTelefono,C.CEmail,S.SDescripcion,S.SPrecio,S.SFecha,S.STerminado
from Servicio AS S
INNER JOIN Vehiculo AS V ON S.VehiculoId=V.VehiculoId
INNER JOIN Empleado AS E ON S.EmpleadoID=E.EmpleadoId
INNER JOIN Cliente As C  ON C.ClienteId=V.ClienteId
where SFecha is not NULL and STerminado is not NULL and SEntregado is NULL order by S.ServicioId
go
--Vehiculo
create proc sp_listar_cliente_vehiculos
as Select V.VehiculoId,C.ClienteId ,CNombre, V.VPlaca,V.VMarca,V.VModelo,V.VAño,V.VColor 
from Vehiculo as V
INNER JOIN Cliente as C
On V.ClienteId=C.ClienteId order by VehiculoId ASC;
go
--drop proc sp_listar_cliente_vehiculos
---Lista Clientes
create proc sp_listar_clientes
as select * from Cliente order by ClienteId
go
---Combobox Lista Cliente drop proc sp_combobox_clientes
create proc sp_combobox_clientes
as 
select ClienteId, CONCAT (CNombre,' ',CApellidos)nombreCompleto
from Cliente 
order by CNombre asc
go
create proc sp_combobox_vehiculo_cliente
@IdCliente int
as
select VehiculoId,
CONCAT ('Placa:',VPlaca,' Marca:',VMarca)as VehiculoCliente
from Vehiculo
where ClienteId = @IdCliente order by VPlaca
go
exec sp_combobox_vehiculo_cliente 5
go
--drop proc sp_combobox_vehiculo_cliente
--Buscar Cliente
create proc sp_buscar_cliente
@ClienteId int
as 
select * from Cliente 
where ClienteId=@ClienteId
go

exec sp_listar_clientes;
exec sp_buscar_cliente @ClienteId=1
--
create proc sp_operaciones_cliente
@ClienteId int,
@CNombre Varchar(80),
@CApellidos varchar(80),
@CTelefono varchar(11),
@CEmail Varchar(50),
@CDireccion Varchar(150),
@accion varchar (2)
as
if(@accion='1')
begin
	insert into Cliente(CNombre,CApellidos,CTelefono,CEmail,CDireccion) values(@CNombre,@CApellidos,@CTelefono,@CEmail,@CDireccion) 
	
end
else if(@accion='2')
begin
	update Cliente set CNombre=@CNombre, CApellidos=@CApellidos, CTelefono=@CTelefono, CEmail=@CEmail, CDireccion=@CDireccion where ClienteId=@ClienteId
end
go
--

--Empleado
create proc sp_listar_empleado
as select * from Empleado order by EmpleadoId
go
---Combobox Lista Empleado
create proc sp_combobox_empleados
as select EmpleadoId, 
CONCAT (ENombre,' ',EApellidos)nombreCompleto
from Empleado 
where EStatus IS NULL
order by EmpleadoId 
go

--drop proc sp_combobox_empleados


exec sp_listar_empleado;

exec sp_listar_cliente_vehiculos;
exec sp_listar_servicios_Completado;
exec sp_listar_servicios_Nuevos;
exec sp_listar_servicios_Terminados;

drop proc sp_listar_cliente_vehiculos;
drop proc sp_listar_servicios_Completado
drop proc sp_listar_servicios_Nuevos
drop proc sp_listar_servicios_Terminados

 Select * from Vehiculo INNER JOIN Cliente On Vehiculo.ClienteId=Cliente.ClienteId
create proc sp_servicio
@ServicioIdBuscar int
as
select S.ServicioId,S.VehiculoId,S.EmpleadoID,C.ClienteId,S.SDescripcion,S.SComentario,S.SPrecio,S.SFecha,S.STerminado,S.SEntregado,
V.VMarca,V.VPlaca,V.VModelo,V.VAño,V.VColor,
E.ENombre,E.EApellidos,E.ETelefono,E.EEmail,E.EDireccion,E.EStatus,
C.CNombre,C.CApellidos,C.CTelefono,C.CEmail,C.CDireccion
from Servicio AS S
INNER JOIN Vehiculo AS V ON S.VehiculoId=V.VehiculoId
INNER JOIN Empleado AS E ON S.EmpleadoID=E.EmpleadoId
INNER JOIN Cliente AS C ON V.ClienteId=C.ClienteId
where    S.ServicioId=@ServicioIdBuscar
go
exec sp_servicio  156
select *from Servicio where STerminado is not NULL and SEntregado is not NULL and ServicioId=304
--drop proc sp_servicio
 select *from Vehiculo where VehiculoId=16


exec sp_operaciones_cliente @ClienteId=0, @CNombre='Javier',@CApellidos='Zamora',@CTelefono='3111442481', @CEmail='Zamora@mail.com',@CDireccion='Col. Morelos, Tepic, Nayarit.',@accion='1'
exec sp_operaciones_cliente @ClienteId=215, @CNombre='Victor',@CApellidos='Zamora',@CTelefono='3111442481', @CEmail='Zamora@mail.com',@CDireccion='Col. Morelos, Tepic, Nayarit.',@accion='2'

drop proc sp_operaciones_cliente

create proc sp_operaciones_empleado
@EmpleadoId int,
@ENombre Varchar(80),
@EApellidos varchar(80),
@ETelefono varchar(11),
@EEmail Varchar(50),
@EDireccion Varchar(150),
@accion varchar (2)
as
if(@accion='1')
begin
	insert into Empleado(ENombre,EApellidos,ETelefono,EEmail,EDireccion) values(@ENombre,@EApellidos,@ETelefono,@EEmail,@EDireccion) 
end
else if(@accion='2')
begin
	update Empleado set ENombre=@ENombre, EApellidos=@EApellidos, ETelefono=@ETelefono, EEmail=@EEmail, EDireccion=@EDireccion where EmpleadoId=@EmpleadoId
end
go

exec sp_operaciones_empleado @EmpleadoId=0, @ENombre='Hana',@EApellidos='Hernandez',@ETelefono='3111448124', @EEmail='Hernandez@mail.com',@EDireccion='Zapopan, Jalisco.',@accion='1'
exec sp_operaciones_empleado @EmpleadoId=101, @ENombre='Hana Mayte',@EApellidos='Hernandez',@ETelefono='3111448124', @EEmail='Hernandez@mail.com',@EDireccion='Zapopan, Jalisco.',@accion='2'

update Empleado set ENombre='Hana', EApellidos='Zamora', ETelefono='3111442481', EEmail='Hernandez@mail.com', EDireccion='Zapopan, Jalisco.', EStatus=null where EmpleadoId=101
update Empleado set EStatus=null where EmpleadoId=101
update Empleado set EStatus='(SELECT CONVERT(DATE,GETDATE())' where EmpleadoId=101
drop proc sp_operaciones_empleado

---Desactivar Empleado
create proc sp_fecha_desactivar_empleado
@EmpleadoId int
as
update Empleado 
set EStatus=CONVERT(date,GETDATE(),103) where EmpleadoId=@EmpleadoId
go
--drop proc sp_fecha_desactivar_empleado
exec sp_fecha_desactivar_empleado 2;

--DECLARE @fecha2 date=CONVERT(date,GETDATE(),103)


--
create proc sp_fecha_activar_empleado
@EmpleadoId int
as
update Empleado set EStatus=null where EmpleadoId=@EmpleadoId
go
--drop proc sp_fecha_activar_empleado
exec sp_fecha_activar_empleado 101;
--
create proc sp_operaciones_vehiculo
@VehiculoId int,
@ClienteId int,
@VMarca Varchar(60),
@VPlaca varchar(60),
@VModelo varchar(60),
@VAño Varchar(10),
@VColor Varchar(50),
@accion varchar (2)
as
if(@accion='1')
begin
	insert into Vehiculo(ClienteId,VMarca,VPlaca,VModelo,VAño,VColor) values(@ClienteId,@VMarca,@VPlaca,@VModelo,@VAño,@VColor) 
	
end
else if(@accion='2')
begin
	update Vehiculo set ClienteId=@ClienteId,VMarca=@VMarca, VPlaca=@VPlaca, VModelo=@VModelo, VAño=@VAño, VColor=@VColor where VehiculoId=@VehiculoId
end
go

create proc sp_ValidarEmpleado
@EmpleadoId int
as
select COUNT(EmpleadoId) as Ts from Servicio where STerminado is null and EmpleadoId=@EmpleadoId
go
--drop proc ValidarEmpleado

--drop proc sp_operaciones_servicio
create proc sp_operaciones_servicio
@ServicioId int,
@VehiculoId int,
@EmpleadoId int,
@SDescripcion varchar(150),
@SComentario varchar(150),
@SPrecio float,
@accion varchar(2)
as
if(@accion='1')
begin
	insert into Servicio(VehiculoId,EmpleadoId,SDescripcion,SComentario,SPrecio,SFecha) values(@VehiculoId,@EmpleadoId,@SDescripcion,@SComentario,@SPrecio,CONVERT(date,GETDATE(),103)) 
end
else if(@accion='2')
begin
	update Servicio set VehiculoId=@VehiculoId, EmpleadoId=@EmpleadoId, SDescripcion=@SDescripcion, SComentario=@SComentario, SPrecio=@SPrecio where ServicioId=@ServicioId
end
go
select*from Vehiculo as V
INNER JOIN Cliente AS C ON V.ClienteId=C.ClienteId
where V.ClienteId=66


create proc sp_servicio_actualizar
@ServicioId int,
@accion varchar(2)
as
if(@accion='1')
begin
update Servicio set STerminado=CONVERT(date,GETDATE(),103) where ServicioId=@ServicioId
end
else if(@accion='2')
begin
update Servicio set SEntregado=CONVERT(date,GETDATE(),103) where ServicioId=@ServicioId
end
go

exec sp_servicio_actualizar 255,'1';
exec sp_servicio_actualizar 255,'2';
