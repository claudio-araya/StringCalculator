module Calculator

open System

let Add (numbers: string) : int =
    match numbers with
    | null | "" -> 0
    | _ ->
        let delimiters, numbersPart =
            if numbers.StartsWith("//") then
                let idx = numbers.IndexOf('\n')
                let delimiterPart = numbers.Substring(2, idx - 2)
                let numbersPart = numbers.Substring(idx + 1)

                let customDelims =
                    if delimiterPart.Contains("[") then
                        delimiterPart.Split([| '['; ']' |], StringSplitOptions.RemoveEmptyEntries)
                    else
                        [| delimiterPart |]

                (customDelims, numbersPart)
            else
                ([| ","; "\n" |], numbers)

        let numberStrings =
            numbersPart.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)

        let parsedNumbers = numberStrings |> Array.map int

        let negatives = parsedNumbers |> Array.filter (fun n -> n < 0)

        if negatives.Length > 0 then
            let message = negatives |> Array.map string |> String.concat ", "
            raise (Exception($"negatives not allowed: {message}"))
        else
            parsedNumbers
            |> Array.filter (fun n -> n <= 1000)
            |> Array.sum
