// Open namespaces using the 'open' keyword.
open System
open System.Linq

/// Strings are fundamental data types in F#.  Here are some examples of Strings and basic String manipulation.
///
/// To learn more, see: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/strings
module Main =

    type A = Nucleobase.Adenine
    type C = Nucleobase.Cytosine
    type G = Nucleobase.Guanine
    type T = Nucleobase.Thymine


    //let a = A()

    //let x = a.Sign
 
    //printfn "%c" x
 
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }
    //let code2 = [ A; C ]

    let seqNumbers = [ 1.0; 1.5; 2.0; 1.5; 1.0; 1.5 ] :> seq<float>
    let seqNumberss = [ "1"; "1"; "2"; "1"; "1"; "1" ]
    let seqNumbersss = [ A; C ]
    

    //for letter in code2 do
    //    printfn "%c" 'X'
        

    let code = "ATGCTGATCTTGGCCATCAATG"

    let palindrom (mep:string) = seq {
        for letter in mep.Reverse() do
            if letter.Equals('A') then 
                yield 'T'
            else if letter.Equals('T') then 
                yield 'A'
            else if letter.Equals('C') then 
                yield 'G'
            else if letter.Equals('G') then 
                yield 'C'
            else
                yield '-' }

    let reverse = palindrom code |> String.Concat
    
    // This line uses '%s' to print a string value.  This is type-safe.
    printfn "%s" reverse


    
    Console.ReadKey() |> ignore