
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_BasketItem_Customer]') AND parent_object_id = OBJECT_ID('[BasketItem]'))
alter table [BasketItem]  drop constraint FK_BasketItem_Customer


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_BasketItem_Product]') AND parent_object_id = OBJECT_ID('[BasketItem]'))
alter table [BasketItem]  drop constraint FK_BasketItem_Product


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_OrderItem_Order]') AND parent_object_id = OBJECT_ID('[OrderItem]'))
alter table [OrderItem]  drop constraint FK_OrderItem_Order


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_OrderItem_Product]') AND parent_object_id = OBJECT_ID('[OrderItem]'))
alter table [OrderItem]  drop constraint FK_OrderItem_Product


    if exists (select * from dbo.sysobjects where id = object_id(N'[BasketItem]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [BasketItem]

    if exists (select * from dbo.sysobjects where id = object_id(N'[Customer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Customer]

    if exists (select * from dbo.sysobjects where id = object_id(N'[Order]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Order]

    if exists (select * from dbo.sysobjects where id = object_id(N'[OrderItem]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [OrderItem]

    if exists (select * from dbo.sysobjects where id = object_id(N'[Product]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Product]

    if exists (select * from dbo.sysobjects where id = object_id(N'hibernate_unique_key') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table hibernate_unique_key

    create table [BasketItem] (
        Id INT not null,
       Count INT not null,
       CustomerId INT not null,
       ProductId INT not null,
       primary key (Id)
    )

    create table [Customer] (
        Id INT not null,
       DeliveryAddress NVARCHAR(MAX) null,
       primary key (Id)
    )

    create table [Order] (
        Id INT not null,
       DeliveryAddress NVARCHAR(MAX) not null,
       primary key (Id)
    )

    create table [OrderItem] (
        Id INT not null,
       Count INT not null,
       OrderId INT not null,
       ProductId INT not null,
       primary key (Id)
    )

    create table [Product] (
        Id INT not null,
       Name NVARCHAR(MAX) not null,
       Description NVARCHAR(MAX) not null,
       Price DECIMAL(19,5) not null,
       primary key (Id)
    )

    alter table [BasketItem] 
        add constraint FK_BasketItem_Customer 
        foreign key (CustomerId) 
        references [Customer]

    alter table [BasketItem] 
        add constraint FK_BasketItem_Product 
        foreign key (ProductId) 
        references [Product]

    alter table [OrderItem] 
        add constraint FK_OrderItem_Order 
        foreign key (OrderId) 
        references [Order]

    alter table [OrderItem] 
        add constraint FK_OrderItem_Product 
        foreign key (ProductId) 
        references [Product]

    create table hibernate_unique_key (
         next_hi INT 
    )

    insert into hibernate_unique_key values ( 1 )
