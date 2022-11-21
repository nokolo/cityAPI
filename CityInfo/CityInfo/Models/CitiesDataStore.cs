using System;
namespace CityInfo.Models
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; private set; }

        public CitiesDataStore()
        {
             Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The Big Apple",
                    PointOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "The most vistied urban park"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Empire State Building",
                            Description = "102 Stories!"
                        }

                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Rochester",
                    Description = "RocCity 585",
                     PointOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "ESL",
                            Description = "Great Place to Work"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Nick Tahoo",
                            Description = "Great Garbage Plates"
                        }

                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Boston",
                    Description = "New England!",
                     PointOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Gillete Staduim",
                            Description = "Pats Home"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Robert Kraft",
                            Description = "Owner"
                        }

                    }

                }

            };
        }
    }
}

