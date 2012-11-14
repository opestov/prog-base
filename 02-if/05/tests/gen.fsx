let mutable id = 0

let gen = new System.Random(13564)
let wtemp = sprintf "%d %d %d"

let ftemp = sprintf "%02d"
let create_file () =
  id <- id + 1
  System.IO.File.CreateText((ftemp id))

let create_test a b c =
  let f = create_file()
  f.WriteLine(wtemp a b c)
  f.Close()

for i in {-1..1} do
  for j in {-1..1} do
    for k in {-1..1} do
      create_test i j k

for i in {1..20} do
  create_test (gen.Next(10, 15)) (gen.Next(10, 15)) (gen.Next(10, 15)) 
for i in {1..20} do
  create_test (gen.Next(100, 105)) (gen.Next(100, 105)) (gen.Next(100, 105))
for i in {1..30} do
  create_test (gen.Next(-1000, 1000)) (gen.Next(-1000, 1000)) (gen.Next(-1000, 1000)) 

