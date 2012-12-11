let mutable id = 0

let gen = new System.Random(716351)

let ftemp = sprintf "%02d"
let create_test callme =
  id <- id + 1
  let ouf = System.IO.File.CreateText((ftemp id))
  callme ouf
  ouf.Close()

let print a =
  let foo (ouf : System.IO.StreamWriter) =
    ouf.WriteLine(string(a))
  foo

let rand a b = gen.Next(a, b + 1)

create_test (print 1)
create_test (print 5)
for i in {1..20} do
  create_test (print (rand 1 30))
for i in {1..20} do
  create_test (print (rand 100 300))
for i in {1..20} do
  create_test (print (rand 900 1000))
                                                