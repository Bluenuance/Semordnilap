namespace Semordnilap

open System

//    module Purines/Pyrimidines

//should not be a base class, just an interface (was done like this, because of verbosity with ToString in each type)
[<AbstractClass>]
type Nucleobase() =
    abstract member Sign: char
    abstract member Opposite: unit -> Nucleobase //TODO: bases should not know their own opposite (else we have a problem using those for RNA)
    override this.ToString() = String(this.Sign, 1)


type Adenine() =
    inherit Nucleobase()
    override this.Sign = 'A'
    override this.Opposite() = Thymine() :> Nucleobase
            
and Cytosine() =
    inherit Nucleobase()
    override this.Sign = 'C'
    override this.Opposite() = Guanine() :> Nucleobase
        
and Guanine() =
    inherit Nucleobase()
    override this.Sign = 'G'
    override this.Opposite() = Cytosine() :> Nucleobase

and Thymine() =
    inherit Nucleobase()
    override this.Sign = 'T'
    override this.Opposite() = Adenine() :> Nucleobase


and Nucleobases = 
    static member FromSign(sign: char) = 
        match sign with
        | 'A' -> Adenine() :> Nucleobase
        | 'C' -> Cytosine() :> Nucleobase
        | 'G' -> Guanine() :> Nucleobase
        | 'T' -> Thymine() :> Nucleobase
        | _ -> raise (NotSupportedException())

    //TODO: remove if not necessary
    //static member FromSign(sign: string) = 
    //    match sign with
    //    | "A" -> Adenine() :> Nucleobase
    //    | "C" -> Cytosine() :> Nucleobase
    //    | "G" -> Guanine() :> Nucleobase
    //    | "T" -> Thymine() :> Nucleobase
    //    | _ -> raise (NotSupportedException())