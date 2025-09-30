from calculator import Calculator

def main():
    print("=== String Calculator ===")
    delimiter = input("Enter delimiter (without //): ")
    numbers_line = input("Enter numbers line: ")

    numbers = f"//{delimiter}\n{numbers_line}"

    try:
        calc = Calculator(numbers)
        result = calc.add()
        print("Result:", result)
    except Exception as e:
        print("Error:", e)

if __name__ == "__main__":
    main()
