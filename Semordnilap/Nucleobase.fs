module Nucleobase

//    module Purines

//interface type INucleobase =
//   //abstract member Add: int -> int -> int
//   abstract (*member *)Sign: char
//   // abstract read/write property
//   //abstract member Area : float with get,set
//end


type INucleobase =
    interface
        abstract member Sign: char
        abstract Opposite: INucleobase
    end

type Adenine() =
    interface INucleobase with
        member this.Sign = 'A'
        member this.Opposite() = Thymine()
        
and Cytosine() =
    interface INucleobase with
        member this.Sign = 'C'
        member this.Opposite() = Guanine()
        
and Guanine() =
    interface INucleobase with
        member this.Sign = 'G'
        member this.Opposite() = Cytosine()

and Thymine() =
    interface INucleobase with
        member this.Sign = 'T'
        member this.Opposite() = Adenine()

