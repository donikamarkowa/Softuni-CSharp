using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task AddBookAsync(AddBookViewModel model);
        Task AddBookToCollectionAsync(string userId, BookViewModel book);
        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();
        Task<BookViewModel?> GetBookByIdAsync(int id);
        Task<IEnumerable<AllBookViewModel>> GetMyBooksAsync(string userId);
        Task<AddBookViewModel> GetNewAddBookModelAsync();
        Task RemoveFromCollectionAsync(string userId, BookViewModel book);
    }
}
