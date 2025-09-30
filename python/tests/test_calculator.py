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


# Task 5: Negative Rebellion
@pytest.mark.parametrize("input_str, expected_message", [
    ("1,-2", "negatives not allowed: -2"),
    ("1\n-2,3", "negatives not allowed: -2"),
    ("//;\n1;-2;3", "negatives not allowed: -2"),
    ("1,-2,-3,4", "negatives not allowed: -2, -3"),
])
def test_task5_add_throws_exception_for_negatives(input_str, expected_message):
    with pytest.raises(ValueError) as excinfo:
        Calculator(input_str).add()
    assert str(excinfo.value) == expected_message


# Task 6: Ignoring Giants
@pytest.mark.parametrize("input_str, expected", [
    ("2,1001", 2),
    ("1000,5,2000", 1005),
    ("999,1000,1001", 1999),
    ("//;\n2;1001;3", 5),
])
def test_task6_add_ignores_numbers_greater_than_1000(input_str, expected):
    assert Calculator(input_str).add() == expected


# Task 7: Flexible Delimiters
@pytest.mark.parametrize("input_str, expected", [
    ("//[***]\n1***2***3", 6),
    ("//[###]\n10###20###30", 60),
    ("//[--]\n5--10--1001", 15),
])
def test_task7_add_supports_delimiters_of_any_length(input_str, expected):
    assert Calculator(input_str).add() == expected


def test_task7_add_throws_exception_for_negatives_with_flexible_delimiter():
    with pytest.raises(ValueError) as excinfo:
        Calculator("//[***]\n1***-2***3").add()
    assert str(excinfo.value) == "negatives not allowed: -2"


# Task 8: Multiple Delimiters
@pytest.mark.parametrize("input_str, expected", [
    ("//[*][%]\n1*2%3", 6),
    ("//[;][#][!]\n4;5#6!7", 22),
    ("//[&][?]\n2&1001?3", 5),
])
def test_task8_add_supports_multiple_delimiters(input_str, expected):
    assert Calculator(input_str).add() == expected


def test_task8_add_throws_exception_for_negatives_with_multiple_delimiters():
    with pytest.raises(ValueError) as excinfo:
        Calculator("//[@][!]\n7@-8!9").add()
    assert str(excinfo.value) == "negatives not allowed: -8"


# Task 9: Complex Delimiters
@pytest.mark.parametrize("input_str, expected", [
    ("//[***][%%]\n1***2%%3", 6),
    ("//[&&][###][!!]\n5&&10###15!!20", 50),
    ("//[abc][defg]\n7abc8defg9", 24),
])
def test_task9_add_supports_multiple_long_delimiters(input_str, expected):
    assert Calculator(input_str).add() == expected


def test_task9_add_throws_exception_for_negatives_with_long_delimiters():
    with pytest.raises(ValueError) as excinfo:
        Calculator("//[***][%%]\n1***-2%%3").add()
    assert str(excinfo.value) == "negatives not allowed: -2"