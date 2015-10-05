using UnityEngine;

public class KeepAlive : MonoBehaviour
{
	public void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}
}