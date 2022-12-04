module Input
open System
open Data
let stdinStream =
    Seq.initInfinite (fun _ -> Console.ReadLine())
    |> Seq.takeWhile ((<>) null) 

let mapShape shape =
    match shape with
    | "A" -> Rock
    | "X" -> Rock
    | "B" -> Paper
    | "Y" -> Paper
    | "C" -> Scissors
    | "Z" -> Scissors
    | _ -> raise (FormatException("Cant parse shape"))

let mapOutcome outcome =
    match outcome with
    | "X" -> Loss
    | "Y" -> Draw
    | "Z" -> Win
    | _ -> raise (FormatException("Cant parse outcome"))

let gameStream =
    stdinStream
    |> Seq.map (fun stringGame ->
        match stringGame.Split " " with
        | [| opponent; you |] -> Some ((mapShape opponent, mapShape you), (mapShape opponent, mapOutcome you))
        | _ -> None
    )
    |> Seq.choose id
        
        
