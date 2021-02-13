namespace Semordnilap

open System

type IAminoAcid =
    abstract member Letter1: char
    abstract member Letter3: string

//not polar, aliphatic
type Alanin() =
    interface IAminoAcid with
        member this.Letter1 = 'A'
        member this.Letter3 = "Ala"
            
