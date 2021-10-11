# 4. Hafta Ödev
Basit bir e-ticaret apisi geliştirin.
- Ürün, kullanıcı ve sipariş tablolarınız olsun.
- Ürün ve sipariş ekleme seçeceğiz ilişkisel bir veritabanına dapper kullanarak yapılacaktır.
- Ürün ekleme ve sipariş oluşturma için birer restful api yapılmalıdır.
- Sipariş oluşturulduktan sonra siparişin özet bilgisinin yer aldığı bir kayıt mongodb ye atılmalıdır.(siparişi veren kullanıcı, siparişteki ürünlerin bilgileri vb.)
- Siparişleri listelemek için hem kullanıcı özelinde hem de id özelinde mongodb deki sipariş bilgilerini gösteren bir grpc servis geliştirin.(restful da olabilir.)


#Bonus:
- unit testleri yazın.
- sipariş oluşturma aşaması için integration test yazın
- CQRS ve meditaor pattern kullanın
