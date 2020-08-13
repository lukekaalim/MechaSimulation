module State

type Mecha = {
  id : System.Guid
}

type Game = {
  mechas : Map<System.Guid, Mecha>
}