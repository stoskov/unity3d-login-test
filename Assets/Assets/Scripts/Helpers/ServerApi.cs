using System;
using RestSharp;

public static class ServerApi
{
	private const string ServerApiAddress = "http://api.animals-at-war.com:8080/api/";
	private const string LoginApi = "users/login";

	public static void Login(string username, string password, Action<LoginResponse> callback)
	{
		var client = new RestClient(ServerApi.ServerApiAddress);

		var request = new RestRequest(ServerApi.LoginApi, Method.POST);

		request.AddHeader("Accept", "application/json");
		request.RequestFormat = DataFormat.Json;
		request.AddBody(new
		{
			username = username,
			password = password
		});

		client.ExecuteAsync<LoginResponse>(request, response =>
		{
			callback(response.Data);
		});
	}
}