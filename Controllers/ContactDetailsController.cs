using Contact.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetailsController : ControllerBase
    {
        private readonly IContactDetailsRepository _contactDetailsRepository;

        public ContactDetailsController(IContactDetailsRepository contactDetailsRepository)
        {
            _contactDetailsRepository = contactDetailsRepository;
        }


        [HttpGet("getAllContactDetails")]
        public IActionResult GetAllContactDetails()
        {
            var contactDetails = _contactDetailsRepository.GetAll();
            if (contactDetails.Count == 0)
                return BadRequest("No contact details available");
            return Ok(contactDetails);
        }

        [HttpGet("getContactDetailById/{id:int}")]
        public IActionResult GetContactDetail(int id)
        {
            var contactDetail = _contactDetailsRepository.GetById(id);
            if (contactDetail != null)
                return Ok(contactDetail);
            return NotFound("Contact detail not found");
        }
    }
}
