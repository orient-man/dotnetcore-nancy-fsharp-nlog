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

Target "Zip" <| fun _ ->
    let outputZip = sprintf "%s/Package.zip" output
    [ "", { !! (sprintf "%s/**" output) with BaseDirectory = output; Excludes = [ outputZip ] } ]
    |> ZipOfIncludes outputZip

"Restore"
    ==> "Build"
    ==> "Test"
    ==> "Publish"
    ==> "Zip"

RunTargetOrDefault "Build"