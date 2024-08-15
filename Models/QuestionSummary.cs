using System;

namespace TeachingSite.Frontend.Models;

public class QuestionSummary
{
	public int Id {get; set;}
	public required string Name {get; set;}
	public string? Prompt {get; set;} 
	public required string Subject {get; set;}
	public required string Answer {get; set;}
	public List<string> WrongAnswers {get; set;} = [];
}
