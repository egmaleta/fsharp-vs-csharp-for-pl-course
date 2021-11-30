let rec safe (x1,y1) (x2,y2) = 
    ((x1 <> x2) && (y1 <> y2))
    && (x2 - x1 <> y2 - y1)
    && (x1 - y2 <> x2 - y1)

let rec search f n size queens ps acc =
    match ps with
    | [] when size = n -> f queens acc
    | [] -> acc
    | q::ps ->
        search f n size queens ps acc
        |> search f n (size + 1) (q::queens) (List.filter (safe q) ps)

let solve n =
    let fn = [ for i in 1 .. n do
               for j in 1 .. n
               -> (i,j) ]
    let print queens i =
        for x in 1 .. n do
            for y in 1 .. n do
                printf "%s" (if List.contains (x,y) queens then " Q " else " . ")
            printf "\n"
        printf "==============================\n";
    let f queens i =
        // print queens i;
        i+1
    search f n 0 [] fn 0