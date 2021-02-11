namespace Semordnilap

type DNA(code: list<Nucleobase>) =
    
    new(letterCodes: string) = 
        let arrayLetterCodes = letterCodes :> seq<char>
        let c = List.map (fun x -> Nucleobases.FromSign(x: char)) (List.ofSeq arrayLetterCodes)
        DNA(c)

    member private this.Code = code
    
    member private this.Reverse(code: list<Nucleobase>) = Seq.rev code
    member private this.Complementary(code: seq<Nucleobase>) = code |> Seq.map (fun x -> x.Opposite())

    ///complementary, reverse
    member this.FacingStrand() = this.Complementary (this.Reverse this.Code)
        


