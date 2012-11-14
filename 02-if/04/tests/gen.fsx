let mutable id = 0

let gen = new System.Random(1356)
let wtemp = sprintf "%d %d %d"

let ftemp = sprintf "%02d"
let create_file () =
  id <- id + 1
  System.IO.File.CreateText((ftemp id))

let create_test a b c =
  let f = create_file()
  f.WriteLine(wtemp a b c)
  f.Close()

for i in {1..3} do
  for j in {1..3} do
    for k in {1..3} do
      create_test i j k

for i in {1..60} do
  create_test (gen.Next(1, 1000)) (gen.Next(1, 1000)) (gen.Next(1, 1000)) 

