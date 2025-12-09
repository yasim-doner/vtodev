# Veritabanı Lab 2526 - Proje Duyurusu

Oluşturacağınız veritabanı en az 4 tablo içermelidir. Her tabloda en az 10 kayıt bulunmalıdır.

Tablolarınızda primary key ve foreign key kısıtlarını kullanmalısınız.

En az bir tabloda silme kısıtı ve sayı kısıtı olmalıdır.

Arayüzden en az birer tane insert, update ve delete işlemi gerçekleştirilebilmelidir.

Arayüzden girilecek bir değere göre ekrana sonuçların listelendiği bir sorgu yazmalısınız.

Arayüzden çağrılan sorgulardan en az biri “view” olarak tanımlanmış olmalıdır.

Tasarladağınız veritabanının tablolarının en az birinde gerekli olduğunu düşündüğünüz bir sütun için index oluşturmalısınız. Arayüzden yaptığınız arama işlemi arka planda bu index üzerinden gerçekleşmeli.

En az bir adet “sequence” oluşturmalı ve arayüzden yapılacak insert sırasında ilgili sütundaki değerlerin otomatik olarak atanmasını sağlamalısınız.

Arayüzden çağrılan sorgulardan en az birinde union veya intersect veya except kullanmış olmalısınız.
Sorgularınızın en az biri aggregate fonksiyonlar içermeli, having ifadesi kullanılmalıdır.

Arayüzden girilen değerleri parametre olarak alıp ekrana sonuç döndüren 3 farklı SQL fonksiyonu tanımlamış olmalısınız. Bu fonksiyonların en az birinde “record” ve “cursor” tanımı-kullanımı olmalıdır. 
2 adet trigger tanımlamalı ve arayüzden girilecek değerlerle tetiklemelisiniz. Trigger’ın çalıştığına dair arayüze bilgilendirme mesajı döndürülmelidir.

Programınızda en az 2 farklı rolde ve yetkide kullanıcı profili olmalı: örn. admin, user.

-----

Projenizle beraber bir de rapor yazmanız istenmektedir. Raporda bulunması gerekenler:

- Tasarlanan veri tabanına ait ER diyagramı
- Tablolarınızın ekran görüntüleri

- Yukarıdaki maddelerin sağlandığını gösteren kod blokları. 

Örneğin, yukarıdaki 4.maddede geçen 

“Arayüzden en az birer tane insert, update ve delete işlemi gerçekleştirilebilmelidir” için;
     			INSERT INTO …..
UPDATE …...
			(yazdığınız sql kodları)

Proje tesliminde göndereceğiniz zip dosyasında bulunması gerekenler:
- Proje kodları
- .sql uzantılı veritabanı şema dosyanız (tablo oluşturma kodlarının bulunduğu dosya)
- Proje raporunuz (pdf formatında)

Son Teslim Tarihi :  **09.01.2026 Cuma 21:00**’a kadar, ileride linki ilan edilecek forma yüklemelerinizi yapmanız istenecektir. Projelerinizi 10-11 Ocak’ta, gün içerisinde verilecek randevu saatinizde, 15 dk’lık süre içerisinde ZOOM üzerinden sunmanız beklenecektir. 


Projeden puan alınabilmesi için sunum yapılması şarttır. Puanlama kriterleri şöyledir:

Tasarım (ER Diyagramı) : 10 puan

Sorgular & Fonksiyonlar & Triggerlar : 65 puan

Arayüz tasarımı ve sistemin kullanılabilirliği : 25 puan

ÖNEMLİ! Sorgu ve fonksiyonların mantıklı işler yapması, kullanışlı olması ve birbirinden farklı senaryoları gerçeklemeleri puanlamayı etkileyecektir.

Projeden alacağınız puan, dersin genel notuna %10 etki edecektir. 



# Mahalle Atık Paylaşım & Geri Dönüşüm Takas Platformu (RecycleShare)
- Mahalle sakinleri kullanılabilir durumdaki atıkları (karton, cam, elektronik) platforma ekleyebilir.
- Geri dönüşüm toplayıcıları veya geri dönüşüm işleyen kişiler bu ürünleri almak için rezervasyon yapabilir.
- Sistem, aylık geri dönüşüm katkısını hesaplayıp kullanıcıya kişisel çevresel etki raporu üretir.
