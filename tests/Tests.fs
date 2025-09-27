module Tests

open Xunit
open System
open Calculator

// Task 1: Simple Summation

[<Theory>]
[<InlineData("", 0)>]
[<InlineData("4", 4)>]
[<InlineData("1,2", 3)>]
let ``Task1_Add supports up to two numbers`` (input: string, expected: int) =
    Assert.Equal(expected, Add input)


// Task 2: Infinite Arithmetic

[<Theory>]
[<InlineData("1,2,3,4", 10)>]
[<InlineData("5,10,15", 30)>]
let ``Task2_Add supports multiple numbers`` (input: string, expected: int) =
    Assert.Equal(expected, Add input)


// Task 3: Breaking Newlines

[<Theory>]
[<InlineData("1\n2,3", 6)>]
[<InlineData("2\n3\n5,", 10)>]
let ``Task3_Add supports newlines as delimiters`` (input: string, expected: int) =
    Assert.Equal(expected, Add input)


// Task 4: Custom Delimiters

[<Theory>]
[<InlineData("//;\n1;2", 3)>]
[<InlineData("//|\n2|3|4", 9)>]
let ``Task4_Add supports custom delimiters`` (input: string, expected: int) =
    Assert.Equal(expected, Add input)


// Task 5: Negative Rebellion

[<Theory>]
[<InlineData("1,-2", "negatives not allowed: -2")>]
[<InlineData("1\n-2,3", "negatives not allowed: -2")>]
[<InlineData("//;\n1;-2;3", "negatives not allowed: -2")>]
[<InlineData("1,-2,-3,4", "negatives not allowed: -2, -3")>]
let ``Task5_Add throws exception for negatives with correct message`` (input: string, expectedMessage: string) =
    let ex = Assert.Throws<Exception>(fun () -> Add input |> ignore)
    Assert.Equal(expectedMessage, ex.Message)
