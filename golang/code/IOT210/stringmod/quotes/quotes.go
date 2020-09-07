package quotes

import (
	turtle "github.com/hackebrot/turtle"
)

func GetEmoji(name string) string {
	emoji, ok := turtle.Emojis[name]

	if ok {
		return emoji.Char
	}

	return ""
}
