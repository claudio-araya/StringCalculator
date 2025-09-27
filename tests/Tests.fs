module Tests

open Xunit
open Calculator

[<Theory>]
[<InlineData("", 0)>]
[<InlineData("4", 4)>]
[<InlineData("1,2", 3)>]
[<InlineData("1\n2,3", 6)>]
[<InlineData("2\n3\n5,", 10)>]
let ``Add supports commas and newlines`` (input: string, expected: int) =
    Assert.Equal(expected, Add input)

