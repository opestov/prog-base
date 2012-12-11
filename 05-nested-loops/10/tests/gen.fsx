let mutable id = 0

let gen = new System.Random(7163)

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

let rec rand a b = gen.Next(a, b + 1)

for i in {0..30} do
  create_test (print_num (1+i))
for i in {0..10} do
  create_test (print_num (1000000-i))
for i in {0..30} do
  create_test (print_num (rand 999000 1000000))
for i in {239..249} do
  create_test (print_num (i*i))

