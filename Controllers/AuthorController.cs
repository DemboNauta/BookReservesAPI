using AutoMapper;
using BookReservesAPI.Data;
using BookReservesAPI.DTO;
using BookReservesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookReservesAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class AuthorController : ControllerBase
    {
        IDataRepository _dataRepository;
        IMapper _mapper;
        public AuthorController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<AuthorDTO, Author>();
            }));
        }
        [HttpGet("Authors")]
        public IEnumerable<Author> GetAuthors()
        {
            return _dataRepository.GetAuthors();
        }

        [HttpGet("Authors/{authorId}")]
        public Author GetAuthor(int authorId)
        {
            return _dataRepository.GetSingleAuthor(authorId);
        }

        [HttpPost("Authors")]
        public IActionResult PostAuthor(AuthorDTO authorDTO)
        {
            Author author = _mapper.Map<Author>(authorDTO);

            _dataRepository.AddEntity<Author>(author);
            if (_dataRepository.SaveChanges())
            {
                return Ok();
            }
            return BadRequest("Error al subir el autor");
        }

        [HttpPut("Authors")]
        public IActionResult EditAuthors(Author author)
        {
            Book authorDb = _dataRepository.GetSingleBook(author.Id);
            if (authorDb == null)
            {
                return NotFound("Author not found");
            }

            _mapper.Map(author, authorDb);

            if (_dataRepository.SaveChanges())
            {
                return Ok();
            }
            return BadRequest("Failed to update author info");
        }

    }
}
