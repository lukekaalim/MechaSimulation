module Trig

let Precision = 16
let SemiLength = Precision / 2
let QuadrentLength = SemiLength / 2

// As thousandths
let SineLookupArray =
  [|
    0
    382
    707
    923
  |]
  
let MapToLookupSineArray x = SineLookupArray.[x]

let MapToSineRange x = x % Precision
let MapToQuadrantSpace x = x % QuadrentLength
let MapToSemiSpace x = x % SemiLength

// Map it to quadrant space ()
let MapToInvertedQuadrant x = (-1 * (MapToQuadrantSpace x)) + QuadrentLength

let Negate x = -x

let MapToSineQuadrant x =
  match abs (x / QuadrentLength) with
    | 0 -> x |> MapToLookupSineArray
    | 1 -> x |> MapToInvertedQuadrant |> MapToLookupSineArray
    | 2 -> x |> MapToSemiSpace |> MapToLookupSineArray |> Negate
    | 3 -> x |> MapToSemiSpace |> MapToInvertedQuadrant |> MapToLookupSineArray |> Negate

let Sine x = x |> MapToSineRange |> MapToSineQuadrant
let Cos x = (x + QuadrentLength) |> MapToSineRange |> MapToSineQuadrant
    