
# Weather App

Weather App, kullanıcıların mevcut hava durumu verilerini görselleştirmelerine olanak tanır. Uygulama, belirli bir şehir için hava durumu bilgilerini gösterir ve güncel hava koşullarını, sıcaklık gibi detayları açıklamalarla birlikte sunar.

## Özellikler

- Şehir bazında hava durumu verisi gösterimi
- Hava durumu verileri API üzerinden alınır (OpenWeatherMap API)
- Hızlı ve kullanıcı dostu arayüz
- Hava durumu bilgilerini güncel tutmak için otomatik güncelleme

## Teknolojiler

- **C#** (Windows Forms)
- **.NET Framework** / **.NET Core** 
- **OpenWeatherMap API** 

## Kurulum

1. Bu repository'yi bilgisayarınıza klonlayın:
2. Visual Studio 2022'yi kullanarak projeyi açın.
3. Gerekli bağımlılıkları yükleyin (Visual Studio gerekli paketleri otomatik olarak yükler).
4. API anahtarınızı alın ([OpenWeatherMap API](https://openweathermap.org/api)) ve uygulama içerisinde yapılandırın.
5. Projeyi çalıştırın.

## Kullanım

1. Uygulama açıldığında, şehir ismini girmeniz için bir alan olacak.
2. Şehri girdikten sonra, **Hava Durumu Görüntüle** butonuna tıklayarak o şehir için hava durumu bilgilerini alabilirsiniz.
3. Ekranda sıcaklık ve hava durumu bilgileri görüntülenecektir.
4. Uygulama otomatik olarak hava durumu bilgisini günceller.

## API Entegrasyonu

Bu uygulama, hava durumu verilerini [OpenWeatherMap API](https://openweathermap.org/api) kullanarak çeker. API anahtarınızı alarak proje dosyasında gerekli kısımları düzenlemeniz gerekmektedir.

## Katkı

Eğer bu projeye katkıda bulunmak isterseniz, pull request'leri bekliyoruz! Yeni özellikler veya hata düzeltmeleri eklemek isterseniz, aşağıdaki adımları takip edebilirsiniz.

1. Bu repository'yi fork'layın.
2. Yeni bir branch oluşturun.
3. Değişikliklerinizi yapın ve commit'leyin.
4. Pull request gönderin.
