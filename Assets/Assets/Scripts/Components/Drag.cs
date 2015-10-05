using UnityEngine;

public class Drag : MonoBehaviour
{
	private Vector3 screenPoint;
	private Vector3 offset;

	private void OnMouseDown()
	{
		//	this.screenPoint = Camera.main.WorldToScreenPoint(this.gameObject.transform.InverseTransformPoint(this.gameObject.transform.position));
		//	this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 3, this.transform.position.z);

		//	this.offset = this.gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Time.deltaTime * 100);
	}

	private void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + this.offset;
		this.transform.position = curPosition;
	}
}