using System;
using TeachingSite.Frontend.Models;

namespace TeachingSite.Frontend.Clients;

public class SubjectsClient
{
	private readonly Subject[] subjects =
	[
		new()
		{
			Id = 1,
			Name = "Math"
		},
		new()
		{
			Id = 2,
			Name = "Geography"
		}
	];
	
	
	public Subject[] GetSubjects() => subjects;
}
