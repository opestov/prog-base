let mutable id = 0

let gen = new System.Random(98124)

let ftemp = sprintf "%02d"
let create_test callme =
  id <- id + 1
  let ouf = System.IO.File.CreateText((ftemp id))
  callme ouf
  ouf.Close()

let print_array (data : (int*int) array) =
  let foo (ouf : System.IO.StreamWriter) =
    ouf.WriteLine(data.Length)
    Array.iter (fun (x, y) -> ouf.WriteLine(sprintf "%d %d" x y)) data
  foo

let rand a b = gen.Next(a, b + 1)

create_test (print_array [|(11, 0)|])
create_test (print_array [|(10, 1); (11, 1)|])
create_test (print_array [|(2, 200); (1, 200); (2, 200)|])

for i in {1..4} do
  create_test (print_array (Array.init 1 (fun i -> (rand 10 11, rand 0 9))))
for i in {1..4} do
  create_test (print_array (Array.init 2 (fun i -> (rand 10 11, rand 0 99))))
for i in {1..4} do
  create_test (print_array (Array.init 10 (fun i -> (rand 10 11, rand 0 99))))
for i in {1..4} do
  create_test (print_array (Array.init 10 (fun i -> (rand 10 11, rand 700 703))))
for i in {1..4} do
  create_test (print_array (Array.init (rand 20 40) (fun i -> (rand 10 11, rand 600 700))))
for i in {1..10} do
  create_test (print_array (Array.init (rand 180 200) (fun i -> (rand 10 11, rand 0 800))))
create_test (print_array (Array.init 200 (fun i -> (rand 10 11, rand 749 750))))
create_test (print_array (Array.init 200 (fun i -> (rand 10 11, rand 750 750))))

for i in {1..10} do
  create_test (print_array (Array.init (rand 180 200) (fun i -> (rand 1 11, rand 0 800))))
for i in {1..10} do
  create_test (print_array (Array.init (rand 180 200) (fun i -> (rand 1 11, rand 780 800))))
create_test (print_array (Array.init 200 (fun i -> (rand 7 7, rand 777 777))))
create_test (print_array (Array.init 200 (fun i -> (rand 7 7, rand 1 800))))
create_test (print_array (Array.init 200 (fun i -> (rand 7 7, rand 600 620))))
