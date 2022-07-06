module Api

let routeBuilder x y =
    sprintf "/api/%s/%s" x y
    
type IApi =
    { Test: unit -> Async<Result<unit, string>> }

