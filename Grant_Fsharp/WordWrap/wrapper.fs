module WordWrap

let until index (text:string) = text.[0..index-1]
let from index (text:string) = text.[index..]

let wrap fullText lineLength =
    let rec wrapRecursive (text:string) =
        if text.Length <= lineLength then
            text.Trim()
        else
            let wrapIndex,nextLineIndex =
                match (text |> until lineLength).LastIndexOf(" ") with
                | -1 -> lineLength, lineLength
                | spaceIndex -> spaceIndex, spaceIndex+1

            (text |> until wrapIndex).Trim() + "\n" + wrapRecursive (text |> from nextLineIndex)
    wrapRecursive fullText
            