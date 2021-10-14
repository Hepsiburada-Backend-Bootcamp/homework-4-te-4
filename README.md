# Database kurulumu
Gerekli toolların kurulumu:

`dotnet tool install --global dotnet-ef`

Docker ayağa kaldırma (Solution altında çalıştırılmalı):

`docker compose up -d`

Migrationlar ekleme ve database update (API projesinin altında çalıştırılmalı):

`dotnet ef migrations add AddTables -v`

`dotnet ef database update -v`


# Database admin panel erişimi

Docker ayağa kaldırıldıktan sonra `localhost:5050` ile admin paneline erişilir.

```
email: root@hepsinerede.com
password: toor
```
Servers'e sağ tıklayarak Create > Server ile server oluşturma ekranında "General" ve "Connection" sekmelerinden aşağıdaki ayarlamalar yapılır.

```
name: ecommerce

host name: postgresql
port: 5432
username: postgres
password: toor
```

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
