let rec quicksort L =
    match L with
    | []    -> L
    | [x]   -> L
    | (h :: xs) -> let lt,gt = List.partition ((>=) h) xs
                   quicksort(lt) @ [h] @ quicksort(gt)