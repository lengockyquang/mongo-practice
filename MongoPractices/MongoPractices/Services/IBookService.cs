using MongoPractices.Models;

namespace MongoPractices.Services;

public interface IBookService
{
    Task<List<Book>> GetAsync(CancellationToken cancellationToken = default);
    Task<Book?> GetAsync(string id, CancellationToken cancellationToken = default);
    Task CreateAsync(Book newBook);
    Task UpdateAsync(string id, Book updatedBook);
    Task RemoveAsync(string id);
}