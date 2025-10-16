routes:
    /api/skills  == Api
    /Skills      == Mvc

controller: SkillsController.cs == Api
            skillController.cs  == Mvc
models/
    Skill.cs
    projectSkill.cs
    SkillProfile.cs
dtos/    
    SkillCreateDto.cs
    SkillUpdateDto.cs
    SkillReadDto.cs
viewmodels/
    SkillViewModel.cs
repositories/
    SkillRepository.cs
    ISkillRepository.cs
services/
    ISkillService.cs
    SkillService.cs

/Views/Skills/
    Index.cshtml
    Create.cshtml
    Edit.cshtml
    Delete.cshtml
    Details.cshtml

wwwroot/
    js/skills.js
    css/skills.css