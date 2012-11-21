let mutable id = 0

let gen = new System.Random(6519)

let ftemp = sprintf "%02d"
let create_file () =
  id <- id + 1
  System.IO.File.CreateText((ftemp id))

let create_test () =
  let f = create_file()
  for i in {1..9} do
    f.Write(gen.Next(-1000, 1001).ToString() + " ")
  f.WriteLine(gen.Next(-1000, 1001).ToString())
  f.Close()

for i in {1..30} do
  create_test ()