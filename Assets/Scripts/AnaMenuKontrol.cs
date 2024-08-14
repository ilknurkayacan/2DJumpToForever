using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnaMenuKontrol : MonoBehaviour
{
    [SerializeField]
    private Button muzikBtn;
    [SerializeField]
    private Sprite[] muzikAcikKapali;

    void Start()
    {
        KontrolMuzik();
    }

    void KontrolMuzik()
    {
        if (OyunTercihleri.GetirMuzikDurum() == 1)
        {
            MuzikKontrol.muzikKontrol.OynatMuzik(true);
            muzikBtn.image.sprite = muzikAcikKapali[1];
        }
        else
        {
            MuzikKontrol.muzikKontrol.OynatMuzik(false);
            muzikBtn.image.sprite = muzikAcikKapali[0];
        }
    }

    public void OyunuBaslat()
    {
        OyunYoneticisi.oyunYoneticisi.AnamenudenBasla = true;
        SahneGecis.sahneGecis.LoadLevel("Oyun");
    }
    public void YuksekSkor()
    {
        SceneManager.LoadScene("YuksekSkor");
    }
    public void Options()
    {
        SceneManager.LoadScene("Ayarlar");
    }

    public void Muzik()
    {
        if (OyunTercihleri.GetirMuzikDurum() == 0)
        {
            OyunTercihleri.AyarlaMuzikDurum(1);
            MuzikKontrol.muzikKontrol.OynatMuzik(true);
            muzikBtn.image.sprite = muzikAcikKapali[1];
        }
        else if (OyunTercihleri.GetirMuzikDurum() == 1)
        {
            OyunTercihleri.AyarlaMuzikDurum(0);
            MuzikKontrol.muzikKontrol.OynatMuzik(false);
            muzikBtn.image.sprite = muzikAcikKapali[0];
        }
    }
}

   
