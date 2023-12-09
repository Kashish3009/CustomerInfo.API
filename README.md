
# CustomerInfo API v1

**Live** **on**: https://api-customerinfo-eastus-001.azurewebsites.net/swagger/index.html 

This is a .NET 7 (core) based web APIs project that renders a scenario to store the customer information like FirstName, LastName, Email, Phone.

Operations supported:

    1. Create a Customer record
    2. Fetch all customers records 
    3. Fetch a customer by Id 
    4. Update customer record
    5. Delete a customer record by Id



## Demo

![CustomerInfo APIs](https://github.com/Kashish3009/CustomerInfo.API/assets/28315450/71d23f0f-2fe3-4f36-9df5-24adaabb9b8d)

## API Reference

#### Get all customers

```http
  GET /api/customers
```

| Query Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `filterOn` | `string` | **optional** - field to filter on |
| `filterQuery` | `string` | **optional** - value of the field |
| `sortBy` | `string` | **optional** - field name  |
| `isAscending` | `bool` | **optional** - 'true' or 'false' |
| `pageNumber` | `int` | **optional** - page number to fetch |
| `pageSize` | `int` | **optional** - no. of records in one page |

**Example**: /api/customers?filterOn=FirstName&filterQuery=Kashish&sortBy=LastName&isAscending&pageNumber=1&pageSize=10

#### Get customer by id

```http
  GET /api/customers/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required** - Id of item to fetch |

#### Create customer

```http
  POST /api/customers
```

Body Schema:

{
  "firstName": "string",
  "lastName": "string",
  "email": "user@example.com",
  "phoneNumber": "string"
}

#### Update customer

```http
  PUT /api/customers/{id}
```

|  Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `FirstName`      | `string` | **Required** -  first name of the customer |
| `LastName`      | `string` | **Required** - last name of the customer |
| `Email`      | `string` | **Required** - email id of the customer |
| `PhoneNumber`      | `string` | **Required** - phone number of the customer |

Body Schema:

{ "firstName": "string", "lastName": "string", "email": "user@example.com", "phoneNumber": "string" }



#### Delete customer

```http
  DELETE /api/customers/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required** - Id of customer to be deleted |

## Tech Stack

    1. .NET core 7
    2. Web API
    3. C#
    4. Azure
    5. MS SQl Server database
    6. Github
    7. Swagger UI
    8. Visual Studio 2022 IDE community edition

## Cloning the code

Follow below steps sequentially for cloning the source code to your local workspace:


__Using cmd:__

Step 1:  Open Git Bash.

Step 2: Change the current working directory to the location where you want the cloned directory

Step 3: Copy below command in the git bash and hit enter.

```bash
    git clone https://github.com/Kashish3009/CustomerInfo.API.git
```

####
![image](https://github.com/Kashish3009/CustomerInfo.API/assets/28315450/3db1a9d8-6463-4e08-a6e5-7949f2a3c408)


__Using Visual Studio 2022 UI__

To clone directly using Visual Studio 2022, open Visual Studio 2022 and 

        1. Go to "File", 
        2. Click on "Clone Repository", 
        3. Copy below URL

```bash
    https://github.com/Kashish3009/CustomerInfo.API.git
```
        5. Paste the URL in the "Repository Location" box.
        6. Click on "Clone" button.

####
![image](https://github.com/Kashish3009/CustomerInfo.API/assets/28315450/a752c84b-2e6b-4523-9ec6-94c571356dc2)


Reference: https://docs.github.com/en/repositories/creating-and-managing-repositories/cloning-a-repository
## Deployment to Azure cloud

After cloning the source code in local environment,  follow steps below to deploy in Azure cloud:


**Pre-requisites:**

        1. Azure Account: If you don't have an Azure account, you can sign up for a free account here.
        2. Visual Studio 2022: Ensure you have Visual Studio 2022 installed on your machine.


__Step 1: Create an Azure Account and Activate Subscription.__
            
        1. Sign Up for Azure: Go to Azure Portal and sign up for a new Azure account.   
        2. Activate Subscription: Once signed in, activate your Azure subscription.

__Step 2: Create a Resource Group in Azure UI__

        1. Navigate to the Azure Portal: Open the Azure Portal.
        2. To create a Resource group, In the left sidebar, click on "Resource groups."
        3. Click the "+ Add" button.
        4. Fill in the required details (Name, Region etc.).
        4. Click "Review + create" and then "Create."


__Step 3: Create App Service in Azure UI__

        1. Navigate to Resource Group: In the Azure Portal, go to your newly created resource group.
        2. To create an App Service, Click on "+ Add."
        3. Search for "App Service" and select it.
        4. Click "Create."
        5. Fill in the required details (App name, Subscription, Resource group, OS, etc.).
        6. Click "Review + create" and then "Create."

__Step 4: Add SQL Server DB to Resource Group__
        
        1. Navigate to Resource Group: In the Azure Portal, go to your resource group.
        2. Add SQL Server: Click on "+ Add."
        3. Search for "SQL Database" and select it.
        4. Click "Create."
        5. Fill in the required details (Database name, Server, Pricing tier, etc.).
        6. Click "Review + create" and then "Create."

__Step 5: Add SQL Database to SQL Server__

        1. Navigate to SQL Server: In the Azure Portal, go to your SQL Server instance.
        2. Add a Database: In the left sidebar, under Settings, click on "Databases."
        3. Click "+ Add" and fill in the required details.
        4. Click "Review + create" and then "Create."

__Step 6: Add Local IP Address to Networking in Azure SQL Server__

        1. Navigate to SQL Server: In the Azure Portal, go to your SQL Server instance.
        2. Configure Firewall Rules: In the left sidebar, under Settings, click on "Firewalls and virtual networks."
        3. Add the IP address range of your local SQL Server to the allowed IP addresses.

__Step 7: Publish API from Visual Studio IDE__

        1. Open your .NET Core 7 Web API project in Visual Studio 2022 you cloned after following "cloning" section.
        2. Right-Click on Project: Right-click on your project in Solution Explorer.
        3. Select "Publish."
        4. Publish to Azure: Choose "Azure" as the target.
        5. Click "Create New" to configure the connection.
        6. Follow the wizard to configure your Azure App Service.
        7. Click "Publish" to deploy your API to Azure.

####
![image](https://github.com/Kashish3009/CustomerInfo.API/assets/28315450/0440ae66-b6be-4c93-aa5b-dca8c7f8f0ef)


__Step 8: Verify Deployment__

        1. Check App Service: Go to the Azure Portal.
        2. Navigate to your App Service.
        3. In the left sidebar, click on "Overview" to get the URL.

__Test the API:__
    Use tools like Postman, curL etc. to test your API using the Azure App Service URL.

Congratulations!! You have successfully deployed customersInfo API to Azure App Service with an Azure SQL Database.


## References

Install .NET 7: https://dotnet.microsoft.com/en-us/download/dotnet/7.0 

Download Visual Studio 2022 community edition: https://visualstudio.microsoft.com/vs/community/

Download and install SQL Server: https://www.microsoft.com/en-in/sql-server/sql-server-downloads

Create Azure account: https://azure.microsoft.com/en-in/free

Create Azure Resource group: https://techcommunity.microsoft.com/t5/startups-at-microsoft/step-by-step-guide-creating-an-azure-resource-group-on-azure/ba-p/3792368

Create SQl Server DB in Azure: https://learn.microsoft.com/en-us/azure/azure-sql/database/single-database-create-quickstart?view=azuresql&tabs=azure-portal 

Connect SSMS to Azure SQl DB: https://learn.microsoft.com/en-us/azure/azure-sql/database/connect-query-ssms?view=azuresql 

Publish .NET Core Web API to Azure using Visual Studio 2022 IDE: https://learn.microsoft.com/en-us/aspnet/core/tutorials/publish-to-azure-webapp-using-vs?view=aspnetcore-8.0

Deploy .NET Core and Azure SQL DB in Azure: https://learn.microsoft.com/en-us/azure/app-service/tutorial-dotnetcore-sqldb-app 


