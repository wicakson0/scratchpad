import threading
from concurrent.futures import ProcessPoolExecutor
from typing import List


def factorization(num: int) -> List[int]:
    factors: List[int] = []
    for i in range(1, num + 1):
        if num % i == 0:
            factors.append(i)
    return factors


def parallel_factorization(num_list: List[int], num_thread: int) -> List[int]:
    with ProcessPoolExecutor() as executor:
        return list(executor.map(factorization, num_list))


def main():
    num_to_factor = [123, 456, 789]
    result_list = parallel_factorization(num_to_factor, 3)
    print(result_list)


if __name__ == "__main__":
    main()
