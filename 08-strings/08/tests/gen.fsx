open System
open System.IO

// Random generator and utility random functions 
let gen = new Random(715134)
// Returns integer random variable from range [a..b] with uniform distribution
let rand a b = gen.Next(a, b + 1)
let randomChar a b = char (rand (int a) (int b))
let randomWord len  = new String(Array.init len (fun i -> randomChar 'a' 'z'))

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

// Writes char to the given stream
let print_test (s : string) (t : string) (output : StreamWriter) =
  output.WriteLine(s)
  output.WriteLine(t)

let one_test c al ar bl br =
  let common = randomWord c
  let s = (randomWord al) + common + (randomWord ar)
  let t = (randomWord bl) + common + (randomWord br)
  print_test s t |> create_test

print_test "green" "red" |> create_test
print_test "school" "chocolate" |> create_test
for i = 1 to 10 do
  one_test (rand 1 33) (rand 1 33) (rand 1 33) (rand 1 33) (rand 1 33)
one_test 100 0 0 0 0
one_test 33 33 33 33 33
one_test 80 0 10 5 0
one_test 0 50 50 50 50