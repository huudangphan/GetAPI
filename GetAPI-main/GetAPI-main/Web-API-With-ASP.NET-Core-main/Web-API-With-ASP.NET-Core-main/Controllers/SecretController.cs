using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.API_s;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [APIKey]
    public class SecretController:ControllerBase
    {
        Query acc = new Query();
        [HttpGet(template:"secret")]
        public string getAccount()
        {

            return acc.GetAccount();

        }
        [HttpGet("{id}")]
        public string getaccountByID(int id)
        {
            return acc.GetAccountByID(id);
        }
        [HttpGet("{username}/{password}")]
        public string login(string username, string password)
        {
            return acc.Login(username, password);
        }
        [HttpPost]
        public void AddAccount(string username, string password)
        {
            acc.AddAccount(username, password);
        }
        [HttpPut]
        public void updateAccount(string username, string password)
        {
            acc.UpdateAccount(username, password);
        }

    }
}
