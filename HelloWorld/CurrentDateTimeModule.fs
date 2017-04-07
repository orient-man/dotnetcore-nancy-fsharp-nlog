namespace HelloWorld

open System
open Nancy
open NLog

type CurrentDateTimeModule () as this =
    inherit NancyModule ()

    static let logger = LogManager.GetCurrentClassLogger()

    do
        this.Get("/", fun _ ->
            "Getting current time..." |> logger.Info
            DateTime.UtcNow)