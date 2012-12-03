let mutable id = 0

let gen = new System.Random(1356)
let wtemp = sprintf "%d"

let ftemp = sprintf "%02d"
let create_file () =
  id <- id + 1
  System.IO.File.CreateText((ftemp id))

let create_test a =
  let f = create_file()
  f.WriteLine(wtemp a)
  f.Close()

for i in {1..25} do
  create_test i

for i in {1..60} do
  create_test (gen.Next(1, 1000001))

