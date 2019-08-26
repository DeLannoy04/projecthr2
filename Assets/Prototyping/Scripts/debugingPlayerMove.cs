using UnityEngine;
using System.Collections;

public class debugingPlayerMove : MonoBehaviour
{
	public float speed;

	void Update()
	{
		float move = speed * Input.GetAxis("Horizontal") * Time.deltaTime;

		transform.Translate(move, 0, 0);
	}
}
