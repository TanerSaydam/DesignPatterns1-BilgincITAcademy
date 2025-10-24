# Bridge Pattern
Soyutlama (abstraction) ile uygulamanın (implementation) birbirinden bağımsız olarak geliştirilmesini sağlayan pattern.

- Ne yapıyorum => Abstraction
- Nasıl yapıyorum => Implementation

## Örnek
Ben birden farklı yere loglama yapmak istiyorum. Loglama yaparkende tür seçmek istiyorum. 

### Loglama yapacağım yer (Implementation)
- Console Loglama
- File Loglama
- Db Loglama

### Loglama türü (Abstraction)
- Audit verileri
- Error verileri
- App verileri
