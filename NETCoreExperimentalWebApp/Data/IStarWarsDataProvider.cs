using NETCoreExperimentalWebApp.Models;
using System.Collections.Generic;

namespace NETCoreExperimentalWebApp.Data
{
    public interface IStarWarsDataProvider
    {
        IEnumerable<StarshipModel> GetStarships();

        PersonModel GetPerson(int personId);
    }

}
