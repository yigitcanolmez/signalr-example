# SignalR Example

ASP.NET Core SignalR kullanarak gerçek zamanlı iletişim gösteren bir örnek proje.

## 📋 Proje Açıklaması

Bu proje, ASP.NET Core SignalR teknolojisini kullanarak sunucu ve istemci arasında gerçek zamanlı (real-time) veri iletişimini göstermektedir. Proje, COVID-19 verilerini grafikler aracılığıyla sunucu tarafından istemciye anında göndermektedir.

## 🏗️ Proje Yapısı

```
signalr-example/
├── CovidChart.API/          # COVID-19 verileri sağlayan API
├── SignalR.Api/             # SignalR Hub sunucusu
├── SignalR.Web/             # Web istemcisi (Client)
├── signalr-example.sln      # Visual Studio çözümü
└── README.md                # Bu dosya
```

### Bileşenler

#### 📊 CovidChart.API
- COVID-19 verileri sağlayan REST API
- Veri kaynağı olarak işlev görmektedir

#### 🔌 SignalR.Api
- ASP.NET Core SignalR Hub'ı barındıran sunucu
- Gerçek zamanlı veri iletişimini yönetir
- CovidChart.API'den veri alarak istemcilere gönderir

#### 🌐 SignalR.Web
- Web tabanlı istemci uygulaması
- SignalR sunucusuyla bağlantı kurar
- Gerçek zamanlı veri güncellemelerini grafiklerle görüntüler

## 🚀 Başlangıç

### Gereksinimler

- .NET 6.0 veya üstü
- Visual Studio 2019+ veya Visual Studio Code
- Modern web tarayıcı

### Kurulum

1. **Projeyi klonlayın:**
```bash
git clone https://github.com/yigitcanolmez/signalr-example.git
cd signalr-example
```

2. **Çözümü açın:**
```bash
# Visual Studio ile
start signalr-example.sln

# veya dotnet CLI ile
dotnet restore
```

### Çalıştırma

1. **CovidChart.API'yi başlatın:**
```bash
cd CovidChart.API
dotnet run
```

2. **SignalR.Api'yi başlatın (yeni terminal):**
```bash
cd SignalR.Api
dotnet run
```

3. **SignalR.Web'i başlatın (yeni terminal):**
```bash
cd SignalR.Web
dotnet run
```

Daha sonra tarayıcınızda `https://localhost:5001` adresine giderek uygulamayı kullanabilirsiniz.

## 📡 SignalR Özellikleri

Bu proje aşağıdaki SignalR özelliklerini göstermektedir:

- **Hub Bağlantıları** - Sunucu ile istemci arasında WebSocket bağlantısı
- **Server-to-Client Mesajları** - Sunucudan istemciye gerçek zamanlı veri gönderimi
- **Grup Yönetimi** - İstemcileri gruplara ayırarak seçli yayın
- **Otomatik Yeniden Bağlantı** - Bağlantı koptuğunda otomatik yeniden bağlanma

## 💻 Teknolojiler

- **Backend:** ASP.NET Core, SignalR
- **Frontend:** HTML, CSS, JavaScript
- **Veri İletişimi:** WebSocket (SignalR ile)
- **API:** REST API (CovidChart.API)

## 📚 Kaynaklar

- [ASP.NET Core SignalR Resmi Belgeleri](https://learn.microsoft.com/en-us/aspnet/core/signalr/)
- [SignalR Hub'lar](https://learn.microsoft.com/en-us/aspnet/core/signalr/hubs)
- [JavaScript istemcisi](https://learn.microsoft.com/en-us/aspnet/core/signalr/javascript-client)

