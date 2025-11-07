<h1 align="center">🧠 SimpleHMI – Beckhoff PLC + WPF HMI</h1>

<p align="center">
  Integration demo between <b>Beckhoff TwinCAT 3 PLC</b> and a <b>WPF (.NET 8, C#)</b> Human-Machine Interface.<br>
  Real-time communication via <b>ADS (TwinCAT.Ads)</b> protocol, including simulated sensor values and control buttons.
</p>

---

<p align="center">
  <a href="#-program-description">🧠 Program Description</a> •
  <a href="#-purpose">🎯 Purpose</a> •
  <a href="#-project-structure">🗂️ Project Structure</a> •
  <a href="#️-requirements">⚙️ Requirements</a> •
  <a href="#-run-plc">🧩 Run PLC</a> •
  <a href="#-running-the-hmi-application">🚀 Run HMI</a> •

</p>

---

## 🧠 Program Description

This project demonstrates a simple functional integration between a **Beckhoff TwinCAT 3 PLC** and a **C# WPF-based HMI (Human Machine Interface)** using the **ADS communication protocol**. It is designed as an educational and practical example of how to exchange data in real time between an industrial controller and a PC-based application.

### 🔧 How it works

1. The **PLC (Beckhoff_PLC)** runs a TwinCAT 3 program that exposes process variables such as:
   - `iCounter` — a numeric counter variable.  
   - `rTemperature` — a simulated temperature sensor signal.

2. The **HMI application (BeckhoffHMI_WPF)**, built in **C# and .NET 8**, connects to the PLC via the **Beckhoff.TwinCAT.Ads** library.

3. Through ADS communication, the HMI:
   - Reads live variable values from the PLC (counter and temperature).  
   - Displays the current process values in a WPF interface.  
   - Allows the user to modify values — e.g., incrementing the counter from the UI.  
   - Provides connection status and simulated sensor visualization (color indicator, dynamic value).

4. The data flow is **bi-directional**:
   - PLC updates are reflected in real time on the HMI.  
   - User actions in the HMI (button clicks) send data back to the PLC.  

---

## 🎯 Purpose

The purpose of this demo is to:
- Illustrate **real-time industrial communication** using the **ADS protocol**.  
- Serve as a **foundation for building more complex HMIs**, such as production dashboards, data loggers, or SCADA-like interfaces.  
- Provide a **clean and modern WPF UI template** for developers working with Beckhoff controllers.

---

## 🗂️ Project Structure

SimpleHMI/  
├── C#/  
│ ├── BeckhoffHMI.sln - Visual Studio (.NET/WPF) solution  
│ └── BeckhoffHMI_WPF/  
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
│ ├── PLC/ - PLC source (MAIN program, FBs, etc.)  
│ ├── Beckhoff_PLC.~u - TwinCAT user data  
│ ├── Beckhoff_PLC.bak - Backup file  
│ ├── Beckhoff_PLC.tsproj - TwinCAT PLC project  
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

---

## 🚀 Running the HMI Application

1. Open BeckhoffHMI.sln in Visual Studio.
2. Ensure the NuGet package Beckhoff.TwinCAT.Ads is restored.
3. Update the AMS Net ID and port in MainWindow.xaml.cs if necessary:
4. Build and run the project.



