CREATE PROCEDURE [dbo].[uspGetProducts]
	
	@Command Varchar(100)=NULL

AS

	DECLARE @ErrorMessage Varchar(100)=NULL

	IF @Command='Get-Products'
		BEGIN

		

			BEGIN TRY 

				BEGIN TRANSACTION 


					SELECT 
						P.ProductIdentity,
						P.ProductName as 'ProductName',
						P.UnitPrice
					FROM 
						dbo.Products AS P WITH(NOLOCK)


				COMMIT TRANSACTION

			END TRY 

			BEGIN CATCH
				SET @ErrorMessage=ERROR_MESSAGE();
				RAISERROR(@ErrorMessage,16,1);
				ROLLBACK TRANSACTION
			END CATCH
		END
	

GO

