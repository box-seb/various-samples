package main

import (
	"encoding/json"
	"fmt"
	"io/ioutil"
	"log"
	"net/http"
)

var c2 chan struct {
	name        string
	title       string
	description string
}

type Article struct {
	source struct {
		name string
	}
	title       string
	description string
}

func fetchData(url string) {
	resp, err := http.Get(url)
	if err != nil {
		log.Fatal(err)
	}
	defer resp.Body.Close()
	body, err := ioutil.ReadAll(resp.Body)
	if err != nil {
		log.Fatal(err)
	}
	str := string(body)
	var result map[string]interface{}
	json.Unmarshal([]byte(str), &result)
	articles := result["articles"].([]Article)
	c2 <- struct {
		name        string
		title       string
		description string
	}{
		name:        articles[0].source.name,
		title:       articles[0].title,
		description: articles[0].description,
	}
}
func main2() {
	c2 = make(chan struct {
		name        string
		title       string
		description string
	})
	go fetchData("https://newsapi.org/v2/top-headlines?country=us&category=business&apiKey=68abed74b6aa468aa1c2bcdd04ccaca9")
	result := <-c2
	fmt.Println(result)
	fmt.Scanln()
}
