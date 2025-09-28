namespace StringCalculator

open System

type Calculator() =

    static member private ParseDelimitersAndNumbers(input: string) =
        if input.StartsWith("//") then
            let idx = input.IndexOf('\n')
            let delimiterPart = input.Substring(2, idx - 2)
            let numbersPart = input.Substring(idx + 1)

            let customDelims =
                if delimiterPart.Contains("[") then
                    delimiterPart.Split([| '['; ']' |], StringSplitOptions.RemoveEmptyEntries)
                else
                    [| delimiterPart |]

            (customDelims, numbersPart)
        else
            ([| ","; "\n" |], input)

    static member private ParseNumbers(input: string, delimiters: string[]) =
        input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
        |> Array.map int

    static member private ValidateNegatives(numbers: int[]) =
        let negatives = numbers |> Array.filter (fun n -> n < 0)
        if negatives.Length > 0 then
            let message = negatives |> Array.map string |> String.concat ", "
            raise (Exception($"negatives not allowed: {message}"))

    static member Add(numbers: string) : int =
        match numbers with
        | null | "" -> 0
        | _ ->
            let delimiters, numbersPart = Calculator.ParseDelimitersAndNumbers(numbers)
            let parsedNumbers = Calculator.ParseNumbers(numbersPart, delimiters)
            Calculator.ValidateNegatives(parsedNumbers)
            parsedNumbers
            |> Array.filter (fun n -> n <= 1000)
            |> Array.sum
