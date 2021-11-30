type Node = {value:int; left:Node option; right:Node option}

let rec addNode (tree:Node option) (newValue:int) : Node = 
    match tree with
    | Some t -> if newValue < t.value then {t with left=Some (addNode t.left newValue)}
                else if newValue > t.value then {t with right=Some (addNode t.right newValue)}
                else t
    | None -> {value=newValue; left=None; right=None}

let rec containsNode (tree:Node option) (containsValue: int) : Node option =
    match tree with
    | Some t -> if containsValue = t.value then Some t
                else if containsValue < t.value then containsNode t.left containsValue
                else if containsValue > t.value then containsNode t.right containsValue
                else None
    | None -> None

let tree = [32; 81; 49; 77; 26; 38] 
           |> List.fold (fun acc item -> Some (addNode acc item)) None

let rnode = containsNode tree 26
let wnode = containsNode tree 27