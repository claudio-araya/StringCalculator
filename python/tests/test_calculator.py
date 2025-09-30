import pytest
from src.calculator import Calculator

# Task 1: Simple Summation
@pytest.mark.parametrize("input_str, expected", [
    ("", 0),
    ("4", 4),
    ("1,2", 3),
])
def test_task1_add_supports_up_to_two_numbers(input_str, expected):
    assert Calculator(input_str).add() == expected


# Task 2: Infinite Arithmetic
@pytest.mark.parametrize("input_str, expected", [
    ("1,2,3,4", 10),
    ("5,10,15", 30),
])
def test_task2_add_supports_multiple_numbers(input_str, expected):
    assert Calculator(input_str).add() == expected


# Task 3: Breaking Newlines
@pytest.mark.parametrize("input_str, expected", [
    ("1\n2,3", 6),
    ("2\n3\n5,", 10),
])
def test_task3_add_supports_newlines_as_delimiters(input_str, expected):
    assert Calculator(input_str).add() == expected


# Task 4: Custom Delimiters
@pytest.mark.parametrize("input_str, expected", [
    ("//;\n1;2", 3),
    ("//|\n2|3|4", 9),
])
def test_task4_add_supports_custom_delimiters(input_str, expected):
    assert Calculator(input_str).add() == expected
