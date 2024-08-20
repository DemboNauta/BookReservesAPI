using BookReservesAPI.Models;

namespace BookReservesAPI.Data
{
    public interface IDataRepository
    {
        public bool SaveChanges();
        public void AddEntity<T>(T entityToAdd);
        public void RemoveEntity<T>(T entityToAdd);
        public IEnumerable<User> GetUsers();
        public IEnumerable<Book> GetBooks();
        public IEnumerable<Reservation> GetReservations();
        public IEnumerable<Author> GetAuthors();

        public User GetSingleUser(int userId);
        public Book GetSingleBook(int bookId);
        public Reservation GetSingleReservation(int reservationId);
        public Author GetSingleAuthor(int authorId);



    }
}
