let mutable id = 0

let gen = new System.Random(716351)

let ftemp = sprintf "%02d"
let create_test callme =
  id <- id + 1
  let ouf = System.IO.File.CreateText((ftemp id))
  callme ouf
  ouf.Close()

let print a b =
  let foo (ouf : System.IO.StreamWriter) =
    ouf.WriteLine(string(a) + " " + string(b))
  foo

let rand a b = gen.Next(a, b + 1)

for i in {1..10} do
  create_test (print (rand 1 30) (rand 1 30))
for i in {1..20} do
  create_test (print (rand 1 1000) (rand 1 1000))
for i in {1..20} do
  create_test (print (rand 900000000 1000000000) (rand 900000000 1000000000))
for i in {1..20} do
  let cd = rand 900000 1000000
  create_test (print (cd * rand 900 1000) (cd * rand 900 1000))

let rec step k fp f =
  if (k < 45) then
    if (k > 40) then
      create_test (print fp f)
      create_test (print f fp)
    step (k + 1) f (fp + f)
step 1 0 1


                                                