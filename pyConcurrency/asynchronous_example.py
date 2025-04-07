import asyncio
from dataclasses import dataclass
from datetime import datetime


@dataclass
class HashData:
    data: str
    ttl: datetime


htable: dict[str, HashData] = {}


async def hset(key: str, data: HashData):
    htable[key] = data
    return f"inserted {key} : {data}"


async def main():
    data_1 = HashData("testing 1", None)
    task1 = hset("1", data_1)

    data_2 = HashData("testing 2", None)
    task2 = hset("2", data_2)

    results = await asyncio.gather(task1, task2, return_exceptions=True)
    print(results)


if __name__ == "__main__":
    asyncio.run(main())
