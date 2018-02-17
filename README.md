# filo-elasticsearch-poc
ElasticSearch sample with .NetCore 2.0

<p><span style="text-decoration: underline;"><strong>Attributes:</strong></span></p>
<p><br /><strong>MatchQuery</strong><br />Hem tam metin hem de tam metin alanlarıyla nasıl bulacağını biliyor.Metin olarak "<strong>quick</strong>" yazıldığında aşağıdaki gibi bir sonu&ccedil; alınır.</p>
<p>"hits": [<br />{<br />"_id": "1",<br />"_score": 0.5, <br />"_source": {<br />"title": "The <strong>quick</strong> brown fox"<br />}<br />},<br />{<br />"_id": "3",<br />"_score": 0.44194174, <br />"_source": {<br />"title": "The <strong>quick</strong> brown fox jumps over the quick dog"<br />}<br />},<br />{<br />"_id": "2",<br />"_score": 0.3125, <br />"_source": {<br />"title": "The <strong>quick</strong> brown fox jumps over the lazy dog"<br />}<br />}<br />]</p>
<p><strong>MatchQueryAttributes:</strong></p>
<p><strong>FieldName</strong>: Girilen değerin hangi alan i&ccedil;in arayacağını belirlemek i&ccedil;in.</p>
<p><strong>FieldValue</strong>: Aranılacak metin.</p>
<p><strong>Fuzziness</strong>: Kullanıcıdan alınan text 'in belirsiz olması durumda eşleştirmeyi sağlar. default değeri "Auto" olarak atanmıştır(Genelde bu tercih ediliyor.). Auto ve Ratio olmak &uuml;zere iki tane se&ccedil;enek var.</p>
<p><strong>prefix_length</strong>: varsayılan olarak 0 atanmıştır.</p>
<p><strong>max_expansions</strong>: varsayılan 50 olarak belirlenmiştir.(aranılacak metinde )</p>
<p><span style="background-color: #ffff00;">Not:max_expansions değerinin y&uuml;ksek , prefix_length değerinin &ccedil;ok d&uuml;ş&uuml;k olması sorgunuzun yavaş &ccedil;alışmasına neden olabilir.</span></p>
<p><strong>fuzzy_transpositions</strong>: ( ab -&gt; ba ) gibi yazımlarda metin ifadenin bulunmasını sağlıyor. ("Merkez" yerine "Merkze" yazdığımda "Merkez" ile eşleşebiliyor)</p>
<p><a href="https://www.elastic.co/guide/en/elasticsearch/reference/current/common-options.html#fuzziness">https://www.elastic.co/guide/en/elasticsearch/reference/current/common-options.html#fuzziness</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>



