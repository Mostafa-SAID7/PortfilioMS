# Complete ASP.NET MVC Portfolio Website Development Prompt

## Project Overview
I want to build a professional portfolio website using ASP.NET MVC (.NET 9) 
with the following specifications:

---

## PHASE 1: Project Setup & Configuration

### 1.1 Initial Setup
```
Create a new ASP.NET MVC project with:
- .NET 9 framework
- Entity Framework Core for database
- SQL Server as database provider
- Bootstrap 5 for responsive design
- Font Awesome for icons
- jQuery for client-side interactions

Provide the complete Program.cs with all necessary service configurations including:
- DbContext registration
- Dependency injection setup
- Static files configuration
- Routing configuration
- Session and authentication setup
```

### 1.2 Database Configuration
```
Create appsettings.json with:
- Connection string for SQL Server
- Email service settings (SMTP)
- Application settings
- Logging configuration

Also create appsettings.Development.json for development environment
```

---

## PHASE 2: Database Models & Context

### 2.1 Create Entity Models
```
Create the following models in the Models folder:

1. Project.cs with properties:
   - Id (int, primary key)
   - Title (string, required)
   - Description (string, required)
   - LongDescription (string)
   - Technologies (string - comma separated)
   - ImageUrl (string)
   - GithubUrl (string)
   - LiveDemoUrl (string)
   - Category (string)
   - StartDate (DateTime)
   - EndDate (DateTime, nullable)
   - IsFeatured (bool)
   - DisplayOrder (int)
   - CreatedAt (DateTime)

2. Skill.cs with properties:
   - Id
   - Name
   - Category (Frontend, Backend, Database, Tools, etc.)
   - ProficiencyLevel (1-100)
   - Icon (string - for Font Awesome icon class)
   - DisplayOrder

3. Education.cs with properties:
   - Id
   - Degree
   - Institution
   - StartDate
   - EndDate
   - Description
   - Grade/GPA

4. Experience.cs with properties:
   - Id
   - JobTitle
   - Company
   - Location
   - StartDate
   - EndDate (nullable)
   - Description
   - Responsibilities (string array or list)
   - IsCurrentJob (bool)

5. ContactMessage.cs with properties:
   - Id
   - Name
   - Email
   - Subject
   - Message
   - SentDate
   - IsRead
   - IpAddress

6. BlogPost.cs with properties:
   - Id
   - Title
   - Slug
   - Content
   - Summary
   - ImageUrl
   - Category
   - Tags
   - PublishedDate
   - IsPublished
   - ViewCount

7. SocialLink.cs with properties:
   - Id
   - Platform (LinkedIn, GitHub, Twitter, etc.)
   - Url
   - Icon
   - DisplayOrder

Include proper data annotations for validation on all models.
```

### 2.2 Create ViewModels
```
Create ViewModels in Models/ViewModels/:

1. HomeViewModel.cs - combining data for home page
2. AboutViewModel.cs - for about page with education, experience, skills
3. ProjectsViewModel.cs - with filtering options
4. ContactViewModel.cs - for contact form
5. ProjectDetailsViewModel.cs

Each ViewModel should have appropriate properties and validation attributes.
```

### 2.3 Database Context
```
Create Data/ApplicationDbContext.cs with:
- DbSet for each entity
- OnModelCreating method for:
  * Configuring relationships
  * Setting default values
  * Configuring indexes
  * Seed data for skills, social links, and sample projects

Include fluent API configurations for all entities.
```

### 2.4 Database Migration
```
Provide the commands to:
- Add initial migration
- Update database
- Create seed data migration
```

---

## PHASE 3: Repository Pattern & Services

### 3.1 Generic Repository
```
Create Repositories/IRepository.cs interface with generic CRUD methods:
- GetAll()
- GetById(id)
- Add(entity)
- Update(entity)
- Delete(id)
- Find(expression)
- SaveChanges()

Create Repositories/Repository.cs implementing IRepository<T>
```

