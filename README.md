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
POST /api/card - Request: {"card": json board}, Response: {"status": status, "newItemId": new item id}
```
```
PUT /api/card/id - Request: {"card": json board}, Response: {"status": status}
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
POST /api/column - Request: {"column": json board}, Response: {"status": status, "newItemId": new item id}
```
```
PUT /api/column/id - Request: {"column": json board}, Response: {"status": status}
```
```
DELETE /api/column/id - Response: {"status": status}
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