# Factory Pattern
Oluşturacağım nesnenin birden fazla farklı türü varsa (notification => Email | Sms | WP gibi) bunların hangisinin instance türetileceği ana kodda gizlenir ve arka planda karar verilir. Bu yapıyla beraber asıl yapılan işlem ana kodda gözükürken, arka plan geliştirilebilir bir mekanızma sağlar.

## Hangi prensibe uygun
- Open/Closed Prensibi
- Dependency Inversiyon Prensibi