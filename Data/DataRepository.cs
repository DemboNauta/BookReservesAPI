using BookReservesAPI.Models;
using System.Net;

namespace BookReservesAPI.Data
{
    public class DataRepository : IDataRepository
    {
        DataContext _entityFrameWork;
        public DataRepository(IConfiguration config)
        {
            _entityFrameWork = new DataContext(config);
        }

        public void AddEntity<T>(T entityToAdd)
        {
            if (entityToAdd != null) _entityFrameWork.Add(entityToAdd);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _entityFrameWork.Books.ToList();
        }

        public IEnumerable<Reservation> GetReservations()
        {
            return _entityFrameWork.Reservations.ToList();
        }
        public IEnumerable<Author> GetAuthors()
        {
            return _entityFrameWork.Authors.ToList();
        }

        public Book GetSingleBook(int bookId)
        {
            Book? book = _entityFrameWork.Books.Where(b => b.Id == bookId).FirstOrDefault();
            if (book != null)
            {
                return book;
            }
            throw new Exception("Failed to Get Book");
        }

        public Reservation GetSingleReservation(int reservationId)
        {
            Reservation? reservation = _entityFrameWork.Reservations.Where(r => r.Id == reservationId).FirstOrDefault();
            if (reservation != null)
            {
                return reservation;
            }
            throw new Exception("Failed to Get Reservation");
        }

        public User GetSingleUser(int userId)
        {
            User? user = _entityFrameWork.Users.Where(u => u.Id == userId).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            throw new Exception("Failed to Get User");
        }
        public Author GetSingleAuthor(int authorId)
        {
            Author? author = _entityFrameWork.Authors.Where(a => a.Id == authorId).FirstOrDefault();
            if (author != null)
            {
                return author;
            }
            throw new Exception("Failed to Get Author");
        }

        public IEnumerable<User> GetUsers()
        {
            return _entityFrameWork.Users.ToList();
        }

        public void RemoveEntity<T>(T entityToAdd)
        {
            if (entityToAdd != null) _entityFrameWork.Remove(entityToAdd);
        }

        public bool SaveChanges()
        {
            return _entityFrameWork.SaveChanges() > 0;
        }
    }
}
