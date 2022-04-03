## API

## HTTP

# Methods
|GET    |/api/todo              |                                               |
|GET    |/api/todo/{id}         |                                               |
|GET    |/api/todo/{id}/{id_t}  |                                               |
|POST   |/api/todo              |{id, t_list, date_added, due_date, iscomplete} |
|POST   |/api/todo/{id}         |{id,description}                               |
|PUT    |/api/todo/{id}         |{id, t_list, date_added, due_date, iscomplete} |
|PUT    |/api/todo/{id}/{id_t}  |{id,description}                               |
|DELETE |/api/todo/{id}         |                                               |
|DELETE |/api/todo/{id}/{id_t}  |                                               |

# Response

Went Success
|GET    |200|
|POST   |200|
|POST   |201|
|PUT    |200|
|DELETE |204|


Went wrong
|400| Bad Request: user error, invalid payload          |
|401| Unauthorized: invalid credential, not logged in   |
|403| Forbidden: user accessing admin panel             |
|404| Not Found: GET request on deleted content         |
|409| Conflict: modify deleted content                  |
|500| Internal Server Error: code throw exception       |