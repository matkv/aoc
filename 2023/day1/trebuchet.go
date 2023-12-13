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

	return sum
}

func solvePartTwo(input string) int {
	var lines = strings.Split(input, "\n")

	var numbersList []int

	for _, str := range lines {
		var currentNumber int

		for _, char := range str {
			// Extract consecutive letters to form a word
			if char >= 'a' && char <= 'z' || char >= 'A' && char <= 'Z' {
				currentNumberStr := string(char)
				// Check if spelled-out number word is found
				if num, ok := spelledOutNumberToDigit(currentNumberStr); ok {
					currentNumber = currentNumber*10 + num // Accumulate the digit
				}
			} else {
				// Reset the currentNumber if non-letter character is encountered
				currentNumber = 0
			}

			if currentNumber != 0 {
				numbersList = append(numbersList, currentNumber)
			}
		}
	}
	return 0
}

func spelledOutNumberToDigit(word string) (int, bool) {
	digitWords := map[string]int{
		"zero":  0,
		"one":   1,
		"two":   2,
		"three": 3,
		"four":  4,
		"five":  5,
		"six":   6,
		"seven": 7,
		"eight": 8,
		"nine":  9,
	}

	if digit, lookupSuccessful := digitWords[strings.ToLower(word)]; lookupSuccessful {
		return digit, true
	}
	return -1, false
}

func main() {
	input, err := readFile("exampleinput2.txt") // Replace "input.txt" with your input file
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
