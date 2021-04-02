
using BookAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;


using BookAPI.API_s;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        Query acc = new Query();
        #region a
        //private readonly IAccountRepository accountRepository;
        //public AccountController(IAccountRepository accountRepository)
        //{
        //    this.accountRepository = accountRepository;
        //}
        //[HttpGet]
        //public async Task<IEnumerable<Account>> GetAccounts()
        //{
        //    return await accountRepository.Get();
        //}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Account>> GetAccount(int id)
        //{
        //    return await accountRepository.Get(id);
        //}

        //[HttpGet("{username}/{password}")]
        //public ActionResult<List<Account>> Login(string username, string password)
        //{
        //    return accountRepository.Login(username, password);

        //}
        //[HttpGet("{id}/{username}/{password}")]
        //public ActionResult<List<Account>> Login2(int id, string username, string password)
        //{
        //    return accountRepository.Login2(id, username, password);

        //}


        //[HttpPost]

        //public async Task<ActionResult<Account>> PostAccount([FromBody] Account acc)
        //{
        //    var newAcc = await accountRepository.Create(acc);
        //    return CreatedAtAction(nameof(GetAccount), new { id = newAcc.Id }, newAcc);
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
        #endregion
        [HttpGet]
        public  string getAccount()
        {

            return acc.GetAccount();

        }
        [HttpGet("{id}")]
        public string getaccountByID(int id)
        {
            return acc.GetAccountByID(id);
        }
        [HttpGet("{username}/{password}/{id}")]
        public string login(string username, string password ,int id)
        {
            return acc.Login(username, password,id );
        }
        [HttpPost]
        public void AddAccount(string username, string password)
        {
            acc.AddAccount(username, password);
        }
        [HttpPut("{username}/{password}")]
        public void updateAccount(string username, string password)
        {
            acc.UpdateAccount(username, password);
        }
    }
}
