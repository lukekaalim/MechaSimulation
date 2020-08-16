module Actions
  type SpawnMecha = {
    time: int;
    mecha: Mecha.T;
  }
  type DriveMecha = {
    time: int;
    id: Mecha.ID;
    velocity: Vector2D.T;
  }

  type T =
    | SpawnMecha of SpawnMecha
    | DriveMecha of DriveMecha
    
  let SpawnMecha (time, mecha) = SpawnMecha({ time = time; mecha = mecha })
  let DriveMecha (time, id, velocity) = DriveMecha({ time = time; id = id; velocity = velocity })