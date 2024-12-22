import heapq

import utils

@utils.execution_time_decorator
def part1():
    result = 0

    for line in utils.read_input_generator('day2.txt'):
        values = [int(i) for i in line.split()]
        result += _process_part1_line(values)
                
    print(result)
    return result

def _process_part1_line(values: list[int]) -> 0:
    increasing_order = True
    decreasing_order = True

    for i in range(len(values) - 1):
        diff = values[i] - values[i+1]
        if abs(diff) < 1 or abs(diff) > 3:
            return 0
        
        if diff > 0:
            increasing_order = False
        if diff < 0:
            decreasing_order = False

    if increasing_order or decreasing_order:
        return 1

    return 0


@utils.execution_time_decorator
def part2():
    pass

part1_expected = 326
assert part1_expected == part1()