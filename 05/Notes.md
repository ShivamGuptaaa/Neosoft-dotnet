# Middlewares to connect backend (Db) with app
## [ADO.Net](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ado-net-overview)
- It is a framework within .Net which is used to connect the backend with the app front using .Net compliant languages.
- We can use this framework: 
  - Connecting to a data source (Excel, MS Access, Oracle Db, Postgres Sql, Sql Server and more....)
  - Read data from data base and filter it
  - Manipulate data 
  - Perform transactions
  - ...more
- ADO.Net supports 2 types of app architecture:
  - Connected architecture
    - app is connected to Db all the time 
  - Disconnected architecture
    - app doesn't need to be connected with the server all the time.
    - User can perform operations offline and can push the data once server is connected
    - mordern multi-tier applications use disconnected architecture for scalibility and extensibility 
- [ADO.NET Components](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ado-net-architecture):
    1. .NET Data Providers
       - used for data manipulation and fast, forward-only, read-only access to data.
       - Various objects of this components are used to perform various duties:
         - **Connection** object provide connectivity to data source
         - **Command** object enables connection to DB commands to *return data*, *modify data*, *run SP, send or retrieve parameters*           
            - Command          - Return Value                                     
            - ExecuteReader    - Returns a DataReader object                      
            - ExecuteScalar    - Returns a single scalar value                    
            - ExecuteNonQuery  - Executes a command that does not return any rows 
            
         - **DataReader** object provides high performance stream of data from data source in *forward only* direction.
         - **DataAdapter** object provides *bridge* between **dataset** object and the data source. Data adapter uses **Command** object to execute the SQL commands ant the data source to load dataset.

    2. [Dataset](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ado-net-datasets)
        - its like mini database at client's end whicg can be used to perform db operations locally and then pushing this dataset to make changes to actual data source
        - Data set consists of 
          - DataTableCollection
            - DataRowCollection
              - DataRow
            - DataColumnCollection
              - DataColumn
          - DataRelationColection
   - Choosing between DataReader or a DataSet
     - Cache data locally in your app to manipulate use **DataSet**
     - If you need to read results of a query **DataReader** is a better choice
     - remote data between tiers use dataset
     - interact with data dynamically, ex binding drop down values from db use dataset
     - perform extensive processing on data without opening connection to the data source
     - while using LINQ to dataset to quwery data at compile time with type checking.
- **[Connection Pooling](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-pooling)**
  - Connecting to a data source can be time consuming. To minimize the cost of opening connections, ADO.NET uses an optimization technique called connection pooling, which minimizes the cost of repeatedly opening and closing connections.
## Entity Framework/Entity Framework core 
- The baseline for this framework is ADO.NET and we call it as ORM