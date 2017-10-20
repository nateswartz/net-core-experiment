using System.Collections.Generic;

namespace NETCoreExperimentalWebApp.Models.StarWarsModels
{
    public class StarshipResponse
    {
        public List<StarshipModel> results;
        public int count;
    }

    public class StarshipModel
    {
        public string Name { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public long? Cost_In_Credits { get; set; }

        public double? Length { get; set; }

        public double? Hyperdrive_Rating { get; set; }

        public int? MGLT { get; set; }
    }
}
/*
		"name": "Executor",
			"model": "Executor-class star dreadnought",
			"manufacturer": "Kuat Drive Yards, Fondor Shipyards",
			"cost_in_credits": "1143350000",
			"length": "19000",
			"max_atmosphering_speed": "n/a",
			"crew": "279144",
			"passengers": "38000",
			"cargo_capacity": "250000000",
			"consumables": "6 years",
			"hyperdrive_rating": "2.0",
			"MGLT": "40",
			"starship_class": "Star dreadnought",
			"pilots": [],
			"films": [
				"https://swapi.co/api/films/2/",
				"https://swapi.co/api/films/3/"
			],
			"created": "2014-12-15T12:31:42.547000Z",
			"edited": "2017-04-19T10:56:06.685592Z",
			"url": "https://swapi.co/api/starships/15/"
 */