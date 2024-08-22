using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;
using Blazored.FluentValidation;
using FluentValidation;
using Microsoft.AspNetCore.Http.Timeouts;
using TeachingSite.Frontend.Converters;

namespace TeachingSite.Frontend.Models.QuestionModels;

public class QuestionDetails
{
	public int Id {get; set;}
	public required string Name {get; set;}
	public string? Prompt {get; set;} 
	[JsonConverter(typeof(StringConverter))]
	public string? SubjectId {get; set;}
	public required string Answer {get; set;}
	public List<string> WrongAnswers {get; set;} =[];
}
//This is unused, might be helpful later to switch to fluentValidator though
public class QuestionValidator: AbstractValidator<QuestionDetails>
{
	public QuestionValidator()
	{
		RuleFor(q => q.WrongAnswers)
			.Must(HaveNoDuplicates).WithMessage("There must be no duplicate answers.")
			.Must(HaveMaxThreeItems).WithMessage("A maximum of 3 wrong answers is allowed.")
			.Must(HaveNoTrueAnswer).WithMessage("Wrong answers must not contain the correct answer.");
		RuleFor(q => q.Name).NotEmpty().WithMessage("A name is required.");
		RuleFor(q => q.SubjectId).NotEmpty().WithMessage("A subject is required.");
		RuleFor(q => q.Answer).NotEmpty().WithMessage("An answer is required.");
	}
	
	private bool HaveNoDuplicates(List<string> list)
	{
		return list.Distinct().Count() == list.Count;
	}

	private bool HaveMaxThreeItems(List<string> list)
	{
		return list.Count <= 3;
	}
	private bool HaveNoTrueAnswer(QuestionDetails question,List<string> list)
	{
		return !list.Contains(question.Answer);
	}
	
}