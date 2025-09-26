module Tests

open Xunit
open Calculator

[<Theory>]
[<InlineData("", 0)>]
[<InlineData(null, 0)>]
[<InlineData("5", 5)>]
[<InlineData("4,5", 9)>]
[<InlineData("1,2,3", 6)>]
[<InlineData("10,20,30,40", 100)>]
[<InlineData("1,2,3,4,5,6,7,8,9,10", 55)>]
let ``Add returns correct result for valid inputs`` (input: string, expected: int) =
    Assert.Equal(expected, Add input)
