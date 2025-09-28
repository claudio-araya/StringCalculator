open System
open StringCalculator

[<EntryPoint>]
let main argv =

    let result = Calculator.Add "//[***][%%]\n2***2%%3"

    printfn "Result: %d" result

    // Validation is done through xUnit tests in the tests folder.

    0