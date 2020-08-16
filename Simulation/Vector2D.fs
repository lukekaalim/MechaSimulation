﻿module Vector2D

[<Struct>]
type T = {
  x: int
  y: int
}

let Add (a: T) (b: T) = {
  x = a.x + b.x;
  y = a.y + b.y;
}

let MultiplyScalar (a: T) (b: int) = {
  x = a.x * b;
  y = a.y * b;
}