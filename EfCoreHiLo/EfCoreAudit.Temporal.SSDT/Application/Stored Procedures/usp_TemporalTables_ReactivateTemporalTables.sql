CREATE PROCEDURE [Application].[usp_TemporalTables_ReactivateTemporalTables]
AS BEGIN
    IF OBJECTPROPERTY(OBJECT_ID('[Application].[Person]'), 'TableTemporalType') = 0
    BEGIN
	    PRINT 'Reactivate Temporal Table for [Application].[Person]'

	    ALTER TABLE [Application].[Person] ADD PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo]);
	    ALTER TABLE [Application].[Person] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[PersonHistory], DATA_CONSISTENCY_CHECK = ON));
    END
END