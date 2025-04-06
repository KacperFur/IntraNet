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

## 3. API Documentation 

## API Endpoints
### Employee Controller
###  1. Getting all employees
**GET** `api/intranet/employee`

#### Example response:
```json
[
  {
    "id": 0,
    "firstName": "string",
    "lastName": "string",
    "email": "string",
    "position": "string",
    "status": "string",
    "tasksAssigned": [
      {
        "id": 0,
        "tag": "string",
        "title": "string",
        "description": "string",
        "authorId": 0,
        "createdDate": "2025-03-29T09:18:27.668Z",
        "startDate": "2025-03-29T09:18:27.668Z",
        "finishDate": "2025-03-29T09:18:27.668Z"
      }
    ],
    "events": [
      {
        "id": 0,
        "name": "string",
        "description": "string",
        "date": "2025-03-29T09:18:27.668Z",
        "authorId": 0
      }
    ]
  }
]
```
###  2. Getting employee by id
**GET** `api/intranet/employee/{id}`

#### Example response:
```json
[
  {
    "id": 0,
    "firstName": "string",
    "lastName": "string",
    "email": "string",
    "position": "string",
    "status": "string",
    "tasksAssigned": [
      {
        "id": 0,
        "tag": "string",
        "title": "string",
        "description": "string",
        "authorId": 0,
        "createdDate": "2025-03-29T09:18:27.668Z",
        "startDate": "2025-03-29T09:18:27.668Z",
        "finishDate": "2025-03-29T09:18:27.668Z"
      }
    ],
    "events": [
      {
        "id": 0,
        "name": "string",
        "description": "string",
        "date": "2025-03-29T09:18:27.668Z",
        "authorId": 0
      }
    ]
  }
]
```
###  3. Creating new employee
**POST** `api/intranet/employee/`

#### Example body request :
```json
{
  "firstName": "string",
  "lastName": "string",
  "email": "user@example.com",
  "position": "string",
  "status": "string",
  "password": "string",
  "roleId": 0
}
```
###  4. Deleting employee
**DELETE** `api/intranet/employee/{id}`

#### Example body request :
```json
{
  "firstName": "string",
  "lastName": "string",
  "email": "user@example.com",
  "position": "string",
  "status": "string",
  "password": "string",
  "roleId": 0
}
```


## TODO
- [ ] Autoryzacja i JWT
- [ ] Logowanie błędów (Serilog)
- [ ] Dockerfile i konfiguracja CI/CD