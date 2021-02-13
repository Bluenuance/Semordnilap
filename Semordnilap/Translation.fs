namespace Semordnilap

open System

type Translation =

    static member private ToProtein(nucleobase1: Nucleobase, nucleobase2: Nucleobase, nucleobase3: Nucleobase): Nucleobase = 
        match nucleobase1, nucleobase2, nucleobase3 with
        //| :? Adenine -> Adenine() :> Nucleobase
        //| :? Cytosine -> Cytosine() :> Nucleobase
        //| :? Guanine -> Guanine() :> Nucleobase
        //| :? Thymine -> Uracil() :> Nucleobase
        | _ -> raise (Exception())

    static member ToProtein(bases: list<Nucleobase>): Protein =
        assert(bases.Length % 3 = 0) //triplets
        let tripletCount: int = bases.Length / 3;
        let triplets: list<list<Nucleobase>> = List.splitInto tripletCount bases
        
        //List.take
        Protein()
