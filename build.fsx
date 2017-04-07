// include Fake lib
#r "packages/FAKE/tools/FakeLib.dll"
open Fake

Target "Restore" (fun _ ->
    !! "*/*.fsproj"
    |> Seq.iter(fun proj -> DotNetCli.Restore (fun p -> { p with Project = proj })))

Target "Build" (fun _ ->
    !! "*/*.fsproj"
    |> Seq.iter(fun proj -> DotNetCli.Build (fun p -> { p with Project = proj; Configuration = "Debug" })))

RunTargetOrDefault "Build"