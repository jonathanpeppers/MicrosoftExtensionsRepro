# How to update `custom.aprof`

Run:

    dotnet build ProfiledAot/build.proj -t:Record

`custom.aprof.txt` is a list of method names contained within the profile. We
don't ship these, but we can use them to track changes over time. Note that they
are not always in order, so I opened the files in VS Code and did Ctrl+Shift+P
to get the command palette. Then `Sort lines ascending` to get them in
alphabetical order. If the text files don't change, it is likely not necessary
to update the profile.