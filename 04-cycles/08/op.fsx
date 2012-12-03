let [|a;b|] = System.Console.ReadLine().Split() |> Array.map int

let rec gcd a b =
    if a = 0 then b
    else gcd (b%a) a
let g = gcd a b

printf "%d %d\n" (a/g) (b/g)

