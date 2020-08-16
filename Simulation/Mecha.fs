module Mecha

type ID = ID of System.Guid

type T = {
  id: ID
  position: Vector2D.T
  velocity: Vector2D.T
}

let Create initialPosition = {
  id = ID(System.Guid.NewGuid());
  position = initialPosition;
  velocity = { x = 0; y = 0 };
};

let Accelerate mecha newVelocity = {
  mecha with
    velocity = newVelocity
}

let Teleport mecha newPosition = {
  mecha with
    position = newPosition
}
