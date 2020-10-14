CREATE FUNCTION [dbo].[IsProductNameExists]
(
	@ProductIdentity uniqueidentifier=null,
	@ProductName Varchar(100)=null
)
RETURNS Bit
AS
BEGIN
	
	DECLARE @Flag bit

	IF @ProductIdentity IS NULL
		BEGIN
			
			IF EXISTS
				(
					SELECT 
						P.ProductId
					FROM 
						dbo.Products AS P WITH(NOLOCK)
					WHERE
						P.[ProductName]=@ProductName
				)
				BEGIN
					SET @Flag=1
				END
			ELSE
				BEGIN
					SET @Flag=0
				END 
		END
	ELSE
		BEGIN
			IF EXISTS
				(
					SELECT 
						P.ProductId
					FROM 
						dbo.Products AS P WITH(NOLOCK)
					WHERE
						P.[ProductName]=@ProductName
						AND
						P.ProductIdentity<>@ProductIdentity
				)
				BEGIN
					SET @Flag=1
				END
			ELSE
				BEGIN
					SET @Flag=0
				END 
		END


		RETURN @Flag;

END
