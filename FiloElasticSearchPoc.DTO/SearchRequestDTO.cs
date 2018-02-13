using System;
using FiloElasticSearchPoc.SearchMapping;

namespace FiloElasticSearchPoc.DTO
{
    public class SearchRequestDTO: ISearchRequestDTO
    {
        [TermQuery]
        public int Id { get; set; }
        public int ContractId { get; set; }
        [MatchQuery]
        public string Plate { get; set; }

        public string CustomerNameSurname { get; set; }
        public string MakeModel { get; set; }
    }
}
