## API ENDPOINTS

This is the Tweet app Endpoints Outlining. 

##### Tweet JSON

* Id (`String`) : Identifier to each Tweet
* ProfileName (`String`) : Profile name of the User who creates this Tweet
* Status (`String`) : Content of this Tweet
* Date (`DateTime`) : Tweet's post Datetime

### References

#### API for receiving all user Tweets (only ADMIN)

```http
    GET /api/users
```

Response body : `[{id, ProfileName, Status, Date}, ...]`

| Response code |       Description        |
| :-----------: | :----------------------: |
|      200      | Get Content Successfully |
|      404      |    Content Not Found     |

#### API for receiving user's all Tweets from Profile name

```http
    GET /api/users/{ProfileName}/
```

Response body : `[{id, ProfileName, Status, Date}, ...]`

| Response code |       Description        |
| :-----------: | :----------------------: |
|      200      | Get Content Successfully |
|      404      |    Content Not Found     |

#### API for receiving a specific Tweet from Tweet id

```http
    GET /api/users/{ProfileName}/tweets/{id} 
```

Response body : `{id, ProfileName, Status, Date}`

| Response code |       Description        |
| :-----------: | :----------------------: |
|      200      | Get Content Successfully |
|      404      |    Content Not Found     |

#### API for inputing a new Tweet from profile name (only specific user)

```http
    POST /api/users/{ProfileName}
```

Request body : `{id, ProfileName, Status, Date}`

Response body : `{id}`

| Response code |           Description           |
| :-----------: | :-----------------------------: |
|      201      | Create New Content Successfully |
|      400      |           Bad Request           |
|      409      |         Conflict Content        |

#### API for editing a specific Tweet from profile name (only specific user)

```http
    PATCH /api/users/{ProfileName}/tweets/{id} 
```

Request body : `{Status, Date}`

Response body : `{id, Status, Date}`

| Response code |         Description         |
| :-----------: | :-------------------------: |
|      200      | Modify Content Successfully |
|      400      |           Bad Request       |

#### API for deleting a specific Tweet from Tweet id (only specific user)

```http
    DELETE /api/users/{ProfileName}/tweets/{id}
```

| Response code |               Description                |
| :-----------: | :--------------------------------------: |
|      204      | Delete Content Successfully (No content) |
|      500      |           Code Throw Exception           |

#### API for deleting all Tweets from Tweet id (only specific user)

```http
    DELETE /api/users/{ProfileName}/
```

| Response code |               Description                |
| :-----------: | :--------------------------------------: |
|      204      | Delete Content Successfully (No content) |
|      500      |           Code Throw Exception           |

  

  

  





