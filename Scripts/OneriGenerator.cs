using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//oneri �zerindeki yaz�lar� olu�turan kod blo�u

public class OneriGenerator : MonoBehaviour
{
	List<string> isimler = new List<string>{ "Mehmet", "Mustafa", "Ahmet", "Ali", "H�seyin", "Hasan", "�brahim", "�smail", "Osman", "Yusuf",
		"Murat", "�mer", "Ramazan", "Halil", "S�leyman", "Abdullah", "Mahmut", "Recep", "Salih", "Fatih", "Kadir", "Emre", "Mehmet Ali", "Hakan",
		"Adem", "Kemal", "Ya�ar", "Bekir", "Musa", "Metin", "Bayram", "Serkan", "Orhan", "Burak", "Furkan", "G�khan", "Yasin", "U�ur", "Yakup",
		"Cemal", "Enes", "Yunus", "Arif", "Onur", "Muhammet", "Y�lmaz", "�aban", "Halil �brahim",
		"Fatma", "Ay�e", "Emine", "Hatice", "Zeynep", "Elif", "Meryem", "Selma", "�erife", "Zehra", "Sultan", "Hanife", "Merve", "Havva", "Zeliha",
		"Esra", "Fadime", "�zlem", "Hacer", "Yasemin", "Melek", "Rabia", "H�lya", "Cemile", "Sevim", "G�ls�m", "Leyla", "Dilek", "B��ra", "Aysel",
		"Song�l", "K�bra", "Halime", "Esma", "Aynur", "Hayriye", "Kadriye", "Tu�ba", "Sevgi", "Rukiye", "Havva", "Sibel", "Derya", "Asiye", "Filiz",
		"Kezban", "Ebru", "Ay�eg�l", "D�nd�", "Ayten"
	};

	List<string> soyisimler = new List<string>{ "�EN", "KANDEM�R", "�EV�K", "ERKURAN", "T�TEN", "�ZT�RK", "Y�ZBA�IO�LU",
		"VURAL", "Y�CEL", "S�NMEZ", "ERTEK�N", "DEDE", "UYANIK", "ASLAN", "AKBULUT", "ORHON", "UZ", "YAVUZ", "ERDEM", 
		"KULA�", "KAYA", "SELV�", "AKPINAR", "ABACIO�LU", "�AY", "I�IK", "�ZER", "�ZDEM�R", "�ZT�RK", "TAHTACI", "B�Y�KCAM", 
		"KULAKSIZ", "AKSEL", "ERO�LU", "KARAKUM", "DAL", "�CAL", "AYHAN", "Y���T", "YARB�L", "CANACANKATAN", "G�M��AY", "MURT", 
		"HALHALLI", "ULU�Z", "�EYHANLI", "�ALI�KANT�RK", "YILMAZ", "SARA�O�LU", "SEZER", "DO�AN", "DEM�R", "KAYAYURT", "S�R�M", 
		"YAVA��", "TURGUT", "�EN TANRIKULU", "BARBAROS", "ALD�N�", "TEK�N", "G�L�AN", "K�FEC�LER", "ALMACIO�LU", "��LD�R", "T�RKDO�AN", "KAYA", "�NER", "�EL�MAN", "YAMAN", "AT�K" };

	int difficulty = 0;
	public float z = 0;

	const int baseFakeValue = 6;

