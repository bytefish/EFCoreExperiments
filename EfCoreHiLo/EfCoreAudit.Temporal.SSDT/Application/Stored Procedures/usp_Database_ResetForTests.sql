CREATE PROCEDURE [Application].[usp_Database_ResetForTests]
AS BEGIN
    EXECUTE [Application].[usp_TemporalTables_DeactivateTemporalTables];

    EXEC(N'DELETE FROM [Application].[PersonAddress]');
    EXEC(N'DELETE FROM [Application].[AddressType]');
    EXEC(N'DELETE FROM [Application].[Address]');
    EXEC(N'DELETE FROM [Application].[Person]');

    EXECUTE [Application].[usp_TemporalTables_ReactivateTemporalTables];
END