# Games Shelf: Backend Repository

This repository is to manage all of the Backend related lambda functions and the REST API.

To see the documentation repository, and the other repositories connected to this project, please go to the [Games Shelf: Documentation Repository](https://github.com/samuel-ward/fsharp-boardgame-inventory-documentation)

These will primarily be written in F# where able, resorting to C# where needed - or another language where appropriate.

Below gives a brief explanation of all of the components of the backend.

## Directory Structure

```
.
├── src
│   └── WebAPI
└── tests
    └── WebAPI.Tests
```

## (src/WebAPI)[./src/WebAPI/]

The WebAPI is a RESTful API that is written in F#, using the Giraffe framework.
It is deployed on AWS as a lambda function.
