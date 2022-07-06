module App

open Api
open Fable.Remoting.Client
open Browser.Dom

let api =
    Remoting.createApi()
    |> Remoting.withRouteBuilder routeBuilder
    |> Remoting.withBinarySerialization
    |> Remoting.buildProxy<IApi>
    
async {
    let! result = api.Test()
    let str =
        match result with
        | Ok () -> "OK"
        | Error err -> $"Error: {err}"
    let el = document.getElementById "response"
    el.textContent <- str
} |> Async.StartImmediate
