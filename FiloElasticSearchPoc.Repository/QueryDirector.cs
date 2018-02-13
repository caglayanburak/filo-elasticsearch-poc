using System;
using System.Collections.Generic;
using System.Linq;
using FiloElasticSearchPoc.DTO;
using FiloElasticSearchPoc.SearchMapping;
using Nest;

namespace FiloElasticSearchPoc.Repository
{
    public class QueryDirector
    {

        public List<QueryContainer> CreateQuery(ISearchRequestDTO request)
        {
            List<QueryContainer> container = new List<QueryContainer>();
            var properties = request.GetType().GetProperties();
           //IQuery query = null;
            foreach (var pInfo in properties)
            {
                if(pInfo.GetCustomAttributes(true).ToList().Any(x => x is MatchQueryAttribute))
                {
                    var query = new MatchQueryBuilder().SetFieldName(pInfo.Name.FirstLetterLower()).SetFieldValue(pInfo.GetValue(request)).Build();
                   container.Add(query);
                }

                if (pInfo.GetCustomAttributes(true).ToList().Any(x => x is TermQueryAttribute))
                {
                    var query = new TermQueryBuilder().SetFieldName(pInfo.Name.FirstLetterLower()).SetFieldValue(pInfo.GetValue(request)).Build();
                   container.Add(query);
                }
            }

            return container;
        }
    }
}
