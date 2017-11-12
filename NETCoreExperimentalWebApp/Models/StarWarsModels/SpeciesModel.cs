namespace NETCoreExperimentalWebApp.Models.StarWarsModels
{
    public class SpeciesResponse : APIResponse<SpeciesModel>
    {
    }

    public class SpeciesModel
    {
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Designation { get; set; }
        public int Average_Height { get; set; }
        public string Skin_Colors { get; set; }
        public string Hair_Colors { get; set; }
        public string Eye_Colors { get; set; }
        public string Average_Lifespan { get; set; }
        public string Language { get; set; }
    }
}
