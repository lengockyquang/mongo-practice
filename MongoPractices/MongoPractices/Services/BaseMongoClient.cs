using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoPractices.Models;

namespace MongoPractices.Services;

public class BaseMongoClient: IBaseMongoClient
{
    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;
    
    public BaseMongoClient(IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
    {
        _client = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);
        _database = _client.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);
    }

    public MongoClient GetMongoClient()
    {
        return _client;
    }

    public IMongoDatabase GetMongoDatabase()
    {
        return _database;
    }

    public IMongoDatabase GetMongoDatabase(string databaseName)
    {
        return _client.GetDatabase(databaseName);
    }

    public IMongoCollection<TDocument> GetMongoCollection<TDocument>(string collectionName) where TDocument : class
    {
        return _database.GetCollection<TDocument>(collectionName);
    }
}