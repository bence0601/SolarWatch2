﻿using Microsoft.AspNetCore.Mvc;
using SolarWatch2.Model;
using SolarWatch2.Services;
using System.ComponentModel.DataAnnotations;

namespace SolarWatch2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SunRiseSunSetController : ControllerBase
    {
        private readonly ILogger<SunRiseSunSetController> _logger;
        private readonly ISunriseSunsetProvider _sunriseSunsetProvider;

        public SunRiseSunSetController(ILogger<SunRiseSunSetController> logger, ISunriseSunsetProvider sunriseSunsetProvider)
        {
            _logger = logger;
            _sunriseSunsetProvider = sunriseSunsetProvider;
        }

        [HttpGet("GetSunRiseSunSet")]
        public ActionResult<IEnumerable<SunriseSunsetResult>> Get([Required] double lat, [Required] double lon, [Required] DateTime startDate, [Required] DateTime endDate)
        {
            try
            {
                var sunriseSunset = _sunriseSunsetProvider.GetSunriseSunset(lat, lon, startDate, endDate);
                return Ok(sunriseSunset);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting SunriseSunset Data");
                return NotFound("Error getting data");
            }
        }


    }
}