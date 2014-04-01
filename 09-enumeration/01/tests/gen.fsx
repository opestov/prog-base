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
// Custom methods that vary from problem to problem
// ------------------------------

let printTest testData stream =
  Print.print2 testData stream
    
let randomTest gen =
  let rec loop n (k : int) =
    if bigint.Pow(bigint k, n) < 10000I then (n, k)
    else loop (Random.nextAB gen 2 20) (Random.nextAB gen 2 20)
  loop 20 20

let g = Random.create 831261
let random = seq { for i = 1 to 25 do yield (randomTest g) } |> Seq.toList
let manual = [(1, 1); (1, 2); (2, 1); (10, 1); (20, 1); (2, 3); (3, 2); (4, 10); (10, 2)]

// We need to pass list of functions to the Print.writeTests method.
// Each function is defined as (StreamWriter -> unit) and writes data to the passed stream.
List.concat [manual; random]
|> List.map printTest
|> Print.writeTests

