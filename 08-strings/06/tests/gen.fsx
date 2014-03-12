open System
open System.IO

// Random generator and utility random functions 
let gen = new Random(85341)
// Returns integer random variable from range [a..b] with uniform distribution
let rand a b = gen.Next(a, b + 1)
let randomLetter () = char (rand (int 'a') (int 'z'))
let randomWord len = new String(Array.init len (fun i -> randomLetter ()))

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
let print_test (s : string) (i : int) (output : StreamWriter) =
  output.WriteLine(s)
  output.WriteLine(string i)

print_test "tdippm" 1 |> create_test
print_test "bbb" 5 |> create_test
for i = 1 to 10 do
  print_test (randomWord (rand 1 255)) (rand 1 10) |> create_test
