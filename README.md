# MyCLIWpfApp

This repository contains a WPF (Windows Presentation Foundation) application and a comprehensive UI test suite using Appium and WinAppDriver.

## Project Structure

- `MyCLIWpfApp.Wpf/` - The main WPF application source code.
- `MyCLIWpfApp.Tests/` - Automated UI tests for the application, written using Appium and NUnit.

## UI Testing with Appium and WinAppDriver

UI tests are implemented using Appium, which allows for robust automation of the WPF application's user interface. WinAppDriver is used as the automation backend to interact with Windows UI elements.

### Running UI Tests in CI

A GitHub Actions workflow is configured to automatically build and test the application on every pull request to the `main` branch. The workflow:

- Checks if .NET is already installed on the self-hosted Windows runner.
- Installs the required .NET SDK if needed.
- Checks out the pull request branch.
- Restores dependencies and builds the solution.
- Starts WinAppDriver.
- Runs the UI tests using Appium and collects code coverage if enabled.

You can find the workflow configuration in `.github/workflows/ci.yml`.

### Environment Variables

The workflow uses the following variables (set in GitHub repository or organization settings):
- `DOTNET_VERSION`: The .NET SDK version to use (e.g., `9.0.x`).
- `BUILD_CONFIGURATION`: Build configuration (e.g., `Release` or `Debug`).
- `ENABLE_CODE_COVERAGE`: Set to `true` or `false` to enable/disable code coverage collection.

## Prerequisites for Local Development

- Visual Studio 2022 or later
- .NET 9 SDK
- WinAppDriver installed on your machine
- Appium .NET client NuGet packages

## Running Tests Locally

1. Start WinAppDriver (`WinAppDriver.exe`).
2. Build the solution.
   ```powershell
   dotnet build
   ```
3. Run the tests in `MyCLIWpfApp.Tests` using your preferred test runner or via the command line:
   ```powershell
   dotnet test MyCLIWpfApp.Tests
   ```

## Test Coverage
Code coverage is automatically collected and reported by the GitHub Actions workflow when tests pass on every pull request to the `main` branch. The workflow:

- Runs tests with code coverage enabled if the `ENABLE_CODE_COVERAGE` variable is set to `true`.
- Generates a coverage report using `dotnet-reportgenerator-globaltool`.
- Updates the `README.md` file by replacing the section between `<!-- COVERAGE-START -->` and `<!-- COVERAGE-END -->` with the latest coverage summary.
- Commits and pushes the updated `README.md` back to the repository.

You can view the workflow configuration in `.github/workflows/ci.yml` for more details.
<!-- COVERAGE-START -->
<details open><summary>Summary</summary>

|||
|:---|:---|
| Generated on: | 5/24/2025 - 4:26:04 PM |
| Coverage date: | 5/24/2025 - 4:26:00 PM |
| Parser: | Cobertura |
| Assemblies: | 1 |
| Classes: | 3 |
| Files: | 4 |
| **Line coverage:** | 100% (9 of 9) |
| Covered lines: | 9 |
| Uncovered lines: | 0 |
| Coverable lines: | 9 |
| Total lines: | 69 |
| **Branch coverage:** | 83.3% (5 of 6) |
| Covered branches: | 5 |
| Total branches: | 6 |
| **Method coverage:** | [Feature is only available for sponsors](https://reportgenerator.io/pro) |

</details>

## Coverage
<details><summary>MyCLIWpfApp.Wpf - 100%</summary>

|**Name**|**Line**|**Branch**|
|:---|---:|---:|
|**MyCLIWpfApp.Wpf**|**100%**|**83.3%**|
|MyCLIWpfApp.Wpf.App|100%||
|MyCLIWpfApp.Wpf.MainWindow|100%|83.3%|
|MyCLIWpfApp.Wpf.ViewModels.BaseViewModel|100%||

</details>
<!-- COVERAGE-END -->

## Contributing

Pull requests are welcome! All PRs are automatically validated by the CI workflow to ensure the application builds and all UI tests pass.

---

For more details, see the workflow file or reach out to the maintainers.



