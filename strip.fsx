open System.IO
open System.Text.RegularExpressions

let (|Regex|_|) pattern input =
    let m = Regex.Match(input, pattern)
    if m.Success then Some(List.tail [ for g in m.Groups -> g.Value ])
    else None

let mutable e = ""
let emojis = [
    for line in File.ReadAllLines("full-emoji-list.html") do
        match line with
        | Regex "<td class='chars'>(.+?)</td>" [emoji] -> e <- emoji
        | Regex "<td class='name'>([^<]+?)</td>" [name] -> yield (e, name)
        | _ -> ()
    done
]

printfn "<!DOCTYPE html>
<html>
<head>
    <meta charset=\"utf-8\">
    <style>
        span { font-size: 25px; }
        * { text-align: center; }
        td { padding: 8px; }
    </style>
</head>
<body>
<table>"

for chunk in emojis |> Seq.chunkBySize 5 do
    printfn "<tr>"
    chunk |> Seq.iter (fun (a, b) -> printfn "<td><span>%s</span></br>%s" a b)
    printfn "</tr>"
done

printfn "</table>
</body>
</html>"