// ------------------------------
// Test generator
// ------------------------------

module Random =
  open System

  let create seed = new Random(seed)
  let nextInt (gen : Random) n = gen.Next(0, n)
  let nextAB (gen : Random) a b = gen.Next(a, b + 1)
  let nextGaussian (gen : Random) =
    let u1 = gen.NextDouble()
    let u2 = gen.NextDouble()
    Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2)

module Print =
  open System
  open System.IO

  let print1 x (stream : StreamWriter) =
    stream.WriteLine(string x)
  let print2 (x, y) (stream : StreamWriter) =
    stream.WriteLine(string x + " " + string y)
  
  let printAdapter f (tid : int) =
    use file = File.CreateText(Path.Combine(__SOURCE_DIRECTORY__, String.Format("{0:00}", tid)))
    f file
    tid + 1
  
  let writeTests tests =
    (tests |> List.map (printAdapter) |> List.reduce (>>)) 1

// ------------------------------
// Custom methods that varies from problem to problem
// ------------------------------

let printTest testData stream =
  Print.print1 testData stream
    
let randomTest gen =
  let n = Random.nextAB gen 1 100
  let a = Array.create n 0
  // element to be decreased
  let i = Random.nextAB gen 0 (n - 2)
  a.[i] <- Random.nextAB gen 1 9  
  // before
  a.[0] <- Random.nextAB gen 1 9
  for z = 1 to i - 1 do
    a.[z] <- Random.nextAB gen 0 9
  // after
  let c = Array.create 10 0
  let m = n - i - 1
  for z = 1 to m do
    let x = if z = 1 then Random.nextAB gen 0 (a.[i] - 1) else Random.nextAB gen 0 9
    c.[x] <- c.[x] + 1
  let mutable j = i + 1
  for z = 0 to 9 do
    while c.[z] > 0 do
      a.[j] <- z
      j <- j + 1
      c.[z] <- c.[z] - 1
  //
  new System.String(a |> Array.map (fun i -> char (i + int '0')))

let g = Random.create 723425
let random = seq { for i = 1 to 25 do yield (randomTest g) } |> Seq.toList
let manual = ["1010101"; "1"; "10"; "11"; "9823"; "300022277777899999"; "300077777899999"]

// We need to pass list of functions to the Print.writeTests method.
// Each function is defined as (StreamWriter -> unit) and writes data to the passed stream.
List.concat [manual; random]
|> List.map printTest
|> Print.writeTests

