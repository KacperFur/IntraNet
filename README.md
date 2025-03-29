# 📌 IntraNet - ASP.NET REST API

IntraNet to prosta aplikacja REST API napisana w ASP.NET Core, która pozwala zarządzać użytkownikami i ich zadaniami.  
Projekt stworzony w celach edukacyjnych i jako portfolio dla rekruterów.

## 🚀 Technologie
- ASP.NET Core 8
- Entity Framework Core
- MS Sql Server
- Swagger UI

## 📂 Struktura projektu
- `IntraNet/Controllers` - kontrolery API
- `IntraNet/Models` - modele danych
- `IntraNet/Entities` - konfiguracja bazy danych

## ⚡ Jak uruchomić API lokalnie?

---
---

### **📌 3. Dokumentacja API**
> Opis endpointów: metoda, URL, parametry, przykładowe odpowiedzi.

Przykład:
```md
## 📡 Endpointy API

### 🔹 1. Pobranie listy użytkowników
**GET** `/api/users`

#### ✅ Przykładowa odpowiedź:
```json
[
  {
    "id": 1,
    "name": "Jan Kowalski",
    "email": "jan@example.com"
  }
]



## 📝 TODO
- [ ] Autoryzacja i JWT
- [ ] Logowanie błędów (Serilog)
- [ ] Dockerfile i konfiguracja CI/CD