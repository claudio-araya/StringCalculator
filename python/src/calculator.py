class Calculator:
    def __init__(self, numbers: str):
        self.numbers = numbers or ""

    def _parse_delimiters_and_numbers(self):
        if self.numbers.startswith("//"):
            parts = self.numbers.split("\n", 1)
            delimiter_part = parts[0][2:]
            num_part = parts[1]

            if "[" in delimiter_part:
                raw_parts = delimiter_part.replace("]", "[").split("[")
                delimiters = [p for p in raw_parts if p]
                
            else:
                delimiters = [delimiter_part]
        else:
            delimiters = [",", "\n"]
            num_part = self.numbers
        return delimiters, num_part

    def _parse_numbers(self, input_str: str, delimiters: list[str]):

        for d in delimiters:
            input_str = input_str.replace(d, ",")
        number_strings = input_str.split(",")
        numbers = [int(n) for n in number_strings if n]
        return numbers


    def add(self) -> int:
        if not self.numbers:
            return 0

        delimiters, num_part = self._parse_delimiters_and_numbers()
        parsed_numbers = self._parse_numbers(num_part, delimiters)

        negatives = [n for n in parsed_numbers if n < 0]
        if negatives:
            raise ValueError(f"negatives not allowed: {', '.join(map(str, negatives))}")

        filtered_numbers = [n for n in parsed_numbers if n <= 1000]

        return sum(filtered_numbers)
