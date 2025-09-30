import pytest
from src.calculator import Calculator

# Task 1: Simple Summation
@pytest.mark.parametrize("input_str, expected", [
    ("", 0),
    ("4", 4),
    ("1,2", 3),
])
def test_task1_add_supports_up_to_two_numbers(input_str, expected):
    assert Calculator.add(input_str) == expected


# Task 2: Infinite Arithmetic
@pytest.mark.parametrize("input_str, expected", [
    ("1,2,3,4", 10),
    ("5,10,15", 30),
])
def test_task2_add_supports_multiple_numbers(input_str, expected):
    assert Calculator.add(input_str) == expected
