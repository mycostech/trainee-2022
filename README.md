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

#### API for testing server status

```http
  GET /api/test
```

#### Response

| Variable | Type      | Description                                         |
| :------- | :-------- | :-------------------------------------------------- |
|          | `JSON`    |                                                     |
| success  | `Boolean` | `true` means server is read                         |
|          |           | `false` means server is down                        |
| message  | `string`  | description from server usually indicate the errors |

#### More will be documented in the future ...
