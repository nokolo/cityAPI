using System;
using Microsoft.AspNetCore.Mvc;
using CityInfo.Models;

namespace CityInfo.Controllers
{
  //Edit Code Change
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/cities")]
    public class CitiesController : ControllerBase
    {

        public CitiesController()
        {
        }
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>>GetCities()
        {
            var citiesToReturn = CitiesDataStore.Current.Cities;
            return Ok(citiesToReturn);

            //return new JsonResult(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]

        public ActionResult<CityDto> GetCity(int id)
        {
            //find city
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if(cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);

           // return new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id));
        }
    }
}

