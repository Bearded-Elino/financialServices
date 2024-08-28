using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialServices.interfaces.IAccountRepo;
using Microsoft.AspNetCore.Mvc;

namespace FinancialServices.controllers.accountControl
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(Guid customerId)
        {
            try
            {
                var account = await _accountRepository.CreateAccountAsync(customerId);
                return Ok(account);
            }
            catch (Exception)
            {
                
                return BadRequest(new{status="failed", mesage ="Account could not be created"});
            }
        }
    }
}