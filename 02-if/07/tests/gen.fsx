let mutable id = 0

let gen = new System.Random(135)
let wtemp = sprintf "%d %d %d %d"

let ftemp = sprintf "%02d"
let create_file () =
  id <- id + 1
  System.IO.File.CreateText((ftemp id))

let create_test a b c d=
  let f = create_file()
  f.WriteLine(wtemp a b c d)
  f.Close()

let rand a b = gen.Next(a, b + 1)

for i in {1..99} do
  create_test (rand 1 8) (rand 1 8) (rand 1 8) (rand 1 8)
