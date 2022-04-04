## Database Design

### Entity

* mood

  * level `int`

  * name `string`

* employee

  * id `string`

  * title `string`

  * firstname`string`

  * lastname`string`

  * email`string`

  * position`string`

### Relation

* have
  * moodTime `dateTime`

### SQL Database Drafting

#### Employee

| Attribute | Type     | Description                                                  |
| --------- | -------- | ------------------------------------------------------------ |
| id (PK)   | `int`    | Employee's identify number                                   |
| title     | `string` | Title name                                                   |
| firstName | `string` | First name                                                   |
| lastname  | `string` | Last name                                                    |
| email     | `string` | Email under the domain [mycostech.com](http://mycostech.com/) |
| position  | `string` | Employee's position in    Mycos Technologies                 |

#### Mood

| Attribute  | Type     | Description                                                  |
| ---------- | -------- | ------------------------------------------------------------ |
| level (PK) | `int`    | Mood level                                                   |
| name       | `string` | Mood name (level 1 = Sad, 2 = Exhausted, 3 = So-so, 4 = Good, 5 = Great) |

#### EmployeeMood

| Attribute       | Type       | Description                                         |
| --------------- | ---------- | --------------------------------------------------- |
| id(PK)          | `int`      | Employee Mood's identify number                     |
| dateTime        | `dateTime` | Date time when the system tracking employee's mood. |
| employeeId (FK) | `int`      | Employee's identify number                          |
| level (FK)      | `int`      | Mood level                                          |