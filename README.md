**To Run tests you must place your Firebase key json file in folder `FireSource.Test\Resources`.**

**FIRST create your Firestore database following the guide [isel-AVE-2021-FireStore-get-started.md](isel-AVE-2021-FireStore-get-started.md)**

***

Assignments:
1. Published 28-3-2021, DEADLINE: 18-4-2021, [FireMapper-1-reflection](Assignments/FireMapper-1-reflection.md)
2. TBD
3. TBD

***

High level view of projects (in `<<...>>`) and core types:

<img src="FireMapper.svg">

***

Run tests with `dotnet test --logger "console;verbosity=detailed"` to see `Console` output.

List tests with `dotnet test -t`

Select tests to run with `dotnet test --filter NameOfTheClassTest`


Run coverage with:
```
dotnet test --collect:"XPlat Code Coverage"
reportgenerator -reports:Project.Tests\TestResults\66e8839d-6844-4b8a-8067-dc9c32abed5d\coverage.cobertura.xml  -targetdir:coverage
coverage\index.htm
```