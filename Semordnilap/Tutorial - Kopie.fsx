// This sample will guide you through elements of the F# language.
//
// *******************************************************************************************************
//   To execute the code in F# Interactive, highlight a section of code and press Alt-Enter or right-click
//   and select "Execute in Interactive".  You can open the F# Interactive Window from the "View" menu.
// *******************************************************************************************************
//
// To install the Visual F# Power Tools, use
//     'Tools' --> 'Extensions and Updates' --> `Online` and search
//
// For additional templates to use with F#, see the 'Online Templates' in Visual Studio,
//     'New Project' --> 'Online Templates'

// F# supports three kinds of comments:


// Open namespaces using the 'open' keyword.
open System
open System.Linq

//Debug.AnyAsString [1;2;3]

/// Strings are fundamental data types in F#.  Here are some examples of Strings and basic String manipulation.
///
/// To learn more, see: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/strings
module Main =

    //let a = Adenine
 
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

    let reverse = palindrom code |> String.Concat; 
    
    // This line uses '%s' to print a string value.  This is type-safe.
    printfn "%s" reverse

    

/// Sequences are a logical series of elements, all of the same type.  These are a more general type than Lists and Arrays.
///
/// Sequences are evaluated on-demand and are re-evaluated each time they are iterated.
/// An F# sequence is an alias for a .NET System.Collections.Generic.IEnumerable<'T>.
///
/// Sequence processing functions can be applied to Lists and Arrays as well.
///
/// To learn more, see: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/sequences
module Sequences = 

    /// This a sequence of values.
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    let rnd = System.Random()

    /// This is an infinite sequence which is a random walk.
    /// This example uses yield! to return each element of a subsequence.
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    /// This example shows the first 100 elements of the random walk.
    let first100ValuesOfRandomWalk = 
        randomWalk 5.0 
        |> Seq.truncate 100
        |> Seq.toList

    printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk


/// Pattern Matching is a feature of F# that allows you to utilize Patterns,
/// which are a way to compare data with a logical structure or structures,
/// decompose data into constituent parts, or extract information from data in various ways.
/// You can then dispatch on the "shape" of a pattern via Pattern Matching.
///
/// To learn more, see: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/pattern-matching
module PatternMatching =

    /// A record for a person's first and last name
    type Person = {
        First : string
        Last  : string
    }

    /// A Discriminated Union of 3 different kinds of employees
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee

    /// Count everyone underneath the employee in the management hierarchy,
    /// including the employee.
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(id) ->
                0
            | Manager(id, reports) ->
                reports |> List.sumBy countReports
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    /// Find all managers/executives named "Dave" who do not have any reports.
    /// This uses the 'function' shorthand to as a lambda expression.
    let rec findDaveWithOpenPosition(emps : List<Employee>) =
        emps
        |> List.filter(function
                       | Manager({First = "Dave"}, []) -> true // [] matches an empty list.
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false) // '_' is a wildcard pattern that matches anything.
                                     // This handles the "or else" case.

    /// You can also use the shorthand function construct for pattern matching,
    /// which is useful when you're writing functions which make use of Partial Application.
    let private parseHelper f = f >> function
        | (true, item) -> Some item
        | (false, _) -> None

    let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

    let result = parseDateTimeOffset "1970-01-01"
    match result with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"

    // Define some more functions which parse with the helper function.
    let parseInt = parseHelper Int32.TryParse
    let parseDouble = parseHelper Double.TryParse
    let parseTimeSpan = parseHelper TimeSpan.TryParse

    // Active Patterns are another powerful construct to use with pattern matching.
    // They allow you to partition input data into custom forms, decomposing them at the pattern match call site.
    //
    // To learn more, see: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/active-patterns
    let (|Int|_|) = parseInt
    let (|Double|_|) = parseDouble
    let (|Date|_|) = parseDateTimeOffset
    let (|TimeSpan|_|) = parseTimeSpan

    /// Pattern Matching via 'function' keyword and Active Patterns often looks like this.
    let printParseResult = function
        | Int x -> printfn "%d" x
        | Double x -> printfn "%f" x
        | Date d -> printfn "%s" (d.ToString())
        | TimeSpan t -> printfn "%s" (t.ToString())
        | _ -> printfn "Nothing was parse-able!"

    // Call the printer with some different values to parse.
    printParseResult "12"
    printParseResult "12.045"
    printParseResult "12/28/2016"
    printParseResult "9:01PM"
    printParseResult "banana!"


/// Classes are a way of defining new object types in F#, and support standard Object-oriented constructs.
/// They can have a variety of members (methods, properties, events, etc.)
///
/// To learn more about Classes, see: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/classes
///
/// To learn more about Members, see: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/members
module DefiningClasses = 

    /// A simple two-dimensional Vector class.
    ///
    /// The class's constructor is on the first line,
    /// and takes two arguments: dx and dy, both of type 'double'.
    type Vector2D(dx : double, dy : double) =

        /// This internal field stores the length of the vector, computed when the
        /// object is constructed
        let length = sqrt (dx*dx + dy*dy)

        // 'this' specifies a name for the object's self identifier.
        // In instance methods, it must appear before the member name.
        member this.DX = dx

        member this.DY = dy

        member this.Length = length

        /// This member is a method.  The previous members were properties.
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)
    
    /// This is how you instantiate the Vector2D class.
    let vector1 = Vector2D(3.0, 4.0)

    /// Get a new scaled vector object, without modifying the original object.
    let vector2 = vector1.Scale(10.0)

    printfn "Length of vector1: %f\nLength of vector2: %f" vector1.Length vector2.Length




#if COMPILED
module BoilerPlateForForm = 
    [<System.STAThread>]
    do ()
    do System.Windows.Forms.Application.Run()
#endif
