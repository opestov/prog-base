let n = System.Console.ReadLine() |> int

let rec find i k p10 p =
    if i >= p10 then find i k (p10*10) (p+1)
    elif k+p < n then find (i+1) (k+p) p10 p
    else i.ToString().[n-k-1]

find 1 0 10 1 |> printf "%c\n"

