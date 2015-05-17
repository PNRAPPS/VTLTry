CREATE TABLE [dbo].[Customers] (
    [Id]                  UNIQUEIDENTIFIER NOT NULL,
    [CustomerName]        NVARCHAR (100)   NOT NULL,
    [ContactPerson]       NVARCHAR (50)    NULL,
    [Phone]               NVARCHAR (30)    NULL,
    [PhoneExt]            NVARCHAR (30)    NULL,
    [Fax]                 NVARCHAR (30)    NULL,
    [AltPhone]            NVARCHAR (30)    NULL,
    [AltContactPerson]    NVARCHAR (50)    NULL,
    [Email1]              NVARCHAR (50)    NULL,
    [Email2]              NVARCHAR (50)    NULL,
    [Address1]            NVARCHAR (50)    NULL,
    [Address2]            NVARCHAR (50)    NULL,
    [City]                NVARCHAR (50)    NULL,
    [Province]            NVARCHAR (50)    NULL,
    [PostalCode]          NVARCHAR (50)    NULL,
    [Country]             NVARCHAR (15)    NULL,
    [SalesRepresentative] NVARCHAR (50)    NULL,
    [CommissionRate]      DECIMAL (18, 2)  NOT NULL,
    [UserName]            NVARCHAR (20)    NULL,
    [Password]            NVARCHAR (100)   NULL,
    CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED ([Id] ASC)
);



CREATE TABLE [dbo].[Consignees] (
    [Id]                       UNIQUEIDENTIFIER NOT NULL,
    [ConsigneeName]            NVARCHAR (100)   NOT NULL,
    [ConsigneeAddress1]        NVARCHAR (50)    NULL,
    [ConsigneeAddress2]        NVARCHAR (50)    NULL,
    [ConsigneeAddress3]        NVARCHAR (50)    NULL,
    [ConsigneeCity]            NVARCHAR (50)    NULL,
    [ConsigneeStateOrProvince] NVARCHAR (50)    NULL,
    [COnsigneePostalOrZip]     NVARCHAR (50)    NULL,
    [ConsigneeCountry]         NVARCHAR (15)    NULL,
    [ConsigneeContactPerson]   NVARCHAR (50)    NULL,
    [ConsigneePhone]           NVARCHAR (30)    NULL,
    [ConsigneePhoneExt]        NVARCHAR (20)    NULL,
    [ConsigneeEmail]           NVARCHAR (100)   NULL,
    [ConsigneeIsResidential]   BIT              NULL,
    [UPSId]                    NVARCHAR (30)    NULL,
    CONSTRAINT [PK_dbo.Consignees] PRIMARY KEY CLUSTERED ([Id] ASC)
);

