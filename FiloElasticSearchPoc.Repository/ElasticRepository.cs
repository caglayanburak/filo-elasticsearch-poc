using System;
using System.Collections.Generic;
using System.Linq;
using FiloElasticSearchPoc.DTO;
using FiloElasticSearchPoc.Repository;
using Nest;

namespace FiloElasticSearchPoc.Models
{
    public class ElasticRepository<T> where T : class, IEntity
    {
        public ElasticRepository(string defaultIndex)
        {
            var uri = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(uri);
            settings.DefaultIndex(defaultIndex);
            client = new Lazy<ElasticClient>(() => new ElasticClient(settings));

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
            var r = client.Value.IndexMany<T>(entities, defaultIndex);
            return r.IsValid;
        }

        public string Add(T entity)
        {

            var r = client.Value.Index<T>(entity, i => i.Index(defaultIndex));
            return r.Id;
        }

        public string Update(T entity)
        {

            var result = client.Value.Update<T, object>(DocumentPath<T>.Id(entity.Id), u => u.Index(defaultIndex).Doc(entity));
            return result.Id;
        }

        public string Delete(int id)
        {
            var r = client.Value.Delete<T>(DocumentPath<T>.Id(id), u => u.Index(defaultIndex));
            return r.Id;
        }

        public void DeleteAll()
        {
            client.Value.DeleteIndex(Indices.Index(defaultIndex));
        }

        public List<EventCustomer> Search(SearchRequestDTO input, int from, int size)
        {
            List<QueryContainer> container = new QueryDirector().CreateQuery(input);
            ISearchRequest request = new SearchRequest<EventCustomer>()
            {
                Query = new BoolQuery()
                {
                    Must = container
                },
                From = from,
                Size = size
            };

            var result = client.Value.Search<EventCustomer>(request).Documents.ToList();
            return result;
        }
    }
}
