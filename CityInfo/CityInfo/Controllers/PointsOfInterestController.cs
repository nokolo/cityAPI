using System;
using CityInfo.Models;
using CityInfo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers
{
    [Route("api/v{version:apiVersion}/cities/{cityId}/pointsofinterest")]
    [ApiVersion("2.0")]
    [ApiController]

    public class PointsOfInterestController : ControllerBase
    {

        private readonly ILogger<PointsOfInterestController> _logger;
        //private readonly LocalMailService _mailService;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger/*, LocalMailService mailService*/)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            //_mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }


        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>>GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                _logger.LogInformation($"City with id {cityId} wasn't found when acessing point of interest");
                return NotFound();
            }

            return Ok(city.PointOfInterest);
        }

        [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterestDto>GetPointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointofInterest = city.PointOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
            if (pointofInterest == null)
            {
                return NotFound();
            }

            return Ok(pointofInterest);
        }

        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, PointOfInterestForCreationDto pointOfInterest)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }

            //calculate id for point of interest
            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(
                c => c.PointOfInterest).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    cityId = cityId,
                    pointOfInterestId = finalPointOfInterest.Id
                },
                finalPointOfInterest);
        }

        [HttpPut("{pointOfInterestId}")]
        public ActionResult UpdatePointOfInterest(int cityId, int pointOfInterestId, PointOfInterestForUpdateDto pointOfInterest)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointofInterestFromStore = city.PointOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
            if (pointofInterestFromStore == null)
            {
                return NotFound();
            }

            pointofInterestFromStore.Name = pointOfInterest.Name;
            pointofInterestFromStore.Description = pointOfInterest.Description;

            return NoContent();

        }

        [HttpDelete("{pointOfInterestId}")]
        public ActionResult DeletePointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointofInterestFromStore = city.PointOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
            if (pointofInterestFromStore == null)
            {
                return NotFound();
            }

            city.PointOfInterest.Remove(pointofInterestFromStore);
            /*_mailService.Send(
                "Point of Interes deleted.",
                $"Point of interest{pointofInterestFromStore.Name} with id {pointofInterestFromStore.Id} has been deleted."
                );*/
            return NoContent();
        }
    }
}

