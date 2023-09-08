# C-exercises
c# exericeses at A2SV

# Student Grade Calculator

This is a C# console application that allows students to calculate their average grade based on different subjects.

## Features

- Prompt the student to enter their name and the number of subjects they have taken.
- For each subject, the student can enter the subject name and the grade obtained (numeric value).
- Validate input using conditional statements to ensure grade values are within a valid range.
- Use loops to handle multiple subjects and grades.
- Utilize collections (such as List or Dictionary) to store subject names and corresponding grades.
- Define a method to calculate the average grade based on the entered grades.
- Display the student's name, individual subject grades, and the calculated average grade using string interpolation.


## Example

```plaintext
Welcome to the Student Grade Calculator!

Please enter your name: John Doe
Please enter the number of subjects: 3

Subject 1 Name: Mathematics
Grade: 85

Subject 2 Name: Science
Grade: 92

Subject 3 Name: English
Grade: 78

Calculating average grade...

Student: John Doe

Subject Grades:
- Mathematics: 85
- Science: 92
- English: 78

Average Grade: 85

Thank you for using the Student Grade Calculator! ```

Certainly! Here's a short version of the README markdown:

# Word Frequency Count

This C# function takes a string as input and returns a dictionary containing the frequency of each word in the string. It treats words in a case-insensitive manner and ignores punctuation marks.

## Usage

```csharp
Dictionary<string, int> wordFrequency = CountWordFrequency(input);
```

The `CountWordFrequency` function accepts a string `input` and returns a dictionary where the keys are the words (in lowercase) and the values are their corresponding frequencies.

