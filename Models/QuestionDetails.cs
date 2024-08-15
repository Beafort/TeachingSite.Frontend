using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.Timeouts;

namespace TeachingSite.Frontend.Models;

public class QuestionDetails
{
	public int Id {get; set;}
	[Required(ErrorMessage = "A name is required.")]
	public required string Name {get; set;}
	public string? Prompt {get; set;} 
	[Required(ErrorMessage = "A subject is required.")]
	public string? SubjectId {get; set;}
	[Required(ErrorMessage = "An answer is required.")]
	public required string Answer {get; set;}
	[MaxLength(3, ErrorMessage ="A maximum of 3 wrong answers is allowed")]
	public List<string> WrongAnswers {get; set;} =[];
}
