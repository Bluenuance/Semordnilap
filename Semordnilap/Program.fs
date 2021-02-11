namespace Debug

open Semordnilap
open System

module Main =

    type N = Nucleobase

    type A = Adenine
    type C = Cytosine
    type G = Guanine
    type T = Thymine

    let code: Nucleobase list = [ A();T();G();C();T();G();A();T();C();T();T();G();G();C();C();A();T();C();A();A();T();G(); ]

    let dna = DNA(code)
    let dnaAsLetterCode = dna.FacingStrand() |> String.Concat

    printfn "%s" dnaAsLetterCode

    if dnaAsLetterCode.Equals("CATTGATGGCCAAGATCAGCAT") = false then
        printf "%s" "passt NICHT!!!"
            
    Console.ReadKey() |> ignore

    