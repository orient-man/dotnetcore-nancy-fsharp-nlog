// include Fake lib
#r "packages/FAKE/tools/FakeLib.dll"
open Fake

Target "Restore" <| fun _ -> DotNetCli.Restore id

Target "Build" <| fun _ -> DotNetCli.Build id

Target "Test" <| fun _ ->
    !! "src/**/*Tests.fsproj"
    |> Seq.iter (fun proj ->
        DotNetCli.Test <| fun p -> { p with Project = proj })

Target "Publish" <| fun _ -> DotNetCli.Publish id

"Restore"
    ==> "Build"
    ==> "Test"
    ==> "Publish"

RunTargetOrDefault "Build"