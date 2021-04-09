
using BookAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using BookAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


//using BookAPI.API_s;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller     
    {
        private IConfiguration _config;

        public AccountController(IConfiguration config)
        {
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]

        public  IActionResult PostAccount([FromBody] Account acc)
        {
            //var newAcc = await accountRepository.Create(acc);
            //return CreatedAtAction(nameof(GetAccount), new { id = newAcc.Id }, newAcc);
            //var user = AuthenticateUser(acc);

            IActionResult response = Unauthorized();
            var user = AuthenticateUser(acc);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;


        }

        private string GenerateJSONWebToken(Account userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private Account AuthenticateUser(Account login)
        {
            Account user = null;

            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.Username == "Jignesh")
            {
                user = new Account { Username = "Jignesh Trivedi"    };
            }
            return user;
        }



        private readonly IAccountRepository accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await accountRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            return await accountRepository.Get(id);
        }

        //[HttpGet("{username}/{password}")]
        //public ActionResult<List<Account>> Login(string username, string password)
        //{
        //    return AccountRepository.Login(username, password);

        //}
        //[HttpGet("{id}/{username}/{password}")]
        //public ActionResult<List<Account>> Login2(int id, string username, string password)
        //{
        //    return AccountRepository.Login2(id, username, password);

        //}


        
        //[HttpPut("{id}")]
        //public async Task<ActionResult> PutAccount(int id, [FromBody] Account acc)
        //{
        //    if (id != acc.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await accountRepository.Update(acc);

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var accToDelete = await accountRepository.Get(id);
        //    if (accToDelete == null)
        //        return NotFound();

        //    await accountRepository.Delete(accToDelete.Id);
        //    return NoContent();
        //}

        //Query acc = new Query();
        //#region a
        ////private readonly IAccountRepository accountRepository;
        ////public AccountController(IAccountRepository accountRepository)
        ////{
        ////    this.accountRepository = accountRepository;
        ////}
        ////[HttpGet]
        ////public async Task<IEnumerable<Account>> GetAccounts()
        ////{
        ////    return await accountRepository.Get();
        ////}
        ////[HttpGet("{id}")]
        ////public async Task<ActionResult<Account>> GetAccount(int id)
        ////{
        ////    return await accountRepository.Get(id);
        ////}

        ////[HttpGet("{username}/{password}")]
        ////public ActionResult<List<Account>> Login(string username, string password)
        ////{
        ////    return accountRepository.Login(username, password);

        ////}
        ////[HttpGet("{id}/{username}/{password}")]
        ////public ActionResult<List<Account>> Login2(int id, string username, string password)
        ////{
        ////    return accountRepository.Login2(id, username, password);

        ////}


        ////[HttpPost]

        ////public async Task<ActionResult<Account>> PostAccount([FromBody] Account acc)
        ////{
        ////    var newAcc = await accountRepository.Create(acc);
        ////    return CreatedAtAction(nameof(GetAccount), new { id = newAcc.Id }, newAcc);
        ////}
        ////[HttpPut("{id}")]
        ////public async Task<ActionResult> PutAccount(int id, [FromBody] Account acc)
        ////{
        ////    if (id != acc.Id)
        ////    {
        ////        return BadRequest();
        ////    }

        ////    await accountRepository.Update(acc);

        ////    return NoContent();
        ////}

        ////[HttpDelete("{id}")]
        ////public async Task<ActionResult> Delete(int id)
        ////{
        ////    var accToDelete = await accountRepository.Get(id);
        ////    if (accToDelete == null)
        ////        return NotFound();

        ////    await accountRepository.Delete(accToDelete.Id);
        ////    return NoContent();
        ////}
        //#endregion
        //[HttpGet]
        //public  string getAccount()
        //{

        //    return acc.GetAccount();

        //}
        //[HttpGet("{id}")]
        //public string getaccountByID(int id)
        //{
        //    return acc.GetAccountByID(id);
        //}
        //[HttpGet("{username}/{password}")]
        //public string login(string username, string password)
        //{
        //    return acc.Login(username, password);
        //}
        //[HttpPost]
        //public void AddAccount(string username, string password)
        //{
        //    acc.AddAccount(username, password);
        //}
        //[HttpPut]
        //public void updateAccount(string username, string password)
        //{
        //    acc.UpdateAccount(username, password);
        //}
    }
}
