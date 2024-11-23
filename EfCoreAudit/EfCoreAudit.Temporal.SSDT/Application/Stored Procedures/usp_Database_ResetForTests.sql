CREATE PROCEDURE [Application].[usp_Database_ResetForTests]
AS BEGIN
    EXECUTE [Application].[usp_TemporalTables_DeactivateTemporalTables];

    EXEC(N'DELETE FROM [Application].[Person]');
    EXEC(N'DELETE FROM [Application].[PersonHistory]');

    EXECUTE [Application].[usp_TemporalTables_ReactivateTemporalTables];
END