import time

PROJECT_DIR = 'E:/dev-local/AdventOfCode/2024/input'

# def read_input(filename: str) -> list[str]:
#     filename = f'{PROJECT_DIR}/{filename}'
#     try:
#         with open(filename, 'r') as f:
#             return f.readlines()
#     except Exception as e:
#         print(e)
#         return []
    

def read_input_generator(filename):
    file_path = f'{PROJECT_DIR}/{filename}'
    try:
        with open(file_path, 'r') as f:
            for line in f:
                yield line.strip()
    except Exception as e:
        print(e)
        return []
    
# import time

# start = time.time()
# print("hello")
# end = time.time()
# print(end - start)


def execution_time_decorator(func):
    def wrapper(*args, **kwargs):
        start = time.time()
        result = func(*args, **kwargs)  # Call the original function
        end = time.time()
        print(f"Execution time: {end-start} seconds")
        return result
    return wrapper