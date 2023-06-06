# Preperation

- Generate AC's
- Create json source files (fix errors)
- Create other project files
  - Tests
  - Logic
- Add validator for search
- Import data from json files

# AC's
```
GIVEN: customer 1 makes a search
WHEN: They depart from Manchester airport (MAN)
AND: are traveling to Malaga airport (AGP)
AND: the departure date is 2023/07/01
AND: they are staying for 7 nights
THEN: best match should be flight id 2
AND: hotel id 9

GIVEN: customer 2 makes a search
WHEN: They depart from any London airport
AND: are traveling to Mallorca airport (PMI)
AND: the departure date is 2023/06/15
AND: they are staying for 10 nights
THEN: best match should be flight id 6
AND: hotel id 5

GIVEN: customer 3 makes a search
WHEN: They depart from any airport
AND: are traveling to Gran Canaria Airport (LPA)
AND: the departure date is 2022/11/10
AND: they are staying for 14 nights
THEN: best match should be flight id 7
AND: hotel id 6
```


