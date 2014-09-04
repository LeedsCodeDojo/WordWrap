module wrapper_tests

open WordWrap
open Xunit
open FsUnit.Xunit

[<Fact>]
let ``text less than length returns unmodified text`` () =
    wrap "hello" 10 |> should equal "hello"

[<Fact>]
let ``word slightly longer that length get wrapped`` () =
    wrap "hello" 3 |> should equal "hel\nlo"

[<Fact>]
let ``word much longer that length get wrapped onto multiple lines`` () =
    wrap "hellomum" 3 |> should equal "hel\nlom\num"

[<Fact>]
let ``text slightly longer than length with a space wraps on the space and removes it`` () =
    wrap "hello mum" 7 |> should equal "hello\nmum"

[<Fact>]
let ``text slightly longer than length with multiple spaces wraps on the last space and removes it`` () =
    wrap "hello there mum" 13 |> should equal "hello there\nmum"

[<Fact>]
let ``text with a space just before the break gets the space removed when wrapped`` () =
    wrap "hello mum" 6 |> should equal "hello\nmum"

[<Fact>]
let ``text with a space just after the break gets the space removed when wrapped`` () =
    wrap "hello mum" 5 |> should equal "hello\nmum"

[<Fact>]
let ``text much longer than length with multiple spaces wraps onto several lines`` () =
    wrap "hello there mum, how are you doing today?" 15 |> should equal "hello there\nmum, how are\nyou doing\ntoday?"

[<Fact>]
let ``text with spaces and long words wraps correctly`` () =
    wrap "a few short words and some verylongwordsindeed wraps well" 15 |> should equal "a few short\nwords and some\nverylongwordsin\ndeed wraps well"