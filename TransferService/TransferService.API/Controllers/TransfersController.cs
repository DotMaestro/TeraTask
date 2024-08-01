using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TransferService.Application.Transfers.Commands;

namespace TransferService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransfersController : ControllerBase
    {
        private readonly ISender _medaitor;

        public TransfersController(ISender medaitor)
        {
            _medaitor = medaitor;
        }

        /// <summary>
        /// Create Transfer by Account Number
        /// </summary>
        /// <param name="command"></param>
        /// <returns>TransferId</returns>
        [HttpPost(Name = "CreateTransfer")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> CreateTransferAsync([FromBody] CreateTransferCommand command)
        {
            var transferId = await _medaitor.Send(command);

            return Ok(transferId);
        }
    }
}
