namespace Semordnilap

open System

//    module Purines/Pyrimidines

//should not be a base class, just an interface (was done like this, because of verbosity with ToString in each type)
[<AbstractClass>]
type Nucleobase() =
    abstract member Letter: char
    abstract member Opposite: unit -> Nucleobase //TODO: bases should not know their own opposite (else we have a problem using those for RNA)

type Adenine() =
    inherit Nucleobase()
    static member LetterCode = 'A'
    override this.Letter = Adenine.LetterCode
    override this.Opposite() = Thymine() :> Nucleobase
    override this.ToString() = String(Adenine.LetterCode, 1)
            
and Cytosine() =
    inherit Nucleobase()
    static member LetterCode = 'C'
    override this.Letter = Cytosine.LetterCode
    override this.Opposite() = Guanine() :> Nucleobase
    override this.ToString() = String(Cytosine.LetterCode, 1)
        
and Guanine() =
    inherit Nucleobase()
    static member LetterCode = 'G'
    override this.Letter = Guanine.LetterCode
    override this.Opposite() = Cytosine() :> Nucleobase
    override this.ToString() = String(Guanine.LetterCode, 1)

and Thymine() =
    inherit Nucleobase()
    static member LetterCode = 'T'
    override this.Letter = Thymine.LetterCode
    override this.Opposite() = Adenine() :> Nucleobase
    override this.ToString() = String(Thymine.LetterCode, 1)

and Uracil() =
    inherit Nucleobase()
    static member LetterCode = 'U'
    override this.Letter = 'U'
    override this.Opposite() = Adenine() :> Nucleobase
    override this.ToString() = String(Uracil.LetterCode, 1)

and Nucleobases = 
    static member FromLetter(sign: char) = 
        match sign with
        | 'A' -> Adenine() :> Nucleobase
        | 'C' -> Cytosine() :> Nucleobase
        | 'G' -> Guanine() :> Nucleobase
        | 'T' -> Thymine() :> Nucleobase
        | _ -> raise (NotSupportedException())

    static member FromLetters(signs: string) =
        let arrayLetterCodes = signs :> seq<char>
        List.map (fun x -> Nucleobases.FromLetter(x: char)) (List.ofSeq arrayLetterCodes)
        
