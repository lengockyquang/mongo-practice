# mongo-practice

## Setup
- Setup your [free mongodb cluster instance](https://account.mongodb.com/account/login)
- Create appsettings.json file
- Add following json content:
```code
{
    "BookStoreDatabase": {
        "ConnectionString": "<MONGO_DB_CONNECTION_STRING",
        "DatabaseName": "<DEFAULT_DATABASE_NAME",
        "BooksCollectionName": "<BOOKS_COLLECTION_NAME"
    },
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    }
}
```
- Run command to start
```
dotnet run
```
