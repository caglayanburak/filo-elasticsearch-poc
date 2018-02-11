# filo-elasticsearch-poc
ElasticSearch sample with .NetCore 2.0

if you want to run docker container , follow below steps;

- docker build -t aspnetapp .

- docker run -d -p 8080:80 --name containerName aspnetapp

When you run this code on your terminal, your container is ready to work.

After that I run elasticsearch instance. I followed below steps for downloading elasticsearch container;

- docker pull docker.elastic.co/elasticsearch/elasticsearch:6.2.0

-docker run -p 9200:9200 -p 9300:9300 -e "discovery.type=single-node" docker.elastic.co/elasticsearch/elasticsearch:6.2.0

When you try to go http://localhost:9200 elasticsearch instance has been ready.

If you reach elasticsearch instance from .net core application on docker , you have to change elasticsearch Uri information. Thus you write "docker ps" on terminal  and then choose Container Id of elasticsearch 

Container Id        Image <br>
c23f10bbdb70        docker.elastic.co/elasticsearch/elasticsearch:6.2.0   ......

I write this container Id "docker inspect" on terminal. after that I find my container IP address and then replace localhost keyword.That is all. Your Containers can talk each others.




