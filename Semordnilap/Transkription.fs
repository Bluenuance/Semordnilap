namespace Semordnilap

open System

type Transkription =

    static member private ToRna(nucleobase: Nucleobase): Nucleobase = 
        match nucleobase with
        | :? Adenine -> Adenine() :> Nucleobase
        | :? Cytosine -> Cytosine() :> Nucleobase
        | :? Guanine -> Guanine() :> Nucleobase
        | :? Thymine -> Uracil() :> Nucleobase
        | _ -> raise (Exception())

    static member ToRna(dna: DNA): RNA =
        RNA(dna.Code |> List.map (fun x -> Transkription.ToRna(x)))
