package main

import (
	"encoding/json"
	"fmt"
	"io/ioutil"
	"log"
	"net/http"
)

func fetchData2() string {
	url := "http://data.fixer.io/api/latest?access_key=71de6fa4e130654c0f70dc69e9687840"
	resp, err := http.Get(url)

	if err != nil {
		log.Fatal(err)
	}

	defer resp.Body.Close()

	body, err := ioutil.ReadAll(resp.Body)

	if err != nil {
		log.Fatal(err)
	}

	return string(body)
}

func fetchData3(url string, c chan string) {
	resp, err := http.Get(url)
	if err != nil {
		log.Fatal(err)
	}
	defer resp.Body.Close()
	body, err := ioutil.ReadAll(resp.Body)
	if err != nil {
		log.Fatal(err)
	}
	//fmt.Println(string(body))
	c <- string(body)
}

func main() {

	c1 := make(chan string)
	c2 := make(chan string)
	c3 := make(chan string)

	go fetchData3("http://data.fixer.io/api/latest?access_key"+
		"=71de6fa4e130654c0f70dc69e9687840", c1)
	go fetchData3("http://api.openweathermap.org/data/2.5/weather?"+
		"q=SINGAPORE&appid=3f63ccf4a308a813a06606c1bc526a16", c2)

	go fetchData3("https://newsapi.org/v2/top-headlines?"+
		"country=us&category=business&apiKey=68abed74b6aa468aa1c2bcdd04ccaca9", c3)

	// currencies := <-c1
	// fmt.Println(currencies)
	// weather := <-c2
	// fmt.Println(weather)

	news := <-c3

	var result map[string]interface{}

	json.Unmarshal([]byte(news), &result)
	fmt.Println(result["status"])
	articles := result["articles"]
	//fmt.Println(articles)

	// arrticlesArray := articles.([]interface{})
	// fmt.Println(arrticlesArray)

	for _, n := range articles.([]interface{}) {
		fmt.Println("%T", n)
		//fmt.Println(i, n)
		source := n.(map[string]interface{})["source"]
		fmt.Println(source)

	}

	//fmt.Println(sgd)

	//fmt.Println(news)
	fmt.Scanln()
}
