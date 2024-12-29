using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Oyun baþýnda ve içerisinde çýkan yazýlý kaðýtlara ait kod yýðýný

public class Dragabble : MonoBehaviour
{
	bool held = false;
	public float finalScale = 1;

	private Vector3 screenPoint;
	protected Vector3 offset;
	bool appearing = true;

	private void Start()
	{
		transform.localScale = new Vector3(.001f, .001f, 1);
		appearing = true;
	}

	protected void Update()
	{
		if(appearing && transform.localScale.x < finalScale)
		{
			transform.localScale += new Vector3(Time.deltaTime*3.5f, Time.deltaTime * 3.5f, 0);
		}
		else if (appearing)
		{
			transform.localScale = new Vector3(finalScale, finalScale, 1);
			appearing = false;
		}
	}

	protected void OnMouseDown()
	{
		if (OneriManager.instance.state == OyunSahneDurumu.Gameplay)
		{
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
			held = true;
		}
	}

	protected void OnMouseDrag()
	{
		if (OneriManager.instance.state == OyunSahneDurumu.Gameplay)
		{
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
			transform.position = curPosition;
		}
	}

	protected void OnMouseUp()
	{
		if (OneriManager.instance.state == OyunSahneDurumu.Gameplay)
		{
			if (held)
			{
				held = false;
			}
		}
	}
}
