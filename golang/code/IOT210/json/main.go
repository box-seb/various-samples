package main

import (
	"encoding/json"
	"fmt"
)

type People struct {
	Firstname string // first char must be capitalized
	Lastname  string // first char must be capitalized
	Details   struct {
		Height int32
		Weight float32
	}
}

type Rates struct {
	Base   string `json:"base currency"`
	Symbol string `json:"destination currency"`
}

func main() {

	var person []People
	jsonString :=
		`[
        { 
            "firstname":"Wei-Meng",     
            "lastname":"Lee",
            "details": {
                "height":175,
                "weight":70.0
            }
        },
        { 
            "firstname":"Mickey",       
            "lastname":"Mouse",
            "details": {
                "height":105,
                "weight":85.5
            }
        }        
	]`

	jsonString2 :=
		`{
        "base currency":"EUR",
        "destination currency":"USD"
     }`

	err := json.Unmarshal([]byte(jsonString), &person)
	fmt.Println(person) // {Wei-Meng Lee}
	fmt.Println(err)    // <nil>

	for _, v := range person {
		fmt.Println(v.Firstname)
		fmt.Println(v.Lastname)
		fmt.Println(v.Details.Height)
		fmt.Println(v.Details.Weight)
	}

	var rates Rates
	json.Unmarshal([]byte(jsonString2), &rates)
	fmt.Println(rates.Base)
	fmt.Println(rates.Symbol)

	jsonString3 :=
		`{
        "success": true,
        "timestamp": 1588779306,
        "base": "EUR",
        "date": "2020-05-06",
        "rates": {
            "AUD": 1.683349,
            "CAD": 1.528643,
            "GBP": 0.874757,
            "SGD": 1.534513,
            "USD": 1.080054
        }
	}`

	var result map[string]interface{}

	json.Unmarshal([]byte(jsonString3), &result)
	fmt.Println(result["success"])
	currRates := result["rates"]

	fmt.Println(currRates)

	sgd := currRates.(map[string]interface{})["SGD"]

	fmt.Println(sgd)

}
