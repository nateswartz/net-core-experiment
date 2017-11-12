using System.Collections.Generic;

namespace NETCoreExperimentalWebApp.Models.StarWarsModels
{
    public class StarshipResponse : APIResponse<StarshipModel>
    {
    }

    public class APIResponse<T>
    {
        public List<T> Results { get; set; }
        public int Count { get; set; }
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