### 3.2 Unit of Work
```
Create Repositories/IUnitOfWork.cs and UnitOfWork.cs for managing repositories and transactions
```

### 3.3 Services
```
Create Services folder with:

1. IEmailService.cs and EmailService.cs for:
   - SendContactEmail()
   - SendWelcomeEmail()
   - Email template support

2. IProjectService.cs and ProjectService.cs for:
   - GetAllProjects()
   - GetFeaturedProjects()
   - GetProjectsByCategory()
   - SearchProjects()

3. ISkillService.cs and SkillService.cs
4. IBlogService.cs and BlogService.cs

Each service should handle business logic and use the repository pattern.
```

---

## PHASE 4: Controllers

### 4.1 HomeController
```
Create Controllers/HomeController.cs with actions:
- Index() - Display hero section, featured projects, skills summary
- Privacy()
- Error()

Use dependency injection for required services.
Include proper error handling and logging.
```

### 4.2 ProjectsController
```
Create Controllers/ProjectsController.cs with:
- Index() - List all projects with filtering and pagination
- Details(id) - Show single project details
- Filter by category
- Search functionality

Include ViewBag/ViewData for page titles and meta descriptions.
```

### 4.3 AboutController
```
Create Controllers/AboutController.cs with:
- Index() - Display bio, education, experience, skills
- Download resume functionality
```

### 4.4 ContactController
```
Create Controllers/ContactController.cs with:
- Index() - Display contact form
- Submit() [HttpPost] - Handle form submission
  * Validate input
  * Save to database
  * Send email notification
  * Return success message
- Include anti-forgery token validation
```

### 4.5 BlogController
```
Create Controllers/BlogController.cs with:
- Index() - List all published posts
- Post(slug) - Display single blog post
- Category(category) - Filter by category
- Search(query) - Search posts
```

### 4.6 SkillsController
```
Create Controllers/SkillsController.cs with:
- Index() - Display all skills grouped by category
```

---

## PHASE 5: Views & Layout

### 5.1 Shared Layout
```
Create Views/Shared/_Layout.cshtml with:
- Modern, clean navigation bar
- Responsive menu for mobile
- Footer with social links and copyright
- Links to CSS and JS files
- Font Awesome CDN
- Bootstrap CDN
- jQuery CDN
- Custom CSS and JS references
```

### 5.2 Navigation Partial
```
Create Views/Shared/_Navigation.cshtml with:
- Sticky header on scroll
- Active menu highlighting
- Mobile hamburger menu
- Smooth scroll to sections
- Professional styling
```

### 5.3 Footer Partial
```
Create Views/Shared/_Footer.cshtml with:
- Social media links
- Quick links
- Copyright information
- Contact information
- Back to top button
```

### 5.4 Home Views
```
Create Views/Home/Index.cshtml with sections:

1. Hero Section:
   - Full-screen background
   - Your name and title
   - Animated typed.js effect for roles
   - Call-to-action buttons (View Projects, Contact Me)
   - Professional photo

2. About Summary:
   - Brief introduction
   - Key highlights
   - Statistics (Years of Experience, Projects Completed, etc.)

3. Featured Projects:
   - Card-based layout
   - Hover effects
   - Technology tags
   - Links to details

4. Skills Summary:
   - Top skills with progress bars
   - Icon representations

5. Call to Action:
   - Contact section
   - Download resume button

Use modern CSS animations and transitions.
```

### 5.5 About Page
```
Create Views/About/Index.cshtml with:
- Professional profile section
- Detailed bio
- Education timeline
- Work experience timeline
- Skills section (grouped by category)
- Certifications
- Download resume button
- Professional achievements

Use timeline design for education and experience.
Include smooth animations on scroll.
```

