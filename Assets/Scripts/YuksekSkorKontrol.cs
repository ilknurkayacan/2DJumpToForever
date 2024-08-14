using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YuksekSkorKontrol : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text skorTxt, altinSkorTxt;
    void Start()
    {
        AyarlaZorlukSeviyesineGoreSkor();   
    }

    void SkorAyarla(int skor, int altinskor)
    {
        skorTxt.text = skor.ToString();
        altinSkorTxt.text = altinskor.ToString();
    }

    void AyarlaZorlukSeviyesineGoreSkor()
    {
        if (OyunTercihleri.GetirKolayZorlukDurumu() == 1)
        {
            SkorAyarla(OyunTercihleri.GetirKolayZorlukYuksekSkor(), OyunTercihleri.GetirKolayZorlukAltinSkor());
        }
        if (OyunTercihleri.GetirNormalZorlukDurumu() == 1)
        {
            SkorAyarla(OyunTercihleri.GetirNormalZorlukYuksekSkor(), OyunTercihleri.GetirNormalZorlukAltinSkor());
        }
        if (OyunTercihleri.GetirYuksekZorlukDurumu() == 1)
        {
            SkorAyarla(OyunTercihleri.GetirYuksekZorlukYuksekSkor(), OyunTercihleri.GetirYuksekZorlukAltinSkor());
        }
    }

    public void AnaMenuyedon()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
