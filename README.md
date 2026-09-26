<div align="center">
  <img src=".github/assets/banner.png" alt="EasySave banner" width="100%" />

  <h1>EasySave</h1>
  <p>
    File backup software suite developed for a fictional client, ProSoft, as part of a school project (CESI)
  </p>

<p>
  <img src="https://img.shields.io/github/last-commit/BaditSad/EasySave.V2?style=flat-square" alt="last update" />
  <img src="https://img.shields.io/github/languages/top/BaditSad/EasySave.V2?style=flat-square" alt="top language" />
  <img src="https://img.shields.io/badge/.NET-6.0-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt=".NET 6" />
</p>
</div>

<br />

## :notebook_with_decorative_cover: Table of Contents

- [About](#star2-about)
  * [Architecture](#classical_building-architecture)
  * [Diagrams](#bar_chart-diagrams)
  * [Tech Stack](#space_invader-tech-stack)
  * [Features](#dart-features)
- [Getting Started](#toolbox-getting-started)
  * [Prerequisites](#bangbang-prerequisites)
  * [Installation](#gear-installation)
  * [Run the Project](#running-run-the-project)
- [Contact](#handshake-contact)

## :star2: About

EasySave is a suite of 4 pieces of software developed in C# to address a file backup need, each with a
specific role:

- **EasySave** is the main software (WPF application), used to create backup jobs and drive the other
  components.
- **CryptoSoft** is a command-line utility that encrypts or decrypts files on EasySave's request.
- **EasySave Server** runs continuously and centralizes the progress state of ongoing backup jobs.
- **EasySave Client** connects to the server to display this progress in real time and can pause or cancel a
  transfer.

### :classical_building: Architecture

The Client and Server communicate over TCP (sockets, port 11111) to transmit backup progress state. EasySave
launches CryptoSoft as a subprocess for encryption operations, passing it its install path and configuration
(language, extensions to encrypt, target folder) through JSON files.

### :bar_chart: Diagrams

<div align="center">
  <img src="Diagram/dc.EasySave3.0.drawio.png" alt="EasySave class diagram" width="700" />
</div>

Other diagrams (use case, sequence, components) for each module are available in the [`Diagram`](./Diagram)
folder.

### :space_invader: Tech Stack

<details>
  <summary>EasySave (main application)</summary>
  <ul>
    <li><a href="https://dotnet.microsoft.com/">.NET 6</a></li>
    <li><a href="https://learn.microsoft.com/dotnet/desktop/wpf/">WPF</a></li>
    <li><a href="https://www.newtonsoft.com/json">Newtonsoft.Json</a></li>
  </ul>
</details>

<details>
  <summary>EasySave Client / Server</summary>
  <ul>
    <li><a href="https://dotnet.microsoft.com/">.NET 6</a></li>
    <li><a href="https://learn.microsoft.com/dotnet/api/system.net.sockets">TCP Sockets (System.Net.Sockets)</a></li>
  </ul>
</details>

<details>
  <summary>CryptoSoft</summary>
  <ul>
    <li><a href="https://dotnet.microsoft.com/">.NET 6</a></li>
    <li>Console application</li>
  </ul>
</details>

### :dart: Features

- Backup job creation from a source folder to a target folder, full folder or specific files
- Browsable backup history, in XML or JSON format depending on configuration
- Encryption and decryption of backed-up files via CryptoSoft, with extension filtering
- Real-time progress tracking from EasySave Client, with pause and cancel
- Options menu to configure the default target folder and log format
- Interface available in French and English

## :toolbox: Getting Started

### :bangbang: Prerequisites

- Windows (WPF application)
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- Visual Studio 2022 (or any IDE supporting .NET/WPF projects)

### :gear: Installation

```bash
git clone https://github.com/BaditSad/EasySave.V2.git
cd EasySave.V2
```

Open `EasySave.sln` in Visual Studio, then restore the project's NuGet packages.

### :running: Run the Project

Set `EasySave` as the startup project and run the application. To test real-time tracking, run
`EasySave Server` then `EasySave Client` separately.

## :handshake: Contact

Brieuc Dumortier

[LinkedIn](https://www.linkedin.com/in/dumortier-brieuc/) - [GitHub](https://github.com/BaditSad) - dumortier.contact@gmail.com