### 5.6 Projects Pages
```
Create Views/Projects/Index.cshtml with:
- Grid layout (responsive: 3 columns desktop, 2 tablet, 1 mobile)
- Filter buttons by category
- Search bar
- Sort options (Date, Name, Featured)
- Project cards with:
  * Thumbnail image
  * Title
  * Short description
  * Technology badges
  * View Details button
  * GitHub and Live Demo links
- Pagination controls
- Loading animations

Create Views/Projects/Details.cshtml with:
- Full project information
- Image gallery/carousel
- Technologies used
- Features list
- Challenges and solutions
- Links (GitHub, Live Demo, Documentation)
- Related projects section
- Back to projects button
```

### 5.7 Skills Page
```
Create Views/Skills/Index.cshtml with:
- Skills grouped by category
- Visual representation:
  * Progress bars
  * Circular progress (with percentage)
  * Icon grid
- Smooth animations on scroll
- Filter/toggle between categories
- Interactive hover effects
```

### 5.8 Contact Page
```
Create Views/Contact/Index.cshtml with:
- Contact form:
  * Name (required)
  * Email (required, email validation)
  * Subject (required)
  * Message (required, textarea)
  * Submit button with loading state
- Client-side and server-side validation
- Success/error messages
- Contact information display:
  * Email address
  * Social media links
  * Location (optional)
- Google Maps embed (optional)
- Anti-spam measures

Create Views/Contact/Success.cshtml for successful submission
```

### 5.9 Blog Pages
```
Create Views/Blog/Index.cshtml with:
- Blog post list
- Featured post section
- Sidebar with:
  * Categories
  * Recent posts
  * Tags cloud
- Pagination
- Search functionality

Create Views/Blog/Post.cshtml with:
- Full post content
- Author info
- Published date
- Category and tags
- Social share buttons
- Related posts
- Comments section (optional)
```

---

## PHASE 6: Admin Area

### 6.1 Admin Setup
```
Create Areas/Admin folder structure with:
- Controllers/
- Views/
- Models/

Configure area routing in Program.cs
```

### 6.2 Authentication
```
Implement ASP.NET Core Identity with:
- User registration
- Login/Logout
- Role-based authorization (Admin role)
- Password reset functionality

Create AccountController with:
- Login action and view
- Register action (for initial admin only)
- Logout action
```

### 6.3 Admin Dashboard
```
Create Areas/Admin/Controllers/DashboardController.cs with:
- Index() - Display statistics:
  * Total projects
  * Total messages
  * Total blog posts
  * Recent activity

Create corresponding view with charts and statistics
```

### 6.4 Project Management
```
Create Areas/Admin/Controllers/ProjectManagementController.cs with CRUD:
- Index() - List all projects
- Create() - Add new project
- Edit(id) - Update project
- Delete(id) - Remove project
- Upload images functionality

Create all corresponding views with forms including:
- Image upload
- Rich text editor for descriptions
- Technology multi-select
- Date pickers
- Form validation
```

### 6.5 Message Management
```
Create controller and views to:
- View all contact messages
- Mark as read
- Delete messages
- Reply to messages
```

### 6.6 Blog Management
```
Create controller and views for:
- CRUD operations on blog posts
- Rich text editor (TinyMCE or CKEditor)
- Image upload for post content
- Publish/Unpublish functionality
- SEO settings (meta description, keywords)
```

---

## PHASE 7: Static Files & Styling

### 7.1 CSS Files
```
Create wwwroot/css/site.css with:
- CSS custom properties (variables) for colors, fonts, spacing
- Modern color scheme (professional portfolio colors)
- Typography system
- Utility classes
- Responsive breakpoints

Create wwwroot/css/home.css for homepage specific styles
Create wwwroot/css/projects.css for projects pages
Create wwwroot/css/animations.css for all animations and transitions

Include:
- Smooth scroll behavior
- Hover effects
- Fade-in animations
- Slide animations
- Card hover effects
- Button styles and states
- Form styling
- Modern gradient backgrounds
- Box shadows and depth
```

