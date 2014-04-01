open System
open System.IO

// Random generator and utility random functions 
let gen = new Random(71513)
// Returns integer random variable from range [a..b] with uniform distribution
let rand a b = gen.Next(a, b + 1)
let randomChar a b = char (rand (int a) (int b))
let randomText len a b  = new String(Array.init len (fun i -> randomChar a b))

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
let print_test (s : string) (output : StreamWriter) =
  output.WriteLine(s)

print_test "green" |> create_test
print_test (new String(Array.create 100 't')) |> create_test
for i = 1 to 10 do
  print_test (randomText (rand 1 100) (int 'a') (int 'b')) |> create_test
for i = 1 to 20 do
  print_test (randomText (rand 1 100) 32 126) |> create_test
