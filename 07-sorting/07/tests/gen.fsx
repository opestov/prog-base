// Generator of arrays that can be used to test sort algorithms.
// Please change the following constants appropriately before running the script.
// This script is similar to the one used to generate arrays for quadratic sort
// with one exception - there are no k-sorted arrays here.

let ARRAY_SIZE = 100000
let VALUE_BOUND = 1000000000

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


// random shuffle/sorted in ascending order/sorted in descending order
Console.Write("random shuffle/sorted in ascending order/sorted in descending order...")
gen_rand ARRAY_SIZE |> print_test |> create_test
gen_asc ARRAY_SIZE |> sort_asc |> print_test |> create_test
gen_desc ARRAY_SIZE |> sort_desc |> print_test |> create_test
Console.WriteLine("ok")


// group of tests with small number of unique elements
Console.Write("group of tests with small number of unique elements...")
let unique (a : int []) n = Array.init n (fun i -> a.[rand 0 (a.Length - 1)])
let unique_asc (a : int []) n = unique a n |> sort_asc
let unique_desc (a : int []) n = unique a n |> sort_desc
unique [|next_int ()|] ARRAY_SIZE |> print_test |> create_test
unique (gen_rand 10) ARRAY_SIZE |> print_test |> create_test
unique_asc (gen_rand 3) ARRAY_SIZE |> print_test |> create_test
unique_desc (gen_rand 10) ARRAY_SIZE |> print_test |> create_test
Console.WriteLine("ok")

// group of chainsaw tests
Console.Write("group of chainsaw tests...")
let chainsaw give_me_a give_me_b saw_size =
  seq [for i in {1..ARRAY_SIZE / saw_size} do yield (if i % 2 = 0 then give_me_a else give_me_b) saw_size] |> Array.concat
// chainsaw of sorted parts
chainsaw gen_asc gen_desc 12 |> print_test |> create_test
// each part is an array of few unique elements (elements from different parts are the same)
let u = gen_rand 5 in chainsaw (unique_asc u) (unique_desc u) 15 |> print_test |> create_test
let u = gen_rand 12 in chainsaw (unique_asc u) (unique_desc u) 20 |> print_test |> create_test
Console.WriteLine("ok")

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
gen_asc ARRAY_SIZE |> add_noise 300 |> print_test |> create_test
gen_desc ARRAY_SIZE |> add_noise 1000 |> print_test |> create_test
Console.WriteLine("ok")


