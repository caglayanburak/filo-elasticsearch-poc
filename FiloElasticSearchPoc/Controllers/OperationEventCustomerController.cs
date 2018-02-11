using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiloElasticSearchPoc.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FiloElasticSearchPoc.Controllers
{
    public class OperationEventCustomerController : Controller
    {

        public OperationEventCustomerController()
        {
            repository = new ElasticRepository<EventCustomer>();
        }

        ElasticRepository<EventCustomer> repository;
        // GET: /<controller>/
        [HttpPost]
        [Route("~/api/operationeventcustomer/add/")]
        public string Add([FromBody]EventCustomer customer)
        {
            var result = repository.Add(customer);
            return result;
        }

        [HttpPost]
        [Route("~/api/operationeventcustomer/addbulk/")]
        public bool AddBulk([FromBody]List<EventCustomer> customers)
        {
            var result = repository.AddMany(customers);
            return result;
        }


        [HttpPost]
        [Route("/api/operationeventcustomer/deleteall")]
        public string DeleteAll()
        {
            repository.DeleteAll();
            return string.Empty;
        }

        [HttpPost]
        [Route("/api/operationeventcustomer/update")]
        public string Update([FromBody]EventCustomer customer)
        {
            var result = repository.Update(customer);
            return result;
        }

        [HttpPost]
        [Route("/api/operationeventcustomer/search")]
        public List<EventCustomer> Search([FromBody]EventCustomer customer)
        {
            var result = repository.Search(customer.Plate, customer.CustomerNameSurname, customer.ContractId);
            return result;
        }
    }
}
