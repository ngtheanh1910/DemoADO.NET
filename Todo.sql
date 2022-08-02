create database TodoList
go

use TodoList
go

create table Task(
	id int identity(1, 1) not null primary key ,
	title nvarchar(255)
)

--Thêm
create procedure [dbo].[Add]
(
	@title nvarchar(255)
)
as
begin
	insert into Task(title) values (@title)
end

--Hiển thị
create procedure [dbo].[Get]
as
begin 
	select * from Task
end

--Sửa
create procedure [dbo].[Update]
(
	@id int,
	@title nvarchar(255)
)
as
begin 
	Update Task 
	set title = @title
	where id = @id
end

--Xóa
create procedure [dbo].[Delete]
(
	@id int
)
as
begin 
	Delete from Task where id = @id
end

select * from Task