using System;
using System.Collections.Generic;
using FiloElasticSearchPoc.DTO;
using Nest;

namespace FiloElasticSearchPoc.Repository
{
    public abstract class ESQueryBuilder<T>
    {
        public abstract ESQueryBuilder<T> SetFieldName(string fieldName);
        public abstract ESQueryBuilder<T> SetFieldValue(object value);
        public abstract T Build();
    }
}
