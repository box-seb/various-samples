package main

import (
	"fmt"

	turtle "github.com/hackebrot/turtle"
	quotes "github.com/weimenglee/stringmod/quotes"
)

func main() {
	emoji, ok := turtle.Emojis["smiley"]

	if !ok {
		fmt.Println("No emoji found")
	} else {
		fmt.Println("Emoji found", emoji)
	}

	fmt.Println(quotes.GetEmoji("turtle"))
}
