open Data
open Input

let getWinningShape shape =
    match shape with
    | Rock -> Paper
    | Paper -> Scissors
    | Scissors -> Rock

let getLosingShape shape =
    match shape with
    | Rock -> Scissors
    | Paper -> Rock
    | Scissors -> Paper

let playWithShape game =
    let opponent, you = game
    match you with
    | _ when (getWinningShape opponent) = you -> game, Win
    | _ when you = opponent -> game, Draw
    | _ -> game, Loss
       
let playWithOutcome game =
    match game with
    | opponent, Win -> (opponent, getWinningShape opponent), Win
    | opponent, Loss -> (opponent, getLosingShape opponent), Loss
    | opponent, Draw -> (opponent, opponent), Draw

let scoreShape shape =
    match shape with
    | Rock -> 1
    | Paper -> 2
    | Scissors -> 3

let scoreOutcome outcome =
    match outcome with
    | Win -> 6
    | Draw -> 3
    | Loss -> 0

let score playedGame =
    let (_, you), outcome = playedGame
    scoreShape you + scoreOutcome outcome

let totalScore =
    gameStream
    |> Seq.map (fun (game, hypothetical) -> playWithShape game, playWithOutcome hypothetical)
    |> Seq.map (fun (game, hypothetical) -> score game, score hypothetical)
    |> Seq.reduce (fun (sumGames, sumHypothetical) (nextGame, nextHypothetical) ->
        (sumGames + nextGame, sumHypothetical + nextHypothetical)
    )
    
printfn "%i %i" (fst totalScore) (snd totalScore)