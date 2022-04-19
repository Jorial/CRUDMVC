create database CRUDMVC;
go

use CRUDMVC;

create table Contacto(
idcontacto int identity primary key,
nombre varchar(100) not null,
Telefono numeric not null
);



-- creando un procedimiento almacenado para consultar nuestros contactos 
create procedure sp_ReadContact
as
begin
	select idcontacto as Id, nombre as 'Nombre de Contacto', Telefono from Contacto;
end

 -- Procedimiento almacenado para consultar un contacto 
 create proc sp_SerchContact (
 @IdContact int
 )
 as
 begin
	select * from Contacto where idcontacto = @IdContact
 end

 -- Procedimiento almacenado para Crear un contacto
 create proc sp_CreateContact(
 @Nombre varchar(100),
 @Telefono numeric
 )
 as
 begin
	insert into Contacto(nombre,Telefono) values (@Nombre,@Telefono)
 end


 -- Procedimiento Almacenado para Editar un contacto 
 create proc sp_UpdateContact(@idcontacto int, @nombre varchar(100), @telefono numeric )
 as
 begin
   update Contacto set nombre = @nombre, Telefono = @telefono where idcontacto = @idcontacto;
 end

 create proc sp_DeleteContact (@idContact numeric)
 as
 begin
	delete Contacto where idcontacto = @idContact
 end

 create procedure sp_OnlyOneRegister( @IdFiltrar numeric)
 as
 begin
	select * from Contacto where idcontacto = @IdFiltrar;
 end

 use CRUDMVC;

 exec sp_OnlyOneRegister 3;

 exec sp_ReadContact

 exec sp_UpdateContact 2,'Pedro Paz', 77448833;

 exec sp_DeleteContact 4;

 exec sp_UpdateContact 9,'Oscar Paz',89898989