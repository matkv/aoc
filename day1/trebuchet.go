package main

import (
	"fmt"
	"os"
	"regexp"
	"strconv"
	"strings"
)

func readFile(filename string) (string, error) {
	data, err := os.ReadFile(filename)
	if err != nil {
		return "", err
	}
	return string(data), nil
}

func solvePartOne(input string) int {

	re := regexp.MustCompile("[0-9]")
	var lines = strings.Split(input, "\n")

	var sum int

	for _, line := range lines {
		var numbersInString = re.FindAllString(line, -1)

		if len(numbersInString) > 0 {

			var firstDigit, _ = strconv.ParseInt(numbersInString[0], 10, 64)
			var lastDigit, _ = strconv.ParseInt(numbersInString[len(numbersInString)-1], 10, 64)

			var generatedNumberString = strconv.FormatInt(firstDigit, 10) + strconv.FormatInt(lastDigit, 10)
			var generatedNumber, _ = strconv.Atoi(generatedNumberString)

			sum = sum + generatedNumber
		}
	}

	return sum // Placeholder return value
}

func solvePartTwo(input string) int {
	// Implement your solution for Part Two here
	return 0 // Placeholder return value
}

func main() {
	input, err := readFile("input.txt") // Replace "input.txt" with your input file
	if err != nil {
		fmt.Println("Error reading input file:", err)
		return
	}

	// Solve Part One
	resultPartOne := solvePartOne(input)
	fmt.Println("Part One:", resultPartOne)

	// Solve Part Two
	resultPartTwo := solvePartTwo(input)
	fmt.Println("Part Two:", resultPartTwo)
}
