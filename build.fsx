// include Fake lib
#r "packages/FAKE/tools/FakeLib.dll"
open Fake

let configuration = getBuildParamOrDefault "Configuration" "Debug"
let output = getBuildParamOrDefault "Output" ""

Target "Restore" <| fun _ -> DotNetCli.Restore id

Target "Build" <| fun _ ->
    DotNetCli.Build <| fun p -> { p with Configuration = configuration }

Target "Test" <| fun _ ->
    !! "src/**/*Tests.fsproj"
    |> Seq.iter (fun proj ->
        DotNetCli.Test <| fun p ->
            { p with
                Configuration = configuration
                Project = proj })

Target "Publish" <| fun _ ->
    DotNetCli.Publish <| fun p ->
        { p with
            Configuration = configuration
            Output = output }

"Restore"
    ==> "Build"
    ==> "Test"
    ==> "Publish"

RunTargetOrDefault "Build"