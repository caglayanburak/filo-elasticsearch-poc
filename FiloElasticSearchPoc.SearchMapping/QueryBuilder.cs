using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nest;

namespace FiloElasticSearchPoc.SearchMapping
{
    public class QueryBuilder
    {
        public QueryBuilder()
        {
            container = new List<QueryContainer>();
        }

        List<QueryContainer> container;
    }
}
