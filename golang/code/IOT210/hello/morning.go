package main

import (
	"fmt"
	r "math/rand"
	"strings"
)

const rate = 3
const factor float32 = 2.5
const welcome = "Welcome, "

func variablesFunc() {
	fmt.Println("hello worldhels!")
	fmt.Println(r.Intn(100))

	println(welcome)

	//var num1 = 5
	//var num2 int = 6
	num4 := 89
	num3 := 7

	println(num3)
	num3 = 99
	println(num3)
	num3 = num4
	println(num3)

	var raining bool = false
	println(raining)

	var (
		age  = 25
		name = "Peter"
	)

	println(age)
	println(name)

	fmt.Printf("%T", num3)

	str := fmt.Sprintf("num 1 is %d and rates is %.2f", num4, factor)
	println(str)

}

func doSomething(num1 int, num2 int) int {
	str := fmt.Sprintf("do something %d", num1+num2)
	println(str)
	return num1 + num2
}

// takes variable number of variables
func addNums(nums ...int) int {
	total := 0

	//nums is an array
	for _, n := range nums {
		total += n
	}

	return total / len(nums)
}

func countOddEven(s string) (odds, evens int) {
	odds, evens = 0, 0
	for _, c := range s {
		if int(c)%2 == 0 {
			evens++
		} else {
			odds++
		}
	}
	return
}

func callFunctions() {
	ret := doSomething(2, 3)
	println(ret)

	ret = addNums(1, 2, 3, 4, 5)
	println(ret)

	a, b := countOddEven("12345")

	println(a, b)
}

func intoToSlices() {
	var nums [5]int
	fmt.Println(nums)

	var c [3]string
	c[0] = "ios"
	c[1] = "android"
	c[2] = "windows"
	fmt.Println(c)

	// creating a slice with capacity of 5
	// resizable array
	var x = make([]int, 5)
	fmt.Println(x)

	primes := []int{2, 3, 5, 7, 11}
	fmt.Println(primes)

	original := []int{1, 2, 3, 4} // slice of capacity = 4
	other := original             // other is now a reference to original
	other[2] = 8
	// array is a pointer and assignment copies only pointer
	fmt.Println(original) // [1 2 8 4]
	fmt.Println(other)    // [1 2 8 4]

	other = append(original, 5) // append a 5 to original and assign it to other
	// other is now pointing to a new slice
	other[2] = 9
	fmt.Println(other)    // [1 2 9 4 5]
	fmt.Println(original) // [1 2 8 4]

}

func moreSlices() {
	x := make([]int, 2, 4)
	fmt.Println(x)
	y := x
	y[0] = 1
	fmt.Println(x) // [1 0]
	fmt.Println(y) // [1 0]

	x = append(x, 5)
	fmt.Println(x) // [1 0 5]
	fmt.Println(y) // [1 0]

	y[1] = 99
	fmt.Println(x) // [1 99 5]
	fmt.Println(y) // [1 99]

	x = append(x, 6)
	fmt.Println(x) // [1 99 5 6]
	fmt.Println(y) // [1 99]

	x = append(x, 7)
	fmt.Println(x) // [1 99 5 6 7]
	fmt.Println(y) // [1 99]

	y = append(y, 16)
	fmt.Println(x) // [1 99 5 6 7]
	fmt.Println(y) // [1 99 16]

	s1 := []string{"s1", "s1"} //cap 2
	fmt.Println(cap(s1))
	s2 := append(s1, "s2", "s2")
	fmt.Println(cap(s2))
	s3 := append(s2, "s3", "s3")
	fmt.Println(cap(s3))
	s4 := append(s3, "s4", "s4")
	fmt.Println(cap(s4))

	s4[0] = "xx"

	fmt.Println(s1)
	fmt.Println(s2)
	fmt.Println(s3)
	fmt.Println(s4)
}

func selectingItemsFromSlice() {
	var c [3]string
	c[0] = "iOS"
	c[1] = "Android"
	c[2] = "Windows"

	fmt.Println(c[:])
	fmt.Println(c[1:])
}

func add(num1, num2 int) int {
	return num1 + num2
}

