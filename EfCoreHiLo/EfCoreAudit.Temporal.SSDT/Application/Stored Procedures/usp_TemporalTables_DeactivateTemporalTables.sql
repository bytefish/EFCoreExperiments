CREATE PROCEDURE [Application].[usp_TemporalTables_DeactivateTemporalTables]
AS BEGIN
    IF OBJECTPROPERTY(OBJECT_ID('[Application].[Person]'), 'TableTemporalType') = 2
    BEGIN
	    PRINT 'Deactivate Temporal Table for [Application].[Person]'

	    ALTER TABLE [Application].[Person] SET (SYSTEM_VERSIONING = OFF);
	    ALTER TABLE [Application].[Person] DROP PERIOD FOR SYSTEM_TIME;
    END
END