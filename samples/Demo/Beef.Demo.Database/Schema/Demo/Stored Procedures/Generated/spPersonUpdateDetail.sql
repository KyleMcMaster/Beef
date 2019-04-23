CREATE PROCEDURE [Demo].[spPersonUpdateDetail]
   @PersonId AS UNIQUEIDENTIFIER
  ,@FirstName AS NVARCHAR(50) NULL = NULL
  ,@LastName AS NVARCHAR(50) NULL = NULL
  ,@Birthday AS DATE NULL = NULL
  ,@GenderId AS UNIQUEIDENTIFIER NULL = NULL
  ,@Street AS NVARCHAR(100) NULL = NULL
  ,@City AS NVARCHAR(100) NULL = NULL
  ,@RowVersion AS TIMESTAMP
  ,@UpdatedBy AS NVARCHAR(250) NULL = NULL
  ,@UpdatedDate AS DATETIME2 NULL = NULL
  ,@UniqueCode AS NVARCHAR(20) NULL = NULL
  ,@WorkHistoryList AS [Demo].[udtWorkHistoryList] READONLY
  ,@ReselectRecord AS BIT = 0
AS
BEGIN
  /*
   * This file is automatically generated; any changes will be lost. 
   */
 
  SET NOCOUNT ON;
  
  BEGIN TRY
    -- Wrap in a transaction.
    BEGIN TRANSACTION

    -- Set audit details, etc.
    EXEC @UpdatedDate = fnGetTimestamp @UpdatedDate
    EXEC @UpdatedBy = fnGetUsername @UpdatedBy

    -- Check exists.
    DECLARE @PrevRowVersion BINARY(8)
    SET @PrevRowVersion = (SELECT TOP 1 x.[RowVersion] FROM [Demo].[Person] AS x WHERE x.[PersonId] = @PersonId)
    IF @PrevRowVersion IS NULL
    BEGIN
      EXEC spThrowNotFoundException
    END

    -- Check concurrency (where provided).
    IF @RowVersion IS NULL OR @PrevRowVersion <> @RowVersion
    BEGIN
      EXEC spThrowConcurrencyException
    END

    -- Update the record.
    UPDATE [Demo].[Person] SET
         [FirstName] = @FirstName
        ,[LastName] = @LastName
        ,[Birthday] = @Birthday
        ,[GenderId] = @GenderId
        ,[Street] = @Street
        ,[City] = @City
        ,[UpdatedBy] = @UpdatedBy
        ,[UpdatedDate] = @UpdatedDate
        ,[UniqueCode] = @UniqueCode
      WHERE [PersonId] = @PersonId

    -- Execute additional statements.
    EXEC [Demo].[spWorkHistoryMerge] @PersonId, @WorkHistoryList

    -- Commit the transaction.
    COMMIT TRANSACTION
  END TRY
  BEGIN CATCH
    -- Rollback transaction and rethrow error.
    IF @@TRANCOUNT > 0
      ROLLBACK TRANSACTION;

    THROW;
  END CATCH
  
  -- Reselect record.
  IF @ReselectRecord = 1
  BEGIN
    EXEC [Demo].[spPersonGetDetail] @PersonId
  END
END