using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Pro_Tech_Task.StringOper;

namespace Swagger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public Controller(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("process")]
        public async Task<IActionResult> ProcessString([FromQuery] string inputString)
        {
            AppSettings appSettings = _configuration.GetSection("Settings").Get<AppSettings>();
            try
            {
                if (string.IsNullOrWhiteSpace(inputString))
                {
                    return BadRequest("HTTP error 400 Bad Request. Invalid input string.");
                }
                if (!Regex.IsMatch(inputString, "^[a-z]+$"))
                {
                    return BadRequest("HTTP error 400 Bad Request. Invalid input string.");
                }
                if (appSettings?.BlackList?.Contains(inputString) == true)
                {
                    return BadRequest($"HTTP error 400 Bad Request. The string is in the BlackList ");
                }
                StringOperation mod = new StringOperation(inputString);
                RandomNumber rnd = new RandomNumber();
                Sort sort = new Sort();


                var result = new
                {
                    InputString = inputString,
                    ModString = mod.StringSplit(),
                    Count = mod.CountPrint(),
                    MaxSubstring = mod.FindLargestVowelSubstring(mod.ModString),
                    TrimString = rnd.RemoveChar(inputString),
                    SortStringQuick = sort.QuickSort(inputString),
                    SortStringTree = sort.TreeSort(inputString),

                };
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest($"HTTP error 400 Bad Request. Message: {ex.Message}");
            }
        }
    }
}