	List<string> dogruOneri = new List<string> { "T�m �al��anlara g��l� bir parolan�n nas�l olu�turulaca�� hakk�nda e�itim verelim.",
		"�irket �al��anlar�n�n 90 g�nde bir parolalar�n� de�i�tirmeleri i�in periyodik hat�rlatmalar yapal�m.",
		"E-posta, VPN, bulut hizmetleri gibi kritik sistemlere eri�imlerde 2 ad�ml� do�rulama kullanal�m.",
		"Hassas bilgileri i�eren sistemler ve genel sistemleri farkl� a�larda �al��t�ral�m.",
		"Geli�mi� g�venlik duvarlar� ve Sald�r� Tespit/�nleme Sistemleri (IDS/IPS) uygulamalar� yapal�m.",
		"T�m �irket cihazlar�na antivir�s ve anti-malware yaz�l�mlar� kural�m.",
		"Sistemler, yaz�l�mlar ve cihazlar� d�zenli olarak g�ncelleyelim ve g�ncellemeleri denetleyelim.",
		"�al��anlara d�zenli olarak siber g�venlik fark�ndal��� e�itimi verilmeli.",
		"Kritik verileri d�zenli olarak yedeklemeliyiz. Yedek verileri de �evrimd��� bir ortamda saklamal�y�z.",
		"Her �al��ana sadece �al��t��� alanda gerekli oldu�u kadar eri�im izni verilmeli. Bu konuda bir toplant� yapal�m",
		"�irket �ap�nda bir siber g�venlik politikas� olu�turulmal�. Bu politikay� t�m �al��anlara iletmeliyiz.",
		"�irket i�inde ve �irkete ait cihazlarda VPN kullan�m�n� zorunlu hale getirilmeli. ",
		"Uzaktan �al��anlar�n cihazlar�n�n g�venli�ini sa�lamak i�in �irkete ait bir VPN a�� kurulmal�. Bu cihazlara ait yaz�l�mlar s�rekli g�ncel tutularak antivir�s programlar� kullan�lmal�.",
		"D�zenli aral�klarla �irket sistemlerine y�nelik penetrasyon testleri yapmal�y�z.",
		"Kritik sistemleri s�rekli olarak izlemeliyiz. Sistem loglar�n� analiz edilerek olas� tehditler hakk�nda �nceden haberdar olabiliriz.",
		"�al��anlar� sosyal m�hendislik sald�r�lar�na kar�� test etmeli ve bu konularda e�itim vermeliyiz.",
		"Ki�isel cihazlar�n� i� ortam�nda da kullanan �al��anlar i�in, kulland�klar� cihazlara ait g�venlik standartlar�n� belirlemeliyiz.",
		"T�m sistemlerde g�venlik a��klar� d�zenli olarak taranmal� ve giderilmeli.",
		"Sunucu odalar�na sadece yetkili ki�iler eri�ebilmeli. Gerekirse y�neticilerin bile bu odalara girmesini engellemeliyiz.",
		"DDoS sald�r�lar�na kar�� korumak i�in �zel ��z�mler kullanmal�y�z. A� trafi�ini izlemeli ve anormal durumlarda hemen �nlem almal�y�z.",
		"Olas� bir siber sald�r�ya kar�� olay m�dahale plan� haz�rlanmal�y�z ve d�zenli aral�klarla m�dahale plan�n�n �zerinden ge�meliyiz.",
		"A� trafi�i analiz eden yapay zeka tabanl� IDS/IPS sistemleri entegrasyonu yapabiliriz.",
		"�al��anlar�n siber sald�r� sim�lasyonlar�na kat�larak ger�ek tehditlerle nas�l ba�a ��kacaklar�n� ��renmeleri sa�lanmal�.",
		"U�tan uca �ifreleme protokolleri �irket i�i ve d��� veri ileti�iminde zorunlu hale getirilmeli.",
		"Yedeklere ait kurtarma testleri d�zenli olarak yap�larak �al���r durumda olduklar�ndan emin olmal�y�z.",
		"Sahte e-posta sald�r� testleri d�zenli aral�klarla yap�lmal� ve sonu�lar e�itim materyallerine eklenmeli.",
		"Ki�isel cihazlar�n g�venli�ini kontrol etmek i�in a� ba�lant�s� �ncesinde cihaz durum de�erlendirmesi yap�labiliriz.",
		"Kullan�c� ve sistem davran��lar�n� analiz etme a�amas�nda yapay zeka tabanl� ��z�mlere ba�vurabiliriz.",
		"Yetkisiz USB cihazlar�n�n �irket bilgisayarlar�na tak�lmas�n� �nlemek i�in fiziksel ve yaz�l�msal kontroller uygulamal�y�z.",
		"�al��anlar�n zararl� web sitelerine eri�imini engellemek i�in DNS filtreleme ve g�venli DNS hizmetleri kullanmal�y�z.",
		"�irket verilerinin d�zenli olarak otomatik yedeklenmesini sa�layal�m ve bu yedekleri g�venli bir konumda saklayal�m.",
		"�al��anlar�n i� d���nda kullan�lan cihazlardan �irket sistemlerine eri�imini k�s�tlayal�m.",
		"Veri ta��nabilirli�i ve eri�imi i�in yaln�zca g�venli USB cihazlar� ve �ifrelenmi� s�r�c�leri kullanal�m.",
		"A� trafi�i i�in �ifrelenmi� protokoller kullanal�m.",
		"Misafir cihazlar�n�n �irket a��na ba�lanmas�n� engellemek i�in ayr� bir misafir a�� olu�tural�m.",
		"T�m �al��anlar�n cihazlar�nda ekran kilidi ve otomatik kilitleme ayarlar�n� zorunlu hale getirelim.",
		"�irket e-postalar� i�in g�venlik filtreleri kullanal�m.",
		"Kritik sistemlerin eri�im loglar�n� d�zenli olarak analiz edelim ve anormallikleri raporlayal�m.",
		"�irket verilerinin izinsiz kopyalanmas�n� �nlemek i�in veri kayb� �nleme ��z�mleri uygulayal�m.",
		"�irket cihazlar�n� ve a�lar�n� d�zenli olarak taramadan ge�irelim."};


