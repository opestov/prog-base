let n = System.Console.ReadLine() |> int

let rec fact i =
    if i = 0 then 1
    else i*fact(i-1)

printf "%d\n" (fact n)

