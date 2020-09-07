package main

import (
	"fmt"
	"net/http"
)

func home(w http.ResponseWriter, req *http.Request) {
	fmt.Fprintf(w, "Welcome to my site!\n")
}
func headers(w http.ResponseWriter, req *http.Request) {
	for name, headers := range req.Header {
		for _, h := range headers {
			fmt.Fprintf(w, "%s: %s\n", name, h)
		}
	}
}
func main() {
	http.HandleFunc("/", home)
	http.HandleFunc("/headers", headers)
	http.ListenAndServe(":5000", nil)
}
