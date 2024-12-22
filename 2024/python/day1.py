import heapq

import utils

@utils.execution_time_decorator
def part1():
    left = []
    right = []

    for line in utils.read_input_generator('day1.txt'):
        l, r = line.split()
        left.append(int(l))
        right.append(int(r))

    heapq.heapify(left)
    heapq.heapify(right)

    distance = 0
    for _ in range(len(left)):
        l = heapq.heappop(left)
        r = heapq.heappop(right)

        distance += abs(l - r)

    print(distance)
    return distance

@utils.execution_time_decorator
def part2():
    left = []
    right = {}

    for line in utils.read_input_generator('day1.txt'):
        l, r = line.split()
        left.append(int(l))

        r = int(r)
        existing_value = right.get(r)
        if existing_value is None:
            right[r] = 1
        else:
            right[r] = right[r] + 1

    result = 0
    for i in left:
        result += i * right.get(i, 0)

    print(result)
    return result

part1()
part2()