﻿namespace TechCareer.Models.Dtos.Company;

public class CompanyResponseDto
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string Description { get; set; } = string.Empty;
}