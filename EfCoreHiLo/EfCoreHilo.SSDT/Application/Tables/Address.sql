CREATE TABLE [Application].[Address](
    [AddressID]             INT                                         CONSTRAINT [DF_Application_Address_AddressID] DEFAULT (NEXT VALUE FOR [Application].[sq_Address]) NOT NULL,
    [AddressLine1]          NVARCHAR(255)                               NOT NULL,
    [AddressLine2]          NVARCHAR(255)                               NULL,
    [PostalCode]            NVARCHAR(255)                               NULL,
    [City]                  NVARCHAR(255)                               NOT NULL,
    [RowVersion]            ROWVERSION                                  NULL,
    [LastEditedBy]          INT                                         NOT NULL,
    [ValidFrom]             DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [ValidTo]               DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY ([AddressID]),
    CONSTRAINT [FK_Address_LastEditedBy_User_UserID] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[User] ([UserID]),
    PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[AddressHistory]));