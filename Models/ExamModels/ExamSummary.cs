using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Blazored.FluentValidation;
using FluentValidation;
using Microsoft.AspNetCore.Http.Timeouts;
using TeachingSite.Frontend.Models.QuestionModels;

namespace TeachingSite.Frontend.Models.ExamModels;

public class ExamSummary
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Subject { get; set; }
    public List<QuestionSummary>? Questions { get; set; }
}