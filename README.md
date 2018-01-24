# NG2 Trello Backend

REST Api for Trello app

## Endpoints

### Account

```
POST /api/account/data - Request: {"token": jwt token}, Response: json userdata
```
```
POST /api/account/login - Request: {"username":username, "password": password}, Response: json {"token": jwt token}
```
```
POST /api/account/register - Request: {"username":username, "password": password}, Response: json {"token": jwt token} 
```

### Board
Needs authentication header

```
GET /api/board - All boards info
```
```
GET /api/board/id - Board by id info
```
```
POST /api/board - Request: {"board": json board}, Response: {"status": status, "newItemId": new item id}
```
```
PUT /api/board/id - Request: {"board": json board}, Response: {"status": status}
```
```
DELETE /api/board/id - Response: {"status": status}
```

### Card
Needs authentication header

```
GET /api/card - All cards info
```
```
GET /api/card/id - Card by id info
```
```
POST /api/card/boardid - All cards by board id info
```
```
POST /api/card - Request: {"card": json card}, Response: {"status": status, "newItemId": new item id}
```
```
PUT /api/card/id - Request: {"card": json card}, Response: {"status": status}
```
```
DELETE /api/card/id - Response: {"status": status}
```

### Column
Needs authentication header

```
GET /api/column - All columns info
```
```
GET /api/column/id - Column by id info
```
```
POST /api/column/boardid - All columns by board id info
```
```
POST /api/column - Request: {"column": json column}, Response: {"status": status, "newItemId": new item id}
```
```
PUT /api/column/id - Request: {"column": json column}, Response: {"status": status}
```
```
DELETE /api/column/id - Response: {"status": status}
```

### Team
Needs authentication header

```
GET /api/team/id - team by id info
```
```
POST /api/team - Request: {"team": json team}, Response: {"status": status, "newItemId": new item id}
```
```
PUT /api/team/id - Request: {"team": json team}, Response: {"status": status}
```
```
DELETE /api/team/id - Response: {"team": status}
```

### Card Action
Needs authentication header

```
GET /api/cardaction - All cardactions info
```
```
GET /api/cardaction/id - cardaction by id info
```
```
POST /api/cardaction/cardid - All cardactions by card id info
```
```
POST /api/cardaction - Request: {"cardaction": json cardaction}, Response: {"status": status, "newItemId": new item id}
```
```
PUT /api/cardaction/id - Request: {"cardaction": json cardaction}, Response: {"status": status}
```
```
DELETE /api/cardaction/id - Response: {"status": status}
```

### Comment
Needs authentication header

```
GET /api/comment - All comments info
```
```
GET /api/comment/id - Comment by id info
```
```
POST /api/comment - Request: {"comment": json comment}, Response: {"status": status, "newItemId": new item id}
```
```
PUT /api/comment/id - Request: {"comment": json comment}, Response: {"status": status}
```
```
DELETE /api/comment/id - Response: {"status": status}
```

### Content
Needs authentication header

```
GET /api/content - All contents info
```
```
GET /api/content/id - Content by id info
```
```
POST /api/content - Request: {"content": json content}, Response: {"status": status, "newItemId": new item id}
```
```
PUT /api/content/id - Request: {"content": json content}, Response: {"status": status}
```
```
DELETE /api/content/id - Response: {"status": status}
```

### Todolist
Needs authentication header

```
GET /api/todolist - All todolists info
```
```
GET /api/todolist/id - Todolist by id info
```
```
POST /api/todolist - Request: {"todolist": json todolist}, Response: {"status": status, "newItemId": new item id}
```
```
PUT /api/todolist/id - Request: {"todolist": json todolist}, Response: {"status": status}
```
```
DELETE /api/todolist/id - Response: {"status": status}
```
### Todo

```
POST /api/todo/todolistid - Request: {"todo": json todo}, Response: {"status": status, "newItemId": new item id}
```
```
PUT /api/todo/todolistid/id - Request: {"todo": json todo}, Response: {"status": status}
```
```
DELETE /api/todo/todolistid/id - Request: {"todo": json todo}, Response: {"status": status}
```
## JSON Data format

### User
```
int Id
string Username
string Role
string Email
string AvatarUrl
string Description
string Preferences
```
### Board
```
int Id
string Title
List<int> ColumnIds
List<int> CardIds
List<int> ParticipantIds
string Status
string Sorting
```
### Board
```
int Id
string Title
List<int> ColumnIds
List<int> CardIds
List<int> ParticipantIds
string Status
string Sorting
```
### Card
```
int Id
List<int> ParticipantIds
int BoardId
long CreationTimestamp
long ExpirationTimestamp
int ColumnId
List<int> ActionIds
List<string> Labels
int? TodolistId
List<int> CommentIds
```
### Column
```
int Id
int BoardId
List<int> CardIds
string Title
```
### Team
```
int Id
List<int> ParticipantIds
string Title
List<int> BoardIds
```
### Card Action
```
int Id
int CardId
string Text
int ParticipantId
```
### Comment
```
int Id
int UserId
string Text
string Data
```
### Content
```
int Id
int CardId
string Text
string ImageUrl
```
### Todolist
```
int Id
List<SerTodo> Todos
string Title
```
### Todo
```
int Id
string Text
bool Status
```