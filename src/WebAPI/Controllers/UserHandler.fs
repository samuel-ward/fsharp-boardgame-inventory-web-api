namespace User.Games.Http

open Giraffe
open Microsoft.AspNetCore.Http
open System

open User.Games

module UserGamesHttp =
    let handlers : HttpFunc -> HttpContext -> HttpFuncResult =
        choose [
            GET >=> route "/games" >=>
                fun next context ->
                    let find = context.GetService<UserGamesFind>()
                    let userGames = find UserGameCriteria.All
                    json userGames next context
            
            POST >=> route "/games" >=>
                fun next context ->
                    task {
                        let save = context.GetService<UserGameSave>()
                        let! userGame = context.BindJsonAsync<UserGame>()
                        let userGame = { userGame with Id = ShortGuid.fromGuid(Guid.NewGuid()) }
                        return! json (save userGame) next context
                    }
            
            GET >=> routef "/games/%s" (fun id -> 
                fun next context ->
                    let find = context.GetService<UserGameFind>()
                    json (find id) next context
            )
            
            PUT >=> routef "/games/%s" (fun id -> 
                fun next context ->
                    task {
                        let save = context.GetService<UserGameSave>()
                        let! userGame = context.BindJsonAsync<UserGame>()
                        let userGame = { userGame with Id = id }
                        return! json (save userGame) next context
                    }
            )
            
            DELETE >=> routef "/games/%s" (fun id -> 
                fun next context ->
                    let delete = context.GetService<UserGameDelete>()
                    json (delete id) next context
            )
        ]