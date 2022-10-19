using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailRewardsProgram.Data;
using RetailRewardsProgram.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RetailRewardsProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _repo;

        public UsersController(IUserRepository repo)
        {
            _repo = repo;
        }

        // External route used by the Angular application on port 2429
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            try
            {
                return Ok(_repo.GetAllUsersAndTheirPurchases()); // Ok returns a 200 status code
            }
            catch (Exception ex)
            {
                //Add extra logging functionality... 
                return BadRequest("Request Failed"); 
            }
        }

        // Internal route used for testing server side rendering
        [HttpGet("{id:int}")]
        public ActionResult<User> Get(int Id)
        {
            try 
            {
                var user = _repo.GetUserById(Id); 
                if (user != null) return Ok(user); // Ok returns a 200 status code
                else return NotFound(); 
            }
            catch (Exception ex)
            {
                //Add extra logging functionality...
                return BadRequest("Request Failed");
            }
        }

        // Create more routes ...
    }
}
