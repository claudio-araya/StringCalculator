<h1 align="center" style="margin: 0 0 12px; font-size: 35px;">
    <span style="letter-spacing:0.5px">String Calculator Challenge</span>
</h1>
<p align="center" style="margin:0 0 24px; color:#667085;">
  F# · xUnit · .NET
</p>


## Project Setup & Tests (F# + xUnit)

1. **Creating the main project**
```bash
dotnet new console -lang "F#" -o src
```

2. **Creating the test folder**

```bash
dotnet new xunit -lang "F#" -o tests
```
xUnit is the standard unit testing framework for .NET and in this case it's going to be used to test each task.

3. **Linking tests to the app code**

```bash
dotnet add tests/tests.fsproj reference src/src.fsproj
```
This adds a project reference so that the test project can access and test the code from src.

4. **Creating and linking the solution file**

```bash
dotnet new sln -n StringCalculatorChallenge
dotnet sln add src/src.fsproj
dotnet sln add tests/tests.fsproj
```
This allows both the app and the test project to be managed together.


## Running the project

> [!IMPORTANT]
The .NET SDK must be installed.

- **Build the project**:

    ```bash
    dotnet build
    ```

- **Run the main app**:

    ```bash
    dotnet run --project src
    ```

- **Run the tests**:

    ```bash
    dotnet test
    ```

# Task 1: Simple Summation

> Create a method int Add(string numbers) that sums up to two numbers. Return 0 for an empty string.

## ✅ Tests performed
- Verified that an **empty string** returns `0`.  
- Verified that a **single number** input returns its own value.  
- Verified that **two numbers separated by a comma** return the correct sum.  
- Verified that providing **more than two numbers** throws an exception.

# Task 2: Infinite Arithmetic

> Modify the Add method to handle an unknown number of inputs.


## ✅ Tests performed
- Verified that an **empty string** returns 0.
- Verified that a **null** input returns 0.
- Verified that a **single number** input returns its own value.
- Verified that **two numbers** separated by a comma return the correct sum.
- Verified that **three or more numbers** are summed correctly.

# Task 3: Breaking Newlines

> Allow the method to handle newline characters as delimiters.

## ✅ Tests performed
- Verified that an **empty string** returns 0.
- Verified that a **single number** input returns its own value.
- Verified that **two numbers** separated by a comma return the correct sum.
- Verified that inputs with **mixed commas and newlines** return the correct sum (e.g., `"1\n2,3"` → 6).
- Verified that inputs with **only newlines** return the correct sum (e.g., `"2\n3\n5,"` → 10).
