let mutable id = 0

let ftemp = sprintf "%02d"
let create_test callme =
  id <- id + 1
  let ouf = System.IO.File.CreateText((ftemp id))
  callme ouf
  ouf.Close()

let print_num n =
  let foo (ouf : System.IO.StreamWriter) =
    ouf.WriteLine(string n)
  foo

for i in {0..9} do
  create_test (print_num (i))
