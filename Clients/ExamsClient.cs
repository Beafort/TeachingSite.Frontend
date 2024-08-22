using System;
using Microsoft.AspNetCore.Mvc;
using TeachingSite.Frontend.Models;
using TeachingSite.Frontend.Models.ExamModels;
using TeachingSite.Frontend.Models.QuestionModels;

namespace TeachingSite.Frontend.Clients;

public class ExamsClient(HttpClient httpClient)
{
	private List<QuestionSummary> questions;

	public async Task InitializeQuestionsAsync(HttpClient httpClient)
	{
		questions = (await new QuestionsClient(httpClient).GetQuestionsAsync()).ToList();
	}
	private readonly List<ExamSummary> exams =
	[
		new()
		{
			Id =1,
			Name = "test",
			Subject = "Math",
		}	
	];
	
	public ExamSummary[] GetExams()
	{
		InitializeQuestionsAsync(httpClient);
		exams[0].Questions = questions;
		
		return [..exams];
	}
	
	
	
	
	
}
