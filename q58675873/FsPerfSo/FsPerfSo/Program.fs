open System
open System.Diagnostics
open System.Numerics

type Z = BigInteger

let now =
  let sw = Stopwatch ()
  sw.Start ()
  fun () -> sw.ElapsedMilliseconds

let time a =
  let inline cc n = GC.CollectionCount n

  GC.Collect (2, GCCollectionMode.Forced)
  GC.WaitForFullGCComplete () |> ignore

  let bcc0, bcc1, bcc2 = cc 0, cc 1, cc 2

  let before = now ()

  let v = a ()

  let after = now ()

  let acc0, acc1, acc2 = cc 0, cc 1, cc 2

  v, after - before, (acc0 - bcc0, acc1 - bcc1, acc2 - bcc2)

let rho n c1 =
  let mutable iter = 1
  let mutable prod = 1I
  let mutable x    = 2I
  let mutable y    = 11I
  let mutable gcd  = 0I
  let mutable solution = false

  while not solution do
    x <- (x * x + c1) % n;
    y <- (y * y + c1) % n;
    y <- (y * y + c1) % n;
    prod <- ((y - x) * prod) % n;
    if (iter % 150 = 0) 
    then
      gcd <- Z.GreatestCommonDivisor (n, prod)
      if (gcd <> 1I) then
        printfn "rho c1 = %A" c1
        printfn "factor, iterations = %A, %A" gcd iter
        solution <- true
      else
        prod <- 1I
        iter <- iter+1
    else
      iter <- iter+1

  if (not solution) then
    printfn "no solution, iterations = %A" iter
  else printfn "solution"


[<EntryPoint>]
let main argv =
  let n = Z.Pow(2I,257) - 1I
  printfn "calling rho"
  let _, ms, cc = time (fun () -> rho n 7I)

  printfn "Computing result took %d ms with %A CC" ms cc

  0
