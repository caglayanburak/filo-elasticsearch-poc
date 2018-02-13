using System;
namespace FiloElasticSearchPoc.Repository
{
    public class SearchInput:ISearchInput
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
    }

    public interface ISearchInput
    {
        
    }
}
