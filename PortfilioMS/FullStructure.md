PortfolioWebsite/
│
├── Controllers/
│   ├── HomeController.cs
│   ├── AboutController.cs
│   ├── ProjectsController.cs
│   ├── SkillsController.cs
│   ├── ContactController.cs
│   ├── BlogController.cs
│   └── Api/
│       ├── ProjectsApiController.cs
│       ├── BlogApiController.cs
│       └── ContactApiController.cs
│
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
│   │
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
│
├── Views/
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   ├── _AdminLayout.cshtml
│   │   ├── _Header.cshtml
│   │   ├── _Footer.cshtml
│   │   ├── _Navigation.cshtml
│   │   ├── _Sidebar.cshtml
│   │   ├── _Scripts.cshtml
│   │   ├── _Styles.cshtml
│   │   ├── Error.cshtml
│   │   ├── _NotificationPartial.cshtml
│   │   └── Components/
│   │       ├── ProjectCard.cshtml
│   │       ├── BlogCard.cshtml
│   │       └── SkillCard.cshtml
│   │
│   ├── Home/
│   │   ├── Index.cshtml
│   │   ├── Privacy.cshtml
│   │   └── Partial/
│   │       ├── _HeroSection.cshtml
│   │       ├── _AboutSection.cshtml
│   │       └── _StatsSection.cshtml
│   │
│   ├── About/
│   │   ├── Index.cshtml
│   │   └── Partial/
│   │       ├── _EducationTimeline.cshtml
│   │       └── _ExperienceTimeline.cshtml
│   │
│   ├── Projects/
│   │   ├── Index.cshtml
│   │   ├── Details.cshtml
│   │   ├── Category.cshtml
│   │   └── Partial/
│   │       ├── _ProjectFilter.cshtml
│   │       ├── _ProjectGrid.cshtml
│   │       └── _ProjectDetailsPartial.cshtml
│   │
│   ├── Skills/
│   │   ├── Index.cshtml
│   │   └── Partial/
│   │       ├── _SkillsByCategory.cshtml
│   │       └── _SkillProgress.cshtml
│   │
│   ├── Contact/
│   │   ├── Index.cshtml
│   │   ├── Success.cshtml
│   │   └── Partial/
│   │       └── _ContactForm.cshtml
│   │
│   ├── Blog/
│   │   ├── Index.cshtml
│   │   ├── Post.cshtml
│   │   ├── Category.cshtml
│   │   ├── Tag.cshtml
│   │   └── Partial/
│   │       ├── _BlogSidebar.cshtml
│   │       ├── _BlogCard.cshtml
│   │       └── _RecentPosts.cshtml
│   │
│   └── Shared/
│       └── Components/
│           ├── Pagination/
│           │   └── Default.cshtml
│           ├── Search/
│           │   └── Default.cshtml
│           └── Notification/
│               └── Toast.cshtml
│
├── Data/
│   ├── ApplicationDbContext.cs
│   ├── DatabaseInitializer.cs
│   ├── Interfaces/
│   │   ├── IApplicationDbContext.cs
│   │   └── IDatabaseInitializer.cs
│   │
│   ├── Migrations/ (auto-generated)
│   │
│   ├── Configurations/
│   │   ├── ProjectConfiguration.cs
│   │   ├── SkillConfiguration.cs
│   │   ├── BlogPostConfiguration.cs
│   │   ├── ContactMessageConfiguration.cs
│   │   ├── EducationConfiguration.cs
│   │   └── ExperienceConfiguration.cs
│   │
│   ├── Seeds/
│   │   ├── ProjectSeed.cs
│   │   ├── SkillSeed.cs
│   │   ├── BlogPostSeed.cs
│   │   ├── EducationSeed.cs
│   │   ├── ExperienceSeed.cs
│   │   └── SeedData.cs
│   │
│   └── Repository/
│       ├── Interfaces/
│       │   ├── IRepository.cs
│       │   ├── IProjectRepository.cs
│       │   ├── IBlogRepository.cs
│       │   ├── IContactRepository.cs
│       │   └── IUnitOfWork.cs
│       └── Implementations/
│           ├── Repository.cs
│           ├── ProjectRepository.cs
│           ├── BlogRepository.cs
│           ├── ContactRepository.cs
│           └── UnitOfWork.cs
│
├── Services/
│   ├── Interfaces/
│   │   ├── IEmailService.cs
│   │   ├── IProjectService.cs
│   │   ├── IBlogService.cs
│   │   ├── IContactService.cs
│   │   ├── IFileService.cs
│   │   ├── IImageService.cs
│   │   └── ICacheService.cs
│   │
│   └── Implementations/
│       ├── EmailService.cs
│       ├── ProjectService.cs
│       ├── BlogService.cs
│       ├── ContactService.cs
│       ├── FileService.cs
│       ├── ImageService.cs
│       ├── CacheService.cs
│       └── NotificationService.cs
│
├── wwwroot/
│   ├── css/
│   │   ├── site.css
│   │   ├── admin.css
│   │   ├── home.css
│   │   ├── projects.css
│   │   ├── blog.css
│   │   ├── contact.css
│   │   ├── responsive.css
│   │   └── components/
│   │       ├── buttons.css
│   │       ├── cards.css
│   │       ├── forms.css
│   │       └── animations.css
│   │
│   ├── js/
│   │   ├── site.js
│   │   ├── admin.js
│   │   ├── home/
│   │   │   ├── hero-animations.js
│   │   │   └── typewriter.js
│   │   ├── projects/
│   │   │   ├── project-filter.js
│   │   │   ├── project-modal.js
│   │   │   └── isotope-grid.js
│   │   ├── blog/
│   │   │   ├── blog-search.js
│   │   │   └── share-buttons.js
│   │   ├── contact/
│   │   │   ├── contact-form.js
│   │   │   └── form-validation.js
│   │   ├── shared/
│   │   │   ├── animations.js
│   │   │   ├── notifications.js
│   │   │   ├── ajax-helpers.js
│   │   │   └── utils.js
│   │   └── lib/
│   │       ├── custom/
│   │       │   ├── smooth-scroll.js
│   │       │   └── lazy-load.js
│   │       └── third-party/
│   │           ├── chartjs/
│   │           └── particlesjs/
│   │
│   ├── images/
│   │   ├── profile/
│   │   │   ├── avatar.jpg
│   │   │   ├── hero-bg.jpg
│   │   │   └── about.jpg
│   │   ├── projects/
│   │   │   ├── thumbnails/
│   │   │   ├── screenshots/
│   │   │   └── featured/
│   │   ├── blog/
│   │   │   ├── featured/
│   │   │   └── thumbnails/
│   │   ├── icons/
│   │   │   ├── skills/
│   │   │   ├── social/
│   │   │   └── ui/
│   │   ├── logos/
│   │   │   ├── companies/
│   │   │   └── education/
│   │   └── background/
│   │       ├── patterns/
│   │       └── gradients/
│   │
│   ├── lib/
│   │   ├── bootstrap/
│   │   ├── jquery/
│   │   ├── font-awesome/
│   │   ├── chart.js/
│   │   ├── particles.js/
│   │   └── prism/
│   │
│   ├── fonts/
│   │   ├── custom/
│   │   └── icon-fonts/
│   │
│   └── documents/
│       ├── resume.pdf
│       ├── cv.pdf
│       └── portfolio.pdf
│
├── Areas/
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
│
├── Helpers/
│   ├── ImageHelper.cs
│   ├── ValidationHelper.cs
│   ├── EmailHelper.cs
│   ├── SecurityHelper.cs
│   ├── FileHelper.cs
│   ├── StringHelper.cs
│   ├── DateTimeHelper.cs
│   └── UrlHelper.cs
│
├── Utilities/
│   ├── Constants/
│   │   ├── AppConstants.cs
│   │   ├── RoleConstants.cs
│   │   ├── CacheConstants.cs
│   │   └── FileConstants.cs
│   │
│   ├── Enums/
│   │   ├── ProjectStatus.cs
│   │   ├── SkillLevel.cs
│   │   ├── ContactStatus.cs
│   │   ├── BlogStatus.cs
│   │   └── NotificationType.cs
│   │
│   ├── Extensions/
│   │   ├── StringExtensions.cs
│   │   ├── DateTimeExtensions.cs
│   │   ├── EnumExtensions.cs
│   │   ├── QueryableExtensions.cs
│   │   ├── ServiceCollectionExtensions.cs
│   │   └── ApplicationBuilderExtensions.cs
│   │
│   └── Results/
│       ├── OperationResult.cs
│       ├── PagedResult.cs
│       └── ApiResult.cs
│
├── Middleware/
│   ├── ExceptionHandlerMiddleware.cs
│   ├── RequestLoggingMiddleware.cs
│   ├── PerformanceMiddleware.cs
│   └── SecurityHeadersMiddleware.cs
│
├── Filters/
│   ├── CustomExceptionFilter.cs
│   ├── ValidationFilter.cs
│   ├── LogActionFilter.cs
│   └── AdminAuthorizationFilter.cs
│
├── Attributes/
│   ├── ValidateMimeMultipartContentFilter.cs
│   ├── FileSizeAttribute.cs
│   ├── AllowedExtensionsAttribute.cs
│   └── SanitizeHtmlAttribute.cs
│
├── Configuration/
│   ├── EmailSettings.cs
│   ├── CloudinarySettings.cs
│   ├── CacheSettings.cs
│   └── AppSettings.cs
│
├── BackgroundServices/
│   ├── EmailBackgroundService.cs
│   ├── CacheBackgroundService.cs
│   └── DatabaseCleanupService.cs
│
├── HostedServices/
│   ├── SeedDataHostedService.cs
│   └── CacheWarmupService.cs
│
├── HealthChecks/
│   ├── DatabaseHealthCheck.cs
│   ├── EmailHealthCheck.cs
│   └── CustomHealthCheck.cs
│
├── Logging/
│   ├── CustomLogger.cs
│   ├── DatabaseLogger.cs
│   └── LogEvents.cs
│
├── Mappings/
│   ├── Profiles/
│   │   ├── ProjectProfile.cs
│   │   ├── BlogProfile.cs
│   │   ├── ContactProfile.cs
│   │   └── AutoMapperProfile.cs
│   │
│   └── Extensions/
│       ├── ProjectMappings.cs
│       ├── BlogMappings.cs
│       └── ContactMappings.cs
│
├── Validators/
│   ├── ProjectValidators/
│   │   ├── CreateProjectValidator.cs
│   │   └── UpdateProjectValidator.cs
│   ├── BlogValidators/
│   │   ├── CreateBlogPostValidator.cs
│   │   └── UpdateBlogPostValidator.cs
│   ├── ContactValidators/
│   │   └── ContactMessageValidator.cs
│   └── CustomValidators/
│       ├── FileSizeValidator.cs
│       └── AllowedExtensionsValidator.cs
│
├── Infrastructure/
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
├── appsettings.json
├── appsettings.Development.json
├── appsettings.Production.json
├── Program.cs
├── PortfolioWebsite.csproj
├── Dockerfile
├── docker-compose.yml
├── .dockerignore
├── .gitignore
├── README.md
├── CHANGELOG.md
├── LICENSE
└── docs/
    ├── API.md
    ├── DEPLOYMENT.md
    ├── DEVELOPMENT.md
    └── database/
        ├── schema.sql
        └── seed-data.sql