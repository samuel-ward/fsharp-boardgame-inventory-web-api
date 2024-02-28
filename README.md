# Games Shelf: Backend Repository

This repository is to manage all of the Backend related lambda functions and the REST API.

These while primarily be written in F# where able, resorting to C# where needed - or another language where appropriate.

Below gives a brief explanation of all of the components.

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
