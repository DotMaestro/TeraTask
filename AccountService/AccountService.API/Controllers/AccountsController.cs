using AccountService.Application.Accounts.Queries;
using AccountService.Application.Dtos;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ISender _medaitor;

        public AccountsController(ISender medaitor)
        {
            _medaitor = medaitor;
        }

        /// <summary>
        /// Get Account Details by Account Number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns>Account Details</returns>
        [HttpGet("{accountNumber:guid}/details")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<AccountDetailsDto>> GetAccountDetailsAsync(Guid accountNumber)
        {

            var accountDetails = await _medaitor.Send(new GetAccountDetailsQuery(accountNumber));

            if (accountDetails == null)
            {
                return NotFound();
            }

            return Ok(accountDetails);
        }

        /// <summary>
        /// Get Balance on the Account and Account Holder by Account Number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        [HttpGet("{accountNumber:guid}/balance")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<AccountBalanceDto>> GetAccountBalanceAsync(Guid accountNumber)
        {

            var accountBalance = await _medaitor.Send(new GetAccountBalanceQuery(accountNumber));

            if (accountBalance == null)
            {
                return NotFound();
            }

            return Ok(accountBalance);
        }
    }
}
