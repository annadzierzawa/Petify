using System.Collections.Generic;
using Petify.Common.CQRS;
using Petify.PublishedLanguage.Dtos.Common;

namespace Petify.PublishedLanguage.Queries.Pets
{
    public class GetSpeciesParameter : IQuery<List<LookupDTO>>
    {
    }
}
