module Calculator

open System

let Add (numbers: string) : int =
    match numbers with
    | null -> 0
    | "" -> 0
    | _ ->
        numbers.Split([|','; '\n'|], StringSplitOptions.RemoveEmptyEntries)
        |> Array.map Int32.Parse
        |> Array.sum
