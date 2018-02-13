using System;
using System.Collections.Generic;
using Nest;

namespace FiloElasticSearchPoc.SearchMapping
{
    public class SearchInput : ISearchInput
    {
        public SearchInput()
        {
        }
        public int Id { get; set; }
        public int ContractId { get; set; }

        public string Plate { get; set; }

        public string CustomerNameSurname { get; set; }
        public string MakeModel { get; set; }
        public bool IsActive { get; set; }
        public int CustomerId { get; set; }
        public string CustomerType { get; set; }
        public string ContractStatus { get; set; }
        public int VehicleId { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public string ContractStartAndEndDate { get; set; }
        public string Make { get; set; }
        public string Carline { get; set; }
        public string CarModel { get; set; }
        public string Year { get; set; }
        public int CustomerNetId { get; set; }

       /* public List<QueryContainer> QueryMapping()
        {
            List<QueryContainer> container = new List<QueryContainer>();

            //MatchQuery
            MatchQueryBuilder<SearchInput> matchQueryBuilder = new MatchQueryBuilder<SearchInput>();
            var matchQuery = matchQueryBuilder.FieldName(z=>z.Id).SearchValue(this.Id.ToString()).Create();
            container.Add(matchQuery);

            //TermQuery


            return container;
        }*/
    }
}
