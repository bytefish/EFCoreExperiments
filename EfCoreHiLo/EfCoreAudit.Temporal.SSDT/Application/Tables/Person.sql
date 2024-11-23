CREATE TABLE [Application].[Person](
    [PersonID]              INT                                         CONSTRAINT [DF_Application_Person_PersonID] DEFAULT (NEXT VALUE FOR [Application].[sq_Person]) NOT NULL,
    [FullName]              NVARCHAR(255)                               NOT NULL,
    [PreferredName]         NVARCHAR(255)                               NULL,
    [Email]                 NVARCHAR(2000)                              NULL,
    [RowVersion]            ROWVERSION                                  NULL,
    [LastEditedBy]          INT                                         NOT NULL,
    [ValidFrom]             DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [ValidTo]               DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY ([PersonID]),
    CONSTRAINT [FK_Person_LastEditedBy_User_UserID] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[User] ([UserID]),
    PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[PersonHistory]));