CREATE TABLE [Application].[AddressType](
    [AddressTypeID]         INT                                         CONSTRAINT [DF_Application_AddressType_AddressTypeID] DEFAULT (NEXT VALUE FOR [Application].[sq_AddressType]) NOT NULL,
    [Name]                  NVARCHAR(255)                               NOT NULL,
    [ValidFrom]             DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [ValidTo]               DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY ([PersonID]),
    PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[AddressTypeHistory]));