using System;
namespace FiloElasticSearchPoc.Models
{
    public class EventCustomer:IEntity
    {
        public int Id { get; set; }
        public int ContractId { get; set; }

        public string Plate { get; set; }

        public string CustomerNameSurname { get; set; }
    }

    public interface IEntity
    {
        int Id { get; set; }
    }
}
