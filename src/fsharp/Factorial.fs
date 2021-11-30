// Factorial function:
let rec factorial n = 
    match n with 
    | 0 | 1 -> 1
    | _ -> n * factorial (n-1)

// Operator overriding, required to be prefix-like as in: !5 = 120
let inline (!) x = factorial x