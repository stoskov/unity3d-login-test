using System;
using UnityEngine;
using UnityEngine.UI;

public class LoginApi : MonoBehaviour
{
	public GameObject UsernameObject;
	public GameObject PasswordObject;
	public GameObject StatusTextObject;

	private TaskQueue TaskQueue;

	public void Awake()
	{
		this.TaskQueue = new TaskQueue();
	}

	public void Update()
	{
		this.TaskQueue.ProcessNext();
	}

	public void Login()
	{
		var username = this.UsernameObject.GetComponent<InputField>();
		var password = this.PasswordObject.GetComponent<InputField>();
		var status = this.StatusTextObject.GetComponent<Text>();
		var user = GameObject.Find("GameState").GetComponent<User>();

		this.TaskQueue.AddTask(new TaskQueue.Task(delegate
		{
			status.text = "Loading";
		}));

		ServerApi.Login(username.text, password.text, (response) =>
		{
			if (!String.IsNullOrEmpty(response.Message))
			{
				this.TaskQueue.AddTask(new TaskQueue.Task(delegate
				{
					status.text = response.Message;
				}));
			}
			else if (response == null)
			{
				this.TaskQueue.AddTask(new TaskQueue.Task(delegate
				{
					status.text = "Error";
				}));
			}
			else
			{
				this.TaskQueue.AddTask(new TaskQueue.Task(delegate
				{
					user.Username = response.Username;
					user.DisplayName = response.DisplayName;
					user.AccessToken = response.AccessToken;

					Application.LoadLevel("Game");
				}));
			}
		});
	}
}