	List<string> yanlisOneri = new List<string> { "",
		"�irketin bize verdi�i �ifreler �ok kar���k, 123456 veya isim2024 gibi �ifreler koysak olmaz m�?",
		"2FA do�rulamas�n� kald�ral�m sadece kullan�c� ad� ve parola yeterli",
		"T�m �irket cihazlar�n�, sunucular� ve misafir cihazlar� tek bir a�a ba�layal�m. ",
		"A� trafi�ini h�zland�rmak i�in g�venlik duvarlar�n� kapatabiliriz.",
		"Antivir�s yaz�l�mlar� bilgisayarlar�m�z�n kaynaklar�n� t�ketiyor. G�venlik yaz�l�mlar�na ihtiyac�m�z yok.",
		"Sistemler zaten d�zg�n �al���yor, yeni g�ncellemeleri kurmam�za gerek yok.",
		"Siber g�venlik e�itimine ne gerek var. 5 ya��ndaki �ocuk bile ��pheli linklere t�klamamay� ak�l edebilir.",
		"�irket verilerini depolad���m�z sistemlerdeki �ifrelemeyi kald�ral�m.",
		"Veriler g�vende, neden yedekleme yapal�m ki?",
		"�al��anlara i�lerini kolayla�t�rmak i�in s�n�rs�z eri�im izni verelim. Her i� ��kt���nda �st kademe ile ileti�ime ge�mek uzun s�r�yor.",
		"�u ana kadar sistemlerde sorun olmad�, test etmeye gerek yok.",
		"�al��anlar�m�z kendi ki�isel cihazlarla �irket sistemlerine eri�ebilmeli.",
		"A��k kaynak kodlu yaz�l�mlar� kullanal�m. Daha ucuza gelir.",
		"Herkes sunucu odalar�na girebilmeli.",
		"Olas� bir siber sald�r�ya nas�l yan�t verece�imiz konusunda herhangi bir plan yapmam�za gerek yok.",
		"T�m �al��anlar�n ayn� parolay� kullansa ne kaybederiz ki?",
		"�irket cihazlar�ndaki koruma sistemi y�z�nden teknik ekip m�dahalesi olmadan program y�kleyip kuram�yoruz. Bu koruma yaz�l�mlar�n� kald�ral�m.",
		"Yeni nesil cihazlar zaten en son teknoloji g�venlik sistemleriyle geliyor. Ek bir programa gerek yok.",
		"Bulut hizmetleri, verilerimizi zaten g�venle sakl�yor. Ba�ka bir yedekleme sistemine ihtiyac�m�z yok.",
		"T�m �al��anlar�m�za y�netici eri�imi verelim. Bu sayede herkes istedi�i verilere kolaysa eri�ebilir.",
		"G�venlik politikalar� zaman kayb�, herkes kendi y�ntemini uygulas�n.",
		"Sistemlerin kararl�l���n� art�rmak i�in, i�letim sistemi ve yaz�l�mlardaki otomatik g�ncellemeleri devre d��� b�rakal�m.",
		"�irkete ait a�lara ait �ifreleri yaz�p, misafir a��rlad���m�z alanlar�na yap��t�ral�m. Ba�lanmak isteyen herkes ba�lans�n.",
		"T�m cihazlar� ve uygulamalar� varsay�lan ayarlar�nda b�rakal�m. �zel g�venlik ayarlar� yapmak u�ra�t�r�c� oluyor.",
		"Neden �irket a�� �zerinden istedi�imiz sitelere eri�emiyoruz ki? S�n�rlamalar gereksiz bence.",
		"�ifre uzunluklar� minimum 4 karakter olsun. ��lerimiz h�zlan�r.",
		"D�� hizmet sa�lay�c�larla g�venlik standartlar� belirlemek, g�r��meleri uzat�yor ve i�ler aks�yor. Standart belirlememize gerek yok.",
		"�irket bilgisayarlar�n�n �ifrelerini her kullan�c� i�in ayn� yapal�m, b�ylece hat�rlamas� kolay olur.",
		"E-posta do�rulamalar�n� kald�ral�m, kimlik do�rulama i�lemleri �ok zaman al�yor.",
		"VPN kullanmay� b�rakal�m, ba�lant� yava�l�yor.",
		"Eski yaz�l�mlar gayet iyi �al���yor, neden yenilerini y�kleyelim ki?",
		"�irket yaz��malar�n� WhatsApp �zerinden yapal�m, daha h�zl� olur.",
		"�irket verilerini USB belleklerde ta��yal�m, bulut kullanmaya gerek yok.",
		"�nternet g�venlik protokollerini kald�r�rsak a� ba�lant�s� daha stabil olur."};

