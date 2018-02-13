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
                Id=1,
                ContractId=1,
                CustomerNameSurname="Burak Çağlayan",
                Plate="41BC058"
            }; 

           var result = repository.Add(eventCustomer);
           Assert.Equal(eventCustomer.Id.ToString(),result);
        }

        [Fact]
        public void Update()
        {
            var eventCustomer = new EventCustomer
            {
                Id=1,
                ContractId = 1,
                CustomerNameSurname = "Burak Çağlayan",
                Plate = "41BC580"
            };
            var result = repository.Update(eventCustomer);

            //var searchResult = repository.Search("41BC580", null, 0);
           // Assert.Equal(1,searchResult.Count);
        }

        [Fact]
        public void Search()
        {
            //var searchResult = repository.Search("41BC580", null, 0);
            //Assert.Equal(1, searchResult.Count);
        }

        [Fact]
        public void DeleteIndex()
        {
           repository.DeleteAll();
        }
    }
}
