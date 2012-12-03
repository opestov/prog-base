let gen = new System.Random(1791)

let mutable id = 0
let ftemp = sprintf "%02d"
let create_file () =
  id <- id + 1
  System.IO.File.CreateText((ftemp id))

let create_test data =
  let f = create_file()
  let s = Array.map string data
  let q = (Array.length s) - 1
  f.Write(s.[0])
  for i in {1..q} do
    f.Write(" " + s.[i])
  f.WriteLine()
  f.Close()

let rand a b = gen.Next(a, b + 1)

let gen_random size =
  let a = Array.init size (fun i -> rand -100 100)
  for step in {1..4} do
    let i = rand 0 (size - 2)
    a.[i] <- 0
    a.[i + 1] <- 0
  a

let gen_random0 size =
  let a = Array.init size (fun i -> rand -2 2)
  for step in {1..1} do
    let i = rand 0 (size - 2)
    a.[i] <- 0
    a.[i + 1] <- 0
  a


create_test [|0; 0|]
create_test [|1; 0; 0|]
create_test [|0; 1; 0; 0|]
create_test [|1; 0; 0|]
create_test [|-1; 1; 1; -1; 0; 0|]
for i in {1..10} do
  create_test (gen_random 20)
for i in {1..10} do
  create_test (gen_random 200)
for i in {1..20} do
  create_test (gen_random 1000)
for i in {1..20} do
  create_test (gen_random0 20)
for i in {1..20} do
  create_test (gen_random0 1000)

