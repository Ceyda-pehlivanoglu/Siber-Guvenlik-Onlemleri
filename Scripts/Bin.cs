using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Oyun içerisindeki kutulara ait kod yýðýný

public enum kutuTipi
{
	kabul,
	red,
	acilDurum,
	tip_null
}


public class Bin : MonoBehaviour
{
	public kutuTipi tip;

	void OnMouseEnter()
	{
		OneriManager.instance.kutuTipiAta(tip);
	}
	void OnMouseExit()
	{
		OneriManager.instance.kutuyaBirak(tip);
	}
}
