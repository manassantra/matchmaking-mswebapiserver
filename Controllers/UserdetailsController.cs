using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mswebapiserver.DTOs;
using mswebapiserver.Models.User;

namespace mswebapiserver.Controllers
{
    public class UserdetailsController : BaseapiController
    {
        private readonly DatabaseContext _context;

        public UserdetailsController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpPost("familydetails/{id}")]
        public async Task<ActionResult<FamilyDetailsDTO>> CreateFamilyDetails(int id, FamilyDetailsDTO familyDetails)
        {
            var user = _context.AppUsers.FirstOrDefault(x => x.id == id);
            if (user == null) return BadRequest();
            if (await ExistFamilyDetails(id)) return BadRequest("Family Details Allready exist for this User !");

            var details = new FamilyDetail
            {
                userRefId = id,
                fathersName = familyDetails.fathersName,
                mothersName = familyDetails.mothersName,
                familyType = familyDetails.familyType,
                noOfBrothers = familyDetails.noOfBrothers,
                noOfSisters = familyDetails.noOfSisters,
                nativePlace = familyDetails.nativePlace,
                location = familyDetails.location,
                createdDate = DateTime.Now,
                modifiedDate = DateTime.Now,
                modifiedBy = user.email,
                isActive = true
            };

            _context.UserFamilyDetails.Add(details);
            await _context.SaveChangesAsync();

            return Ok("Family Details Added Successfully !");
        }


        [HttpGet("familydetails/{id}")]
        public ActionResult GetFamilyDetails(int id)
        {
            var familyDetails = _context.UserFamilyDetails.Where(x => x.userRefId == id && x.isActive == true);
            if (familyDetails == null)
            {
                return NotFound("No Details Available !");
            }
            return Ok(familyDetails);
        }


        [HttpPost("personaldetails/{id}")]
        public async Task<ActionResult<PersonalDetailsDTO>>  CreatePerosnalDetails(int id, PersonalDetailsDTO personalDetails)
        {
            var user = _context.AppUsers.FirstOrDefault(x => x.id == id);
            if (user == null) return BadRequest();
            if (await ExistPersonalDetails(id)) return BadRequest("Personal Details already exist for this user !");

            var details = new PersonalDetail
            {
                userRefId = user.id,
                maritalStatus = personalDetails.maritalStatus,
                sunSign = personalDetails.sunSign,
                bloodGroup = personalDetails.bloodGroup,
                height = personalDetails.height,
                age = personalDetails.age,
                dob = personalDetails.dob,
                dite = personalDetails.dite,
                grewUpLocation = personalDetails.grewUpLocation,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                modifiedBy = user.email,
                isActive = true
            };

            _context.UserPersonalDetails.Add(details);
            await _context.SaveChangesAsync();

            return Ok("Personal Details Saved Successfully !");
        }


        [HttpGet("personaldetails/{id}")]
        public ActionResult GetPersonalDetails(int id)
        {
            var personaalDetails = _context.UserPersonalDetails.Where(x => x.userRefId == id && x.isActive == true);
            if (personaalDetails == null)
            {
                return NotFound("No Details Available !");
            }
            return Ok(personaalDetails);
        }


        [HttpPost("educationaldetails/{id}")]
        public async Task<ActionResult<EducationalDetailsDTO>> CreateEducationalDetails(int id, EducationalDetailsDTO educationalDetails)
        {
            var user = _context.AppUsers.FirstOrDefault(x => x.id == id);
            if (user == null) return BadRequest();
            if (await ExistEducationalDetails(id)) return BadRequest("Educational Details Exist for this user !");

            var details = new UserEducationDetail
            {
                userRefId = user.id,
                heighestQualification = educationalDetails.heighestQualification,
                instituteName = educationalDetails.instituteName,
                instituteLocation = educationalDetails.instituteLocation,
                passOutDate = educationalDetails.passOutDate,
                createdDate = DateTime.Now,
                modifiedDate = DateTime.Now,
                modifiedBy = user.email,
                isActive = true
            };

            _context.UserEducationDetails.Add(details);
            await _context.SaveChangesAsync();

            return Ok("Educational Details Saved Successfully !");
        }


        [HttpGet("educationaldetails/{id}")]
        public ActionResult GetEducationalDetails(int id)
        {
            var educationalDetails = _context.UserEducationDetails.Where(x => x.userRefId == id && x.isActive == true);
            if (educationalDetails == null)
            {
                return NotFound("No Details Available !");
            }
            return Ok(educationalDetails);
        }


        [HttpPost("jobdetails/{id}")]
        public async Task<ActionResult<JobDetailsDTO>> CreateJobDetails(int id, JobDetailsDTO jobDetails)
        {
            var user = _context.AppUsers.FirstOrDefault(x => x.id == id);
            if (user == null) return BadRequest();
            if (await ExistJobDetails(id)) return BadRequest("Job Details Exist for this user !");

            var details = new UserJobDetail
            {
                userRefId = user.id,
                JobTitle = jobDetails.JobTitle,
                JobType = jobDetails.JobType,
                companyName = jobDetails.companyName,
                salaryDetails = jobDetails.salaryDetails,
                jobLocation = jobDetails.jobLocation,
                jobStartDate = jobDetails.jobStartDate,
                createdDate = DateTime.Now,
                modifiedDate = DateTime.Now,
                modifiedBy = user.email,
                isDeleted = false
            };

            _context.UserJobDetails.Add(details);
            await _context.SaveChangesAsync();

            return Ok("Job Details Saved Successfully !");
        }

        [HttpGet("jobdetails/{id}")]
        public ActionResult GetJobDetails(int id)
        {
            var jobDetails = _context.UserJobDetails.Where(x => x.userRefId == id && x.isDeleted == false);
            if (jobDetails == null)
            {
                return NotFound("No Details Available !");
            }
            return Ok(jobDetails);
        }



        private async Task<bool> ExistJobDetails(int userRefId)
        {
            return await _context.UserJobDetails.AnyAsync(x => x.userRefId == userRefId && x.isDeleted == false);
        }

        private async Task<bool> ExistEducationalDetails(int userRefId)
        {
            return await _context.UserEducationDetails.AnyAsync(x => x.userRefId == userRefId  && x.isActive == true);  
        }

        private async Task<bool> ExistPersonalDetails(int userRefId)
        {
            return await _context.UserPersonalDetails.AnyAsync(x => x.userRefId == userRefId && x.isActive == true);
        }

        private async Task<bool> ExistFamilyDetails(int userRefId)
        {
            return await _context.UserFamilyDetails.AnyAsync(x => x.userRefId == userRefId && x.isActive == true);
        }
    }
}
