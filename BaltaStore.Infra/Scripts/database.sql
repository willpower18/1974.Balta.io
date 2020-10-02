drop database balta1974;

create database balta1974;

use balta1974;

CREATE TABLE `Customer`
(
	Id Varchar(36) unique PRIMARY KEY NOT NULL,
	FirstName VARCHAR(40) NOT NULL,
	LastName VARCHAR(40) NOT NULL,
	Document CHAR(11) NOT NULL,
	Email VARCHAR(160) NOT NULL,
	Phone VARCHAR(13) NOT NULL
);

CREATE TABLE `Address`
(
	Id Varchar(36) unique PRIMARY KEY NOT NULL,
	CustomerId Varchar(36) unique NOT NULL,
	`Number` VARCHAR(10) NOT NULL,
	Complement VARCHAR(40) NOT NULL,
	District VARCHAR(60) NOT NULL,
	City VARCHAR(60) NOT NULL,
	State CHAR(2) NOT NULL,
	Country CHAR(2) NOT NULL,
	ZipCode CHAR(8) NOT NULL,
	`Type` INT NOT NULL DEFAULT 1
);

ALTER TABLE `Address` add CONSTRAINT FK_Address_Customer foreign key (CustomerId) references Customer(Id);

CREATE TABLE Product
(
	Id Varchar(36) unique PRIMARY KEY NOT NULL,
	Title VARCHAR(255) NOT NULL,
	Description TEXT NOT NULL,
	Image VARCHAR(1024) NOT NULL,
	Price Decimal NOT NULL,
	QuantityOnHand DECIMAL(10,2) NOT NULL
);

CREATE TABLE `Order`
(
	Id Varchar(36) unique PRIMARY KEY NOT NULL,
	CustomerId Varchar(36) unique NOT NULL,
	CreateDate DATETIME NOT NULL,
	`Status` INT NOT NULL DEFAULT 1
);

ALTER TABLE `Order` add CONSTRAINT FK_Order_Customer foreign key (CustomerId) references Customer(Id);

CREATE TABLE OrderItem (
	Id Varchar(36) unique PRIMARY KEY NOT NULL,
	OrderId Varchar(36) unique NOT NULL,
	ProductId Varchar(36) unique NOT NULL,
	Quantity DECIMAL(10, 2) NOT NULL,
	Price Decimal NOT NULL
);

ALTER TABLE `OrderItem` add CONSTRAINT FK_OrderItem_Order foreign key (OrderId) references `Order`(Id);
ALTER TABLE `OrderItem` add CONSTRAINT FK_OrderItem_Product foreign key (ProductId) references Product(Id);

CREATE TABLE Delivery (
	Id Varchar(36) unique PRIMARY KEY NOT NULL,
	OrderId Varchar(36) unique NOT NULL,
	CreateDate DATETIME NOT NULL,
	EstimatedDeliveryDate  DATETIME NOT NULL,
	`Status` INT NOT NULL DEFAULT 1
);

ALTER TABLE `Delivery` add CONSTRAINT FK_Delivery_Order foreign key (OrderId) references `Order`(Id);