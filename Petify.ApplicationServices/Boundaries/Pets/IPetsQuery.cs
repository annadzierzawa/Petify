using System.Collections.Generic;
using System.Threading.Tasks;
using Petify.PublishedLanguage.Dtos.Common;

namespace Petify.ApplicationServices.Boundaries.Pets
{
    public interface IPetsQuery
    {
        Task<List<LookupDTO>> GetSpeciesLookup();
    }
}
