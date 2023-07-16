using Microsoft.AspNetCore.Mvc;
using Api.Models;

namespace Api.Controllers
{
    public class SnackMachineController : ControllerBase
    {
        [HttpPost()]
        public async Task<IActionResult> CreateSnackMachine(
            [FromBody] SnackMachine modem)
        {
            throw new NotImplementedException();
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteSnackMachine(long id)
        {
            throw new NotImplementedException();
        }

        [HttpGet()]
        public async Task<IActionResult> GetSnackMachine()
        {
            throw new NotImplementedException();
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateSnackMachine(
            long id,
            [FromBody] SnackMachine modem)
        {
            throw new NotImplementedException();
        }
    }
}