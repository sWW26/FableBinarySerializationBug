open Api
open Microsoft.AspNetCore.Builder
open Fable.Remoting.Server
open Fable.Remoting.Giraffe
open Giraffe

let api =
    { Test = fun () -> async { return Error "Test" } }
    
let apiHandler =
    Remoting.createApi()
    |> Remoting.withRouteBuilder routeBuilder
    |> Remoting.withBinarySerialization
    |> Remoting.fromValue api
    |> Remoting.buildHttpHandler
    
let builder = WebApplication.CreateBuilder()
builder.Services.AddGiraffe() |> ignore
let app = builder.Build()
app.UseGiraffe apiHandler
app.Run()

