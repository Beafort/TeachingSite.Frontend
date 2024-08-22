using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;
using Blazored.FluentValidation;
using FluentValidation;
using Microsoft.AspNetCore.Http.Timeouts;
using TeachingSite.Frontend.Models.QuestionModels;

namespace TeachingSite.Frontend.Models.ExamModels;

public class ExamDetails
{
	public int Id { get; set; }
	[Required]
	public required string Name { get; set; }
	[Required]
	public required string SubjectId { get; set; }
	public List<int>? Questions { get; set; }
}