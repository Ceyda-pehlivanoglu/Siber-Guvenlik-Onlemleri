using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//oneri üzerindeki yazýlarý oluþturan kod bloðu

public class OneriGenerator : MonoBehaviour
{
	List<string> isimler = new List<string>{ "Mehmet", "Mustafa", "Ahmet", "Ali", "Hüseyin", "Hasan", "Ýbrahim", "Ýsmail", "Osman", "Yusuf",
		"Murat", "Ömer", "Ramazan", "Halil", "Süleyman", "Abdullah", "Mahmut", "Recep", "Salih", "Fatih", "Kadir", "Emre", "Mehmet Ali", "Hakan",
		"Adem", "Kemal", "Yaþar", "Bekir", "Musa", "Metin", "Bayram", "Serkan", "Orhan", "Burak", "Furkan", "Gökhan", "Yasin", "Uður", "Yakup",
		"Cemal", "Enes", "Yunus", "Arif", "Onur", "Muhammet", "Yýlmaz", "Þaban", "Halil Ýbrahim",
		"Fatma", "Ayþe", "Emine", "Hatice", "Zeynep", "Elif", "Meryem", "Selma", "Þerife", "Zehra", "Sultan", "Hanife", "Merve", "Havva", "Zeliha",
		"Esra", "Fadime", "Özlem", "Hacer", "Yasemin", "Melek", "Rabia", "Hülya", "Cemile", "Sevim", "Gülsüm", "Leyla", "Dilek", "Büþra", "Aysel",
		"Songül", "Kübra", "Halime", "Esma", "Aynur", "Hayriye", "Kadriye", "Tuðba", "Sevgi", "Rukiye", "Havva", "Sibel", "Derya", "Asiye", "Filiz",
		"Kezban", "Ebru", "Ayþegül", "Döndü", "Ayten"
	};

	List<string> soyisimler = new List<string>{ "ÞEN", "KANDEMÝR", "ÇEVÝK", "ERKURAN", "TÜTEN", "ÖZTÜRK", "YÜZBAÞIOÐLU",
		"VURAL", "YÜCEL", "SÖNMEZ", "ERTEKÝN", "DEDE", "UYANIK", "ASLAN", "AKBULUT", "ORHON", "UZ", "YAVUZ", "ERDEM", 
		"KULAÇ", "KAYA", "SELVÝ", "AKPINAR", "ABACIOÐLU", "ÇAY", "IÞIK", "ÖZER", "ÖZDEMÝR", "ÖZTÜRK", "TAHTACI", "BÜYÜKCAM", 
		"KULAKSIZ", "AKSEL", "EROÐLU", "KARAKUM", "DAL", "ÖCAL", "AYHAN", "YÝÐÝT", "YARBÝL", "CANACANKATAN", "GÜMÜÞAY", "MURT", 
		"HALHALLI", "ULUÖZ", "ÞEYHANLI", "ÇALIÞKANTÜRK", "YILMAZ", "SARAÇOÐLU", "SEZER", "DOÐAN", "DEMÝR", "KAYAYURT", "SÜRÜM", 
		"YAVAÞÝ", "TURGUT", "ÞEN TANRIKULU", "BARBAROS", "ALDÝNÇ", "TEKÝN", "GÜLÞAN", "KÜFECÝLER", "ALMACIOÐLU", "ÇÝLDÝR", "TÜRKDOÐAN", "KAYA", "ÖNER", "ÞELÝMAN", "YAMAN", "ATÝK" };

	int difficulty = 0;
	public float z = 0;

	const int baseFakeValue = 6;

