using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OpenseaAPI.Business.Interface;
using System;

namespace OpenseaAPI.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class TestController : ControllerBase
    {
        private readonly ITestLogic _testLogic;

        public TestController(ITestLogic testLogic)
        {
            _testLogic = testLogic;
        }

        [HttpGet]
        [Route("api/test1")]
        public IActionResult Test1()
        {
            try
            {
                var response = _testLogic.Test1();
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("api/test2")]
        public IActionResult Test2([FromBody] string data)
        {
            try
            {
                var response = _testLogic.Test1();
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
