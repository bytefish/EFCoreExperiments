CREATE TABLE [Application].[PersonAddress](
    [PersonAddressID]       INT                                         CONSTRAINT [DF_Application_PersonAddress_PersonAddressID] DEFAULT (NEXT VALUE FOR [Application].[sq_PersonAddress]) NOT NULL,
    [PersonID]              INT                                         NOT NULL,
    [AddressID]             INT                                         NOT NULL,
    [AddressTypeID]         INT                                         NOT NULL,
    [RowVersion]            ROWVERSION                                  NULL,
    [LastEditedBy]          INT                                         NOT NULL,
    [ValidFrom]             DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [ValidTo]               DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_PersonAddress] PRIMARY KEY ([PersonAddressID]),
    CONSTRAINT [FK_PersonAddress_Person_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [Application].[Person] ([PersonID]),
    CONSTRAINT [FK_PersonAddress_Address_AddressID] FOREIGN KEY ([AddressID]) REFERENCES [Application].[Address] ([AddressID]),
    CONSTRAINT [FK_PersonAddress_AddressType_AddressTypeID] FOREIGN KEY ([AddressTypeID]) REFERENCES [Application].[AddressType] ([AddressTypeID]),
    CONSTRAINT [FK_PersonAddress_LastEditedBy_User_UserID] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[User] ([UserID]),
    PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[PersonAddressHistory]));