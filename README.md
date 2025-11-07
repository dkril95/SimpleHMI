<p align="center">
  <img src="https://upload.wikimedia.org/wikipedia/commons/1/1d/Beckhoff_logo.svg" alt="Beckhoff Logo" width="200"/>
</p>

<h1 align="center">🧠 SimpleHMI – Beckhoff PLC + WPF HMI</h1>

<p align="center">
  Integration demo between <b>Beckhoff TwinCAT 3 PLC</b> and a <b>WPF (.NET 8, C#)</b> Human-Machine Interface.<br>
  Real-time communication via <b>ADS (TwinCAT.Ads)</b> protocol, including simulated sensor values and control buttons.
</p>

---

<p align="center">
  <a href="#-overview">🧩 Overview</a> •
  <a href="#-project-structure">📂 Project Structure</a> •
  <a href="#️-requirements">⚙️ Requirements</a> •
  <a href="#-plc-configuration">🧠 PLC Configuration</a> •
  <a href="#-running-the-hmi-application">🚀 Run HMI</a> •
  <a href="#-communication-overview">🔌 Communication</a> •
  <a href="#-future-improvements">💡 Next Steps</a> •
</p>

---

## 🧩 Overview

This project demonstrates the integration between a **Beckhoff TwinCAT 3 PLC** and a **C# WPF HMI (.NET 8)**  
through the **ADS (Automation Device Specification)** protocol.

The system simulates sensor data (temperature and counter values), displays them in real-time,  
and allows user interaction with PLC variables via an intuitive WPF interface.

---

## 🗂️ Project Structure

Workspace/
├── .git/ # Git repository
├── PLC/ # Beckhoff TwinCAT PLC project
│ ├── Beckhoff_PLC/ # Main PLC project (MAIN program, variables, config)
│ │ ├── _Boot/ # Auto-start PLC files
│ │ ├── _Config/ # Configuration folder
│ │ ├── PLC/ # Source code (MAIN program, FBs, etc.)
│ │ ├── Beckhoff_PLC.tsproj # TwinCAT PLC project file
│ │ └── Beckhoff_PLC.sln # PLC solution file
│ └── Beckhoff_PLC.sln
│
├── BeckhoffHMI/ # HMI application folder
│ ├── BeckhoffHMI.sln # Visual Studio (.NET/WPF) solution
│ └── BeckhoffHMI_WPF/ # WPF application source code
│ ├── App.xaml / App.xaml.cs # Application entry point
│ ├── MainWindow.xaml / .cs # Main window & logic
│ ├── BeckhoffHMI_WPF.csproj # Project configuration file
│ └── bin / obj # Build output folders
│
└── .gitignore # Git ignore rules


---

## ⚙️ Requirements

- **TwinCAT 3** (v3.1.4026 or newer)  
- **.NET 8.0 SDK**  
- **Visual Studio 2022**  
- **NuGet Package:**

Beckhoff.TwinCAT.Ads (v6.2.511)


---

## 🧠 PLC Configuration

The PLC project is located in:

Workspace/PLC/Beckhoff_PLC/


### Main program (`MAIN`):

PROGRAM MAIN
VAR
    iCounter : UDINT := 0;
    bIncrease : BOOL := FALSE;
    rTemperature : REAL := 22.5;
    tCycle : TON;
    nSeed : INT := 0;
END_VAR

// Increase counter when HMI button is pressed
IF bIncrease THEN
    iCounter := iCounter + 1;
    bIncrease := FALSE;
END_IF

// Simulate temperature changes (smooth sinusoidal function)
tCycle(IN := TRUE, PT := T#500MS);
IF tCycle.Q THEN
    tCycle(IN := FALSE);
    nSeed := nSeed + 1;
    rTemperature := 22.0 + SIN(REAL_TO_LREAL(nSeed) / 5.0) * 2.0;
END_IF

➡️ Run the PLC in Run mode (F5) in TwinCAT to start the ADS server.
🖥️ Running the HMI Application

    Open:

BeckhoffHMI/BeckhoffHMI.sln

in Visual Studio 2022

Install the Beckhoff ADS package:

dotnet add package Beckhoff.TwinCAT.Ads --version 6.2.511

Build and run:

    dotnet run

    The HMI will display:

        ✅ Increase Counter button

        🌡️ Live temperature readout

        🔴🟢 Connection status indicator

        🔗 Connect / Disconnect button

🔌 Communication Overview

The WPF app communicates with the Beckhoff PLC using the ADS protocol.

adsClient.Connect("127.0.0.1.1.1", 851);

    127.0.0.1.1.1 → local AMS address (used for simulation)

    851 → ADS port of the PLC runtime

The HMI reads and writes PLC variables (iCounter, bIncrease, rTemperature) in real time.
💡 Future Improvements

Planned next steps:

Add real-time temperature chart (LiveCharts2)

Integrate MQTT broker communication

Add CSV or SQL data logging

Implement offline simulation mode

    Add better exception handling & reconnection logic

👤 Author

Created by Danylo Kril (2025)
Educational project for learning Beckhoff TwinCAT 3 PLC programming and C#/.NET HMI development.

📍 Technologies: TwinCAT 3, WPF, .NET 8, TwinCAT.Ads
📦 Repository: [add your GitHub link here]
