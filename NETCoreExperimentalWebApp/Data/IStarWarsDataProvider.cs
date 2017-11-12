using System.Collections.Generic;
using NETCoreExperimentalWebApp.Models.StarWarsModels;

namespace NETCoreExperimentalWebApp.Data
{
    public interface IStarWarsDataProvider
    {
        IEnumerable<StarshipModel> GetStarships();

        PersonModel GetPerson(int personId);

        IEnumerable<SpeciesModel> GetSpecies();
    }

}
