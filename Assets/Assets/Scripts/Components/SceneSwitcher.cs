using System;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
	public void Login()
	{
		Application.LoadLevel("Login");
	}

	public void Register()
	{
		Application.LoadLevel("Register");
	}
}