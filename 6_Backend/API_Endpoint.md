## API Endpoint
* HTTP method & URL path & parameters & payload body 
### Method `GET`

```http
GET /api/todoList
```
| Request Body          | Response Body                                        | Description                        |
| :-------------------- | :--------------------------------------------------- | :--------------------------------- |
|                       | [{td_id, td_name, td_description, is_complete}, ...] | Get list of todos                  |

```http
GET /api/todoList/{td_id}
```
| Request Body    | Response Body                                                                            | Description                   |
| :-------------- | :--------------------------------------------------------------------------------------- | :-----------------------------|
|                 | [{t_id, t_name, status, t_description, start_date, due_date, complete_date, td_id}, ...] | Get all tasks of todo {td_id  |

```http
GET /api/todoList/{td_id}/{t_id}
```
| Request Body    | Response Body                                                                      | Description                        |
| :-------------- | :--------------------------------------------------------------------------------- | :--------------------------------- |
|                 | {t_id, t_name, status, t_description, start_date, due_date, complete_date, td_id}  | Get detail of task {t_id}          |

```http
GET /api/todoList/{td_id}/{t_id}/comments
```
| Request Body                                  | Response Body                                 | Description                        |
| :-------------------------------------------- | :-------------------------------------------- | :--------------------------------- |
|                                               | [{cm_id, t_id, content, cm_date}, ...]        |  Get all comments of task {t_id}   |

### Method `POST`
```http
POST /api/todoList
```
| Request Body                                  | Response Body                                 | Description                        |
| :-------------------------------------------- | :-------------------------------------------- | :--------------------------------- |
| {td_id, td_name, td_description, is_complete} | {td_id}                                       | Create new todo                    |

```http
POST /api/todoList/{td_id}
```
| Request Body                                                                      | Response Body       | Description                        |
| :-------------------------------------------------------------------------------- | :------------------ | :--------------------------------- |
| {t_id, t_name, status, t_description, start_date, due_date, complete_date, td_id} | {t_id}              | Create new task of todo {td_id}    |

```http
POST /api/todoList/{td_id}/{t_id}
```
| Request Body                                  | Response Body                                 | Description                        |
| :-------------------------------------------- | :-------------------------------------------- | :--------------------------------- |
| {cm_id, t_id, content, cm_date}               | {cm_id}                                       | Create new comment of task {t_id}  |

### Method `PUT`
```http
PUT /api/todoList/{td_id}
```
| Request Body                                  | Response Body                                 | Description                        |
| :-------------------------------------------- | :-------------------------------------------- | :--------------------------------- |
| td_id, td_name, td_description, is_complete}  |                                               | Modify todo {td_id}                |

```http
PUT /api/todoList/{td_id}/{t_id}
```
| Request Body                                                                      | Response Body       | Description                        |
| :-------------------------------------------------------------------------------- | :------------------ | :--------------------------------- |
| {t_id, t_name, status, t_description, start_date, due_date, complete_date, td_id} | {t_id}              |  Modify task {t_id}                |

```http
PUT /api/todoList/{td_id}/comments/{cm_id}
```
| Request Body                                  | Response Body                                 | Description                        |
| :-------------------------------------------- | :-------------------------------------------- | :--------------------------------- |
| {cm_id, t_id, content, cm_date}               |                                               | Modify comment {cm_id}             |

### Method `DELETE`
```http
DELETE /api/todoList/
```
| Request Body                                  | Response Body                                 | Description                        |
| :-------------------------------------------- | :-------------------------------------------- | :--------------------------------- |
|                                               |                                               | Delete all todos                   |

```http
DELETE /api/todoList/{td_id}
```
| Request Body                                  | Response Body                                 | Description                        |
| :-------------------------------------------- | :-------------------------------------------- | :--------------------------------- |
|                                               |                                               | Delete that todo                   |

```http
DELETE /api/todoList/{td_id}/{t_id}
```
| Request Body                                  | Response Body                                 | Description                        |
| :-------------------------------------------- | :-------------------------------------------- | :--------------------------------- |
|                                               |                                               | Delete that task                   |

```http
DELETE /api/todoList/{td_id}/comments/{cm_id}
```
| Request Body                                  | Response Body                                 | Description                        |
| :-------------------------------------------- | :-------------------------------------------- | :--------------------------------- |
|                                               |                                               | Delete that comment                |

### Method `PATCH`
```http
PATCH /api/todoList/{td_id}
```
| Request Body          | Request Body                                         | Description                        |
| :-------------------- | :--------------------------------------------------- | :--------------------------------- |
| {is_complete}         | {td_id, td_name, td_description, is_complete}        | Modify is_complete of that todo    |

```http
PATCH /api/todoList/{td_id}/{t_id}
```
| Request Body         | Response Body                                                                      | Description                               |
| :------------------- | :--------------------------------------------------------------------------------- | :---------------------------------------- |
| {status, start_date} | {t_id, t_name, status, t_description, start_date, due_date, complete_date, td_id}  | Modify status and start_date of that task |

```http
PATCH /api/todoList/{td_id}/{t_id}
```
| Request Body            | Response Body                                                                      | Description                                  |
| :---------------------- | :--------------------------------------------------------------------------------- | :------------------------------------------- |
| {status, complete_date} | {t_id, t_name, status, t_description, start_date, due_date, complete_date, td_id}  | Modify status and complete_date of that task |

## HTTP Response
| HTTP Method	| Response code                                 | Description                                  |
| :---------- | :-------------------------------------------- | :------------------------------------------- |
| `GET`       | 200 OK                                        | Get data successfully                        |
| `GET`       | 404 Not Found                                 | GET request on deleted content               |
| `POST`      | 201 Created                                   | Create data successfully                     |
| `POST`      | 400 Bad Request                               | Invalid payload                              |
| `POST`      | 409 Conflict                                  | Create existing data                         |
| `PUT`       | 200 OK                                        | Modify data successfully                     |
| `PUT`       | 400 Bad Request                               | Invalid payload                              |
| `PUT`       | 409 Conflict                                  | Modify deleted content                       |
| `DELETE`    | 204 No Content                                | Delete data successfully                     |
| `DELETE`    | 409 Conflict                                  | Delete data that does not exist              |
| `PATCH`     | 200 OK                                        | Modify data successfully                     |
| `PATCH`     | 400 Bad Request                               | Invalid payload                              |
| `PATCH`     | 409 Conflict                                  | Modify deleted content                       |


