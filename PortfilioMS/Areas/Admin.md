Areas/
│   └── Admin/
│       ├── Controllers/
│       │   ├── DashboardController.cs
│       │   ├── ProjectManagementController.cs
│       │   ├── BlogManagementController.cs
│       │   ├── ContactManagementController.cs
│       │   ├── SkillManagementController.cs
│       │   └── SettingsController.cs
│       │
│       ├── Views/
│       │   ├── Dashboard/
│       │   │   ├── Index.cshtml
│       │   │   └── Analytics.cshtml
│       │   ├── ProjectManagement/
│       │   │   ├── Index.cshtml
│       │   │   ├── Create.cshtml
│       │   │   ├── Edit.cshtml
│       │   │   ├── Details.cshtml
│       │   │   └── _ProjectForm.cshtml
│       │   ├── BlogManagement/
│       │   │   ├── Index.cshtml
│       │   │   ├── Create.cshtml
│       │   │   ├── Edit.cshtml
│       │   │   ├── Details.cshtml
│       │   │   └── _BlogForm.cshtml
│       │   ├── ContactManagement/
│       │   │   ├── Index.cshtml
│       │   │   ├── Details.cshtml
│       │   │   └── Reply.cshtml
│       │   ├── SkillManagement/
│       │   │   ├── Index.cshtml
│       │   │   ├── Create.cshtml
│       │   │   └── Edit.cshtml
│       │   ├── Settings/
│       │   │   ├── Index.cshtml
│       │   │   ├── Profile.cshtml
│       │   │   └── Security.cshtml
│       │   └── Shared/
│       │       ├── _AdminLayout.cshtml
│       │       ├── _AdminNavigation.cshtml
│       │       ├── _AdminSidebar.cshtml
│       │       ├── _AdminHeader.cshtml
│       │       ├── _AdminFooter.cshtml
│       │       └── Components/
│       │           ├── _StatsCard.cshtml
│       │           ├── _RecentActivity.cshtml
│       │           └── _QuickActions.cshtml
│       │
│       ├── ViewModels/
│       │   ├── DashboardViewModel.cs
│       │   ├── ProjectManagementViewModel.cs
│       │   ├── BlogManagementViewModel.cs
│       │   ├── ContactManagementViewModel.cs
│       │   └── SettingsViewModel.cs
│       │
│       └── Services/
│           ├── IAdminService.cs
│           └── AdminService.cs