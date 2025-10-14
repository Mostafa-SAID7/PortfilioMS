├── Models/
│   ├── Entities/
│   │   ├── Project.cs
│   │   ├── Skill.cs
│   │   ├── ContactMessage.cs
│   │   ├── BlogPost.cs
│   │   ├── Education.cs
│   │   ├── Experience.cs
│   │   └── Base/
│   │       ├── BaseEntity.cs
│   │       └── AuditableEntity.cs
│   ├── Enums/
│   │   ├── ProjectStatus.cs
│   │   ├── SkillLevel.cs
│   │   ├── ContactStatus.cs
│   │   ├── BlogStatus.cs
│   │   └── NotificationType.cs
│   ├── ViewModels/
│   │   ├── Home/
│   │   │   ├── HomeViewModel.cs
│   │   │   └── DashboardViewModel.cs
│   │   ├── Projects/
│   │   │   ├── ProjectViewModel.cs
│   │   │   ├── ProjectListViewModel.cs
│   │   │   └── CreateProjectViewModel.cs
│   │   ├── Blog/
│   │   │   ├── BlogPostViewModel.cs
│   │   │   ├── BlogListViewModel.cs
│   │   │   └── CreateBlogPostViewModel.cs
│   │   ├── Contact/
│   │   │   ├── ContactViewModel.cs
│   │   │   └── ContactMessageViewModel.cs
│   │   └── Shared/
│   │       ├── PaginationViewModel.cs
│   │       └── SearchViewModel.cs
│   │
│   ├── DTOs/
│   │   ├── Requests/
│   │   │   ├── CreateProjectRequest.cs
│   │   │   ├── UpdateProjectRequest.cs
│   │   │   ├── ContactRequest.cs
│   │   │   └── BlogPostRequest.cs
│   │   └── Responses/
│   │       ├── ApiResponse.cs
│   │       ├── ProjectResponse.cs
│   │       ├── BlogPostResponse.cs
│   │       └── ContactResponse.cs
│   │
│   └── Config/
│       ├── EmailSettings.cs
│       ├── AppSettings.cs
│       └── CloudinarySettings.cs