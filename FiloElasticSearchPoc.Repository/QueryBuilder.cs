using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nest;

namespace FiloElasticSearchPoc.Repository
{
    public class QueryBuilder
    {
        public QueryBuilder()
        {
            container = new List<QueryContainer>();
        }

        List<QueryContainer> container;

        public List<QueryContainer> MakeQuery(ISearchInput input){
            Type myType = typeof(SearchInput);
            // Get the PropertyInfo object by passing the property name.
            PropertyInfo[] myPropInfo = myType.GetProperties();
            foreach (var pInfo in myPropInfo)
            {
                var pTypeName = pInfo.PropertyType.Name;
                var pValue = pInfo.GetValue(input);
                if(pTypeName == typeof(Int32).Name && pValue!=null && (int)pValue > 0 )
                {
                    var termQuery = new TermQuery() { Field = pInfo.Name.FirstLetterLower(), Value = pValue }.Boost(pInfo);
                    container.Add(termQuery);
                }

                if(pTypeName == typeof(String).Name && string.IsNullOrEmpty((string)pValue))
                {
                    var matchQuery = new MatchQuery() { Field = pInfo.Name.FirstLetterLower(), Query = (string)pValue }.Boost(pInfo);
                    container.Add(matchQuery);
                }
            }

            return container;
        }
    }
}
