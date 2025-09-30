class Calculator:
    @staticmethod
    def add(numbers: str) -> int:
        if not numbers:
            return 0

        parts = numbers.split(",")

        if len(parts) == 1:
            return int(parts[0])

        if len(parts) == 2:
            return int(parts[0]) + int(parts[1])
        
        if len(parts) > 2:
            raise ValueError("Two numbers are allowed in Task 1")
        
        raise ValueError("Invalid input")
