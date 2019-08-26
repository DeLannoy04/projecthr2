using UnityEngine;
using System.Collections;

public class attackSystem : MonoBehaviour
{
	private void Update()
	{
		if(Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			if(touch.phase == TouchPhase.Began)
			{
				Shoot(touch.position,5);
			}
		}
		if(Input.GetMouseButtonDown(0))
		{
			//Shoot(Input.mousePosition);
			Shoot(Vector2.zero,5);
		}
	}

	void Shoot(Vector2 pos,int size)
	{
		Debug.Log(pos);
		float y = pos.y;
		float x = pos.x;
		int currentCircle = size;
		float row = 0;
		for (int i = 0; i < size; i++)
		{
			x = pos.x + row;
			y = pos.y + row;
			int index = 0;
			while (index < currentCircle)
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(new Vector3(x,y,transform.position.z));
				if(Physics.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0)), transform.TransformDirection(Vector3.forward), out hit, 10000))
				{
					Debug.Log(hit.collider.name);
				}
				y += 0.1f;
				x += 0.1f;
				index++;
			}
			index = 0;
			while (index < currentCircle)
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y, transform.position.z));
				if (Physics.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0)), transform.TransformDirection(Vector3.forward), out hit, 10000))
				{
					Debug.Log(hit.collider.name);
				}
				y += 0.1f;
				x -= 0.1f;
				index++;
			}
			index = 0;
			while (index < currentCircle)
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y, transform.position.z));
				if (Physics.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0)), transform.TransformDirection(Vector3.forward), out hit, 10000))
				{
					Debug.Log(hit.collider.name);
				}
				y -= 0.1f;
				x -= 0.1f;
				index++;
			}
			index = 0;
			while (index < currentCircle)
			{
				RaycastHit hit;
				if (Physics.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(x,y,0)),transform.TransformDirection(Vector3.forward),out hit,10000))
				{
					Debug.Log(hit.collider.name);
				}
				y -= 0.1f;
				x += 0.1f;
				index++;
			}
			row += 0.1f;
			currentCircle--;
		}
	}
}
