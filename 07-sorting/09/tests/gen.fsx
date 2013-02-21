open System
open System.IO

// Random generator and utility random functions 
let gen = new Random(395891)
// Returns integer random variable from range [a..b] with uniform distribution
let rand a b = gen.Next(a, b + 1)

// This variable represents function that creates a new test file.
// The argument must be (StreamWriter -> unit) function that writes actual data to the stream.
let createTest =
  let id = ref 0
  let f02d = sprintf "%02d"
  let nextTest (callback : StreamWriter -> unit) =
    id := !id + 1
    let testName = Path.Combine(__SOURCE_DIRECTORY__, f02d !id)
    use testFile = File.CreateText(testName)
    callback testFile
  nextTest

let printTest (a : (int*int) []) (output : StreamWriter) =
  output.WriteLine(a.Length)
  Array.iter (fun (x, y) -> output.WriteLine(sprintf "%d %d" x y)) a

// Picks n random points from specified grid
let pickPoints n x1 x2 y1 y2 =
  let d = new Collections.Generic.HashSet<int*int>()
  let p = new ResizeArray<int*int>()
  for i = 0 to n - 1 do
    p.Add(rand x1 x2, rand y1 y2)
    while p.[i] = (0, 0) || d.Contains(p.[i]) do
      p.[i] <- (rand x1 x2, rand y1 y2)
    d.Add(p.[i]) |> ignore
  p.ToArray()

// Picks n random points (coordinates from -nc..nc) that are
// located on r random rays (coordinates from -rc..rc)
let rays r rc n nc =
  let rec gcd = function
  | (a, 0) -> a
  | (a, b) -> gcd(b, a % b)
  let a = new ResizeArray<int*int>()
  for x = -rc to rc do
    for y = -rc to rc do
      if gcd(abs x, abs y) = 1 then
        a.Add(x, y)
  for i in {0..a.Count - 1} do
    let j = rand 0 i
    let k = a.[i]
    a.[i] <- a.[j]
    a.[j] <- k
  let randPoint () =
    let x, y = a.[rand 0 (r - 1)]
    let k = rand 1 (nc / max (abs x) (abs y))
    x * k, y * k

  let d = new Collections.Generic.HashSet<int*int>()
  let p = new ResizeArray<int*int>()
  for i = 0 to n - 1 do
    p.Add(randPoint ())
    while p.[i] = (0, 0) || d.Contains(p.[i]) do
      p.[i] <- randPoint ()
    d.Add(p.[i]) |> ignore
  p.ToArray()

rays 1 3 10 1000 |> printTest |> createTest
rays 2 5 20 100 |> printTest |> createTest
rays 3 5 20 100 |> printTest |> createTest
rays 2 3 5000 10000 |> printTest |> createTest
rays 2 5 3000 10000 |> printTest |> createTest
rays 50 5 80000 10000 |> printTest |> createTest
pickPoints 5 -1 1 -1 1 |> printTest |> createTest
pickPoints 10 0 4 0 2 |> printTest |> createTest
pickPoints 10 -4 0 0 2 |> printTest |> createTest
pickPoints 10 -4 0 -2 0 |> printTest |> createTest
pickPoints 10 0 4 -2 0 |> printTest |> createTest
pickPoints 15 -2 2 -2 2 |> printTest |> createTest
pickPoints 20 -3 3 -3 3 |> printTest |> createTest
pickPoints 10 -3 3 -1 1 |> printTest |> createTest
pickPoints 10 -10 10 0 0 |> printTest |> createTest
pickPoints 10 0 0 -10 10 |> printTest |> createTest
pickPoints 50 -5 5 -5 5 |> printTest |> createTest
pickPoints 100000 -10000 10000 -10000 10000 |> printTest |> createTest
pickPoints 10000 -10000 10000 0 0 |> printTest |> createTest
pickPoints 100000 -10000 10000 -10 10 |> printTest |> createTest
pickPoints 35000 -100 100 -100 100 |> printTest |> createTest
