using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mswebapiserver.DTOs;
using mswebapiserver.Interfaces;
using mswebapiserver.Models;


namespace mswebapiserver.Controllers.AddressController
{
    [Authorize]
    public class AddressController : BaseapiController
    {
        private readonly DatabaseContext _context;
        private readonly ITokenService _tokenService;

        public AddressController(DatabaseContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }


        [HttpGet("")]
        public ActionResult<IList<AddressDetail>> GetAllResult()
        {
            return _context.AddressDetails.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<IList<AddressDetail>> GetAddressDetails(string? id)
        {
            var allAddress = _context.AddressDetails.ToList();
            List<AddressDetail> addresses = allAddress.FindAll(x => x.uid == id);
            return addresses;
        }


        [HttpPost("create/{id}")]
        public async Task<ActionResult<AddressDetailsDTO>> CreateAddress(int id, AddressDetailsDTO addressDetails)
        {
            var user = _context.AppUsers.FirstOrDefault(x => x.id == id);
            if (user == null) return BadRequest("Unauthorized Operations");
            if (await AddressExist(addressDetails.AddressType)) return BadRequest(user.firstName + "'s " + addressDetails.AddressType + " Address Already Exist");

            var address = new AddressDetail
            {
                uid = user.uid,
                AddressType = addressDetails.AddressType,
                AddressLine1 = addressDetails.AddressLine1,
                AddressLine2 = addressDetails.AddressLine2,
                City = addressDetails.City,
                State = addressDetails.State,
                Country = addressDetails.Country,
                PinCode = addressDetails.PinCode,
                createdDate = DateTime.Now,
                modifiedDate = DateTime.Now,
                modifiedBy = user.email,
                isActive = true,
            };
            _context.AddressDetails.Add(address);
            await _context.SaveChangesAsync();
            return Ok( address.AddressType + " Address Created Successfully !");
        }

        private async Task<bool> AddressExist(string? addressType)
        {
            return await _context.AddressDetails.AnyAsync(x => x.AddressType == addressType);
        }
    }
}
