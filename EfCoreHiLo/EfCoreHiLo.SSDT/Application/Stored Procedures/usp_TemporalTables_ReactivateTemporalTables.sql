CREATE PROCEDURE [Application].[usp_TemporalTables_ReactivateTemporalTables]
AS BEGIN
    IF OBJECTPROPERTY(OBJECT_ID('[Application].[Person]'), 'TableTemporalType') = 0
    BEGIN
	    PRINT 'Reactivate Temporal Table for [Application].[Person]'

	    ALTER TABLE [Application].[Person] ADD PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo]);
	    ALTER TABLE [Application].[Person] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[PersonHistory], DATA_CONSISTENCY_CHECK = ON));
    END
    
    IF OBJECTPROPERTY(OBJECT_ID('[Application].[Address]'), 'TableTemporalType') = 0
    BEGIN
	    PRINT 'Reactivate Temporal Table for [Application].[Address]'

	    ALTER TABLE [Application].[Address] ADD PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo]);
	    ALTER TABLE [Application].[Address] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[AddressHistory], DATA_CONSISTENCY_CHECK = ON));
    END    

    IF OBJECTPROPERTY(OBJECT_ID('[Application].[AddressType]'), 'TableTemporalType') = 0
    BEGIN
	    PRINT 'Reactivate Temporal Table for [Application].[AddressType]'

	    ALTER TABLE [Application].[AddressType] ADD PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo]);
	    ALTER TABLE [Application].[AddressType] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[AddressTypeHistory], DATA_CONSISTENCY_CHECK = ON));
    END    

    IF OBJECTPROPERTY(OBJECT_ID('[Application].[PersonAddress]'), 'TableTemporalType') = 0
    BEGIN
	    PRINT 'Reactivate Temporal Table for [Application].[PersonAddress]'

	    ALTER TABLE [Application].[PersonAddress] ADD PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo]);
	    ALTER TABLE [Application].[PersonAddress] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[PersonAddressHistory], DATA_CONSISTENCY_CHECK = ON));
    END    

    IF OBJECTPROPERTY(OBJECT_ID('[Application].[User]'), 'TableTemporalType') = 0
    BEGIN
	    PRINT 'Reactivate Temporal Table for [Application].[User]'

	    ALTER TABLE [Application].[User] ADD PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo]);
	    ALTER TABLE [Application].[User] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[UserHistory], DATA_CONSISTENCY_CHECK = ON));
    END
END