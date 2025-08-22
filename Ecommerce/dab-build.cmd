@echo off
@echo This cmd file creates a Data API Builder configuration based on the chosen database objects.
@echo To run the cmd, create an .env file with the following contents:
@echo dab-connection-string=your connection string
@echo ** Make sure to exclude the .env file from source control **
@echo **
dotnet tool install -g Microsoft.DataApiBuilder
dab init -c dab-config.json --database-type mssql --connection-string "@env('dab-connection-string')" --host-mode Development
@echo Adding tables
dab add "Category" --source "[dbo].[CATEGORY]" --fields.include "id,categoryName,description,remark,isActive" --permissions "anonymous:*" 
dab add "File" --source "[dbo].[FILE]" --fields.include "id,name,tableName,dataName,mainId,descriptions,option1,option2,remark" --permissions "anonymous:*" 
dab add "Order" --source "[dbo].[ORDER]" --fields.include "id,name,address,remark,phone,timer" --permissions "anonymous:*" 
dab add "OrderDetail" --source "[dbo].[ORDER_DETAILS]" --fields.include "id,productName,price,orderId,remark,note" --permissions "anonymous:*" 
dab add "Product" --source "[dbo].[PRODUCT]" --fields.include "id,productName,price,imgUrl,descriptions,categoryId,isActive,isDelete,shopId" --permissions "anonymous:*" 
dab add "Profile" --source "[dbo].[PROFILE]" --fields.include "id,name,email,phone" --permissions "anonymous:*" 
dab add "Shop" --source "[dbo].[SHOP]" --fields.include "id,logoUrl,shopName,descriptions,address,profileId" --permissions "anonymous:*" 
dab add "User" --source "[dbo].[USER]" --fields.include "id,userName,passWord,type,profileId,roleName" --permissions "anonymous:*" 
@echo Adding views and tables without primary key
@echo Adding relationships
@echo Adding stored procedures
@echo **
@echo ** run 'dab validate' to validate your configuration **
@echo ** run 'dab start' to start the development API host **
