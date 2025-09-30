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
