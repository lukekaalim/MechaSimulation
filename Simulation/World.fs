module World

type T = {
  time: int
  mechas: Map<Mecha.ID, Mecha.T>
}

let Create () = {
  time = 0;
  mechas = Map.empty
}

let SimulateMecha (world: T) (timeDelta: int) (mechaId: Mecha.ID) (mecha: Mecha.T) = {
  mecha with
    position = Vector2D.Add mecha.position (Vector2D.MultiplyScalar mecha.velocity timeDelta)
}

let Simulate world timeDelta =
  {
    time = world.time + timeDelta
    mechas = Map.map (SimulateMecha world timeDelta) world.mechas
  }

let Dispatch world action =
  match action with
    | Actions.SpawnMecha(action) -> { world with mechas = world.mechas.Add(action.mecha.id, action.mecha) }
    | Actions.DriveMecha(action) -> { world with mechas = world.mechas.Add(action.id, { world.mechas.[action.id] with velocity = action.velocity }) }
    | _ -> world