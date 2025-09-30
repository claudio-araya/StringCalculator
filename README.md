<h1 align="center" style="margin: 0 0 12px; font-size: 35px;">
    <span style="letter-spacing:0.5px">String Calculator Challenge</span>
</h1>
<p align="center" style="margin:0 0 24px; color:#667085;">
  F# · xUnit · .NET · Python · Pytest
</p>

## Overview

This repository contains my implementation of the **String Calculator Challenge** in **two different languages**: **F#** and **Python**.  

Each task builds incrementally on the previous one, with tests ensuring that no earlier functionality is broken. The project uses **xUnit** as the testing framework for F#, and **pytest** for Python.

## Setup

**Clone the repository:**
   ```bash
   git clone https://github.com/claudio-araya/StringCalculator.git
   cd StringCalculator
   ```

### F# (.NET)

> [!IMPORTANT]  
> The .NET SDK must be installed.

1. **Build the project**:

    ```bash
    cd fsharp
    dotnet build
    ```

2. **Run the main app**:

    ```bash
    dotnet run --project src
    ```

3. **Run the tests**:

    ```bash
    dotnet test
    ```

### Python

> [!IMPORTANT]
> Python 3.10+ is recommended.

1. **Install dependencies**:

    ```bash
    cd python
    pip install -r requirements.txt
    ```

2. **Run the main app**:
    ```bash
    python src/program.py
    ```

3. **Run the tests:**:

    ```bash
    pytest -v
    ```

## Usage

### F#

The calculator logic is implemented in the `Calculator` module, located in `fsharp/src/Calculator.fs`.

```F#
open StringCalculator

let result = Calculator.Add "1,2,3"
printfn "%d" result
```

### Python

The calculator logic is implemented in the `Calculator` class, located in `python/src/calculator.py`.

```python
from src.calculator import Calculator

result = Calculator.add("1,2,3")
print(result)
```

## Project Structure

- F#

    - `fsharp/src/Calculator.fs`: Contains the implementation of the Calculator class.
    - `fsharp/src/Program.fs`: Entry point of the F# console application.
    - `fsharp/tests/Tests.fs`: Unit tests written with xUnit.
    - `fsharp/StringCalculator.sln`: Solution file.

- Python

    - `python/src/calculator.py`: Implementation of the String Calculator.
    - `python/src/program.py`: Entry point of the Python console application.
    - `python/tests/test_calculator.py`: Unit tests written with pytest.


<br>

# Tasks

## Task 1: Simple Summation

> Create a method `int Add(string numbers)` that sums up to two numbers. Return 0 for an empty string.

### ✅ Tests performed
- Verified that an **empty string** returns `0`.  
- Verified that a **single number** input returns its own value.  
- Verified that **two numbers separated by a comma** return the correct sum.  
- Verified that providing **more than two numbers** throws an exception.  



## Task 2: Infinite Arithmetic

> Modify the Add method to handle an unknown number of inputs.

### ✅ Tests performed
- Verified that inputs with **three or more numbers** are summed correctly.  



## Task 3: Breaking Newlines

> Allow the method to handle newline characters as delimiters.

### ✅ Tests performed
- Verified that inputs with **mixed commas and newlines** return the correct sum (e.g., `"1\n2,3"` → 6).  
- Verified that inputs with **only newlines** return the correct sum (e.g., `"2\n3\n5,"` → 10).  



## Task 4: Custom Delimiters

> Support custom delimiters defined in the format `//[delimiter]\n[numbers...]`.

### ✅ Tests performed
- Verified that using a custom delimiter such as `;` works correctly (e.g., `"//;\n1;2"` → 3).  
- Verified that using another custom delimiter such as `|` works correctly (e.g., `"//|\n3|4|5"` → 12).  



## Task 5: Negative Rebellion

> Throw an exception for negative numbers, including them in the message.

### ✅ Tests performed
- Verified that an input with a **single negative number** throws an exception with the correct message.  
- Verified that an input with **multiple negative numbers** throws an exception listing *all* negative values in the message.  



## Task 6: Ignoring Giants

> Ignore numbers greater than **1000** during summation.

### ✅ Tests performed
- Verified that numbers greater than **1000** are ignored (e.g., `"2,1001"` → 2).  
- Verified that **1000 is included** while **2000 is ignored** (e.g., `"1000,5,2000"` → 1005).  
- Verified that inputs with **999 and 1000 are summed**, while 1001 is ignored.  
- Verified that the rule also works with **custom delimiters** (e.g., `"//;\n2;1001;3"` → 5). 



## Task 7: Flexible Delimiters

> Extend the method to support delimiters of any length.

### ✅ Tests performed
- Verified that a **multi-character delimiter** works correctly (e.g., `"//[***]\n1***2***3"` → 6).  
- Verified that delimiters of **different lengths** also work (e.g., `"//[###]\n10###20###30"` → 60).  
- Verified that numbers greater than **1000** are ignored even with flexible delimiters (e.g., `"//[--]\n5--10--1001"` → 15).  
- Verified that an input containing a **negative number** with a flexible delimiter throws the correct exception message (e.g., `"//[***]\n1***-2***3"` → `"negatives not allowed: -2"`).  



## Task 8: Multiple Delimiters

> Allow multiple delimiters in the format //[delim1][delim2]\n.

### ✅ Tests performed

- Verified that inputs with **two delimiters** are parsed and summed correctly (e.g., `"//[*][%]\n1*2%3"` → 6).
- Verified that inputs with **three or more different delimiters** work correctly (e.g., `"//[;][#][!]\n4;5#6!7"` → 22).
- Verified that numbers greater than **1000** are ignored even when multiple delimiters are used (e.g., `"//[&][?]\n2&1001?3` → 5).
- Verified that inputs containing a **negative number** with multiple delimiters throw the correct exception message (e.g., `"//[@][!]\n7@-8!9"` → `"negatives not allowed: -8"`).



## Task 9: Complex Delimiters

> Ensure support for multiple long delimiters.

### ✅ Tests performed

- Verified that inputs with two long delimiters work correctly (e.g., `"//[***][%%]\n1***2%%3"` → 6).
- Verified that inputs with three or more long delimiters return the correct sum (e.g., `"//[&&][###][!!]\n5&&10###15!!20"` → 50).
- Verified that inputs with mixed alphabetic delimiters of different lengths are handled correctly (e.g., `"//[abc][defg]\n7abc8defg9"` → 24).
- Verified that an input containing a negative number with long delimiters throws the correct exception message (e.g., `"//[***][%%]\n1***-2%%3"` → `"negatives not allowed: -2"`).