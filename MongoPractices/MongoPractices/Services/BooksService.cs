using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoPractices.Models;

namespace MongoPractices.Services;

public class BooksService: IBookService
{
    private readonly IMongoCollection<Book> _booksCollection;
    
    public BooksService(IBaseMongoClient baseMongoClient, IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
    {
        var bookCollectionName = bookStoreDatabaseSettings.Value.BooksCollectionName;
        _booksCollection = baseMongoClient.GetMongoCollection<Book>(bookCollectionName);
    }

    public async Task<List<Book>> GetAsync(CancellationToken cancellationToken = default) =>
        await _booksCollection.Find(_ => true).ToListAsync(cancellationToken);

    public async Task<Book?> GetAsync(string id, CancellationToken cancellationToken = default) =>
        await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);

    public async Task CreateAsync(Book newBook) =>
        await _booksCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, Book updatedBook) =>
        await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _booksCollection.DeleteOneAsync(x => x.Id == id);
}