	List<string> secilenlerListesiDogru = new List<string> {};
	List<string> secilenlerListesiYanlis = new List<string> {};

	public void SetDifficulty(int newDifficulty)
	{
		difficulty = newDifficulty;
	}

	public void Generate(Oneri oneriComponent)
	{
		string isim = ListedenRasgeleSec(isimler) + " ";
		string soyisim = ListedenRasgeleSec(soyisimler);

		string dogru = ListedenRasgeleSec2(dogruOneri, secilenlerListesiDogru);
		string yanlis = ListedenRasgeleSec2(yanlisOneri, secilenlerListesiYanlis);

		OneriTipi type = Random.Range(0f, 1f) >= .65f ? OneriTipi.kabul_durumu : OneriTipi.ret_durumu;

		bool isOneriValid = true;

		if (type == OneriTipi.kabul_durumu)
		{
			string oneri_tamamlanmis = isim + soyisim + "\n" + "\n" + dogru;
			oneriComponent.Initialise(oneri_tamamlanmis, isOneriValid, type, z);
			z += .2f;
			if (z > 8.5)
				z = 0;
		}
		if (type == OneriTipi.ret_durumu)
		{
			string oneri_tamamlanmis = isim + soyisim + "\n" + "\n" + yanlis;
			oneriComponent.Initialise(oneri_tamamlanmis, isOneriValid, type, z);
			z += .2f;
			if (z > 8.5)
				z = 0;
		}		

	}

	string ListedenRasgeleSec(List<string> list)
	{
		int index = Mathf.RoundToInt(Random.Range(0, list.Count));

		return list[index];
	}

	string ListedenRasgeleSec2(List<string> list, List<string> secilenlerListesi)
	{
		// E�er liste bo�sa, se�ilenler listesini tekrar orijinal listeye kopyala
		if (list == null || list.Count == 0)
		{
			//throw new System.InvalidOperationException("Liste bo�, s�f�rlan�yor");
			//liste bo� ise s�f�rlan�r
			if (secilenlerListesi.Count == 0)
			{
				throw new System.InvalidOperationException("Her iki liste de bo�");
			}

			list.AddRange(secilenlerListesi);
			secilenlerListesi.Clear();
		}

		// Rastgele bir indeks se�
		int index = Mathf.FloorToInt(Random.Range(0, list.Count));
		string secilenVeri = list[index];

		// Se�ilen ��eyi yeni listeye ekle ve listeden kald�r
		secilenlerListesi.Add(secilenVeri);
		list.RemoveAt(index);

		return secilenVeri;
	}
}
