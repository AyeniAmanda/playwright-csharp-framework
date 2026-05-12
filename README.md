# Playwright C# Test Suite

Automated test suite built with Playwright and NUnit in C#.

## Tech Stack
- Playwright (browser automation)
- NUnit (test framework)
- C# / .NET 10
- GitHub Actions (CI/CD)

## Test Coverage
- Login (success & failure scenarios)
- Secure Area (access & logout)
- Dropdown interactions

## How to Run

### Install browsers
```bash
playwright install chromium
```

### Run all tests
```bash
dotnet test
```

## CI/CD
Tests run automatically on every push via GitHub Actions.