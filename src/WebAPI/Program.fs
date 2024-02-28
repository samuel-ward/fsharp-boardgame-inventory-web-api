open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection

open Giraffe
open User.Games.Http

let routes =
    choose [
        UserGamesHttp.handlers
    ]

let configureApp (app: IApplicationBuilder) =
    app.UseGiraffe routes

let configureServices (services: IServiceCollection) =
    services.AddGiraffe () |> ignore

// ------------------
// Create another entry point specific for lambda executions
// ------------------


// ------------------
// This entry point is for local development
// ------------------
[<EntryPoint>]
let main _ =
    WebHostBuilder()
        .UseKestrel()
        .Configure(Action<IApplicationBuilder> configureApp)
        .ConfigureServices(configureServices)
        .Build()
        .Run()
    0
