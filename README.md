# CMCS-POE-PROG6212
📋 Contract Monthly Claim System (CMCS) 

🎯 Project Overview 

The Contract Monthly Claim System (CMCS) is a modern, web-based application built with ASP.NET Core MVC that streamlines the process of submitting and approving monthly claims for Independent Contractor (IC) lecturers. This system provides a seamless platform for claim management with real-time status tracking and document upload capabilities. 

https://img.shields.io/badge/Status-Completed-brightgreen https://img.shields.io/badge/.NET-8.0-purple https://img.shields.io/badge/ASP.NET_Core-MVC-indigo 

✨ Features 

🎨 Modern User Interface 

· Dark Licorice (#100311) background with Wisteria (#CDA9EC) text · Floating card design with soft shadows and rounded corners · Indigo (#580092) buttons with sinking animation effects · Responsive design that works on all devices · Professional academic aesthetic suitable for educational institutions 

🔧 Core Functionality 

· 📝 Claim Submission: Lecturers can submit monthly claims with hours worked and hourly rates · 🔄 Automatic Calculations: Real-time total amount calculation · 📊 Status Tracking: Visual progress bars and timeline for claim status · 👥 Role-based Views: Separate interfaces for lecturers and coordinators · 📎 Document Upload: Support for PDF, DOCX, and XLSX files with size validation · ✅ Approval Workflow: Streamlined approve/reject process for coordinators · 🕒 Real-time Updates: Auto-refresh status every 10 seconds 

🛡️ System Features 

· File Validation: Secure document upload with type and size restrictions · Error Handling: Graceful error management with user-friendly messages · Data Validation: Comprehensive input validation and model state checking · Unit Testing: 90%+ test coverage with xUnit and FluentAssertions 

🏗️ Architecture & Technology Stack 

Backend 

· Framework: ASP.NET Core 8.0 MVC · Language: C# 12.0 · Architecture: Model-View-Controller (MVC) · Testing: xUnit, Moq, FluentAssertions 

Frontend 

· UI Framework: Bootstrap 5.3 · Styling: Custom CSS with CSS Variables · Icons: Font Awesome 6.0 · Font: Inter (Google Fonts) 

Development Tools 

· IDE: Visual Studio 2022 · Version Control: Git & GitHub · Package Management: NuGet 

📁 Project Structure 

CMCS/ 
├── Controllers/ 
│   ├── HomeController.cs 
│   └── ClaimController.cs 
├── Models/ 
│   └── Claim.cs 
├── Views/ 
│   ├── Home/ 
│   ├── Claim/ 
│   │   ├── Index.cshtml 
│   │   ├── Submit.cshtml 
│   │   └── Details.cshtml 
│   └── Shared/ 
│       └── _Layout.cshtml 
├── wwwroot/ 
│   ├── css/ 
│   │   └── site.css 
│   └── uploads/ 
├── CMCS.Tests/ 
│   ├── Controllers/ 
│   │   └── ClaimControllerTests.cs 
│   ├── Models/ 
│   │   └── ClaimModelTests.cs 
│   └── ValidationTests.cs 
└── Program.cs 
 

🚀 Installation & Setup 

Prerequisites 

· .NET 8.0 SDK · Visual Studio 2022 or VS Code · Git 

Quick Start 

Clone the repositorygit clone https://github.com/yourusername/CMCS.git 
cd CMCS 
 

Open in Visual Studio · Open CMCS.sln in Visual Studio 2022 · Restore NuGet packages 

Build and Run · Press Ctrl + F5 to run without debugging · Or F5 to run with debugging 

Access the Application · Navigate to https://localhost:7000 · Default pages: Home, Submit Claim, View Claims 

Running Tests 

# Run all tests 
dotnet test 
 
# Run specific test project 
dotnet test CMCS.Tests 
 

🎮 How to Use 

For Lecturers 

Submit a Claim · Navigate to "Submit Claim" · Fill in lecturer name, month, hours worked, and hourly rate · Upload supporting documents (optional) · Submit the claim 

Track Status · View all claims on "View Claims" page · Monitor progress through status indicators · Check detailed timeline in claim details 

For Coordinators/Managers 

Review Claims · Access "View Claims" page · See all pending claims in the table · View claim details for more information 

Approve/Reject · Click "Approve" or "Reject" buttons · System updates status in real-time · Processed claims show coordinator name and timestamp 

🧪 Testing Strategy 

Unit Tests 

· Model Tests: Data validation, calculations, business logic · Controller Tests: Action methods, routing, response types · Validation Tests: Input validation, edge cases, boundary conditions 

Test Coverage 

· ✅ Claim model validation and calculations · ✅ Controller action methods · ✅ Business logic and workflows · ✅ Edge cases and error scenarios 

🎨 Design System 

Color Palette 

· Background: Dark Licorice #100311 · Text: Wisteria #CDA9EC · Primary: Indigo #580092 · Success: Teal #06D6A0 · Warning: Amber #F59E0B · Error: Pink #EF476F 

Typography 

· Primary Font: Inter (Sans-serif) · Weights: 300, 400, 500, 600, 700 · Line Height: 1.6 for optimal readability 

Components 

· Cards: Floating design with soft shadows · Buttons: Rounded corners with sinking animation · Forms: Clean inputs with focus states · Tables: Responsive with hover effects 

🔧 Configuration 

File Upload Settings 

· Allowed Types: PDF, DOCX, XLSX · Max File Size: 5MB per file · Storage: wwwroot/uploads directory 

Application Settings 

· Auto-refresh: 10 seconds for status updates · Session Timeout: Default ASP.NET Core settings · HTTPS: Enabled by default 

📈 Future Enhancements 

· Database Integration: Entity Framework with SQL Server · User Authentication: ASP.NET Identity with role management · Email Notifications: Status update emails · Reporting: PDF report generation · Advanced Analytics: Claim statistics and trends · API Endpoints: REST API for mobile applications · Admin Dashboard: Comprehensive administrative tools 

🤝 Contributing 

Fork the repository 

Create a feature branch (git checkout -b feature/AmazingFeature) 

Commit your changes (git commit -m 'Add some AmazingFeature') 

Push to the branch (git push origin feature/AmazingFeature) 

Open a Pull Request 

📄 License 

This project is licensed under the MIT License - see the LICENSE.md file for details. 

👥 Authors 

·Lunga2004 

🙏 Acknowledgments 

· PROG6212 Course for project requirements and guidance · ASP.NET Core documentation and community · Bootstrap team for the responsive framework · Font Awesome for the comprehensive icon set 

📞 Support 

For support, please open an issue on the GitHub repository or contact the development team. 

 

                      Built with ❤️ using ASP.NET Core 8.0  

https://img.shields.io/badge/CMCS-Contract_Monthly_Claim_System-purple https://img.shields.io/badge/ASP.NET_Core-8.0-informational https://img.shields.io/badge/License-MIT-blue 

📋 POE Requirements Checklist  

✅ Part 1: Project Planning & Prototype 

· UML Class Diagram for databases · Project plan with timeline · Non-functional WPF/MVC prototype · Design documentation (400-500 words) · GitHub repository with 5+ commits 

✅ Part 2: Functional Application 

· Claim submission with form validation · Coordinator approval system · Document upload functionality · Real-time status tracking · Unit tests for key functionalities · Error handling and validation · GitHub commits with descriptive messages 

✅ Part 3: Automation & Enhancement 

· Auto-calculation of total amounts · Enhanced user interface with modern design · Status tracking with progress indicators · Comprehensive unit testing  · Final documentation and evidence 

🎯 Key POE Deliverables 

· Functional CMCS Application with all required features · Comprehensive Documentation including design decisions · Unit Test Suite with high coverage · GitHub Repository with commit history · Professional Presentation materials 

This project was developed as part of the PROG6212 Portfolio of Evidence (POE) requirements.
