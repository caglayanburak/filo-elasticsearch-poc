using System;
using System.Collections.Generic;
using System.Linq;
using Nest;

namespace FiloElasticSearchPoc.Models
{
    public class ElasticRepository<T> where T:class,IEntity
    {
        public ElasticRepository(string defaultIndex):this()
        {
            this.defaultIndex = defaultIndex;
        }
        public ElasticRepository()
        {
            var uri = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(uri);
            settings.DefaultIndex(defaultIndex);
            client = new Lazy<ElasticClient>(() => new ElasticClient(settings));
        }

        Lazy<ElasticClient> client;
        string defaultIndex = "contract-vehicle";

        public bool AddMany(List<T> entities)
        {
            var r = client.Value.IndexMany<T>(entities,defaultIndex);
            return r.IsValid;
        }

        public string Add(T entity){

            var r = client.Value.Index<T>(entity, i => i.Index(defaultIndex));
            return r.Id;
        }

        public string Update(T entity)
        {

            var result= client.Value.Update<T, object>(DocumentPath<T>.Id(entity.Id), u => u.Index(defaultIndex).Doc(entity));
            return result.Id;
        }

        public string Delete(int id)
        {
            var r = client.Value.Delete<T>(DocumentPath<T>.Id(id),u=>u.Index(defaultIndex));
            return  r.Id;
        }

        public void DeleteAll()
        {
            client.Value.DeleteIndex(Indices.Index(defaultIndex));
        }

        public List<EventCustomer> Search(string plate,string customerNameSurname,int contractId)
        {
            List<QueryContainer> container = new List<QueryContainer>();

            if(!string.IsNullOrEmpty(plate)){
                container.Add(new MatchQuery(){ Field = "plate", Query = plate });
            }

            if (!string.IsNullOrEmpty(customerNameSurname))
            {
                container.Add(new MatchQuery() { Field = "customerNameSurname", Query = customerNameSurname });
            }

            if (contractId > 0)
            {
                container.Add(new TermQuery() { Field = "contractId", Value = contractId });
            }

            ISearchRequest request = new SearchRequest<EventCustomer>(){ 
                Query = new BoolQuery(){
                    Must = container 
                } };
            
            var result = client.Value.Search<EventCustomer>(request);

            /*var result =  client.Value.Search<EventCustomer>(x=>
                                               x.Index(defaultIndex)
                                               .Query(q=>
                                                      q.Bool(b=>
                                                             b.Must(m=>
                                                                    m.Match(ma=>
                                                                            ma.Field(f=>f.CustomerNameSurname)
                                                                            .Query(customerNameSurname)
                                                                           ),
                                                                    m=>m.Match(ma=>
                                                                               ma.Field(f=>f.ContractId)
                                                                               .Query(contractId)
                                                                              ),
                                                                    m=>m.Match(ma=>
                                                                               ma.Field(f=>f.Plate)
                                                                               .Query(plate)
                                                                              )
                                                                )
                                                         
                                                         )
                                                  
                                                  )
                                              );*/
            
            return result.Documents.ToList();
        }
    }
}
