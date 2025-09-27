open System
open Calculator

[<EntryPoint>]
let main argv =

    printfn "%d" (Add "1,2,2,3\n,,2")

    // Validation is done through xUnit tests in the tests folder.

    0
