using AutoMapper;
using BookReservesAPI.Data;
using BookReservesAPI.DTO;
using BookReservesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookReservesAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class UserController : Controller
    {
        IDataRepository _dataRepository;
        IMapper _mapper;
        public UserController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
            }));

        }
        [HttpGet("Users")]
        public IEnumerable<User> GetUsers()
        {
            return _dataRepository.GetUsers();
        }

        [HttpGet("Users/{userId}")]
        public User GetUser(int userId)
        {
            return _dataRepository.GetSingleUser(userId);
        }

        [HttpPost("Users")]
        public IActionResult PostUser(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);

            _dataRepository.AddEntity<User>(user);
            if (_dataRepository.SaveChanges())
            {
                return Ok();
            }
            return BadRequest("Error al añadir el usuario");
        }

        [HttpPut("Users")]
        public IActionResult EditUser(User user)
        {
            User? userDb = _dataRepository.GetSingleUser(user.Id);
            if (userDb != null)
            {
                userDb.Email = user.Email;
                userDb.FirstName = user.FirstName;
                userDb.LastName = user.LastName;
                userDb.DNI = user.DNI;
                if (_dataRepository.SaveChanges())
                {
                    return Ok();
                }
            }
            return BadRequest("Failed to Update User");
        }

        [HttpDelete("Users/{userdId}")]
        public IActionResult DeleteUser(int userdId)
        {
            User? user = _dataRepository.GetSingleUser(userdId);
            if (user != null)
            {
                _dataRepository.RemoveEntity<User>(user);
                if (_dataRepository.SaveChanges())
                {
                    return Ok();
                }
            }

            return BadRequest("Failed to delete user");
        }
    }
}
