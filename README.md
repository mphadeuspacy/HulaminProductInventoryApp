# HulaminProductInventoryApp

A simple Rolled Products inventory system.

Preconditions before running the source code.
1. SQL Server database access.
2. Create a fresh empty database called Northwind (No need to attach the already existing one). This one is more light weight.
3. Run VS solution 'Gijima.Hulamin.sln' & assert 6 project are loaded successfully.
4. Project 'Gijima.Hulamin.Db' will be used as the Data Store, so do the following:
  1. Right click.
  2. Click 'Schema Compare'
  3. On the right drop down 'Select Target' & Select the newly created Database in 2 (Northwind), then click OK.
  4. Click 'Compare' button. This will compare the 'Gijima.Hulamin.Db' schema with the database created in 2.
  5. Click 'Update'. This will sync the 'Gijima.Hulamin.Db' with database created in 2.
5. Set 'Gijima.Hulamin.WinFormsClient' as a start up project. (Should also assert 'Gijima.Hulamin.WebApi' is also running, 
  or hosted as this will be used as a service to communite with the data store from any platform in this case Desktop client.
  
Limitations:
1. As it stands the UI only caters for 'Supplier' maintenance.
2. Database only caters for Suppliers, Products, & Categories CRUD.
3. Code base services, APIS, & Unit Tests only test for these.
4. Test database not static, so test are sometimes failing on type of data stored, not correct way, but suffice for now.
5. DIs not yet configured to work as IoC containers.
6. Not all validations implemented, especially on the UI.
