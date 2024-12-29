using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //textmeshpro için gerekli kütüphane

public enum OneriTipi 
{
	kabul_durumu,
	ret_durumu,
}

public class Oneri : Dragabble
{
	string oneri_prefab_üzerindeki_yazi;
	public bool isValid { get; private set; }
	public OneriTipi oneriTipiDegisken { get; private set; }
	public SpriteRenderer letterSprite;
	public TextMeshPro text; 
	/*TextMesh ile TextMeshPro componentleri arasýndaki fark: TextMeshPro ile textin bulunacaðý sýnýrlar belirlenebilir. 
	Text, TextMeshPro componenti sýnýrlarý içerisinde kalýr. Yazý bu sýnýr içerisine sýðmaz ise bir sonraki satýra geçer.
	Burada Textmeshpro kullanarak yazýnýn kaðýdýn dýþýna taþmasýný engelledim*/

	bool held = false;  //mouse ile bir obje tutuluyor mu? Baþlangýç durumu false olmalý

	bool isShrinking = false;
	bool isGrowing = false;

	//oneriGenerator'de rasgele oluþturulan metni, kaðýt üzerine yazdýran kod bloðu
	public void Initialise(string _oneriyazisi, bool _isValid, OneriTipi _type, float z)
	{
		float rotation = (Random.Range(0f, 1f) > .5f ? 1 : -1) * Random.Range(0f, 20f);

		transform.rotation = Quaternion.Euler(0, 0, rotation);
		transform.position = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-2.5f, 2.5f), -z - .5f);
		//oneri prefab'ýnýn ekranda rasgele noktalarda belirmesini saðlayan kod satýrý
		text.transform.position = new Vector3(text.transform.position.x, text.transform.position.y, -z - .5f);
		//prefab üzerindeki text objesinin konumunu kaðýda hizalayan kod satýrý

		oneri_prefab_üzerindeki_yazi = _oneriyazisi;
		isValid = _isValid;  //valid mi deðil mi? (mevcut mu? diyebiliriz ama tam anlamý vermiyor)
		oneriTipiDegisken = _type;

		text.text = oneri_prefab_üzerindeki_yazi;


		int index = Mathf.RoundToInt(Random.Range(0.5f, 4.49f));
		int specialOneri = Mathf.RoundToInt(Random.Range(0.5f, 9.49f));

		Texture2D tex;

		if (specialOneri == 1)
		{
			index = Mathf.RoundToInt(Random.Range(4.5f, 6.49f));
			tex = Resources.Load("Oneri" + index.ToString(), typeof(Texture2D)) as Texture2D;
		}
		else
		{
			tex = Resources.Load("Oneri" + index.ToString(), typeof(Texture2D)) as Texture2D;
		}

		//adjust collision for thinner letters
		if(index == 1 || index == 3 || index == 4)
		{
			GetComponent<BoxCollider2D>().size = new Vector2(GetComponent<BoxCollider2D>().size.x, 3.5f);
		}

		letterSprite.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
	}

	void OnMouseDown()
	{
		base.OnMouseDown();
		OneriManager.instance.objeTut(this);
	}

	void OnMouseUp()
	{
		OneriManager.instance.objeBirak(this);
		base.OnMouseUp();
	}

	public void Shrink()
	{
		offset = new Vector3(0, 0, offset.z);

		if (!isShrinking && !isGrowing)
			isShrinking = true;
	}

	public void Grow()
	{
		if (!isShrinking && !isGrowing)
			isGrowing = true;
	}

	void Update()
	{
		base.Update();

		if(isShrinking && transform.localScale.x > .2f)
		{
			transform.localScale -= new Vector3(5f, 5f, 0) * Time.deltaTime;
		}
		else if(isShrinking)
		{
			isShrinking = false;
		}

		if (isGrowing && transform.localScale.x < 1f)
		{
			transform.localScale += new Vector3(5f, 5f, 0) * Time.deltaTime;
		}
		else if (isGrowing)
		{
			isGrowing = false;
		}
	}
}
