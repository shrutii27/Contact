using Contact.DTOs;
using Contact.Model;
using Contact.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Contact.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("getAll")]
        public IActionResult Get()
        {
            var users = _userRepository.GetAll();
            if (users.Count == 0)
                return BadRequest("No user added yet");
            return Ok(users);
        }
        [HttpGet("getById/{id:int}")]
        public IActionResult Get(int id)
        {
            var user = _userRepository.GetById(id);
            if (user != null)
                return Ok(user);
            return NotFound("No such user exists");
        }


        [HttpPost("add")]
        public IActionResult Add(UserDto userDto)
        {
            var user = ConvertToModel(userDto);
            int newUserId = _userRepository.Add(user);
            if (newUserId != null)
            {
                return Ok(newUserId);
            }
            return BadRequest("Some issue while adding record");
        }

        [HttpPut("update")]
        public IActionResult Update(User user)
        {
            var modifiedUser = _userRepository.Update(user);
            if (modifiedUser != null)
            {
                return Ok(modifiedUser);
            }

            return BadRequest("Some issue while updating record");
        }

       
        [HttpDelete("delete")]

        public IActionResult Delete(int id)
        {
            bool isRemoved = _userRepository.Delete(id);
            if (isRemoved)
                return Ok(id);
            return BadRequest("No user found to delete");
        }

        private User ConvertToModel (UserDto userDto)
        {
            return new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                IsAdmin = userDto.IsAdmin,
                IsActive = userDto.IsActive,
            };
        }
     }
}