func ifstatement() {
	limit := 20

	// if with the init statement
	if sum := add(5, 6); sum < limit {
		fmt.Println(sum) // 11
	} else {
		fmt.Println(limit)
	}

	// there is not ternary conditional operator
	// x = 2 > 4 ? dothis : dothat
}

func switchStatements() {
	// break is automatic when case is hit
	// you can use fallthrough to follow with other cases
	grade := "B"
	switch grade {
	case "A":
		fallthrough
	case "B":
		fallthrough
	case "C":
		fallthrough
	case "D":
		fmt.Println("Passed")
	case "F":
		fmt.Println("Failed")
	default:
		fmt.Println("Undefined")
	}
}

type Point struct {
	X int
	Y int
}

func structs() {
	ptA := Point{5, 6}

	ptB := ptA // assignments of a struct makes a copy

	fmt.Println(ptA)   // {5 6}
	fmt.Println(ptA.X) // 5
	fmt.Println(ptA.Y) // 6
	ptA.X = 7
	fmt.Println(ptA) // {7 6}
	fmt.Println(ptB)

	ptC := &ptA // assigning an address of the ptA
	fmt.Println(ptC, ptA)
	ptA.X = 10
	fmt.Println(ptC, ptA)

	fmt.Println(*ptC)
	fmt.Println((*ptC).X)

	type Points []Point

	var allPoints = Points{
		{X: 5, Y: 7},
		{X: 7, Y: 8},
	}

	fmt.Println(allPoints)
}

func forStatement() {
	for i := 0; i < 5; i++ {
		fmt.Println(i)
	}

	// in go there is no while loop
	// you hae to implement it on your own
	counter := 0
	for counter < 5 {
		fmt.Println(counter)
		counter++
	}

	//infinite loop
	for {
		fmt.Println("Enter QUIT to exit")
		var input int
		fmt.Scanln(&input)
		fmt.Printf("%T", input)
		fmt.Println(input)
		//if strings.ToUpper(input) == "QUIT" {
		if input == 0 {
			break
		}
	}
}

func loopOverArray() {
	var c [3]string
	c[0] = "iOS"
	c[1] = "Android"
	c[2] = "Windows"

	for i, n := range c {
		println(i, n)
	}

	for n := range c {
		println(n)
	}
}

func maps() {
	var heights map[string]int
	// key is string
	// value is integer

	heights = make(map[string]int)

	heights["Peter"] = 178
	heights["Joann"] = 188
	heights["Marry"] = 179

	fmt.Println(heights["Marry"])
	//fmt.Println(heights)
	delete(heights, "Joann")
	//fmt.Println(heights)

	//manufacturers := map[string][]string{"apple": {"iPhoneX", "iPhone XS"}, "samsung": {"Galaxy 10", "Fold"}}

	var manufacturers map[string][]string
	manufacturers = make(map[string][]string)

	manufacturers["apple"] = make([]string, 0)
	manufacturers["apple"] = append(manufacturers["apple"], "iPhoneX")
	manufacturers["apple"] = append(manufacturers["apple"], "iPhone XS")

	manufacturers["samsung"] = make([]string, 0)
	manufacturers["samsung"] = append(manufacturers["samsung"], "Galaxy 10")
	manufacturers["samsung"] = append(manufacturers["samsung"], "Fold")

	for key, value := range manufacturers {
		fmt.Println(key)
		//fmt.Println(string.Repeat("-"), len(key)))
		for _, phone := range value {
			fmt.Println(phone)
		}
	}

	comp := map[string][]string{"apple": {"iPhoneX", "iPhone XS"}, "samsung": {"Galaxy 10", "Fold"}}
	for i := range comp {
		println(i)
		println("----------")
		println(strings.Join(comp[i], "\n"))
		println()
	}
}

func testingIfKeyPresentInMap() {
	var heights map[string]int
	heights = make(map[string]int)

	heights["Peter"] = 178
	heights["Joann"] = 188
	heights["Marry"] = 179

	// the ok says if it is present in map
	// value gets a value or default if not present
	value, ok := heights["Peter"]

	fmt.Println(value, ok)

	if ok {
		fmt.Println(value)
	}
}

func moreMaps() {
	weights := map[string]float32{
		"Peter": 180,
		"Joann": 190,
		"Marry": 170,
	}
	fmt.Println(weights)
}
