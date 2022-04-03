# TODO APP

This project was meant to submit as assignment during my training at MyCos Technologies

Since there is no any given requirement, here are my assumptions:

This application will be implemented as web-application

- User shall be able to register and login to the system
- Each user shall have the following properties:
  - ID - indicate the id uses to reference to the user
  - Name - Name that user wants to be displayed on the application
  - Email
  - Password
- User shall be able to add, edit, delete **their own tasks**
- Each task shall contain the following properties:
  - ID - indicate the id uses to reference for task
  - UID - indicate the id of user who created the task
  - Title
  - Description (optional)
  - Subtasks (optional)
  - Priority (default: 5) - indicate urgency of task
  - Completed (default: false) - indicate whether the task is completed or not
  - Color (default: #1A1A1A) - indicate the theme of the task displayed
  - Created At - indicate the date which the task was Created
  - Updated At - indicate the date which the task was latest modified
  - Limited At - indicate the date which the task shall be completed
- User shall be able to add, edit, delete subtask in **their own tasks**
- Each subtask shall contain the following properties:
  - ID - indicate the id uses to reference for subtask
  - PID - indicate the id of the parent task
  - Title
  - Description (optional)
  - Completed (default: false) - indicate whether the subtask is completed or not
- User shall be able to mark complete and incomplete task and subtask
- User shall be able to set priority for each task
- User shall be able to sort task by its priority or date
- User should be able to select the custom color for each task
- The system should be able to work nicely on Mobile or Tablet

## Tech Stack

**Client:** React, TailwindCSS

**Server:** ASP.NET

**Database:** MySQL

## Run Locally

Clone the project

```bash
  git clone https://github.com/mycostech/trainee-2022.git
  git checkout Time
  git pull origin Time
```

### FRONTEND API

Go to the frontend directory

```bash
  cd todoapp-react
```

Install dependencies

```bash
  npm install
```

Start the client

```bash
  npm run start
```

### BACKEND API

Install .NET core 6.0 from official site

https://dotnet.microsoft.com/en-us/download

Go to the backend directory

```bash
  cd todoapp-api
```

Start the server

```bash
  dotnet build
  dotnet run
```

## API Reference

### **API for testing server status**

```http
  GET /api
```

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means server is ready                        |
|          |           | `false` means server is down                        |
| message  | `string`  | description from server usually indicate the errors |

#### Example

```json
{
  "success": true,
  "message": "Server is ready"
}
```

### **API for testing database status**

```http
  GET /api/db
```

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully connect to the database   |
|          |           | `false` means failed to connect to the database     |
| message  | `string`  | description from server usually indicate the errors |

#### Example

```json
{
  "success": true,
  "message": "Connected to the database"
}
```

## **API for authentication**

### **API for user registration**

```http
  POST /api/auth/register
```

### Request-Body

| Variable | Type     | Description   |
| :------- | :------- | :------------ |
|          | `JSON`   |               |
| name     | `string` | user name     |
| email    | `string` | user email    |
| password | `string` | user password |

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully register the user         |
|          |           | `false` means failed to register the user           |
| message  | `string`  | description from server usually indicate the errors |

#### Case 1: Successfully register the user

```json
{
  "success": true,
  "message": "Successfully register the user"
}
```

#### Case 2: Failed to register the user because the email already exists

```json
{
  "success": false,
  "message": "The email already exists"
}
```

#### Case 3: Failed to register the user because the email is invalid

```json
{
  "success": false,
  "message": "The email is invalid"
}
```

#### Case 4: Failed to register the user because the password is invalid

```json
{
  "success": false,
  "message": "The password is invalid"
}
```

#### Case 5: Failed to register the user because the name is invalid

```json
{
  "success": false,
  "message": "The name is invalid"
}
```

#### Case 6: Internal server error

```json
{
  "success": false,
  "message": "Internal server error"
}
```

### **API for user login**

```http
  POST /api/auth/login
```

### Request-Body

| Variable | Type     | Description   |
| :------- | :------- | :------------ |
|          | `JSON`   |               |
| email    | `string` | user email    |
| password | `string` | user password |

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully login the user            |
|          |           | `false` means failed to login the user              |
| message  | `string`  | description from server usually indicate the errors |

#### Case 1: Successfully login the user

```json
{
  "success": true,
  "message": "Successfully login the user"
}
```

#### Case 2: Failed to login the user because the credentials are invalid

```json
{
  "success": false,
  "message": "Either email or password is incorrect or the user is not exist"
}
```

#### Case 3: Internal server error

```json
{
  "success": false,
  "message": "Internal server error"
}
```

### **API for user logout**

```http
  POST /api/auth/logout
```

### Request-Header

| Variable | Type     | Description |
| :------- | :------- | :---------- |
|          | `JSON`   |             |
| token    | `string` | user token  |

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully logout the user           |
|          |           | `false` means failed to logout the user             |
| message  | `string`  | description from server usually indicate the errors |

### **API for forgot password**

```http
  POST /api/auth/forgot-password
```

### Request-Body

| Variable | Type     | Description |
| :------- | :------- | :---------- |
|          | `JSON`   |             |
| email    | `string` | user email  |

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully send the reset password   |
|          |           | `false` means failed to send the reset password     |
| message  | `string`  | description from server usually indicate the errors |

##### Case 1: Successfully send the reset password

```json
{
  "success": true,
  "message": "Successfully send the reset password to your email, if your email exist"
}
```

#### Case 2: Failed to send the reset password because the email is invalid

```json
{
  "success": false,
  "message": "The email is invalid"
}
```

#### Case 3: Internal server error

```json
{
  "success": false,
  "message": "Internal server error"
}
```

## **API for task**

### **API for creating task**

```http
  POST /api/task/create
```

### Request-Header

| Variable | Type     | Description |
| :------- | :------- | :---------- |
|          | `JSON`   |             |
| token    | `string` | user token  |

### Request-Body

#### **Note that:** `variable?` means optional

| Variable     | Type      | Description   |
| :----------- | :-------- | :------------ |
|              | `JSON`    |               |
| title        | `string`  | task title    |
| description? | `string`  | task content  |
| priority?    | `int`     | task priority |
| isCompleted? | `Boolean` | complete yet? |
| status?      | `int`     | enum status   |
| color?       | `string`  | color in hex  |
| limitedAt?   | `string`  | task due date |

Enum Status:

| Value | Description |
| :---: | :---------- |
|   0   | to do       |
|   1   | in progress |
|   2   | completed   |

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully create the task           |
|          |           | `false` means failed to create the task             |
| message  | `string`  | description from server usually indicate the errors |

##### Case 1: Successfully create the task

```json
{
  "success": true,
  "message": "Successfully create the task"
}
```

#### Case 2: Failed to create the task because the authorization header is invalid

```json
{
  "success": false,
  "message": "The authorization header is invalid"
}
```

#### Case 3: Failed to create the task because the title is empty

```json
{
  "success": false,
  "message": "The title is empty"
}
```

#### Case 4: Internal server error

```json
{
  "success": false,
  "message": "Internal server error"
}
```

### **API for getting tasks**

```http
  GET /api/task/get/{amount}
```

### Request-Header

| Variable | Type     | Description |
| :------- | :------- | :---------- |
|          | `JSON`   |             |
| token    | `string` | user token  |

### Request-Parameter

| Variable | Type   | Description            |
| :------- | :----- | :--------------------- |
|          | `JSON` |                        |
| amount   | `int`  | amount of tasks to get |

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully get the tasks             |
|          |           | `false` means failed to get the tasks               |
| message  | `string`  | description from server usually indicate the errors |
| tasks    | `Array`   | array of tasks                                      |

#### Case 1: Successfully get the tasks

```json
{
  "success": true,
  "message": "Successfully get the tasks",
  "tasks": [
    {
      "id": 1,
      "title": "Task 1",
      "description": "Task 1 description",
      "priority": 1,
      "isCompleted": false,
      "status": "to do",
      "color": "#ff0000",
      "limitedAt": "2019-01-01T00:00:00.000Z"
    },
    {
      "id": 2,
      "title": "Task 2",
      "description": "Task 2 description",
      "priority": 2,
      "isCompleted": false,
      "status": "in progress",
      "color": "#ff0000",
      "limitedAt": "2019-01-01T00:00:00.000Z"
    }
  ]
}
```

#### Case 2: Failed to get the tasks because the authorization header is invalid

```json
{
  "success": false,
  "message": "The authorization header is invalid"
}
```

#### Case 3: Failed to get the tasks, amount parameter is required

```json
{
  "success": false,
  "message": "The amount parameter is required"
}
```

#### Case 4: Failed to get the tasks because the amount is invalid

```json
{
  "success": false,
  "message": "The amount is invalid"
}
```

#### Case 5: Failed to get the tasks amount is too large

```json
{
  "success": false,
  "message": "The amount is too large"
}
```

#### Case 6: Internal server error

```json
{
  "success": false,
  "message": "Internal server error"
}
```

### **API for getting tasks by status**

```http
GET /api/task/get/status/{status}/{amount}
```

### Request-Header

| Variable | Type     | Description |
| :------- | :------- | :---------- |
|          | `JSON`   |             |
| token    | `string` | user token  |

### Request-Parameter

| Variable | Type   | Description            |
| :------- | :----- | :--------------------- |
|          | `JSON` |                        |
| status   | `int`  | status of tasks to get |
| amount   | `int`  | amount of tasks to get |

Enum Status:

| Value | Description |
| :---: | :---------- |
|   0   | to do       |
|   1   | in progress |
|   2   | completed   |

#### Request example

```http
GET /api/task/get/status/1/2
```

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully get the tasks             |
|          |           | `false` means failed to get the tasks               |
| message  | `string`  | description from server usually indicate the errors |
| tasks    | `Array`   | array of tasks                                      |

##### Case 1: Successfully get the tasks

```json
{
  "success": true,
  "message": "Successfully get the tasks",
  "tasks": [
    {
      "id": 1,
      "title": "Task 1",
      "description": "Task 1 description",
      "priority": 1,
      "isCompleted": false,
      "status": "in progress",
      "color": "#ff0000",
      "limitedAt": "2019-01-01T00:00:00.000Z"
    },
    {
      "id": 2,
      "title": "Task 2",
      "description": "Task 2 description",
      "priority": 2,
      "isCompleted": false,
      "status": "in progress",
      "color": "#ff0000",
      "limitedAt": "2019-01-01T00:00:00.000Z"
    }
  ]
}
```

##### Case 2: Failed to get the tasks because the authorization header is invalid

```json
{
  "success": false,
  "message": "The authorization header is invalid"
}
```

##### Case 3: Failed to get the tasks, status parameter is required

```json
{
  "success": false,
  "message": "The status parameter is required"
}
```

##### Case 4: Failed to get the tasks, amount parameter is required

```json
{
  "success": false,
  "message": "The amount parameter is required"
}
```

##### Case 5: Failed to get the tasks because the amount is invalid

```json
{
  "success": false,
  "message": "The amount is invalid"
}
```

#### Case 6: Failed to get the tasks amount is too large

```json
{
  "success": false,
  "message": "The amount is too large"
}
```

#### Case 7: Failed to get the tasks because the status is invalid

```json
{
  "success": false,
  "message": "The status is invalid"
}
```

#### Case 8: Internal server error

```json
{
  "success": false,
  "message": "Internal server error"
}
```

### **API for editing task**

```http
POST /api/task/edit/
```

### Request-Header

| Variable | Type     | Description |
| :------- | :------- | :---------- |
|          | `JSON`   |             |
| token    | `string` | user token  |

### Request-Body

#### **Note:** `variable?` means optional

| Variable     | Type      | Description         |
| :----------- | :-------- | :------------------ |
|              | `JSON`    |                     |
| id           | `int`     | id of task          |
| title?       | `string`  | title of task       |
| description? | `string`  | description of task |
| priority?    | `int`     | priority of task    |
| isCompleted? | `boolean` | is task completed   |
| status?      | `int`     | status of task      |
| color?       | `string`  | color of task       |
| limitedAt?   | `string`  | limited at of task  |

#### Request Body Example

```json
{
  "id": 1,
  "isCompleted": true,
  "color": "#ffaa00",
  "limitedAt": "2019-01-01T00:00:00.000Z"
}
```

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully edit the task             |
|          |           | `false` means failed to edit the task               |
| message  | `string`  | description from server usually indicate the errors |

#### Case 1: Successfully edit the task

```json
{
  "success": true,
  "message": "Successfully edit the task"
}
```

#### Case 2: Failed to edit the task because the authorization header is invalid

```json
{
  "success": false,
  "message": "The authorization header is invalid"
}
```

#### Case 3: Failed to edit the task, id parameter is required

```json
{
  "success": false,
  "message": "The id parameter is required"
}
```

#### Case 4: Failed to edit the task, id parameter is invalid

```json
{
  "success": false,
  "message": "The id parameter is invalid"
}
```

#### Case 5: Failed to edit the task, task is not found

```json
{
  "success": false,
  "message": "The task is not found"
}
```

#### Case 6-12: Failed to edit the task because the parameters is invalid

```json
{
  "success": false,
  "message": "title is invalid"
},
{
  "success": false,
  "message": "description is invalid"
},
{
  "success": false,
  "message": "priority is invalid"
},
{
  "success": false,
  "message": "isCompleted is invalid"
},
{
  "success": false,
  "message": "status is invalid"
},
{
  "success": false,
  "message": "color is invalid"
},
{
  "success": false,
  "message": "limitedAt is invalid"
}
```

#### Case 13: Internal server error

```json
{
  "success": false,
  "message": "Internal server error"
}
```

### **API for deleting task**

```http
POST /api/task/delete/
```

### Request-Header

| Variable | Type     | Description |
| :------- | :------- | :---------- |
|          | `JSON`   |             |
| token    | `string` | user token  |

### Request-Body

| Variable | Type   | Description |
| :------- | :----- | :---------- |
|          | `JSON` |             |
| id       | `int`  | id of task  |

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully delete the task           |
|          |           | `false` means failed to delete the task             |
| message  | `string`  | description from server usually indicate the errors |

#### Case 1: Successfully delete the task

```json
{
  "success": true,
  "message": "Successfully delete the task"
}
```

#### Case 2: Failed to delete the task because the authorization header is invalid

```json
{
  "success": false,
  "message": "The authorization header is invalid"
}
```

#### Case 3: Failed to delete the task, id parameter is required

```json
{
  "success": false,
  "message": "The id parameter is required"
}
```

#### Case 4: Failed to delete the task, id parameter is invalid

```json
{
  "success": false,
  "message": "The id parameter is invalid"
}
```

#### Case 5: Failed to delete the task, task is not found

```json
{
  "success": false,
  "message": "The task is not found"
}
```

#### Case 6: Internal server error

```json
{
  "success": false,
  "message": "Internal server error"
}
```

### **API for completing task**

#### Change the status of task to completed

```http
POST /api/task/complete/
```

### Request-Header

| Variable | Type     | Description |
| :------- | :------- | :---------- |
|          | `JSON`   |             |
| token    | `string` | user token  |

### Request-Body

| Variable | Type   | Description |
| :------- | :----- | :---------- |
|          | `JSON` |             |
| id       | `int`  | id of task  |

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully complete the task         |
|          |           | `false` means failed to complete the task           |
| message  | `string`  | description from server usually indicate the errors |

#### Case 1: Successfully complete the task

```json
{
  "success": true,
  "message": "Successfully update the task status to completed"
}
```

#### Case 2: Failed to complete the task because the authorization header is invalid

```json
{
  "success": false,
  "message": "The authorization header is invalid"
}
```

#### Case 3: Failed to complete the task, id parameter is required

```json
{
  "success": false,
  "message": "The id parameter is required"
}
```

#### Case 4: Failed to complete the task, id parameter is invalid

```json
{
  "success": false,
  "message": "The id parameter is invalid"
}
```

#### Case 5: Failed to complete the task, task is not found

```json
{
  "success": false,
  "message": "The task is not found"
}
```

#### Case 6: Internal server error

```json
{
  "success": false,
  "message": "Internal server error"
}
```

### **API for uncompleting task**

#### Change the status of task to uncompleted

```http
POST /api/task/uncomplete/
```

### Request-Header

| Variable | Type     | Description |
| :------- | :------- | :---------- |
|          | `JSON`   |             |
| token    | `string` | user token  |

### Request-Body

| Variable | Type   | Description |
| :------- | :----- | :---------- |
|          | `JSON` |             |
| id       | `int`  | id of task  |

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully uncomplete the task       |
|          |           | `false` means failed to uncomplete the task         |
| message  | `string`  | description from server usually indicate the errors |

#### Case 1: Successfully uncomplete the task

```json
{
  "success": true,
  "message": "Successfully update the task status to uncompleted"
}
```

#### Case 2: Failed to uncomplete the task because the authorization header is invalid

```json
{
  "success": false,
  "message": "The authorization header is invalid"
}
```

#### Case 3: Failed to uncomplete the task, id parameter is required

```json
{
  "success": false,
  "message": "The id parameter is required"
}
```

#### Case 4: Failed to uncomplete the task, id parameter is invalid

```json
{
  "success": false,
  "message": "The id parameter is invalid"
}
```

#### Case 5: Failed to uncomplete the task, task is not found

```json
{
  "success": false,
  "message": "The task is not found"
}
```

#### Case 6: Internal server error

```json
{
  "success": false,
  "message": "Internal server error"
}
```

### **API for searching task**

#### Search the task by title

```http
POST /api/task/search/
```

### Request-Header

| Variable | Type     | Description |
| :------- | :------- | :---------- |
|          | `JSON`   |             |
| token    | `string` | user token  |

### Request-Body

| Variable | Type     | Description   |
| :------- | :------- | :------------ |
|          | `JSON`   |               |
| title    | `string` | title of task |

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully search the task           |
|          |           | `false` means failed to search the task             |
| message  | `string`  | description from server usually indicate the errors |

#### Example Request:

Url

```http
POST /api/task/search/
```

Header

```json
{
  "token": "xxx"
}
```

Body

```json
{
  "title": "task title"
}
```

#### Case 1: Successfully search the task

```json
{
  "success": true,
  "message": "Successfully search the task",
  "data": [
    {
      "id": 1,
      "title": "Task 1",
      "description": "Description of task 1",
      "status": "completed",
      "created_at": "2020-01-01 00:00:00",
      "updated_at": "2020-01-01 00:00:00"
    },
    {
      "id": 2,
      "title": "Task 2",
      "description": "Description of task 2",
      "status": "uncompleted",
      "created_at": "2020-01-01 00:00:00",
      "updated_at": "2020-01-01 00:00:00"
    }
  ]
}
```

#### Case 2: Failed to search the task because the authorization header is invalid

```json
{
  "success": false,
  "message": "The authorization header is invalid"
}
```

#### Case 3: Failed to search the task, title parameter is required

```json
{
  "success": false,
  "message": "The title parameter is required"
}
```

#### Case 4: Failed to search the task, title parameter is invalid

```json
{
  "success": false,
  "message": "The title parameter is invalid"
}
```

#### Case 5: Internal server error

```json
{
  "success": false,
  "message": "Internal server error"
}
```

### **API for creating subtask**

#### Create a subtask

```http
POST /api/subtask/create/
```

### Request-Header

| Variable | Type     | Description |
| :------- | :------- | :---------- |
|          | `JSON`   |             |
| token    | `string` | user token  |

### Request-Body

| Variable     | Type      | Description            |
| :----------- | :-------- | :--------------------- |
|              | `JSON`    |                        |
| taskId       | `int`     | id of parent task      |
| title        | `string`  | title of subtask       |
| description? | `string`  | description of subtask |
| isCompleted? | `boolean` | is subtask completed   |

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully create the subtask        |
|          |           | `false` means failed to create the subtask          |
| message  | `string`  | description from server usually indicate the errors |

#### Example Request:

```http
POST /api/subtask/create/
```

Header

```json
{
  "token": "xxx"
}
```

Body

```json
{
  "id": 1,
  "title": "Subtask 1",
  "description": "Description of subtask 1"
}
```

#### Case 1: Successfully create the subtask

```json
{
  "success": true,
  "message": "Successfully create the subtask",
  "data": {
    "id": 1,
    "title": "Subtask 1",
    "description": "Description of subtask 1",
    "status": "uncompleted",
    "created_at": "2020-01-01 00:00:00",
    "updated_at": "2020-01-01 00:00:00"
  }
}
```

#### Case 2: Failed to create the subtask because the authorization header is invalid

```json
{
  "success": false,
  "message": "The authorization header is invalid"
}
```

#### Case 3: Failed to create the subtask, taskId parameter is required

```json
{
  "success": false,
  "message": "The taskId parameter is required"
}
```

#### Case 4: Failed to create the subtask, taskId parameter is invalid

```json
{
  "success": false,
  "message": "The taskId parameter is invalid"
}
```

#### Case 5: Failed to create the subtask, task is not found

```json
{
  "success": false,
  "message": "Task is not found"
}
```

#### Case 6: Failed to create the subtask, title parameter is required

```json
{
  "success": false,
  "message": "The title parameter is required"
}
```

#### Case 7: Failed to create the subtask, title parameter is invalid

```json
{
  "success": false,
  "message": "The title parameter is invalid"
}
```

#### Case 8: Internal server error

```json
{
  "success": false,
  "message": "Internal server error"
}
```

### **API for editing subtask**

#### Edit a subtask

```http
POST /api/subtask/edit/
```

### Request-Header

| Variable | Type     | Description |
| :------- | :------- | :---------- |
|          | `JSON`   |             |
| token    | `string` | user token  |

### Request-Body

| Variable     | Type      | Description            |
| :----------- | :-------- | :--------------------- |
|              | `JSON`    |                        |
| id           | `int`     | id of subtask          |
| title?       | `string`  | title of subtask       |
| description? | `string`  | description of subtask |
| isCompleted? | `boolean` | is subtask completed   |

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully edit the subtask          |
|          |           | `false` means failed to edit the subtask            |
| message  | `string`  | description from server usually indicate the errors |

#### Example Request:

```http
POST /api/subtask/edit/
```

```json
{
  "id": 1,
  "title": "Subtask 1",
  "description": "Description of subtask 1"
}
```

#### Case 1: Successfully edit the subtask

```json
{
  "success": true,
  "message": "Successfully edit the subtask",
  "data": {
    "id": 1,
    "title": "Subtask 1",
    "description": "Description of subtask 1",
    "status": "uncompleted",
    "created_at": "2020-01-01 00:00:00",
    "updated_at": "2020-01-01 00:00:00"
  }
}
```

#### Case 2: Failed to edit the subtask because the authorization header is invalid

```json
{
  "success": false,
  "message": "The authorization header is invalid"
}
```

#### Case 3: Failed to edit the subtask, subtaskId parameter is required

```json
{
  "success": false,
  "message": "The subtaskId parameter is required"
}
```

#### Case 5: Failed to edit the subtask, subtask is not found

```json
{
  "success": false,
  "message": "Subtask is not found"
}
```

#### Case 6: Failed to edit the subtask, title parameter is required

```json
{
  "success": false,
  "message": "The title parameter is required"
}
```

#### Case 7: Failed to edit the subtask, title parameter is invalid

```json
{
  "success": false,
  "message": "The title parameter is invalid"
}
```

#### Case 8: Internal server error

```json
{
  "success": false,
  "message": "Internal server error"
}
```

### **API for deleting subtask**

#### Delete a subtask

```http
POST /api/subtask/delete/
```

### Request-Header

| Variable | Type     | Description |
| :------- | :------- | :---------- |
|          | `JSON`   |             |
| token    | `string` | user token  |

### Request-Body

| Variable | Type   | Description   |
| :------- | :----- | :------------ |
|          | `JSON` |               |
| id       | `int`  | id of subtask |

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully delete the subtask        |
|          |           | `false` means failed to delete the subtask          |
| message  | `string`  | description from server usually indicate the errors |

### Example Request:

```http
POST /api/subtask/delete/
```

Header

```json
{
  "token": "xxxxxx"
}
```

Body

```json
{
  "id": 1
}
```

#### Case 1: Successfully delete the subtask

```json
{
  "success": true,
  "message": "Successfully delete the subtask"
}
```

#### Case 2: Failed to delete the subtask because the authorization header is invalid

```json
{
  "success": false,
  "message": "The authorization header is invalid"
}
```

#### Case 3: Failed to delete the subtask, subtaskId parameter is required

```json
{
  "success": false,
  "message": "The subtaskId parameter is required"
}
```

#### Case 4: Failed to delete the subtask, subtask is not found

```json
{
  "success": false,
  "message": "Subtask is not found"
}
```

#### Case 5: Internal server error

```json
{
  "success": false,
  "message": "Internal server error"
}
```

### **API for completing subtask**

#### Complete a subtask

```http
POST /api/subtask/complete/
```

### Request-Header

| Variable | Type     | Description |
| :------- | :------- | :---------- |
|          | `JSON`   |             |
| token    | `string` | user token  |

### Request-Body

| Variable | Type   | Description   |
| :------- | :----- | :------------ |
|          | `JSON` |               |
| id       | `int`  | id of subtask |

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully complete the subtask      |
|          |           | `false` means failed to complete the subtask        |
| message  | `string`  | description from server usually indicate the errors |

#### Case 1: Successfully complete the subtask

```json
{
  "success": true,
  "message": "Successfully complete the subtask"
}
```

#### Case 2: Failed to complete the subtask because the authorization header is invalid

```json
{
  "success": false,
  "message": "The authorization header is invalid"
}
```

#### Case 3: Failed to complete the subtask, subtaskId parameter is required

```json
{
  "success": false,
  "message": "The subtaskId parameter is required"
}
```

#### Case 4: Failed to complete the subtask, subtask is not found

```json
{
  "success": false,
  "message": "Subtask is not found"
}
```

#### Case 5: Internal server error

```json
{
  "success": false,
  "message": "Internal server error"
}
```

### **API for uncompleting subtask**

#### Uncomplete a subtask

```http
POST /api/subtask/uncomplete/
```

### Request-Header

| Variable | Type     | Description |
| :------- | :------- | :---------- |
|          | `JSON`   |             |
| token    | `string` | user token  |

### Request-Body

| Variable | Type   | Description   |
| :------- | :----- | :------------ |
|          | `JSON` |               |
| id       | `int`  | id of subtask |

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully uncomplete the subtask    |
|          |           | `false` means failed to uncomplete the subtask      |
| message  | `string`  | description from server usually indicate the errors |

#### Case 1: Successfully uncomplete the subtask

```json
{
  "success": true,
  "message": "Successfully uncomplete the subtask"
}
```

#### Case 2: Failed to uncomplete the subtask because the authorization header is invalid

```json
{
  "success": false,
  "message": "The authorization header is invalid"
}
```

#### Case 3: Failed to uncomplete the subtask, subtaskId parameter is required

```json
{
  "success": false,
  "message": "The subtaskId parameter is required"
}
```

#### Case 4: Failed to uncomplete the subtask, subtask is not found

```json
{
  "success": false,
  "message": "Subtask is not found"
}
```

#### Case 5: Internal server error

```json
{
  "success": false,
  "message": "Internal server error"
}
```

### **API for getting subtask list**

#### Get subtask list

```http
POST /api/subtask/list/
```

### Request-Header

| Variable | Type     | Description |
| :------- | :------- | :---------- |
|          | `JSON`   |             |
| token    | `string` | user token  |

### Request-Body

| Variable | Type   | Description       |
| :------- | :----- | :---------------- |
|          | `JSON` |                   |
| id       | `int`  | id of parent task |

### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means successfully get the subtask list      |
|          |           | `false` means failed to get the subtask list        |
| message  | `string`  | description from server usually indicate the errors |

#### Case 1: Successfully get the subtask list

```json
{
  "success": true,
  "message": "Successfully get the subtask list",
  "data": [
    {
      "id": 1,
      "name": "subtask 1",
      "description": "description of subtask 1",
      "status": "in progress"
    },
    {
      "id": 2,
      "name": "subtask 2",
      "description": "description of subtask 2",
      "status": "to do"
    }
  ]
}
```

#### Case 2: Failed to get the subtask list because the authorization header is invalid

```json
{
  "success": false,
  "message": "The authorization header is invalid"
}
```

#### Case 3: Failed to get the subtask list, taskId parameter is required

```json
{
  "success": false,
  "message": "The taskId parameter is required"
}
```

#### Case 4: Failed to get the subtask list, task is not found

```json
{
  "success": false,
  "message": "Task is not found"
}
```

#### Case 5: Internal server error

```json
{
  "success": false,
  "message": "Internal server error"
}
```

#### More will be documented in the future ...
