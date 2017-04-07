namespace MvcApp

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Owin
open Nancy.Owin

type Startup () =
    member __.Configure(app: IApplicationBuilder) =
        app.UseOwin(fun buildFunc -> buildFunc.UseNancy() |> ignore) |> ignore