### 7.2 JavaScript Files
```
Create wwwroot/js/site.js with:
- Navigation scroll behavior
- Active menu highlighting
- Mobile menu toggle
- Back to top button functionality
- Smooth scroll to anchors

Create wwwroot/js/animations.js with:
- Scroll reveal animations
- Counter animations for statistics
- Typed.js integration for hero section
- Progress bar animations

Create wwwroot/js/contact-form.js with:
- Form validation
- AJAX form submission
- Loading states
- Success/error message display
```

### 7.3 Additional Assets
```
Provide guidance for:
- Image optimization
- Favicon generation (multiple sizes)
- Social media meta tags (Open Graph)
- robots.txt
- sitemap.xml
```

---

## PHASE 8: Additional Features

### 8.1 SEO Optimization
```
Implement:
- Meta tags for each page
- Canonical URLs
- Open Graph tags
- Twitter Card tags
- Structured data (JSON-LD)
- XML sitemap generation
- robots.txt configuration
```

### 8.2 Performance Optimization
```
Add:
- Image lazy loading
- CSS and JS minification
- Bundle and minification configuration
- Caching strategies
- Compression middleware
```

### 8.3 Security Features
```
Implement:
- Anti-forgery tokens
- Input validation and sanitization
- HTTPS enforcement
- CORS policy
- Content Security Policy headers
- Rate limiting for contact form
```

### 8.4 Error Handling
```
Create:
- Custom error pages (404, 500)
- Global exception handling
- Logging with Serilog or NLog
- User-friendly error messages
```

### 8.5 Responsive Design
```
Ensure all pages are fully responsive:
- Mobile-first approach
- Breakpoints: 320px, 576px, 768px, 992px, 1200px, 1400px
- Touch-friendly elements
- Optimized images for different screen sizes
```

---

## PHASE 9: Testing & Deployment

### 9.1 Testing
```
Provide guidance for:
- Unit testing controllers
- Integration testing
- Form validation testing
- Responsive design testing checklist
```

### 9.2 Deployment
```
Provide step-by-step guide for:
- Publishing to IIS
- Publishing to Azure App Service
- Database migration in production
- Environment-specific configurations
- SSL certificate setup
```

---

## Additional Requirements

### Design Specifications
```
- Use a modern, professional color scheme (suggest options)
- Typography: Use Google Fonts (2-3 complementary fonts)
- Icons: Font Awesome 6
- Animations: Subtle and professional, not overwhelming
- White space: Adequate spacing for readability
- Consistency: Maintain design consistency across all pages
```

### Best Practices
```
Follow these principles:
- Clean code with proper comments
- SOLID principles
- DRY (Don't Repeat Yourself)
- Separation of concerns
- Async/await for database operations
- Proper error handling and logging
- Secure coding practices
- Accessibility (WCAG 2.1 guidelines)
```

### Content Suggestions
```
Provide placeholder content for:
- Hero section taglines
- About me bio template
- Sample projects (3-5)
- Sample skills by category
- Footer text
- Privacy policy basic template
```

---

## Delivery Format

Please provide the code in the following order:
1. Project structure overview
2. Configuration files (appsettings.json, Program.cs)
3. Models and ViewModels
4. DbContext and migrations
5. Repositories and Services
6. Controllers (one at a time)
7. Views (organized by controller)
8. Static files (CSS, JS)
9. Admin area (if we reach this point)
10. Deployment guide

For each component, provide:
- Complete, production-ready code
- Inline comments explaining complex logic
- Usage examples where applicable

---

## Questions to Answer First

Before starting, please confirm:
1. Which .NET version should I target? (.NET 6, 7, or 8)
2. Should I include a blog section or skip it?
3. Do you want a dark mode toggle feature?
4. Should I include analytics integration (Google Analytics)?
5. Do you need multi-language support?
6. Should projects support multiple images/gallery?
7. Do you want visitor statistics tracking?

---

Let's start with PHASE 1 and proceed step by step. After each phase, I'll review and provide feedback before moving to the next phase.