	List<string> dogruOneri = new List<string> { "Tüm çalýþanlara güçlü bir parolanýn nasýl oluþturulacaðý hakkýnda eðitim verelim.",
		"Þirket çalýþanlarýnýn 90 günde bir parolalarýný deðiþtirmeleri için periyodik hatýrlatmalar yapalým.",
		"E-posta, VPN, bulut hizmetleri gibi kritik sistemlere eriþimlerde 2 adýmlý doðrulama kullanalým.",
		"Hassas bilgileri içeren sistemler ve genel sistemleri farklý aðlarda çalýþtýralým.",
		"Geliþmiþ güvenlik duvarlarý ve Saldýrý Tespit/Önleme Sistemleri (IDS/IPS) uygulamalarý yapalým.",
		"Tüm þirket cihazlarýna antivirüs ve anti-malware yazýlýmlarý kuralým.",
		"Sistemler, yazýlýmlar ve cihazlarý düzenli olarak güncelleyelim ve güncellemeleri denetleyelim.",
		"Çalýþanlara düzenli olarak siber güvenlik farkýndalýðý eðitimi verilmeli.",
		"Kritik verileri düzenli olarak yedeklemeliyiz. Yedek verileri de çevrimdýþý bir ortamda saklamalýyýz.",
		"Her çalýþana sadece çalýþtýðý alanda gerekli olduðu kadar eriþim izni verilmeli. Bu konuda bir toplantý yapalým",
		"Þirket çapýnda bir siber güvenlik politikasý oluþturulmalý. Bu politikayý tüm çalýþanlara iletmeliyiz.",
		"Þirket içinde ve þirkete ait cihazlarda VPN kullanýmýný zorunlu hale getirilmeli. ",
		"Uzaktan çalýþanlarýn cihazlarýnýn güvenliðini saðlamak için þirkete ait bir VPN aðý kurulmalý. Bu cihazlara ait yazýlýmlar sürekli güncel tutularak antivirüs programlarý kullanýlmalý.",
		"Düzenli aralýklarla þirket sistemlerine yönelik penetrasyon testleri yapmalýyýz.",
		"Kritik sistemleri sürekli olarak izlemeliyiz. Sistem loglarýný analiz edilerek olasý tehditler hakkýnda önceden haberdar olabiliriz.",
		"Çalýþanlarý sosyal mühendislik saldýrýlarýna karþý test etmeli ve bu konularda eðitim vermeliyiz.",
		"Kiþisel cihazlarýný iþ ortamýnda da kullanan çalýþanlar için, kullandýklarý cihazlara ait güvenlik standartlarýný belirlemeliyiz.",
		"Tüm sistemlerde güvenlik açýklarý düzenli olarak taranmalý ve giderilmeli.",
		"Sunucu odalarýna sadece yetkili kiþiler eriþebilmeli. Gerekirse yöneticilerin bile bu odalara girmesini engellemeliyiz.",
		"DDoS saldýrýlarýna karþý korumak için özel çözümler kullanmalýyýz. Að trafiðini izlemeli ve anormal durumlarda hemen önlem almalýyýz.",
		"Olasý bir siber saldýrýya karþý olay müdahale planý hazýrlanmalýyýz ve düzenli aralýklarla müdahale planýnýn üzerinden geçmeliyiz.",
		"Að trafiði analiz eden yapay zeka tabanlý IDS/IPS sistemleri entegrasyonu yapabiliriz.",
		"Çalýþanlarýn siber saldýrý simülasyonlarýna katýlarak gerçek tehditlerle nasýl baþa çýkacaklarýný öðrenmeleri saðlanmalý.",
		"Uçtan uca þifreleme protokolleri þirket içi ve dýþý veri iletiþiminde zorunlu hale getirilmeli.",
		"Yedeklere ait kurtarma testleri düzenli olarak yapýlarak çalýþýr durumda olduklarýndan emin olmalýyýz.",
		"Sahte e-posta saldýrý testleri düzenli aralýklarla yapýlmalý ve sonuçlar eðitim materyallerine eklenmeli.",
		"Kiþisel cihazlarýn güvenliðini kontrol etmek için að baðlantýsý öncesinde cihaz durum deðerlendirmesi yapýlabiliriz.",
		"Kullanýcý ve sistem davranýþlarýný analiz etme aþamasýnda yapay zeka tabanlý çözümlere baþvurabiliriz.",
		"Yetkisiz USB cihazlarýnýn þirket bilgisayarlarýna takýlmasýný önlemek için fiziksel ve yazýlýmsal kontroller uygulamalýyýz.",
		"Çalýþanlarýn zararlý web sitelerine eriþimini engellemek için DNS filtreleme ve güvenli DNS hizmetleri kullanmalýyýz.",
		"Þirket verilerinin düzenli olarak otomatik yedeklenmesini saðlayalým ve bu yedekleri güvenli bir konumda saklayalým.",
		"Çalýþanlarýn iþ dýþýnda kullanýlan cihazlardan þirket sistemlerine eriþimini kýsýtlayalým.",
		"Veri taþýnabilirliði ve eriþimi için yalnýzca güvenli USB cihazlarý ve þifrelenmiþ sürücüleri kullanalým.",
		"Að trafiði için þifrelenmiþ protokoller kullanalým.",
		"Misafir cihazlarýnýn þirket aðýna baðlanmasýný engellemek için ayrý bir misafir aðý oluþturalým.",
		"Tüm çalýþanlarýn cihazlarýnda ekran kilidi ve otomatik kilitleme ayarlarýný zorunlu hale getirelim.",
		"Þirket e-postalarý için güvenlik filtreleri kullanalým.",
		"Kritik sistemlerin eriþim loglarýný düzenli olarak analiz edelim ve anormallikleri raporlayalým.",
		"Þirket verilerinin izinsiz kopyalanmasýný önlemek için veri kaybý önleme çözümleri uygulayalým.",
		"Þirket cihazlarýný ve aðlarýný düzenli olarak taramadan geçirelim."};


