# aoc-23
Repository for Advent of Code 2023.

## Notes

## Daily Template

- Create subfolder called "day-1" for example
- Create new file "nameoftask.go"
- Add the template from /template/template.go

```go
package main

import (
	"fmt"
	"os"
)

func readFile(filename string) (string, error) {
	data, err := os.ReadFile(filename)
	if err != nil {
		return "", err
	}
	return string(data), nil
}

func solvePartOne(input string) int {
	// Implement your solution for Part One here
	return 0 // Placeholder return value
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
```

- Solve the exercise
- To run the file have it selected in VSCode and just press the "Run" button
- Repeat every day

## C#

- to add second day, create new project in subfolder
- in solution explorer -> add project -> choose the new one
- when pressing F5 it then let's you pick which one you want

Overall I need to clean up this whole repository and switch completely to either Go or C#.