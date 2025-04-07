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
### Pagination and search
Some endpoints (listing employees, tasks, events) support pagination via querry parameters:
-`pageNumber` - default is 1
-`pageSize` - possible values are 10, 15, 20

These endpoints support also searching results via following query parameters: 
-`searchPhrase` -  filters employee by first name and last name
-`Name` - filters events by name
-`Tag` - filters tasks by tag

#### Example usage:
**GET** `api/intranet/employee?pageNumber=2&pageSize=15?searchPhrase=Peter`

### Authentication and Authorization
Application uses JWT for authenticating users and protecting resources.
To recive JWT tokenm you need to log in using following endpoint:

**POST** `api/intranet/account/login`

 Endpoint                     | Method | Requires JWT | Required Role         |
|-----------------------------|--------|--------------|------------------------|
| `api/intranet/employee/`    | GET    | ✅           | Admin,User, Supervisor |
| `api/intranet/employee/`    | POST   | ✅           | Admin                  |
| `api/intranet/employee/`    | PUT    | ✅           | Admin                  |
| `api/intranet/employee/`    | DELETE | ✅           | Admin                  |
| `api/intranet/event/`       | GET    | ✅           | Admin,User, Supervisor |
| `api/intranet/event/`       | POST   | ✅           | Admin, Supervisor      |
| `api/intranet/event/`       | PUT    | ✅           | Admin                  |
| `api/intranet/event/`       | DELETE | ✅           | Admin                  |
| `api/intranet/task/`        | GET    | ✅           | Admin,User, Supervisor |
| `api/intranet/task/`        | POST   | ✅           | Admin, Supervisor      |
| `api/intranet/task/`        | PUT    | ✅           | Admin, Supervisor      |
| `api/intranet/task/`        | DELETE | ✅           | Admin, Supervisor      |
| `api/intranet/account/login`| POST   | ❌           | -                      |


#### Example body request :
```json
{
  "email": "admin@mail.com",
  "password": "adminadmin"
}
```
This paricular request allows you to log in as administrator and use all of functions of this application.

#### Using the JWT token in requests
The token must be included in the Authorization header of every secured request, in the following format:
Authorization: Bearer {token}
#### Example :
```css
GET /api/intranet/employee
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6...
```

## API Endpoints
### Account Controller
### 1. login to account
**POST** `api/intranet/account/login`

#### Example body request :
```json
{
  "email": "string",
  "password": "string"
}
```

### Employee Controller
###  1. Getting all employees
**GET** `api/intranet/employee/?pageNumber=1&PageSize=10`

#### Example response:
```json
{
"items": [
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
],
"totalPages": 1,
    "firstItemNumber": 1,
    "lastItemNumber": 10,
    "itemsCount": 1
}
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

### 5. Updating employee informartion
**PUT** `api/intranet/employee/{id}`

#### Example body request :
```json
{
  "email": "string",
  "position": "string",
  "status": "string"
}
```
### Event Controller
###  1. Getting all events
**GET** `api/intranet/event/?pageNumber=1&PageSize=10`

#### Example response:
```json
{
    "items": [
        {
            "id": 1,
            "name": "Christmas Eve",
            "description": "day off",
            "date": "2025-12-29T00:00:00",
            "authorId": 1
        },
        {
            "id": 2,
            "name": "Independence day",
            "description": "day off",
            "date": "2025-11-11T00:00:00",
            "authorId": 1
        },
        {
            "id": 4,
            "name": "Day off",
            "description": "string",
            "date": "2025-04-04T00:00:00",
            "authorId": 1
        },
        {
            "id": 5,
            "name": "Day off",
            "description": "string",
            "date": "2025-04-04T00:00:00",
            "authorId": 0
        }
    ],
    "totalPages": 1,
    "firstItemNumber": 1,
    "lastItemNumber": 10,
    "itemsCount": 4
}
```

###  2. Getting event by id
**GET** `api/intranet/event/{id}`

#### Example response:
```json
{
  "id": 0,
  "name": "string",
  "description": "string",
  "date": "2025-04-07T16:14:25.507Z",
  "authorId": 0
}
```

###  3. Creating new event
**POST** `api/intranet/event/`

#### Example body request :
```json
{
  "name": "string",
  "description": "string",
  "date": "2025-04-07T16:15:45.501Z",
  "authorId": 0
}
```
###  4. Deleting event
**DELETE** `api/intranet/event/{id}`

### Task Controller
###  1. Getting all tasks
**GET** `api/intranet/task/?pageNumber=1&PageSize=10`

#### Example response
```json
"items": [
        {
            "id": 1,
            "tag": "new",
            "title": "task 1",
            "description": "desc",
            "authorId": 0,
            "assignedEmployeeId": null,
            "createdDate": "0001-01-01T00:00:00",
            "startDate": "2025-03-15T00:00:00",
            "finishDate": "2025-03-17T00:00:00"
        },
        {
            "id": 2,
            "tag": "new",
            "title": "task 2",
            "description": "desc",
            "authorId": 0,
            "assignedEmployeeId": 1,
            "createdDate": "0001-01-01T00:00:00",
            "startDate": "2025-03-15T00:00:00",
            "finishDate": "2025-03-17T00:00:00"
        },
        {
            "id": 3,
            "tag": "new",
            "title": "task 4",
            "description": "desc",
            "authorId": 0,
            "assignedEmployeeId": 1,
            "createdDate": "0001-01-01T00:00:00",
            "startDate": "2025-03-15T00:00:00",
            "finishDate": "2025-03-17T00:00:00"
        }
    ],
    "totalPages": 1,
    "firstItemNumber": 1,
    "lastItemNumber": 10,
    "itemsCount": 3
}
```
###  2. Getting task by id
**GET** `api/intranet/task/{id}`

#### Example response:
```json
{
  "id": 0,
  "tag": "string",
  "title": "string",
  "description": "string",
  "authorId": 0,
  "assignedEmployeeId": 0,
  "createdDate": "2025-04-07T16:25:04.792Z",
  "startDate": "2025-04-07T16:25:04.792Z",
  "finishDate": "2025-04-07T16:25:04.792Z"
}
```

###  3. Creating new task
**POST** `api/intranet/task/`

#### Example body request :
```json
{
  "tag": "string",
  "title": "string",
  "description": "string",
  "startDate": "2025-04-07T16:25:20.153Z",
  "finishDate": "2025-04-07T16:25:20.153Z",
  "assignedEmployeeId": 0
}
```
###  4. Deleting task
**DELETE** `api/intranet/task/{id}`

###  5. Updating task
**PUT** `api/intranet/task/{id}`

#### Example body request :
```json
{
  "title": "string",
  "description": "string",
  "startDate": "2025-04-07T16:26:02.905Z",
  "finishDate": "2025-04-07T16:26:02.905Z",
  "assignedEmployeeId": 0
}
```

## TODO
- [ ] Autoryzacja i JWT
- [ ] Logowanie błędów (Serilog)
- [ ] Dockerfile i konfiguracja CI/CD