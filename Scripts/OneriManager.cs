
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Oyunun bulunduðu durum, oyun içerisindeki objelerin tanýmlarý, oyun oynanma mekanikleri, can/skor sayacý vb. mekanik/sayaç ögelerini bulunduran yönetici kod bloðu

public enum OyunSahneDurumu
{
	Start,
	Gameplay,
	End
}


public class OneriManager : MonoBehaviour
{
	public OneriGenerator generator;
	public Oneri heldLetter;
	public kutuTipi hoveredBin = kutuTipi.tip_null;
	public Slider slider;
	public Image deathWheel;

	public OyunSahneDurumu state { get; private set; } = OyunSahneDurumu.Start;

	float olum_sayaci = 0;
	int hata_sayaci = 0;

	public GameObject cross1;
	public GameObject cross2;
	public GameObject cross3;
	public GameObject cross4;
	public GameObject cross5;

	const int toplam_hata = 5;
	const float toplam_olum = 15;

	public Text skor_metni;

	public static OneriManager instance = null;

	GameObject letterObject;

	public GameObject endScreen;
	public GameObject startScreen;
	public GameObject gameplayScreen;
	public Text sonskor;

	float spawn_countdown = 10;
	bool initial_spawn_countdown = true;

	float value_count = 0;

	public int lira_cinsi_skor { get; private set; } = 0;
	public int kurus_cinsi_skor { get; private set; } = 0;


	// Start is called before the first frame update
	void Start()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(this);

		letterObject = (GameObject)Resources.Load("oneripre");
	}

	// Update is called once per frame
	void Update()
	{
		if (state == OyunSahneDurumu.Gameplay)
		{
			spawn_countdown -= Time.deltaTime;

			//not belirdikten sonraki 10sn öneri gelmez
			if (!initial_spawn_countdown && value_count < .5f && spawn_countdown > 2f)
			{
				spawn_countdown = Random.Range(.25f, 2f);
			}
			else if (spawn_countdown < 0)
			{
				initial_spawn_countdown = false;
				spawn_countdown = Mathf.Max(0.25f, Random.Range(3.2f, 6.5f) - ((float)lira_cinsi_skor + kurus_cinsi_skor * 100) / 45f);
				oneriEkle();
			}

			if (heldLetter && hoveredBin != kutuTipi.tip_null)
			{
				heldLetter.Shrink();
			}
			else if (heldLetter && hoveredBin == kutuTipi.tip_null)
			{
				heldLetter.Grow();
			}

			if (value_count >= 19)
			{
				olum_sayaci += Time.deltaTime;
				deathWheel.fillAmount = olum_sayaci / toplam_olum;
			}
			else if (olum_sayaci >= 0)
			{
				olum_sayaci -= Time.deltaTime;
				deathWheel.fillAmount = olum_sayaci / toplam_olum;
			}

			if (olum_sayaci >= toplam_olum || hata_sayaci >= toplam_hata)
			{
				state = OyunSahneDurumu.End;
				gameplayScreen.SetActive(false);
				Debug.Log("end");
				endScreen.SetActive(true);
				sonskor.text = "Skor:" + kurus_cinsi_skor.ToString() + (lira_cinsi_skor < 10 ? "0" : "") + lira_cinsi_skor.ToString();
			}
		}
	}

	public void objeTut(Oneri letter)
	{
		heldLetter = letter;
	}

	public void objeBirak(Oneri letter)
	{
		if (state != OyunSahneDurumu.Gameplay)
			return;

		if (letter == heldLetter)
		{
			if (hoveredBin == kutuTipi.tip_null)
				heldLetter = null;
			else
			{
				if (letter.isValid)
				{
					if (letter.oneriTipiDegisken == OneriTipi.kabul_durumu && hoveredBin == kutuTipi.kabul)
					{
						Debug.Log("obje_birak basarili");
						skorSayac(5);
						oneriSil(letter);
						return;
					}
					else if (letter.oneriTipiDegisken == OneriTipi.ret_durumu && hoveredBin == kutuTipi.red)
					{
						Debug.Log("obje_birak basarili");
						skorSayac(5);
						oneriSil(letter);
						return;
					}

					hataSayac();
					Debug.Log("obje_birak fonk. hatasi");
					oneriSil(letter);
					return;
				}
				else
				{
					if (hoveredBin != kutuTipi.acilDurum)
					{
						hataSayac();
						Debug.Log("obje_birak fonk. hatasi");
						oneriSil(letter);
						return;
					}
					else
					{
						skorSayac(1);
						Debug.Log("obje_birak basarili");
						oneriSil(letter);
					}
				}
			}
		}
		else
			Debug.LogWarning("Tried to release letter that isn't held.");
	}

	public void kutuTipiAta(kutuTipi type)
	{
		hoveredBin = type;
	}

	public void kutuyaBirak(kutuTipi type)
	{
		if (hoveredBin == type)
			hoveredBin = kutuTipi.tip_null;
		else
			Debug.LogWarning("kutuya_birak fonk. hatasý");
	}

	void skorSayac(int delta)
	{
		lira_cinsi_skor += delta;
		if (lira_cinsi_skor >= 100)
		{
			kurus_cinsi_skor++;
			lira_cinsi_skor -= 100;
		}
		skor_metni.text = "Skor:" + kurus_cinsi_skor.ToString() +  (lira_cinsi_skor < 10 ? "0" : "") + lira_cinsi_skor.ToString();
	}

	void oneriEkle()
	{
		GameObject instantiated = Instantiate(letterObject);
		generator.Generate(instantiated.GetComponent<Oneri>());
		value_count += instantiated.GetComponent<Oneri>().oneriTipiDegisken == OneriTipi.kabul_durumu ? 1.5f : 1;
		slider.value = value_count;
	}

	void oneriSil(Oneri letter)
	{
		value_count -= letter.oneriTipiDegisken == OneriTipi.kabul_durumu ? 1.5f : 1;
		Destroy(letter.gameObject);
		slider.value = value_count;
	}

	void hataSayac()
	{
		hata_sayaci++;

		switch (hata_sayaci)
		{
			case 1:
				cross1.SetActive(true);
				break;
			case 2:
				cross2.SetActive(true);
				break;
			case 3:
				cross3.SetActive(true);
				break;
			case 4:
				cross4.SetActive(true);
				break;
			case 5:
				cross5.SetActive(true);
				break;
		}

	}

	public void Reset()
	{
		cross1.SetActive(false);
		cross2.SetActive(false);
		cross3.SetActive(false);
		cross4.SetActive(false);
		cross5.SetActive(false);
		lira_cinsi_skor = 0;
		kurus_cinsi_skor = 0;
		skor_metni.text = "Skor:" + kurus_cinsi_skor.ToString() + (lira_cinsi_skor < 10 ? "0" : "") + lira_cinsi_skor.ToString();

		value_count = 0;

		olum_sayaci = 0;
		hata_sayaci = 0;

		deathWheel.fillAmount = 0;
		slider.value = 0;

		foreach (Object draggable in FindObjectsOfType<Dragabble>())
		{
			Destroy(((Dragabble)draggable).gameObject);
		}

		GameObject note = (GameObject)Instantiate(Resources.Load("Baslangic_notu"));
		note.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-2.5f, 2.5f), -9.0f);
		generator.SetDifficulty(0);
		initial_spawn_countdown = true;
		spawn_countdown = 10f;
		state = OyunSahneDurumu.Gameplay;
		gameplayScreen.SetActive(true);
		startScreen.SetActive(false);
		endScreen.SetActive(false);
	}
}
