open System
open System.IO

// Random generator and utility random functions 
let gen = new Random(85321)
// Returns integer random variable from range [a..b] with uniform distribution
let rand a b = gen.Next(a, b + 1)

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
let print_test (c : char) (output : StreamWriter) =
  output.WriteLine(c)

print_test('a') |> create_test
print_test('t') |> create_test
print_test('+') |> create_test
print_test(char 32) |> create_test
print_test(char 116) |> create_test
for i = 1 to 15 do
  print_test(char (rand 33 115)) |> create_test
