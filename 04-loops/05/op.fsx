let line = System.Console.ReadLine()
printfn "%c %c" (Seq.minBy (fun c -> int(c)) line) (Seq.maxBy(fun c -> int(c)) line)
