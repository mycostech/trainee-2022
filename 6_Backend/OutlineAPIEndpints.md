## HTTP Methods
| HTTP Method | URL | Payload | Description | 
| ----------- | --- | ---- | ----------- |
| GET | /api/todo | |Get list of tasks|
| GET | /api/todo/{task_id} | | Get detail of that task |
| POST | /api/todo | {id,name,description,start_date,end_date,status} | Create new task |
| POST | /api/todo/{task_id} | {id,name,description,status} | Create new Step |
| PUT | /api/todo/{task_id} | {id,name,description,start_date,end_date,status} | Modify that task |
| PUT | /api/todo/{task_id}/{step_id} | {id,name,description,status} | Modify that step |
| Delete | /api/todo/{task_id} || Delete that task |
| Delete | /api/todo/{task_id}/{step_id} | | Delete that step |
| PATCH | /api/todo/{task_id} | {status} | Modify that task's status |
| PATCH | /api/todo/{task_id}/{step_id} | {status} | Modify that step's status |

## HTTP response

- `GET` /api/todo

```
[
    {
        "id": "1",
        "name": "buy some fruit",
        "descriptioni": "at supermarket".
        "start_date": "2022-04-01 10:00:00",
        "end_date": "2022-04-03 15:00:00",
        "status": "not finish"
    },
    {
        "id": "2",
        "name": "clean up the room",
        "descriptioni": "".
        "start_date" "2022-04-02 11:00:00",
        "end_date" "2022-04-02 12:30:00",
        "status": "finished"
    },
    ...
]
```
- `GET` /api/todo/{task_id}

```
{
    "id": "1",
    "name": "buy some fruit",
    "descriptioni": "at supermarket".
    "start_date": "2022-04-01 10:00:00",
    "end_date": "2022-04-03 15:00:00",
    "status": "not finish"
    "step": [
        {
            "id": "1",
            "name": "orange",
            "description": "",
            "status": "finished"
        },
        {
            "id": "2",
            "name": "watermelon",
            "description": "",
            "status": "not finished"
        },
        ...
    ]
}
```
## HTTP Response
| HTTP Method | Response code | Description | 
| ----------- | ---- | ----------- |
| `GET` | 200 | Get data successfully |
| `GET` | 400 | Bad request | 
| `GET` | 404 | Not Found |
| `POST` | 201 | Create successfully |
| `POST` | 400 | invalid payload |
| `POST` | 409 | Modify deleted content |
| `PUT` | 200 | Modify successfully |
| `PUT` | 400 | invalid payload |
| `PUT` | 409 | Modify deleted content |
| `DELETE` | 204 | Delete successfully |
| `PATCH` | 200 | Modify successfully |

## API Endpoint
- Check authentication/authorization(401/403)
- Check input format, payload schema(400)
- Execute CRUD operation on resource(404/409)
- Create response message(2xx,4xx)