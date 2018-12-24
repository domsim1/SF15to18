open System

let convertToInt32 (x: string) = Convert.ToInt32 (x, 2)

let lookupIndex (index: int) = "ABCDEFGHIJKLMNOPQRSTUVWXYZ012345".[index]

let convertID (id: string) =
  let convertChunk (chunk: string) =
    chunk 
    |> Seq.rev
    |> Seq.map (fun x -> if Char.IsUpper x then "1" else "0")
    |> String.Concat
    |> convertToInt32
    |> lookupIndex
  [0..2]
  |> List.map (fun x -> id.[(x*5)..((x*5)+4)] |> convertChunk)
  |> String.Concat
  |> fun x -> id + x

[<EntryPoint>]
let main argv =
  if argv.Length > 0 && argv.[0].Length = 15
    then convertID argv.[0] 
    else "Please enter an ID of 15 chars"
  |> printfn "%s"
  0
