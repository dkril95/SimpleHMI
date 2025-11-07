<h1 align="center">🧠 SimpleHMI – Beckhoff PLC + WPF HMI</h1>

<p align="center">
  Integration demo between <b>Beckhoff TwinCAT 3 PLC</b> and a <b>WPF (.NET 8, C#)</b> Human-Machine Interface.<br>
  Real-time communication via <b>ADS (TwinCAT.Ads)</b> protocol, including simulated sensor values and control buttons.
</p>

---

<p align="center">
  <a href="#-project-structure">📂 Project Structure</a> •
  <a href="#️-requirements">⚙️ Requirements</a> •
  <a href="#-plc-configuration">🧩 Run PLC</a> •
  <a href="#-running-the-hmi-application">🚀 Run HMI</a> •
  <a href="#-communication-overview">🔌 Communication</a> •

</p>

---

## 🧩 Overview

This project demonstrates how to connect a **Beckhoff TwinCAT PLC** to a **C# desktop HMI** using the **ADS protocol**.  
It simulates industrial data exchange such as counters and temperature values, visualized in a WPF user interface.

---

## 🗂️ Project Structure

SimpleHMI/  
├── .git/ - Git repository  
├── .vs/ - Visual Studio environment files  
├── C#/  
│ ├── BeckhoffHMI.sln - Visual Studio (.NET/WPF) solution  
│ └── BeckhoffHMI_WPF/  
│ ├── bin/ - Build output  
│ ├── obj/ - Intermediate build files  
│ ├── App.xaml - WPF application definition  
│ ├── App.xaml.cs - Application startup logic  
│ ├── AssemblyInfo.cs - Assembly metadata  
│ ├── BeckhoffHMI_WPF.csproj - Project configuration  
│ ├── MainWindow.xaml - Main window layout  
│ └── MainWindow.xaml.cs - Main window logic  
│  
├── PLC/  
│ ├── Beckhoff_PLC.sln - TwinCAT 3 solution file  
│ └── Beckhoff_PLC/  
│ ├── .vs/  
│ ├── _Boot/  
│ ├── _Config/  
│ ├── PLC/ - PLC source (MAIN program, FBs, etc.)  
│ ├── Beckhoff_PLC.~u - TwinCAT user data  
│ ├── Beckhoff_PLC.bak - Backup file  
│ ├── Beckhoff_PLC.tsproj - TwinCAT PLC project  
│ ├── Beckhoff_PLC.tsproj.bak - Project backup  
│ └── TrialLicense.tclrs - TwinCAT license file  
│  
└── .gitignore - Git ignore rules  

---

## ⚙️ Requirements

- **TwinCAT 3** (v3.1.4026 or newer)  
- **.NET 8.0 SDK**  
- **Visual Studio 2022**  
- **Beckhoff.TwinCAT.Ads NuGet package** in HMI project  

---

## 🧩 Run PLC

1. Open the PLC solution `Beckhoff_PLC.sln` in TwinCAT XAE.  
2. Verify ADS route to your PLC target (AMS Net ID).  
3. Activate the configuration and set the PLC to Run Mode.



## 🚀 Running the HMI Application

1. Open BeckhoffHMI.sln in Visual Studio.
2. Ensure the NuGet package Beckhoff.TwinCAT.Ads is restored.
3. Update the AMS Net ID and port in MainWindow.xaml.cs if necessary:
4. Build and run the project.

