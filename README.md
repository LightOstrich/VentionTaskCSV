# VentionTaskCSV
The app should be created with .NET WebAPI. 
The app should contain the following two endpoints:

Endpoint1: Upload a CSV file that contains information about users. 
The structure of the file should be as follows: username,useridentifier,age,city,phonenumber,email. 
The app should parse the file and save data from the file to a Database. 
If users do not exist, you should add them. If users exist, you should update their record in the database with the new data from the file.

Endpoint2: Return a set of user objects. 
This endpoint must also provide sorting and limitation features: Sorting can only be applied to the "username" property, and you should specify the sort direction (ascending or descending). 
Limitations: It should be possible to specify the maximum number of users (objects) included in an API response.

Both features are optional, and you can choose to omit one or both of them or apply both simultaneously.
