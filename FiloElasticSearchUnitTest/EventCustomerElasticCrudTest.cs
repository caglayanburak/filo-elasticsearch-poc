using System;
using FiloElasticSearchPoc.Models;
using Xunit;

namespace FiloElasticSearchUnitTest
{
    public class EventCustomerElasticCrudTest
    {
        public EventCustomerElasticCrudTest()
        {
            repository = new ElasticRepository<EventCustomer>("test-event-customer");
        }

        ElasticRepository<EventCustomer> repository;

        [Fact]
        public void Add()
        {
            var eventCustomer = new EventCustomer()
            {
                ContractId=1,
                CustomerNameSurname="Burak Çağlayan",
                Plate="41BC058"
            }; 

           var result = repository.Add(eventCustomer);
           Assert.Equal(eventCustomer.Id.ToString(),result);

           repository.DeleteAll();
        }
    }
}
