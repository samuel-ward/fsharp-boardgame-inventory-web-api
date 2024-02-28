namespace User.Games

type UserGame = {
    Id: string
    Name: string
}

type UserGameSave = UserGame -> UserGame

type UserGameCriteria =
| All

type UserGameFind = string -> UserGame option

type UserGamesFind = UserGameCriteria -> UserGame[]

type UserGameDelete = string -> bool