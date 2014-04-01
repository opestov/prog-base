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
    
let manual = seq { for i = 1 to 10 do yield i } |> Seq.toList

// We need to pass list of functions to the Print.writeTests method.
// Each function is defined as (StreamWriter -> unit) and writes data to the passed stream.
manual
|> List.map printTest
|> Print.writeTests

