CREATE PROCEDURE [Application].[usp_TemporalTables_DeactivateTemporalTables]
AS BEGIN
    
    IF OBJECTPROPERTY(OBJECT_ID('[Application].[Person]'), 'TableTemporalType') = 2
    BEGIN
	    PRINT 'Deactivate Temporal Table for [Application].[Person]'

	    ALTER TABLE [Application].[Person] SET (SYSTEM_VERSIONING = OFF);
	    ALTER TABLE [Application].[Person] DROP PERIOD FOR SYSTEM_TIME;
    END
    
    IF OBJECTPROPERTY(OBJECT_ID('[Application].[Address]'), 'TableTemporalType') = 2
    BEGIN
	    PRINT 'Deactivate Temporal Table for [Application].[Address]'

	    ALTER TABLE [Application].[Address] SET (SYSTEM_VERSIONING = OFF);
	    ALTER TABLE [Application].[Address] DROP PERIOD FOR SYSTEM_TIME;
    END
    
    IF OBJECTPROPERTY(OBJECT_ID('[Application].[AddressType]'), 'TableTemporalType') = 2
    BEGIN
	    PRINT 'Deactivate Temporal Table for [Application].[AddressType]'

	    ALTER TABLE [Application].[AddressType] SET (SYSTEM_VERSIONING = OFF);
	    ALTER TABLE [Application].[AddressType] DROP PERIOD FOR SYSTEM_TIME;
    END
    
    IF OBJECTPROPERTY(OBJECT_ID('[Application].[PersonAddress]'), 'TableTemporalType') = 2
    BEGIN
	    PRINT 'Deactivate Temporal Table for [Application].[PersonAddress]'
    
	    ALTER TABLE [Application].[PersonAddress] SET (SYSTEM_VERSIONING = OFF);
	    ALTER TABLE [Application].[PersonAddress] DROP PERIOD FOR SYSTEM_TIME;                
    END
    
    IF OBJECTPROPERTY(OBJECT_ID('[Application].[User]'), 'TableTemporalType') = 2
    BEGIN
	    PRINT 'Deactivate Temporal Table for [Application].[User]'
    
	    ALTER TABLE [Application].[User] SET (SYSTEM_VERSIONING = OFF);
	    ALTER TABLE [Application].[User] DROP PERIOD FOR SYSTEM_TIME;                
    END
END