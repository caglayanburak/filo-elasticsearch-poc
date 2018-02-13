using System;
using System.Collections.Generic;
using Nest;

namespace FiloElasticSearchPoc.Repository
{
    public class TermQueryBuilder : ESQueryBuilder<TermQuery>
    {
        public TermQueryBuilder()
        {
            termQuery = new TermQuery();
        }
        public TermQuery termQuery { get; set; }

        public override ESQueryBuilder<TermQuery> SetFieldName(string fieldName)
        {
            termQuery.Field = fieldName;
            return this;
        }

        public override ESQueryBuilder<TermQuery> SetFieldValue(object value)
        {
            termQuery.Value = value;
            return this;
        }

        public override TermQuery Build()
        {
            return termQuery;
        }
    }
}