	List<string> yanlisOneri = new List<string> { "",
		"Þirketin bize verdiði þifreler çok karýþýk, 123456 veya isim2024 gibi þifreler koysak olmaz mý?",
		"2FA doðrulamasýný kaldýralým sadece kullanýcý adý ve parola yeterli",
		"Tüm þirket cihazlarýný, sunucularý ve misafir cihazlarý tek bir aða baðlayalým. ",
		"Að trafiðini hýzlandýrmak için güvenlik duvarlarýný kapatabiliriz.",
		"Antivirüs yazýlýmlarý bilgisayarlarýmýzýn kaynaklarýný tüketiyor. Güvenlik yazýlýmlarýna ihtiyacýmýz yok.",
		"Sistemler zaten düzgün çalýþýyor, yeni güncellemeleri kurmamýza gerek yok.",
		"Siber güvenlik eðitimine ne gerek var. 5 yaþýndaki çocuk bile þüpheli linklere týklamamayý akýl edebilir.",
		"Þirket verilerini depoladýðýmýz sistemlerdeki þifrelemeyi kaldýralým.",
		"Veriler güvende, neden yedekleme yapalým ki?",
		"Çalýþanlara iþlerini kolaylaþtýrmak için sýnýrsýz eriþim izni verelim. Her iþ çýktýðýnda üst kademe ile iletiþime geçmek uzun sürüyor.",
		"Þu ana kadar sistemlerde sorun olmadý, test etmeye gerek yok.",
		"Çalýþanlarýmýz kendi kiþisel cihazlarla þirket sistemlerine eriþebilmeli.",
		"Açýk kaynak kodlu yazýlýmlarý kullanalým. Daha ucuza gelir.",
		"Herkes sunucu odalarýna girebilmeli.",
		"Olasý bir siber saldýrýya nasýl yanýt vereceðimiz konusunda herhangi bir plan yapmamýza gerek yok.",
		"Tüm çalýþanlarýn ayný parolayý kullansa ne kaybederiz ki?",
		"Þirket cihazlarýndaki koruma sistemi yüzünden teknik ekip müdahalesi olmadan program yükleyip kuramýyoruz. Bu koruma yazýlýmlarýný kaldýralým.",
		"Yeni nesil cihazlar zaten en son teknoloji güvenlik sistemleriyle geliyor. Ek bir programa gerek yok.",
		"Bulut hizmetleri, verilerimizi zaten güvenle saklýyor. Baþka bir yedekleme sistemine ihtiyacýmýz yok.",
		"Tüm çalýþanlarýmýza yönetici eriþimi verelim. Bu sayede herkes istediði verilere kolaysa eriþebilir.",
		"Güvenlik politikalarý zaman kaybý, herkes kendi yöntemini uygulasýn.",
		"Sistemlerin kararlýlýðýný artýrmak için, iþletim sistemi ve yazýlýmlardaki otomatik güncellemeleri devre dýþý býrakalým.",
		"Þirkete ait aðlara ait þifreleri yazýp, misafir aðýrladýðýmýz alanlarýna yapýþtýralým. Baðlanmak isteyen herkes baðlansýn.",
		"Tüm cihazlarý ve uygulamalarý varsayýlan ayarlarýnda býrakalým. Özel güvenlik ayarlarý yapmak uðraþtýrýcý oluyor.",
		"Neden þirket aðý üzerinden istediðimiz sitelere eriþemiyoruz ki? Sýnýrlamalar gereksiz bence.",
		"Þifre uzunluklarý minimum 4 karakter olsun. Ýþlerimiz hýzlanýr.",
		"Dýþ hizmet saðlayýcýlarla güvenlik standartlarý belirlemek, görüþmeleri uzatýyor ve iþler aksýyor. Standart belirlememize gerek yok.",
		"Þirket bilgisayarlarýnýn þifrelerini her kullanýcý için ayný yapalým, böylece hatýrlamasý kolay olur.",
		"E-posta doðrulamalarýný kaldýralým, kimlik doðrulama iþlemleri çok zaman alýyor.",
		"VPN kullanmayý býrakalým, baðlantý yavaþlýyor.",
		"Eski yazýlýmlar gayet iyi çalýþýyor, neden yenilerini yükleyelim ki?",
		"Þirket yazýþmalarýný WhatsApp üzerinden yapalým, daha hýzlý olur.",
		"Þirket verilerini USB belleklerde taþýyalým, bulut kullanmaya gerek yok.",
		"Ýnternet güvenlik protokollerini kaldýrýrsak að baðlantýsý daha stabil olur."};

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
		// Eðer liste boþsa, seçilenler listesini tekrar orijinal listeye kopyala
		if (list == null || list.Count == 0)
		{
			//throw new System.InvalidOperationException("Liste boþ, sýfýrlanýyor");
			//liste boþ ise sýfýrlanýr
			if (secilenlerListesi.Count == 0)
			{
				throw new System.InvalidOperationException("Her iki liste de boþ");
			}

			list.AddRange(secilenlerListesi);
			secilenlerListesi.Clear();
		}

		// Rastgele bir indeks seç
		int index = Mathf.FloorToInt(Random.Range(0, list.Count));
		string secilenVeri = list[index];

		// Seçilen öðeyi yeni listeye ekle ve listeden kaldýr
		secilenlerListesi.Add(secilenVeri);
		list.RemoveAt(index);

		return secilenVeri;
	}
}
