module Tests

open Xunit
open Calculator

[<Theory>]
[<InlineData("", 0)>]
[<InlineData("5", 5)>]
[<InlineData("4,5", 9)>]
let ``Add returns correct result for valid inputs`` (input: string, expected: int) =
    Assert.Equal(expected, Add input)

[<Fact>]
let ``Add throws exception with correct message`` () =
    let ex = Assert.Throws<System.Exception>(fun () -> Add "1,2,3" |> ignore)
    Assert.Equal("Two numbers are allowed in Task 1", ex.Message)