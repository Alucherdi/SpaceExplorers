using UnityEngine;

public class CursorLookForward : MonoBehaviour
{
	private Vector3 DirectionPlayer;
	private float finalRotationY;

	void Update ()
	{
		if (Input.GetMouseButton (1))
		{
			DirectionPlayer = Input.mousePosition - new Vector3 (Screen.width / 2, Screen.height / 2, 0f);
			finalRotationY = Mathf.Atan2 (DirectionPlayer.y, DirectionPlayer.x) * Mathf.Rad2Deg;
			this.transform.rotation = Quaternion.Euler (90f, 0f, finalRotationY + 90f);
		}
	}
}
