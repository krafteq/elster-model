#r "paket:
nuget Fake.DotNet.Cli
nuget Fake.IO.FileSystem
nuget Fake.Core.Target //"
#load ".fake/build.fsx/intellisense.fsx"
open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators

let artifactsPath = Path.getFullName ".artifacts"
let publishPath = artifactsPath @@ "publish"
let appProjects = !! "src/app/**/*.*proj"
let testProjects = !! "src/test/**/*.*proj"

Target.create "Clean" (fun _ ->
  !! "src/**/bin"
  ++ "src/**/obj"
  ++ artifactsPath
  |> Shell.cleanDirs

  Directory.ensure(artifactsPath)
)

Target.create "Build" (fun _ ->
  appProjects
  |> Seq.iter (DotNet.build id)
)

Target.create "Test" (fun _ -> 
  testProjects
  |> Seq.iter (DotNet.test id)
)

Target.create "Pack" (fun _ ->
  Directory.ensure publishPath

  appProjects
  |> Seq.iter (DotNet.pack (fun opt -> 
    { opt with 
        OutputPath = Some publishPath
    } 
  ))
)

Target.create "Publish" (fun _ ->
  !! (publishPath @@ "*.nupkg")
  |> Seq.iter (DotNet.nugetPush (fun opt -> 
    opt.WithPushParams(
      { opt.PushParams with 
          ApiKey = Some (Environment.environVarOrFail "NUGET_KRAFTEQ_API_KEY")
          Source = Some "https://api.nuget.org/v3/index.json"
      })
  ))
)

Target.create "All" ignore

"Clean"
  ==> "Build"
  ==> "All"

"Clean"
  ==> "Test"
  ==> "All"

"Clean"
  ==> "Pack"
  ==> "Publish"

Target.runOrDefault "All"