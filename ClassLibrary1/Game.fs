namespace rec Simulation

type Vector2D = {
  x: int
  y: int
}

module Mecha =
  type ID = MechaID of System.Guid

  type State = {
    lastPosition: Vector2D
  }

  type Sample = {
    currentPosition: Vector2D
  }

  let GetSample (time: Game.Time) (state: Game.State) (id: ID) = {
    currentPosition = state.mechas.[id].lastPosition
  }

  let Update (state: State) (action: Actions.Action): State = 
    match action with
    | Actions.MoveMecha(action) -> { lastPosition = action.newPosition }
    | _ -> state

module Actions =
  type AddedMecha = {
    id: Mecha.ID
    time: Game.Time
    initialPosition: Vector2D
  }
  type MovedMecha = {
    id: Mecha.ID
    time: Game.Time
    newPosition: Vector2D
  }
  type Action =
    | AddMecha of AddedMecha
    | MoveMecha of MovedMecha

module Game =
  type Time = Time of uint

  type State = {
    mechas : Map<Mecha.ID, Mecha.State>
  }
  type Sample = {
    mechas : Map<Mecha.ID, Mecha.Sample>
  }

  let GetSample (time: Time) (state: State) =
    {
      mechas = Map.map (fun id _ -> Mecha.GetSample time state id) state.mechas
    }

  let Update (state: State) (action: Actions.Action): State =
    match action with
    | Actions.AddMecha(action) -> { mechas = state.mechas.Add(action.id, { lastPosition = action.initialPosition }) }
    | Actions.MoveMecha(action) -> { mechas = state.mechas.Add(action.id, Mecha.Update state.mechas.[action.id] (Actions.MoveMecha(action))) }
    | _ -> state

  let Create (): State = {
    mechas = Map.empty
  }

