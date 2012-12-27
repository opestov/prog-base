let mutable id = 0

let gen = new System.Random(71634)

let ftemp = sprintf "%02d"
let create_test callme =
  id <- id + 1
  let ouf = System.IO.File.CreateText((ftemp id))
  callme ouf
  ouf.Close()

let print_array (data : int array) =
  let foo (ouf : System.IO.StreamWriter) =
    ouf.WriteLine(data.Length)
    Array.iteri (fun i e -> (if i > 0 then ouf.Write(" ")); ouf.Write(string(e))) data
    ouf.WriteLine()
  foo

let generate_array size =
  Array.create 
                       
let rand a b = gen.Next(a, b + 1)

create_test (print_array [|0;|])
create_test (print_array [|1;|])
create_test (print_array [|2;|])
create_test (print_array (Array.init 10 (fun i -> 9)))
create_test (print_array (Array.init 20 (fun i -> 9 - gen.Next(0, 10) / 9)))
create_test (print_array (Array.init 30 (fun i -> 9 - 2 * (gen.Next(0, 10) / 9))))
create_test (print_array (Array.init 40 (fun i -> 9 - 2 * (gen.Next(0, 10) / 9))))
create_test (print_array (Array.init 50 (fun i -> 9 - 2 * (gen.Next(0, 10) / 9))))
create_test (print_array (Array.init 10000 (fun i -> 9 - 3 * (gen.Next(0, 100) / 97))))
create_test (print_array (Array.init 10000 (fun i -> 9 - 4 * (gen.Next(0, 100) / 97))))
create_test (print_array (Array.init 10000 (fun i -> 9 - 5 * (gen.Next(0, 100) / 97))))
create_test (print_array (Array.init 10000 (fun i -> 9 - 6 * (gen.Next(0, 100) / 97))))
create_test (print_array (Array.init 10000 (fun i -> if i = 0 then gen.Next(1, 10) else gen.Next(0, 10))))
create_test (print_array (Array.init 10000 (fun i -> if i = 0 then gen.Next(1, 10) else gen.Next(0, 10))))
create_test (print_array (Array.init 10000 (fun i -> if i = 0 then gen.Next(1, 10) else gen.Next(0, 10))))
create_test (print_array (Array.init 10000 (fun i -> if i = 0 then gen.Next(1, 10) elif i > 9000 then 9 else gen.Next(0, 10))))
create_test (print_array (Array.init 10000 (fun i -> if i = 0 then gen.Next(1, 10) elif i > 2000 then 9 else gen.Next(0, 10))))
create_test (print_array (Array.init 10000 (fun i -> if i = 0 then gen.Next(1, 10) elif i > 1000 then 9 else gen.Next(0, 10))))
create_test (print_array (Array.init 10000 (fun i -> if i = 0 then gen.Next(1, 10) elif i > 30 then 9 else gen.Next(0, 10))))
create_test (print_array (Array.init 10000 (fun i -> if i = 0 then gen.Next(1, 10) elif i > 10 then 9 else gen.Next(0, 10))))
