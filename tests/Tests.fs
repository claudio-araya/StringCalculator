module Tests

open Xunit
open Calculator

[<Theory>]
[<InlineData("", 0)>]
[<InlineData("5", 5)>]
[<InlineData("1,2", 3)>]
[<InlineData("1\n2,3", 6)>]
[<InlineData("//;\n1;2", 3)>]
[<InlineData("//|\n3|4|5", 12)>]
let ``Add supports default and custom delimiters`` (input: string, expected: int) =
    Assert.Equal(expected, Add input)

