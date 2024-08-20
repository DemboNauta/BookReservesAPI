using AutoMapper;
using BookReservesAPI.Data;
using BookReservesAPI.DTO;
using BookReservesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookReservesAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class BookController : ControllerBase
    {
        IDataRepository _dataRepository;
        IMapper _mapper;
        public BookController(IDataRepository dataRepository) 
        {
            _dataRepository = dataRepository;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookDTO, Book>();
                cfg.CreateMap<AuthorDTO, Author>();

            }));

        }

        [HttpGet("Books")]
        public IEnumerable<Book> GetBooks()
        {
            return _dataRepository.GetBooks();
        }

        [HttpGet("Books/{bookId}")]
        public Book GetBook(int bookId)
        {
            return _dataRepository.GetSingleBook(bookId);
        }

        [HttpPost("Books")]
        public IActionResult PostBook(BookDTO bookDTO)
        {
            Book book = _mapper.Map<Book>(bookDTO);

            _dataRepository.AddEntity<Book>(book);
            if (_dataRepository.SaveChanges())
            {
                return Ok();
            }
            return BadRequest("Error al subir el libro");
        }

        [HttpPut("Books")]
        public IActionResult EditBook(Book book)
        {
            Book bookDb = _dataRepository.GetSingleBook(book.Id);
            if (bookDb == null)
            {
                return NotFound("Book not found");
            }

            _mapper.Map(book, bookDb);

            if (_dataRepository.SaveChanges())
            {
                return Ok();
            }
            return BadRequest("Failed to update book info");
        }
        [HttpDelete("Books/{bookId}")]
        public IActionResult DeleteBook(int bookId)
        {
            Book? book = _dataRepository.GetSingleBook(bookId);
            if (book != null)
            {
                _dataRepository.RemoveEntity<Book>(book);
                if (_dataRepository.SaveChanges())
                {
                    return Ok();
                }
            }

            return BadRequest("Failed to delete book");
        }

    }
}
