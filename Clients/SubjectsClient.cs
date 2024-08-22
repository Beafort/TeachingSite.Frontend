using System;
using TeachingSite.Frontend.Models;

namespace TeachingSite.Frontend.Clients;

public class SubjectsClient(HttpClient httpClient)
{
	public async Task<Subject[]> GetSubjectsAsync() 
		=> await httpClient.GetFromJsonAsync<Subject[]>("/subjects") ?? [];
}
