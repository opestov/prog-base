let mutable id = 0

let gen = new System.Random(71634)

let ftemp = sprintf "%02d"
let create_test callme =
  id <- id + 1
  let ouf = System.IO.File.CreateText((ftemp id))
  callme ouf
  ouf.Close()

let print_array (data : (int*int*int) array) =
  let foo (ouf : System.IO.StreamWriter) =
    ouf.WriteLine(data.Length)
    Array.iter (fun (x,y,r) -> ouf.WriteLine(sprintf "%d %d %d" x y r)) data
  foo

let rand a b = gen.Next(a, b + 1)

let check (x1,y1,r1) (x2,y2,r2) =
  (x1-x2)*(x1-x2)+(y1-y2)*(y1-y2) > (r1+r2)*(r1+r2)
let common (a : (int*int*int) array) (i : int) =
  let mutable k = 0
  for j in {0..i-1} do
    if not (check a.[j] a.[i]) then
      k <- k+1
  k

let gen_rand n =
  let a = Array.init n (fun i -> (0, 0, 0))
  for i in {0..n-1} do
    a.[i] <- (rand -1000 1000, rand -1000 1000, rand 1 1000)
  a
let gen0 n =
  let a = Array.init n (fun i -> (0, 0, 0))
  for i in {0..n-1} do
    a.[i] <- (rand -1000 1000, rand -1000 1000, rand 1 1000)
    while (common a i) <> 0 do
      a.[i] <- (rand -1000 1000, rand -1000 1000, rand 1 1000)
  a
let gen1 n =
  let a = Array.init n (fun i -> (0, 0, 0))
  for i in {0..n-1} do
    a.[i] <- (rand -1000 1000, rand -1000 1000, rand 1 1000)
    let z =
      if i = n-1 then 1 else 0
    while (common a i) <> z do
      a.[i] <- (rand -1000 1000, rand -1000 1000, rand 1 1000)
  a

let gen2 n =
  let a = Array.init n (fun i -> (0, 0, 0))
  let d =
    if n = 1 then 999 else 999/(n-1)
  a.[0] <- (rand -100 100, rand -1000 1000, 1000)
  for i in {1..n-1} do
    let px, py, pr = a.[i-1]
    let r = rand (1000-i*d) ((pr-1+1000-i*d)/2)
    let mutable ix = rand -1000 1000
    let mutable iy = rand -1000 1000
    while (px-ix)*(px-ix)+(py-iy)*(py-iy) >= (pr-r)*(pr-r) do
      ix <- rand -1000 1000
      iy <- rand -1000 1000    
    a.[i] <- (ix, iy, r)
  a

let shuffle (a : (int*int*int) array) =
  for i in {0..a.Length - 1} do
    let j = rand 0 i
    let t = a.[i]
    a.[i] <- a.[j]
    a.[j] <- t
  a  

create_test (print_array [|(0,0,20);|])
create_test (print_array [|(0,0,20); (30,0,10)|])
for i in {1..10} do
  create_test (print_array (gen0 i))
for i in {1..10} do
  create_test (print_array (gen_rand i))
for i in {1..3} do
  create_test (print_array (gen0 (100*i)))
for i in {1..10} do
  create_test (print_array (shuffle (gen1 (100*i))))
create_test (print_array (gen_rand 1000))
for i in {995..1000} do
  create_test (print_array (gen0 i))
for i in {1..10} do
  create_test (print_array (shuffle (gen2 (i*10))))
