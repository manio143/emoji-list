# Emoji list
I wrote a script that extracts emojis from http://unicode.org/emoji/charts/full-emoji-list.html because it's way too clutered.

[Extracted emojis](emojis.html)

### How?
The script is written in F# and uses the Regex Active Pattern. I simply apply the Regex patterns to each line, reading the emoji string and its name. And then I print it out to HTML.