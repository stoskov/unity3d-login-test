using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
	public GameObject Text;

	public void Start()
	{
		var gameState = GameObject.Find("GameState").GetComponent<User>();

		var text = this.Text.GetComponent<Text>();
		text.text = gameState.GetComponent<User>().Username;
	}
}