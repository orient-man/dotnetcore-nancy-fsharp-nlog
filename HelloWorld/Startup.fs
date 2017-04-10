namespace MvcApp

open System.IO
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Owin
open Microsoft.Extensions.Configuration
open Nancy.Owin

type Startup () =
    let builder =
        ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)

    let configuration = builder.Build()

    do
        "ElasticSearch"
        |> configuration.GetConnectionString
        |> printfn "ElasticSearch: %s"

    member __.Configure(app: IApplicationBuilder) =
        app.UseOwin(fun buildFunc -> buildFunc.UseNancy() |> ignore) |> ignore