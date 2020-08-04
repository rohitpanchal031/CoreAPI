using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceCore.Models;
using InsuranceCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InsuranceCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractController : ControllerBase
    {
        IDataRepository dataRepository;
        public ContractController(IDataRepository _dataRepository)
        {
            dataRepository = _dataRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetContracts()
        {
            try
            {
                var categories = await dataRepository.GetContracts();
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddContracts(Contracts contracts)
        {
            try
            {
                Contracts result = await dataRepository.AddContracts(contracts);
                if (result !=null)
                {
                    return Ok(result);
                }
                return Ok("Error"); ;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{CustomerId:int}")]
        public async Task<IActionResult> Delete(int CustomerId)
        {
            try
            {
                Contracts result = await dataRepository.DeleteContracts(CustomerId);
                if (result != null)
                {
                    return Ok(result);
                }
                return Ok("Error");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
