using System;
using System.Linq.Expressions;
using Nest;

namespace FiloElasticSearchPoc.SearchMapping
{
    public class MatchQueryBuilder<T>
    {
        public MatchQueryBuilder()
        {
            matchQuery = new MatchQuery();
        }

        MatchQuery matchQuery;

        public MatchQueryBuilder<T> FieldName(Expression<Func<T, object>> fieldName)
        {
            matchQuery.Field = fieldName.GetType().Name.FirstLetterLower();
            return this;
        }

        public MatchQueryBuilder<T> SearchValue(string value)
        {
            matchQuery.Query = value;
            return this;
        }

        public MatchQuery Create()
        {
            return matchQuery;
        }

        public MatchQueryBuilder<T> Boost(double? boost)
        {
            matchQuery.Boost = boost;
            return this;
        }
    }
}
