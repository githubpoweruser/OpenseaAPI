using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OpenseaAPI.Business.Interface;
using System;

namespace OpenseaAPI.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class BasicInfoController : ControllerBase
    {
        private readonly IBasicInfoLogic _basicInfoLogic;

        public BasicInfoController(IBasicInfoLogic basicInfoLogic)
        {
            _basicInfoLogic = basicInfoLogic;
        }

        [HttpGet]
        [Route("api/basicInfo/getCarouselImg")]
        public IActionResult GetCarouselImg()
        {
            try
            {
                var response = _basicInfoLogic.GetCarouselImg();
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("api/basicInfo/getDetailsInfo")]
        public IActionResult GetDetailsInfo()
        {
            try
            {
                var response = _basicInfoLogic.GetDetailsInfo();
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("api/basicInfo/getArticleAndImgInfo")]
        public IActionResult GetArticleAndImgInfo(int menuNumber)
        {
            try
            {
                var response = _basicInfoLogic.GetArticleAndImgInfo(menuNumber);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
