namespace Semordnilap

///TODO: (re)move
type _NA = 
    
    static member IsDnaPart(nucleobase: Nucleobase) = 
        match nucleobase with
        | _ -> true

    static member IsDna(code: seq<Nucleobase>): bool = code |> Seq.forall (fun x -> _NA.IsDnaPart(x))
        

type DNA(code: list<Nucleobase>) =

    static member ValidLetters(code: string): bool = code |> Seq.forall (fun x -> DNA.ValidLetter(x))
    
    static member ValidLetter(sign: char) = 
        match sign with
        | 'A' | 'C' | 'G' | 'T' -> true
        | _ -> false

    member this.Code: list<Nucleobase> = code
    
    member private this.Reverse(code: list<Nucleobase>) = Seq.rev code
    member private this.Complementary(code: seq<Nucleobase>) = code |> Seq.map (fun x -> x.Opposite())

    ///complementary, reverse
    member this.FacingStrand() = this.Complementary (this.Reverse this.Code)
        
