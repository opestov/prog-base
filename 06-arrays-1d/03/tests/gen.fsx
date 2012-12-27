let mutable id = 0

let gen = new System.Random(7163)

let ftemp = sprintf "%02d"
let create_test callme =
  id <- id + 1
  let ouf = System.IO.File.CreateText((ftemp id))
  callme ouf
  ouf.Close()

let print_array (data : int array) =
  let foo (ouf : System.IO.StreamWriter) =
    ouf.WriteLine(data.Length)
    Array.iteri (fun i e -> (if i > 0 then ouf.Write(" ")); ouf.Write(string(e))) data
    ouf.WriteLine()
  foo

let rand a b = gen.Next(a, b + 1)
let randperm n =
  let a = Array.init n (fun i -> i+1)
  Array.iteri (fun i v -> let j = rand 0 i in a.[i] <- a.[j]; a.[j] <- v) a
  a

for i in {2..5} do
  create_test (print_array (Array.init i (fun j -> j+1)))
  create_test (print_array (Array.init i (fun j -> i-j)))
for i in {997..1000} do
  create_test (print_array (Array.init i (fun j -> j+1)))
  create_test (print_array (Array.init i (fun j -> i-j)))

for i in {1..10} do
  create_test (print_array (randperm (i)))
for i in {1..10} do
  create_test (print_array (randperm (10*i)))
for i in {990..1000} do
  create_test (print_array (randperm (i)))
  create_test (print_array (randperm (i)))
