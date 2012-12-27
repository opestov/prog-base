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

create_test (print_array [|0;|])
create_test (print_array [|1;|])
create_test (print_array [|2;|])
create_test (print_array (Array.init 10 (fun i -> 0)))
create_test (print_array (Array.init 20 (fun i -> 1)))
create_test (print_array (Array.init 30 (fun i -> 2)))
create_test (print_array (Array.init 40 (fun i -> gen.Next(0, 2))))
create_test (print_array (Array.init 50 (fun i -> 1 + gen.Next(0, 2))))
create_test (print_array (Array.init 60 (fun i -> 2 * gen.Next(0, 2))))
create_test (print_array (Array.init 100 (fun i -> gen.Next(-3, 3))))
for i in {1..20} do
  create_test (print_array (Array.init (500 * i) (fun i -> gen.Next(0, 3))))
for i in {1..20} do
  create_test (print_array (Array.init (500 * i) (fun i -> gen.Next(0, 1001))))
create_test (print_array (Array.init 9995 (fun i -> gen.Next(-1000000000, 1000000000))))
create_test (print_array (Array.init 9995 (fun i -> gen.Next(-1000000000, 1000000000))))
create_test (print_array (Array.init 9995 (fun i -> gen.Next(-1000000000, 1000000000))))
create_test (print_array (Array.init 9994 (fun i -> 1000000000 * gen.Next(-1, 2))))
