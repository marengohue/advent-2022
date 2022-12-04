open System
open Microsoft.FSharp.Collections
open Microsoft.FSharp.Core

type Elf = int array

let stdinStream =
    Seq.initInfinite (fun _ -> Console.ReadLine())
    |> Seq.takeWhile ((<>) null) 

let elfStream : Elf option seq = Seq.initInfinite (fun _ ->
    let nextElf =
        stdinStream
        |> Seq.takeWhile (String.IsNullOrEmpty >> not)
        |> Seq.map int
        |> Seq.toArray
    
    match nextElf with
    | [| |] -> None
    | _ -> Some nextElf
)

let allElves =
    elfStream
    |> Seq.takeWhile Option.isSome
    |> Seq.map Option.get
    |> Seq.toArray

let fattestElves =
    allElves
    |> Array.map Array.sum
    |> Array.sortDescending
    |> Array.take 3

printf "%i, %i" (fattestElves[0]) (Array.sum fattestElves)