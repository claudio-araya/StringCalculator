class Calculator:
    def __init__(self, numbers: str):
        self.numbers = numbers or ""

    def _parse_delimiters_and_numbers(self):
        if self.numbers.startswith("//"):
            parts = self.numbers.split("\n", 1)
            delimiter = parts[0][2:]
            num_part = parts[1]
        else:
            delimiter = ","
            num_part = self.numbers.replace("\n", ",")
        return delimiter, num_part

    def _parse_numbers(self, input_str: str, delimiter: str):
        number_strings = input_str.split(delimiter)
        numbers = []
        for n in number_strings:
            if n:
                numbers.append(int(n))
        return numbers

    def add(self) -> int:
        if not self.numbers:
            return 0

        delimiter, num_part = self._parse_delimiters_and_numbers()
        parsed_numbers = self._parse_numbers(num_part, delimiter)

        return sum(parsed_numbers)
