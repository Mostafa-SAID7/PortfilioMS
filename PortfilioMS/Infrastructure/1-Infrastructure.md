Infrastructure/
│   ├── Caching/
│   │   ├── ICacheProvider.cs
│   │   ├── MemoryCacheProvider.cs
│   │   └── DistributedCacheProvider.cs
│   │
│   ├── Storage/
│   │   ├── IFileStorage.cs
│   │   ├── LocalFileStorage.cs
│   │   ├── AzureBlobStorage.cs
│   │   └── AWS3Storage.cs
│   │
│   ├── Email/
│   │   ├── IEmailProvider.cs
│   │   ├── SMTPEmailProvider.cs
│   │   ├── SendGridEmailProvider.cs
│   │   └── EmailTemplates/
│   │       ├── ContactNotification.html
│   │       ├── WelcomeEmail.html
│   │       └── PasswordReset.html
│   │
│   └── Security/
│       ├── IPasswordHasher.cs
│       ├── IJwtTokenGenerator.cs
│       ├── PasswordHasher.cs
│       └── JwtTokenGenerator.cs
│