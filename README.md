# HotelAPI projesi notlar:

Onion architecture:

Domain:
merkezi katmandır.
Entities, Value object, Enumeration, Exceptions

Repository & Service Interfaces: ---Application Katmanı
Domain ile iş katmanı arasında soyutlama kavramıdır
Tüm servis arayüzleri(interfaceleri) burada tanımlanır
Domain katmanını referans eder
Bu katmanın amacı veri erişiminde gevşek bağlı(loose coupling) bir yaklaşımı sergilemektir
DTO, ViewModel, Mapping, Validators, CQRS Pattern

Persistence:
Veritabanı operasyonlarını/veri erişim mantığını yürüten katmandır.
Application katmanındaki repository interfacelerinin concrete nesneleri burada oluşturulacaktır.
DbContext, Migrations, Configurations, Seeding

Infrastructure:
Persistence katmanı ile bütünleşebilen bir katmandır. Her ikisi de iş/business katmanıdır.Sadece
persistenceden farkı veri tabanının dışındaki operasyonları,servisleri,işlemleri yürüttüğümüz katmandır
Veri tabanından olan veri erişimi dışındaki tüm servisler bu katmanda inşa edilir (Email,sms vb).

Presentation:
Kullanıcının uygulama ile iletişime geçtiği kısımdır
Web App, Web Api, MVC

Domain ve Application katmanları Core klasörü içinde oluşturulur. Çünkü bunlar çekirdek katmanlardır
Servislerimizi oluşturduğumuz katmanlarımız olan infrastructure ve persistence katmanları da. infr.
klasörü içerisinde tanımlanır

Presentation uygulamaları ise presentation klasörü içerisinde tanımlanır.

ileriki zamanlarda duruma göre farklı veri tabanları kullanılması durumu için repositoryler 
write ve read olarak ayrılır.

IRepository = temel base işlemi tutar 
IWriteRepository = veri tabanından sorgu ile data elde edilmesi read işlemidir
IReadRepository = Ekleme silme vb operasyonlar

IQueryable = bir sorgu üzerinde çalışılmak isteniyorsa kullanılır
interfacelerde bool eklenmesinin nedeni sonucun true veya false dönmesi için

Task = sonucu ilgilendirmeyen görev işlemi async işlemlerde kullanılır

EntityEntry =

AddScoped = Scoped'da her request için oluşturulun nesne iş bittikten sonra imha/dispose edilir

Tracking = Veri tabanından çekilen dataların takip edilmesini sağlayan mekanizmadır.

Interceptor = Başlangıcı ve bitişi belli olan olayda araya giren yapı
Örneğin bir istek verildiğinde datetime now'da verilecek bunun sürekli yazılmasına gerek 
duyulmayıp bir interceptor oluşturulup kullanıcı datetime vermediğinde bile istek'de datetime'nin
otomatik olarak verilmesi

Veri tabanında herhangi bir değişiklik yapıldığında (entity,dbcontext vs.) bu değişiklik sunucuya 
bildirilmeli bunun için migration oluşturulur.

ChangeTracker = Entityler üzerinde yapılan değişikliklerin ya da yeni eklenen verilerin yakalanmasını
sağlayan property'dir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar

UI kısmında admin ve user tarafı var

Validationlar için fluent validations kullanılır

IStorage = Mimaride olabilecek tüm storage yaklaşımlarının implement edildiği interface'dir

local storage katmanı oluşturuldu

bir action methodda aldığı parametreyi route'de bildirmiyorsa bu querystring'den gelecek anlamına 
gelir. Eğer bildiriyorsa bu değer route parametrelerinden gelecek anlamına gelir

CQRS pattern

CQRS pattern nedir:
komutların ve sorguların sorumluluklarının ayrılması prensibi 

Mediator Pattern nedir:
Birden fazla nesne üzerinde organize işlem yapılması gerekilebilir. Buradaki organizasyonu sağlayan
aracın ismidir

Identity Mekanizması kullanıldı

Authentication-kullanıcı/kimlik doğrulama:
Uyuglama tarafından kullanıcının tanımlanmasıdır

Authorization
Kimliği doğrulanmış kullanıcıların yetkilerini kontrol eder

JWT 
JWT yapılanmasında gelen istekleri jwt ile doğrulamak istersek controllerdaki actionlar authorize
ile işaretlenmesi gerekir

DTO'nun temel amacı katmanlar arası veri taşımak

access token

reflesh token = belirli bir ömüre sahip olan ve access token almamızı sağlayan özelliktir
reflesh token access token'dan daha uzun süreli olmalıdır.


Loglar
Uygulamanın runtime'da yaşadığı problemleri yönetebilmemizi kolaylaştırmak için kullandığımız bir
yapılanmadır.

--Log mekanizması ne gibi ayrıntılar içermeli
Sistemi kim kullanıyor?
Arıza kodun neresinde gerçekleşmiştir?
Hata kodu?
Ne zaman oldu?
Uygulama neden başarısız oldu

--Log mekanizmasında neler kaydedilmelidir?
Exceptionlar
Veri değişiklikleri
Süpheli etkinlikler : Başarısız kimlik doğrulaması, kısıtlı verile erişme girişimleri, geçersiz
parametreler
Requestler: Tarih ve saat olarak kayıt edilmelidir.
Kullanıcı bilgileri
Kısa bir açıklama

Loglara hassas veriler dahil edilmemelidir (kullanıcıya dair özel bilgiler)

Loglar console üzerinde yazdırılabilir
Logların analiz edilmesi için harici dosyalarda veya veri tabanlarında fiziksel olarak saklanmaları
gerekmektedir

Serilog = uygulamadaki logları console, file, veritabanlarına, seq(görselleştirici arayüz yapısı) vs.
kolayca aktarmamızı sağlayan bi kütüphanedir

Bu projede veritabanına loglama gerçekleştireceğim
Seq arayüzü üzerinde görselleştirme yapacağım
ve txt dosyasında göstereceğim

Global exception handler oluşturuldu
