using System;
using System.Collections.Generic;
using Nest;

namespace FiloElasticSearchPoc.Repository
{
    public class MatchQueryBuilder : ESQueryBuilder<MatchQuery>
    {
        public MatchQueryBuilder()
        {
            matchQuery = new MatchQuery();
        }

        MatchQuery matchQuery { get; set; }

        public override ESQueryBuilder<MatchQuery> SetFieldName(string fieldName)
        {
            matchQuery.Field = fieldName;
            return this;
        }

        public override ESQueryBuilder<MatchQuery> SetFieldValue(object value)
        {
            if (value == null)
            {
                return this;
            }
            matchQuery.Query = value.ToString();
            return this;
        }

        public override MatchQuery Build()
        {
            return matchQuery;
        }
    }
}
