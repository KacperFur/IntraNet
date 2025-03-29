# 📌 IntraNet - ASP.NET REST API

IntraNet is an application created in ASP.NET Core designed to handle the basic needs of a company. It allows for the management of employees, their tasks, and events taking place within the organization. 

## Technologies
- ASP.NET Core 8
- Entity Framework Core
- MS Sql Server
- Swagger UI

## Project Structure
- `IntraNet/Controllers` - API controllers
- `IntraNet/Entities` - Database configuration
- `IntraNet/Exceptions` - Custom exceptions
- `IntraNet/Middleware` - Exception handling
- `IntraNet/Models` - DTO's
- `IntraNet/Services` - Business logic 

## How to run API locally?

---
---

### **3. API Documentation **
> Opis endpointów: metoda, URL, parametry, przykładowe odpowiedzi.

```md
## API Endpoints

###  1. Getting all employees
**GET** `api/intranet/employee`

#### Example response:
```json
[
  {
    "id": 1,
    "name": "Jan Kowalski",
    "email": "jan@example.com"
  }
]



## TODO
- [ ] Autoryzacja i JWT
- [ ] Logowanie błędów (Serilog)
- [ ] Dockerfile i konfiguracja CI/CD