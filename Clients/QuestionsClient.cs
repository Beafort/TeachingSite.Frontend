using System;
using TeachingSite.Frontend.Models;

namespace TeachingSite.Frontend.Clients;

public class QuestionsClient
{
	private readonly List<QuestionSummary> questions =
	[
		new(){
			Id = 1,
			Name = "Whats 1 + 1",
			Prompt = "1 + 1 = ?",
			Subject = "Math",
			Answer ="2",
			WrongAnswers = new List<string> {"3","4"}
		},
		new(){
			Id = 2,
			Name = "Whats 1 + 2",
			Prompt = "1 + 2 = ?",
			Subject = "Math",
			Answer = "3",
			WrongAnswers = new List<string> {"1" , "2"}
		},
		new(){
			Id = 3,
			Name = "Whats 1 + 4",
			Prompt = "1 + 4 = ?",
			Subject = "Math",
			Answer ="5",
			WrongAnswers = new List<string> { "3", "4" }
		}
	];
	
	public QuestionSummary[] GetQuestions() => [.. questions];
	public QuestionDetails GetQuestion(int Id)
	{
		QuestionSummary question = GetQuestionSummaryById(Id);
		
		var subject = subjects.Single(subject => String.Equals(
			subject.Name,
			question.Subject,
			StringComparison.OrdinalIgnoreCase
		));
		return new QuestionDetails
		{
			Id = question.Id,
			Name = question.Name,
			SubjectId = subject.Id.ToString(),
			Prompt = question.Prompt,
			Answer = question.Answer,
			WrongAnswers = question.WrongAnswers.ToList(),
		};
	}

	public void UpdateQuestion(QuestionDetails updatedQuestion)
	{
		var subject = GetSubjectById(updatedQuestion.SubjectId);
		QuestionSummary existingQuestion = GetQuestionSummaryById(updatedQuestion.Id);
		existingQuestion.Name = updatedQuestion.Name;
		existingQuestion.Subject = subject.Name;
		existingQuestion.Prompt = updatedQuestion.Prompt;
		existingQuestion.Answer = updatedQuestion.Answer;
		existingQuestion.WrongAnswers = new List<string>(updatedQuestion.WrongAnswers);
	}

	public void AddQuestion(QuestionDetails question)
	{
		Subject subject = GetSubjectById(question.SubjectId);
		var questionSummary = new QuestionSummary
		{
			Id = questions.Count + 1,
			Name = question.Name,
			Subject = subject.Name,
			Prompt = question.Prompt,
			Answer = question.Answer,
			WrongAnswers = question.WrongAnswers,
		};
		questions.Add(questionSummary);
	}
	public void DeleteQuestion(int id)
	{
		QuestionSummary question = GetQuestionSummaryById(id);
		questions.Remove(question);
	}
	

	private Subject GetSubjectById(string? id)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(id);
		var subject = subjects.Single(subject => subject.Id == int.Parse(id));
		return subject;
	}
	private QuestionSummary GetQuestionSummaryById(int Id)
	{
		QuestionSummary? question = questions.Find(question => question.Id == Id);
		ArgumentNullException.ThrowIfNull(question);
		return question;
	}	
	private readonly Subject[] subjects = new SubjectsClient().GetSubjects();

}
