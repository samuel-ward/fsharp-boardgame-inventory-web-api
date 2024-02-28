namespace User.Games.Http

open Giraffe
open Microsoft.AspNetCore.Http

module UserGamesHttp =
    let handlers : HttpFunc -> HttpContext -> HttpFuncResult =
        choose [
            GET >=> route "/games" >=>
                fun next context ->
                    text "Read all" next context
            
            POST >=> route "/games" >=>
                fun next context ->
                    text "Create" next context
            
            GET >=> routef "/games/%s" (fun id -> 
                fun next context ->
                    text ("Read " + id) next context
            )
            
            PUT >=> routef "/games/%s" (fun id -> 
                fun next context ->
                    text ("Update " + id) next context
            )
            
            DELETE >=> routef "/games/%s" (fun id -> 
                fun next context ->
                    text ("Delete " + id) next context
            )
        ]