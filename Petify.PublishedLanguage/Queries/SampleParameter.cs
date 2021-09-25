using System.Collections.Generic;
using Petify.Common.CQRS;
using Petify.PublishedLanguage.Dtos;

namespace Petify.PublishedLanguage.Queries
{
    public class SampleParameter : IQuery<List<SampleDTO>>
    {
    }
}
