let mutable id = 0

let gen = new System.Random(135605)
let wtemp = sprintf "%d %d"

let ftemp = sprintf "%02d"
let create_file () =
  id <- id + 1
  System.IO.File.CreateText(ftemp id)

let create_test a b =
  let f = create_file()
  f.WriteLine(wtemp a b)
  f.Close()

create_test 1 1
create_test 0 1
create_test -10000 -10000
create_test -10000 10000

for i in {1..20} do
  let a = gen.Next(-10000, 10001)
  let b = gen.Next(a, 10001);
  create_test a b

