using System;
using TeachingSite.Frontend.Models;
using TeachingSite.Frontend.Models.QuestionModels;

namespace TeachingSite.Frontend.Clients;

public class QuestionsClient(HttpClient httpClient)
{
	public async  Task<QuestionSummary[]> GetQuestionsAsync() 
		=> await httpClient.GetFromJsonAsync<QuestionSummary[]>("questions") ?? [];
	public async Task<QuestionDetails> GetQuestionAsync(int id)
		=> await httpClient.GetFromJsonAsync<QuestionDetails>($"questions/{id}") 
			?? throw new Exception("Could not find question!");

	public async Task UpdateQuestionAsync(QuestionDetails updatedQuestion)
		=> await httpClient.PutAsJsonAsync<QuestionDetails>($"questions/{updatedQuestion.Id}", updatedQuestion);

	public async Task AddQuestionAsync(QuestionDetails question)
		=> await httpClient.PostAsJsonAsync("questions", question);
	public async Task DeleteQuestionAsync(int id)
		=> await httpClient.DeleteAsync($"questions/{id}");
	

}
