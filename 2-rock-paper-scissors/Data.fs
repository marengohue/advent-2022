module Data

type Shape =
| Rock
| Paper
| Scissors
    
type Outcome =
| Win
| Loss
| Draw
    
type Game = Shape * Shape
type GameWithOutcome = Shape * Outcome
type PlayedGame = Game * Outcome