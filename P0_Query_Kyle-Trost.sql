create schema PizzaBox
go

-- Pizzas Sold

create table PizzaBox.PizzasSold
(
	orderId int foreign key references PizzaBox.Orders(orderId),
	pizzaName varchar(max),
	pizzaSize int foreign key references PizzaBox.Sizes(sizeId),
	pizzaCrust int foreign key references PizzaBox.CrustTypes(crustId),
	totalCost money,
	pizzaId int Identity(1, 1) primary key
)

alter table PizzaBox.PizzasSold
	add pizzaId int Identity(1, 1) primary key

select * from PizzaBox.PizzasSold
delete from PizzaBox.PizzasSold
truncate table PizzaBox.PizzasSold

-- Stores

create table PizzaBox.Stores
(
	storeId int Identity(1,1) primary key,
	storeLocation varchar(max)
)

insert into PizzaBox.Stores values('Arlington_TX')
insert into PizzaBox.Stores values('Dallas_TX')
insert into PizzaBox.Stores values('Austin_TX')

select * from PizzaBox.Stores

-- Orders

create table PizzaBox.Orders
(
	orderId int Identity(1,1) primary key,
	storeId int foreign key references PizzaBox.Stores(storeId),
	userId int foreign key references PizzaBox.Users(userId),
	totalCost money,
	orderTimestamp datetime default current_timestamp
)

-- create trigger which sets orderTimestamp whenever order is created

select * from PizzaBox.Orders

-- Users

create table PizzaBox.Users
(
	userId int Identity(1,1) primary key,
	userName varchar(20) unique not null,
	userPass varchar(10) not null,
	storeId int default null
)

insert into PizzaBox.Users values('Kyle', 'qwerty', null)
insert into PizzaBox.Users values('Admin_Arlington', 'pizzapower', 1)
select * from PizzaBox.Users

-- Sizes

create table PizzaBox.Sizes
(
	sizeId int Identity(1,1) primary key,
	sizeName varchar(10) unique not null,
	sizeCost money not null
)

insert into PizzaBox.Sizes values('Small', 7.99)
insert into PizzaBox.Sizes values('Medium', 10.99)
insert into PizzaBox.Sizes values('Large', 13.99)

select * from PizzaBox.Sizes

-- Crust Types

create table PizzaBox.CrustTypes
(
	crustId int Identity(1,1) primary key,
	crustName varchar(10) unique not null,
	crustCost money not null
)

insert into PizzaBox.CrustTypes values('Normal', $0.00)
insert into PizzaBox.CrustTypes values('Thin', $0.00)
insert into PizzaBox.CrustTypes values('Stuffed', $2.00)

select * from PizzaBox.CrustTypes

-- Preset Pizzas

create table PizzaBox.PresetPizzas
(
	presetId int Identity(1,1) primary key,
	presetName varchar(max)
)

insert into PizzaBox.PresetPizzas values('Hawaiian')
insert into PizzaBox.PresetPizzas values('Meat Lovers')
insert into PizzaBox.PresetPizzas values('Veggie')
insert into PizzaBox.PresetPizzas values('Supreme')

select * from PizzaBox.PresetPizzas