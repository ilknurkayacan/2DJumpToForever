using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AyarlarKontrol : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject kolayTik, normalTik, zorTik;
    void Start()
    {
        AyarlaZorluk();   
    }

    void SecZorluk(string zorluk)
    {
        switch (zorluk)
        {
            case "kolay":
                normalTik.SetActive(false);
                zorTik.SetActive(false);
                break;
            case "normal":
                kolayTik.SetActive(false);
                zorTik.SetActive(false);
                break;
            case "zor":
                normalTik.SetActive(false);
                kolayTik.SetActive(false);
                break;
        }
    }

    void AyarlaZorluk()
    {
        if (OyunTercihleri.GetirKolayZorlukDurumu() == 1)
            SecZorluk("kolay");
        if (OyunTercihleri.GetirNormalZorlukDurumu() == 1)
            SecZorluk("normal");
        if (OyunTercihleri.GetirYuksekZorlukDurumu() == 1)
            SecZorluk("zor");
    }

    public void KolayZorluk()
    {
        OyunTercihleri.AyarlaKolayZorlukDurumu(1);
        OyunTercihleri.AyarlaNormalZorlukDurumu(0);
        OyunTercihleri.AyarlaYuksekZorlukDurumu(0);

        kolayTik.SetActive(true);
        normalTik.SetActive(false);
        zorTik.SetActive(false);
    }
    public void NormalZorluk()
    {
        OyunTercihleri.AyarlaKolayZorlukDurumu(0);
        OyunTercihleri.AyarlaNormalZorlukDurumu(1);
        OyunTercihleri.AyarlaYuksekZorlukDurumu(0);

        kolayTik.SetActive(false);
        normalTik.SetActive(true);
        zorTik.SetActive(false);
    }
    public void YuksekZorluk()
    {
        OyunTercihleri.AyarlaKolayZorlukDurumu(0);
        OyunTercihleri.AyarlaNormalZorlukDurumu(0);
        OyunTercihleri.AyarlaYuksekZorlukDurumu(1);

        kolayTik.SetActive(false);
        normalTik.SetActive(false);
        zorTik.SetActive(true);
    }


    public void AnamenuyeDon()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
