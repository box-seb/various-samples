package main

import (
	"fmt"
	"time"
)

func say(s string, times int) {
	for i := 0; i < times; i++ {
		time.Sleep(100 * time.Millisecond)
		fmt.Println(s)
	}
}

func firstGoRoutine() {
	go say("hello", 5)
	go say("world", 5)

	var input int
	fmt.Scanln(&input)
	fmt.Println("Done!")
}

//---send data into a channel---
func sendData(ch chan string) {
	fmt.Println("Sending into channel...")
	ch <- "A"
	fmt.Println("sendData String retrieved from channel")
}

//---getting data from the channel---
func getData(ch chan string) {
	fmt.Println("getData String retrieved from channel", <-ch)
}

func useChannels() {
	ch := make(chan string)
	go sendData(ch)
	time.Sleep(2 * time.Second)
	fmt.Println(<-ch)
	fmt.Scanln()
	fmt.Println("Sending value into channel...")
	go getData(ch)
	time.Sleep(2 * time.Second)
	ch <- "B"
	fmt.Println("Value from channel retrieved")
	fmt.Scanln()
}

func sum(s []int, c chan int) {
	sum := 0
	for _, v := range s {
		sum += v
	}
	c <- sum // send sum to channel
}

func readChannel(ch chan string, readerName string) {
	var ok = true
	var value = ""
	for ok {
		value, ok = <-ch
		fmt.Println("read ", readerName, value)
	}

}

func sendToChannel(ch chan string) {
	ch <- "A"
	time.Sleep(1 * time.Second)
	ch <- "B"
	time.Sleep(1 * time.Second)
	ch <- "C"
	time.Sleep(1 * time.Second)
	ch <- "D"
	time.Sleep(1 * time.Second)
	ch <- "E"
	time.Sleep(1 * time.Second)
	ch <- "F"
	time.Sleep(1 * time.Second)
	ch <- "G"
	close(ch)
}

func runExample() {
	c := make(chan string)

	go readChannel(c, "Alice")
	go readChannel(c, "Bob")
	go sendToChannel(c)

	var input int
	fmt.Scanln(&input)
	fmt.Println("Done!")
}

func moreRoutines() {
	s := []int{7, 2, 8, -9, 4, 0}
	c := make(chan int)     // init a channel containing int values
	go sum(s[:len(s)/2], c) // send the first half of the array to sum()
	go sum(s[len(s)/2:], c) // send the second half of the array to sum()
	x, y := <-c, <-c        // receive the partial sums from the channel
	fmt.Println(x, y, x+y)  // -5 17 12
}

func currentTime() {
	fmt.Println(time.Now().Format("2006-01-02 15:04:05"))
}

func main() {

	c1 := make(chan string)
	c2 := make(chan string)

	go func() {
		time.Sleep(3 * time.Second)
		c1 <- "first"
	}()

	go func() {
		time.Sleep(1 * time.Second)
		c2 <- "second"
	}()

	currentTime()

	for i := 0; i < 2; i++ {
		select {
		case msg1 := <-c1:
			fmt.Println("received", msg1)
			currentTime()
		case msg2 := <-c2:
			fmt.Println("received", msg2)
			currentTime()
		}
	}

}
