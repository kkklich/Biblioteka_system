create database Biblioteka

drop database Biblioteka


use Biblioteka

create table Workers(
IdEmployee int primary key identity not null,
FirstName varchar (50) not null,
Surename varchar(50) not null,
Position varchar(50) not null,
BirthDay date not null,
)

create table Clients (
IdClient int primary key identity not null,
Firstname varchar(50) not null,
Surename varchar(60) not null,
NrPhone varchar(15) ,
Info varchar(100) 
)



create table Books(
IdBook int primary key identity not null,
Title varchar(80) not null
)


create table Author(
IdAuthor int primary key identity not null,
FirstName varchar(100) not null,
Surename varchar(100) not null
)


create table AuthorsBook(
IdAK int primary key identity not null,
IdBook int foreign key references Books(IdBook) not null,
IdAuthor int foreign key references Author(IdAuthor) not null
)



create table Rent(
IdRent int primary key identity not null,
IdClient int foreign key references Clients(IdClient) not null,
IdBook int foreign key references Books(IdBook) not null,
DateStart date not null,
DateReturn date not null
)




