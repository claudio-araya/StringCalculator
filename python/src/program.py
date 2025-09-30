from calculator import Calculator

def main():
    print("=== String Calculator ===")

    # Format for task 1 is a string of numbers separated by commas
    user_input = input("Enter numbers: ")
    try:
        result = Calculator.add(user_input)
        print(f"Result: {result}")
    except Exception as e:
        print(f"Error: {e}")

if __name__ == "__main__":
    main()
