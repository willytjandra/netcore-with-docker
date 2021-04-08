$ErrorActionPreference = "Stop"

#Requires -RunAsAdministrator

Set-Location $PSScriptRoot

Clear-Host

Write-Host "`n`n------------------------------------------------ PREREQUISITES ------------------------------------------------`n" -ForegroundColor Cyan

if (-not (Get-Command "dotnet" -ErrorAction SilentlyContinue)) {
    Write-Error "Dotnet CLI is not installed. Please download and install it. Stopping script."
}

$dotnetCoreVersion = & dotnet --list-sdks | Where-Object { $_.StartsWith("5.0." )}

if (-not ([string]::IsNullOrEmpty($dotnetCoreVersion))) {
    Write-Host ".Net Core 5.0 is installed" -ForegroundColor Green
}
else {
    Write-Error ".Net Core 5.0 is not installed. Please download and install it. Stopping script."
}

Write-Host "`n`n------------------------------------------------ DATABASE ------------------------------------------------`n" -ForegroundColor Cyan

Write-Host "Restoring EntityFramework Core tools" -ForegroundColor Magenta

& dotnet tool restore

Write-Host "Starting localdb" -ForegroundColor Magenta

& sqllocaldb create "MSSQLLocalDB"
& sqllocaldb start "MSSQLLocalDB"

Write-Host "Localdb successfully started" -ForegroundColor Green

Write-Host "Creating / updating database schema" -ForegroundColor Magenta

Push-Location ".\src\HelloWorld.Api"

& dotnet ef database update

Pop-Location

Write-Host "Database schema successfully created / updated" -ForegroundColor Green

Write-Host "`n`n------------------------------------------------ PACKAGES ------------------------------------------------`n" -ForegroundColor Cyan

Write-Host "Installing NuGet packages" -ForegroundColor Magenta

& dotnet restore

Write-Host "NuGet packages successfully installed" -ForegroundColor Green

Write-Host "Running Visual Studio"
Invoke-Item .\HelloWorld.sln

Write-Host "`n`n------------------------------------------------ DEVELOPMENT INSTRUCTIONS ------------------------------------------------`n" -ForegroundColor Cyan

Write-Host "Development environment successfully completed" -ForegroundColor Green