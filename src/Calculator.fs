module Calculator

open System

let Add (numbers: string) : int =
    match numbers with
    | null | "" -> 0
    | _ ->
        let delimiter, numPart =
            if numbers.StartsWith("//") then
                let parts = numbers.Split('\n')
                let delim = parts.[0].Substring(2)
                (delim, parts.[1])
            else
                (",", numbers.Replace("\n", ","))

        let numberStrings = numPart.Split([| delimiter |], StringSplitOptions.RemoveEmptyEntries)
        let parsedNumbers = numberStrings |> Array.map int

        let negatives = parsedNumbers |> Array.filter (fun n -> n < 0)

        if negatives.Length > 0 then
            let message = negatives |> Array.map string |> String.concat ", "
            raise (Exception($"negatives not allowed: {message}"))
        else
            parsedNumbers |> Array.sum
