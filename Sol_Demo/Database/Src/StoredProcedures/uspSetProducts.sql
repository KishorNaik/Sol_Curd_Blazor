CREATE PROCEDURE [dbo].[uspSetProducts]
	@Command Varchar(100)=NULL,

	@ProductIdentity uniqueidentifier=NULL,
	@ProductName Varchar(100)=NULL,
	@UnitPrice Float=NULL
	
AS

	DECLARE @ErrorMessage Varchar(MAX)=NULL;
	DECLARE @IsProductExists bit=NULL;

	IF @Command='Add'
		BEGIN
			
			BEGIN TRY 

				BEGIN TRANSACTION 

					SET @IsProductExists=dbo.IsProductNameExists(@ProductIdentity,@ProductName);

					IF @IsProductExists=0
						BEGIN
							SELECT 'Add Product' AS 'Message';

							INSERT INTO dbo.Products
							(
								ProductIdentity,
								ProductName,
								UnitPrice
							)
							VALUES
							(
								NEWID(),
								@ProductName,
								@UnitPrice
							)

						END
					ELSE
						BEGIN
							SELECT 'Product already exists in database.' as 'Message';
						END
					

				COMMIT TRANSACTION

			END TRY 

			BEGIN CATCH
				SET @ErrorMessage=ERROR_MESSAGE();
				RAISERROR(@ErrorMessage,16,1);
				ROLLBACK TRANSACTION
			END CATCH

		END
	ELSE IF @Command='Update'
		BEGIN

			BEGIN TRY 

				BEGIN TRANSACTION 

					SET @IsProductExists=dbo.IsProductNameExists(@ProductIdentity,@ProductName);

					IF @IsProductExists=0
						BEGIN
							SELECT 'Update Product' AS 'Message';

							UPDATE dbo.Products
								SET 
									ProductName=@ProductName,
									UnitPrice=@UnitPrice
								WHERE
									ProductIdentity=@ProductIdentity

						END
					ELSE
						BEGIN
							SELECT 'Product already exists in database.' as 'Message';
						END
					

				COMMIT TRANSACTION

			END TRY 

			BEGIN CATCH
				SET @ErrorMessage=ERROR_MESSAGE();
				RAISERROR(@ErrorMessage,16,1);
				ROLLBACK TRANSACTION
			END CATCH
		END
	ELSE IF @Command='Delete'
		BEGIN

			BEGIN TRY 

				BEGIN TRANSACTION 

					DELETE FROM dbo.Products WHERE ProductIdentity=@ProductIdentity
					

				COMMIT TRANSACTION

			END TRY 

			BEGIN CATCH
				SET @ErrorMessage=ERROR_MESSAGE();
				RAISERROR(@ErrorMessage,16,1);
				ROLLBACK TRANSACTION
			END CATCH
		END
	
		

GO