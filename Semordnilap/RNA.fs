namespace Semordnilap

type RNA(code: list<Nucleobase>) =
    
    static member ValidLetters(code: string): bool = code |> Seq.forall (fun x -> RNA.ValidLetter(x))
    
    static member ValidLetter(sign: char) = 
        match sign with
        | 'A' | 'C' | 'G' | 'U' -> true
        | _ -> false

    member this.Code = code
    
        


