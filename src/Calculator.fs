module Calculator

open System

let Add (numbers: string) : int =
    match numbers with
    | null -> 0
    | "" -> 0
    | _ ->
        let parts = numbers.Split(',')
        match parts with
        | [| x |] -> int x
        | [| x; y |] -> int x + int y
        | _ -> failwith "Two numbers are allowed in Task 1"
