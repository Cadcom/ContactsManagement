Asp.Net Core 5.0 ContactsManagement

Teknoloji

1. ContactsManagement - ASP.NET Razor - Entity Framework Code First yaklaşımı kullanılarak geliştirilmiştir.

2. Veritabanı PostgreSQL kullanılmıştır.

3. Uygulamada katmanlı mimari kullanılarak katmanlar birbirine dependency injection yöntemi ile bağlanmıştır.

4. Web API'nin yapısını görselleştirmek için Swagger kütüphanesi kullanılmıştır.  

Senaryo

Birbirleri ile haberleşen minimum iki microservice'in olduğu bir yapı tasarlayarak, basit
bir telefon rehberi uygulaması oluşturulması sağlanacaktır.

Not: FrontEnd kısmı İrem hanımın yönlendirmesiyle tamamlanmamıştır.

Beklenen işlevler:

• Rehberde kişi oluşturma : Api/Contacts/InsertOrUpdatePerson

• Rehberde kişi kaldırma :   Api/Contacts/DeletePerson

• Rehberdeki kişiye iletişim bilgisi ekleme :   Api/Contacts/InsertOrUpdateContact

• Rehberdeki kişiden iletişim bilgisi kaldırma :    Api/Contacts/DeleteContact

• Rehberdeki kişilerin listelenmesi :      Api/Contacts/GetAllPersons (Paging opsiyonel)

• Rehberdeki bir kişiyle ilgili iletişim bilgilerinin de yer aldığı detay bilgilerin
getirilmesi :                        Api/Contacts/GetContactsByPersonID

• Rehberdeki kişilerin bulundukları konuma göre istatistiklerini çıkartan bir rapor
talebi

• Sistemin oluşturduğu raporların listelenmesi

• Sistemin oluşturduğu bir raporun detay bilgilerinin getirilmesi


