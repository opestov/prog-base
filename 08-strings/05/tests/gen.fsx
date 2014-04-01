open System
open System.IO

// Random generator and utility random functions 
let gen = new Random(85341)
// Returns integer random variable from range [a..b] with uniform distribution
let rand a b = gen.Next(a, b + 1)
let randomLetter () = char (rand (int 'a') (int 'z'))
let randomWord len = Array.init len (fun i -> randomLetter ())

// This variable represents function that creates a new test file.
// The argument must be (StreamWriter -> unit) function that writes actual data to the stream.
let create_test =
  let id = ref 0
  let f02d = sprintf "%02d"
  let next_test (callback : StreamWriter -> unit) =
    id := !id + 1
    let test_name = Path.Combine(__SOURCE_DIRECTORY__, f02d !id)
    use test_file = File.CreateText(test_name)
    callback test_file
  next_test

// Shuffle the passed array (in-place)
let shuffle (a : char []) =
  for i in {0..a.Length - 1} do
    let j = rand 0 i
    let k = a.[i]
    a.[i] <- a.[j]
    a.[j] <- k
  a

// Writes char to the given stream
let print_test (s : string) (t : string) (output : StreamWriter) =
  output.WriteLine(s)
  output.WriteLine(t)

let yesTest len =
  let a = randomWord len
  let s = new String(a)
  shuffle a |> ignore
  let t = new String(a)
  print_test s t |> create_test

let no1Test len =
  let a = randomWord len
  let s = new String(a)
  let b = a |> Array.map (fun c -> if rand 0 99 < 5 then randomLetter () else c)
  shuffle b |> ignore
  let t = new String(b)
  print_test s t |> create_test

let no2Test len =
  let a = randomWord len
  let s = new String(a)
  let b = 
    a
    |> Array.map (fun c ->
      let z = rand 0 99
      if z < 5 then [||] else if z < 10 then [|randomLetter()|] else if z < 15 then [|c; randomLetter() |] else [|c|])
    |> Array.concat
  shuffle b |> ignore
  let t = new String(b)
  print_test s t |> create_test


[1; 2; 3; 5; 8; 13; 21; 34; 55; 89; 144; 233]
|> List.iter (fun i -> yesTest i)

[8; 9; 10; 11; 12; 13; 14; 15; 21; 100; 255]
|> List.iter (fun i -> no1Test i)

[10; 12; 14; 100; 250]
|> List.iter (fun i -> no2Test i)
