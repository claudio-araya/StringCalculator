class Calculator:
    @staticmethod
    def add(numbers: str) -> int:
        if not numbers:
            return 0

        numbers = numbers.replace("\n", ",")
        parts = numbers.split(",")

        total = 0
        for part in parts:
            if part.strip() != "":
                total += int(part)
        return total
