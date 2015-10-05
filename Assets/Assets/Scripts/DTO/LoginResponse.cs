public class LoginResponse
{
	public string Message { get; set; }
	public string Username { get; set; }
	public string DisplayName { get; set; }
	public bool IsLoggedIn { get; set; }
	public string AccessToken { get; set; }
}