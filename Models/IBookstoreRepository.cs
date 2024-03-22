using Microsoft.EntityFrameworkCore.Query;

namespace Mission11_JacobBigler.Models
{
    public interface IBookstoreRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
