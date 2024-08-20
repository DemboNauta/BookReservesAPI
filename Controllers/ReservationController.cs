using AutoMapper;
using BookReservesAPI.Data;
using BookReservesAPI.DTO;
using BookReservesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookReservesAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ReservationController : Controller
    {
        IDataRepository _dataRepository;
        IMapper _mapper;
        public ReservationController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReservationDTO, Reservation>();
            }));

        }
        [HttpGet("Reservations")]
        public IEnumerable<Reservation> GetReservations()
        {
            return _dataRepository.GetReservations();
        }

        [HttpGet("Reservations/{reservationId}")]
        public Reservation GetReservation(int reservationId)
        {
            return _dataRepository.GetSingleReservation(reservationId);
        }

        [HttpPost("Reservations")]
        public IActionResult PostReservation(ReservationDTO user)
        {
            Reservation reservation = _mapper.Map<Reservation>(user);

            _dataRepository.AddEntity<Reservation>(reservation);
            if (_dataRepository.SaveChanges())
            {
                return Ok();
            }
            return BadRequest("Error al añadir la reserva");
        }
        [HttpPut("Reservations")]
        public IActionResult EditReservations(User user)
        {
            Reservation reservationDb = _dataRepository.GetSingleReservation(user.Id);
            if (reservationDb == null)
            {
                return NotFound("Reservation not found");
            }

            _mapper.Map(user, reservationDb);

            if (_dataRepository.SaveChanges())
            {
                return Ok();
            }
            return BadRequest("Failed to update reservation");
        }

    }
}
