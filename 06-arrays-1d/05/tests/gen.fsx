let mutable id = 0

let gen = new System.Random(3617)

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

create_test (print_array [|0;|])
create_test (print_array [|1;|])
create_test (print_array [|2;|])
create_test (print_array (Array.init 10 (fun i -> 0)))
create_test (print_array (Array.init 30 (fun i -> 1000)))

for i in {1..2} do
  create_test (print_array (Array.init 10 (fun i -> rand 43 44)))  
  create_test (print_array (Array.init 10 (fun i -> rand 900 1000)))  
  create_test (print_array (Array.init 10 (fun i -> rand 0 1000)))  

for i in {1..2} do
  create_test (print_array (Array.init 100 (fun i -> rand 17 18)))  
  create_test (print_array (Array.init 100 (fun i -> rand 900 1000)))  
  create_test (print_array (Array.init 100 (fun i -> rand 0 1000)))  

for i in {1..2} do
  create_test (print_array (Array.init 1000 (fun i -> rand 11 12)))  
  create_test (print_array (Array.init 1000 (fun i -> 9 * (rand 0 100) + 3)))
  create_test (print_array (Array.init 1000 (fun i -> rand 900 1000)))  
  create_test (print_array (Array.init 1000 (fun i -> rand 0 1000)))  

for i in {1..2} do
  create_test (print_array (Array.init 100000 (fun i -> rand 7 8)))
  create_test (print_array (Array.init 100000 (fun i -> 7 * (rand 0 100) + 1)))
  create_test (print_array (Array.init 100000 (fun i -> rand 900 1000)))
  create_test (print_array (Array.init 100000 (fun i -> rand 0 1000)))
