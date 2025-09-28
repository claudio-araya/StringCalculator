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


// Task 6: Ignoring Giants

[<Theory>]
[<InlineData("2,1001", 2)>]             
[<InlineData("1000,5,2000", 1005)>]      
[<InlineData("999,1000,1001", 1999)>]     
[<InlineData("//;\n2;1001;3", 5)>]         
let ``Task6_Add ignores numbers greater than 1000`` (input: string, expected: int) =
    Assert.Equal(expected, Add input)


// Task 7: Flexible Delimiters

[<Theory>]
[<InlineData("//[***]\n1***2***3", 6)>]
[<InlineData("//[###]\n10###20###30", 60)>]
[<InlineData("//[--]\n5--10--1001", 15)>]  // ignores 1001
let ``Task7_Add supports delimiters of any length`` (input: string, expected: int) =
    Assert.Equal(expected, Add input)

[<Fact>]
let ``Task7_Add throws exception for negatives with flexible delimiter`` () =
    let ex = Assert.Throws<Exception>(fun () -> Add "//[***]\n1***-2***3" |> ignore)
    Assert.Equal("negatives not allowed: -2", ex.Message)


// Task 8: Multiple Delimiters


[<Theory>]
[<InlineData("//[*][%]\n1*2%3", 6)>]
[<InlineData("//[;][#][!]\n4;5#6!7", 22)>]       
[<InlineData("//[&][?]\n2&1001?3", 5)>]              
let ``Task8_Add supports multiple delimiters`` (input: string, expected: int) =
    Assert.Equal(expected, Add input)

[<Fact>]
let ``Task8_Add throws exception for negatives with multiple delimiters`` () =
    let ex = Assert.Throws<Exception>(fun () -> Add "//[@][!]\n7@-8!9" |> ignore)
    Assert.Equal("negatives not allowed: -8", ex.Message)


// Task 9: Complex Delimiters

[<Theory>]
[<InlineData("//[***][%%]\n1***2%%3", 6)>]
[<InlineData("//[&&][###][!!]\n5&&10###15!!20", 50)>]
[<InlineData("//[abc][defg]\n7abc8defg9", 24)>]
let ``Task9_Add supports multiple long delimiters`` (input: string, expected: int) =
    Assert.Equal(expected, Add input)

[<Fact>]
let ``Task9_Add throws exception for negatives with long delimiters`` () =
    let ex = Assert.Throws<Exception>(fun () -> Add "//[***][%%]\n1***-2%%3" |> ignore)
    Assert.Equal("negatives not allowed: -2", ex.Message)
