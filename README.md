**To Run tests you must:**
1. place your Firebase key json file in folder `FireSource.Test\Resources`.
1. update the path in `<Content Include="Resources\dummydemo-11dd3-firebase-adminsdk-vp6c5-28b7f0fa93.json">` of `FireSource.Test.csproj`
1. update the `FireStoreFixture.cs` of `FireSource.Test` project with:
   * correct path to Firebase key json file in constant `FIREBASE_CREDENTIALS_PATH`
   * project id in constant `FIREBASE_PROJECT_ID`

**FIRST create your Firestore database following the guide [isel-AVE-2021-FireStore-get-started.md](isel-AVE-2021-FireStore-get-started.md)**

***

## Assignments

1. Published 28-3-2021, DEADLINE: 18-4-2021, [FireMapper-1-reflection](Assignments/FireMapper-1-reflection.md)
2. Published 03-5-2021, DEADLINE: 23-5-2021, [FireMapper-2-meta-programming](Assignments/FireMapper-2-meta-programming.md)
3. TBD

***

## FireMapper overview

High level view of projects (in `<<...>>`) and core types:

<img src="Assets/FireMapper.svg">

***

## Slides Q&A session about FireMapper

<a target="_blank" href="Assets/FireMapper.pdf">
    <img width="500" src="Assets/FireMapper.gif">
</a>

***

## Unit tests and Coverage

Some tips:
* Run tests with `dotnet test --logger "console;verbosity=detailed"` to see `Console` output.
* List tests with `dotnet test -t`
* Select tests to run with `dotnet test --filter NameOfTheClassTest`


Run coverage with auxiliary [coverage.bat](coverage.bat) in root folder, which
performs the following tasks, for example:
```
dotnet test --collect:"XPlat Code Coverage"
reportgenerator -reports:Project.Tests\TestResults\66e8839d-6844-4b8a-8067-dc9c32abed5d\coverage.cobertura.xml  -targetdir:coverage
coverage\index.htm
```

**NOTICE** you must first install the auxiliary dotnet tool _reportgenerator_ [docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-code-coverage](
https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-code-coverage?tabs=windows#generate-reports)