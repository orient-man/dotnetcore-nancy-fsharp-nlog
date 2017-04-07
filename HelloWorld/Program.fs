namespace MvcApp

open System
open System.Collections.Generic
open System.IO
open System.Threading.Tasks
open Microsoft.AspNetCore.Hosting
open NLog

module Program =
    let logger = LogManager.GetLogger("Program")

    [<EntryPoint>]
    let main args =
        let host =
            WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build()

        "Service starting..." |> logger.Info
        host.Run()
        0