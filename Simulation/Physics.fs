module Physics

type Particle2D = {
    initialPosition: Vector2D.T;
    velocity: Vector2D.T;
    radius: int;
  }

type Particle1D = {
  position: int;
  velocity: int;
  radius: int;
}

type Particle =
  | Particle1D of {| position: int; velocity: int; radius: int |}

type Collision1DResult =
  | Miss
  | Hit of entry: int * exit: int

let GetCollision1D particleA particleB =
  let offset = particleA.position - particleB.position
  let velocity = particleA.velocity - particleB.velocity
  let collisonDistance = particleA.radius + particleB.radius
  match velocity with
    | 0 -> Miss
    | _ -> Hit(entry = (offset - collisonDistance) / velocity, exit = (offset + collisonDistance) / velocity)
