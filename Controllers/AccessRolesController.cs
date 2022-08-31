using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mswebapiserver.DTOs;
using mswebapiserver.Models;

namespace mswebapiserver.Controllers
{
    public class AccessRolesController : BaseapiController
    {
        // Database Const
        private readonly DatabaseContext _context;
        public AccessRolesController(DatabaseContext context)
        {
            _context = context;
        }


        // GET - Get All Roles
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IList<ApplicationRole>>  GetAllDetails()
        {
            return _context.ApplicationRoles.ToList();
        }


        // POST - Create Role 
        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<ActionResult<ApplicationRoleDTO>> CreateRoles(ApplicationRoleDTO appRoleDto)
        {
            if (await RoleExist(appRoleDto.roleName)) return BadRequest(appRoleDto.roleName + " - Allready Exist");

            if (appRoleDto == null) return BadRequest("Please fill all fields");

            var role = new ApplicationRole
            {
                roleName = appRoleDto.roleName,
                Description = appRoleDto.Description,
                createdDate = DateTime.Now,
                modifiedBy = null,
                modifiedDate = DateTime.Now,
                isActive  = true
            };
            _context.ApplicationRoles.Add(role);
            await _context.SaveChangesAsync();
            return Ok( role.roleName + " - Role Created Successfully.");
        }


        // CHECK - Role Exist  -:or:-  Not
        private async Task<bool> RoleExist(string? roleName)
        {
            return await _context.ApplicationRoles.AnyAsync(x => x.roleName == roleName);
        }
    }
}
