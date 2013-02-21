// Generator of arrays that can be used to test sort algorithms.
// Please change the following constants appropriately before running the script.

let ARRAY_SIZE = 10000
let VALUE_BOUND = 1000000

// You can view tests with visualizer. Set array size to 700 and
// value bound to 1000. Then run script and type 'vis XY' where XY is a test number.

open System
open System.IO

// Random generator and utility random functions 
let gen = new Random(9812573)
// Returns integer random variable from range [a..b] with uniform distribution
let rand a b = gen.Next(a, b + 1)
// Returns float random variable with distribution N(0, 1)
let rand_normal () =
  let u1 = gen.NextDouble()
  let u2 = gen.NextDouble()
  System.Math.Sqrt(-2.0 * System.Math.Log(u1)) * System.Math.Sin(2.0 * System.Math.PI * u2)

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

// Writes array to the given stream
let print_test (a : int []) (output : StreamWriter) =
  output.WriteLine(a.Length)
  Array.iteri (fun i x ->
    if i > 0 then output.Write(" ")
    output.Write(string(x))) a
  output.WriteLine()

// Shuffle the passed array (in-place)
let shuffle (a : int []) =
  for i in {0..a.Length - 1} do
    let j = rand 0 i
    let k = a.[i]
    a.[i] <- a.[j]
    a.[j] <- k
  a

// Sorts array in ascending order (in-place)
let sort_asc (a : int []) =
  Array.sortInPlace a;
  a

// Sorts array in descending order (in-place)
let sort_desc (a : int []) = 
  Array.sortInPlaceBy (fun x -> -x - 1) a
  a

let next_int () = rand -VALUE_BOUND VALUE_BOUND
let next_normal_int () = max -VALUE_BOUND (min VALUE_BOUND (int(rand_normal() * double(VALUE_BOUND) / 4.0)))
let random_init x = next_int ()
let gen_rand n = Array.init n random_init
let gen_asc n = gen_rand n |> sort_asc
let gen_desc n = gen_rand n |> sort_desc


// 01..03
// random shuffle/sorted in ascending order/sorted in descending order
Console.Write("random shuffle/sorted in ascending order/sorted in descending order...")
gen_rand ARRAY_SIZE |> print_test |> create_test
gen_asc ARRAY_SIZE |> sort_asc |> print_test |> create_test
gen_desc ARRAY_SIZE |> sort_desc |> print_test |> create_test
Console.WriteLine("ok")


// 04..13
// group of tests with small number of unique elements
Console.Write("group of tests with small number of unique elements...")
let unique (a : int []) n = Array.init n (fun i -> a.[rand 0 (a.Length - 1)])
let unique_asc (a : int []) n = unique a n |> sort_asc
let unique_desc (a : int []) n = unique a n |> sort_desc
unique [|next_int ()|] ARRAY_SIZE |> print_test |> create_test
seq [2; 5; 20] |> Seq.iter (fun i ->
  unique (gen_rand i) ARRAY_SIZE |> print_test |> create_test
  unique_asc (gen_rand i) ARRAY_SIZE |> print_test |> create_test
  unique_desc (gen_rand i) ARRAY_SIZE |> print_test |> create_test)
Console.WriteLine("ok")


// group of chainsaw tests
Console.Write("group of chainsaw tests...")
let chainsaw give_me_a give_me_b saw_size =
  seq [for i in {1..ARRAY_SIZE / saw_size} do yield (if i % 2 = 0 then give_me_a else give_me_b) saw_size] |> Array.concat
// 14..17
// chainsaw of sorted parts
chainsaw gen_asc gen_asc 5 |> print_test |> create_test
chainsaw gen_asc gen_desc 25 |> print_test |> create_test
chainsaw gen_desc gen_asc 125 |> print_test |> create_test
chainsaw gen_desc gen_desc 625 |> print_test |> create_test
// 18..29
// each part is an array of few unique elements (elements from different parts are the same)
seq [2; 5; 20] |> Seq.iter (fun i ->
  let u = gen_rand i in chainsaw (unique_asc u) (unique_asc u) 5 |> print_test |> create_test
  let u = gen_rand i in chainsaw (unique_asc u) (unique_desc u) 25 |> print_test |> create_test
  let u = gen_rand i in chainsaw (unique_desc u) (unique_asc u) 125 |> print_test |> create_test
  let u = gen_rand i in chainsaw (unique_desc u) (unique_desc u) 625 |> print_test |> create_test)
Console.WriteLine("ok")


// 30..33
// k-sorted arrays
Console.Write("k-sorted arrays...")
let k_sorted k (a : int []) =
  let n = a.Length
  let graph = Array.init n (fun i -> seq {max 0 (i - k)..min (n - 1) (i + k)} |> Seq.toArray |> shuffle)  
  let m = Array.create n -1
  let t = Array.create n -1
  // strange way to find augmentign path in bipartite graph (using tail recursion)
  let step time =
    let rec dfs u i cont =
      if i = graph.[u].Length then cont false
      else
        let y = graph.[u].[i]
        if m.[y] = -1 then
          m.[y] <- u
          cont true
        else
          let x = m.[y]
          if t.[x] = time then dfs u (i + 1) cont
          else
            t.[x] <- time
            dfs m.[y] 0 (fun res ->
              if res then
                m.[y] <- u
                cont true
              else dfs u (i + 1) cont)
    t.[time] <- time
    dfs time 0 (fun x -> x)    
  for i in {0..n - 1} do
    step i |> ignore
  Array.init n (fun i -> a.[m.[i]])    
seq [10; 250] |> Seq.iter (fun i -> gen_asc ARRAY_SIZE |> k_sorted i |> print_test |> create_test)
seq [50; 1250] |> Seq.iter (fun i -> gen_desc ARRAY_SIZE |> k_sorted i |> print_test |> create_test)
Console.WriteLine("ok")


// 34..37
// already sorted array with permutations
Console.Write("already sorted array with permutations...")
let add_noise n (a : int []) =
  {1..n} |> Seq.iter (fun _ ->
    let i = rand 0 (a.Length - 1)
    let j = rand 0 (a.Length - 1)
    let k = a.[i]
    a.[i] <- a.[j]
    a.[j] <- k)
  a
set [100; 1000;] |> Seq.iter (fun i -> gen_asc ARRAY_SIZE |> add_noise i |> print_test |> create_test)
set [300; 3000;] |> Seq.iter (fun i -> gen_desc ARRAY_SIZE |> add_noise i |> print_test |> create_test)

Console.WriteLine("ok")

// 38..42
// arrays with elements from normal distribution
Console.Write("arrays with elements from normal distribution...")
Array.init ARRAY_SIZE (fun _ -> next_normal_int()) |> print_test |> create_test
Array.init ARRAY_SIZE (fun _ -> next_normal_int()) |> sort_asc |> add_noise 100 |> print_test |> create_test
Array.init ARRAY_SIZE (fun _ -> next_normal_int()) |> sort_asc |> k_sorted 5 |> print_test |> create_test
Array.init ARRAY_SIZE (fun _ -> next_normal_int()) |> sort_desc |> add_noise 1000 |> print_test |> create_test
Array.init ARRAY_SIZE (fun _ -> next_normal_int()) |> sort_desc |> k_sorted 25 |> print_test |> create_test
Console.WriteLine("ok")

