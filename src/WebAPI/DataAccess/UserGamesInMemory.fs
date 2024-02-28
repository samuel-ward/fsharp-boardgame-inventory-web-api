module User.Games.UserGamesInMemory

open Microsoft.Extensions.DependencyInjection
open System
open System.Collections

open User.Games

let find (inMemory: Hashtable) (criteria: UserGameCriteria) : UserGame[] =
    match criteria with
    | All -> inMemory.Values |> Seq.cast |> Array.ofSeq

let findSingle (inMemory: Hashtable) (id: string) : UserGame option =
    inMemory.Values |> Seq.cast |> Array.ofSeq |> Array.tryFind(fun x -> x.Id = id)

let save (inMemory: Hashtable) (userGame: UserGame) : UserGame =
    let userGameOpt = inMemory.Values |> Seq.cast |> Array.ofSeq |> Array.tryFind(fun x -> x.Id = userGame.Id)

    match userGameOpt with
    | None -> inMemory.Add(userGame.Id, userGame) |> ignore
    | Some oldUserGame -> 
        inMemory.Remove(oldUserGame.Id)
        inMemory.Add(userGame.Id, userGame) |> ignore
    
    userGame

let delete (inMemory: Hashtable) (id: string) : bool =
    // TODO: Add some error handling here
    let count = inMemory.Count
    inMemory.Remove(id)
    inMemory.Count < count

type IServiceCollection with
    member this.AddUserGamesInMemory (inMemory: Hashtable) =
        this.AddSingleton<UserGamesFind>(find inMemory) |> ignore
        this.AddSingleton<UserGameSave>(save inMemory) |> ignore
        this.AddSingleton<UserGameFind>(findSingle inMemory) |> ignore
        this.AddSingleton<UserGameDelete>(delete inMemory) |> ignore