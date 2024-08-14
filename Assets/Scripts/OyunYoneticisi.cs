using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OyunYoneticisi : MonoBehaviour
{
    public static OyunYoneticisi oyunYoneticisi;
    [HideInInspector]
    public bool AnamenudenBasla, oluncaBaslat;
    [HideInInspector]
    public int skor, altinSkor, canSkor;
    private void Awake()
    {
        OyunNesne();
    }
    private void Start()
    {
        BaslangicDegiskenleri();
    }

    void BaslangicDegiskenleri()
    {
        if(!PlayerPrefs.HasKey("Oyun Baslatildi"))
        {
            OyunTercihleri.AyarlaKolayZorlukDurumu(0);
            OyunTercihleri.AyarlaKolayZorlukAltinSkor(0);
            OyunTercihleri.AyarlaKolayZorlukYuksekSkor(0);

            OyunTercihleri.AyarlaNormalZorlukDurumu(0);
            OyunTercihleri.AyarlaNormalZorlukAltinSkor(0);
            OyunTercihleri.AyarlaNormalZorlukYuksekSkor(0);

            OyunTercihleri.AyarlaYuksekZorlukDurumu(0);
            OyunTercihleri.AyarlaYuksekZorlukAltinSkor(0);
            OyunTercihleri.AyarlaYuksekZorlukYuksekSkor(0);
            OyunTercihleri.AyarlaMuzikDurum(0);

            PlayerPrefs.SetInt("Oyun Baslatildi", 1234);
        }
    }
    void OyunNesne()
    {
        if(oyunYoneticisi!= null)
        {
            Destroy(gameObject);
        }
        else
        {
            oyunYoneticisi = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if(SceneManager.GetActiveScene().name=="Oyun")
        {
            if (oluncaBaslat)
            {
                OyunKontrol.oyunkontrol.SkorHesapla(skor);
                OyunKontrol.oyunkontrol.AltinHesapla(altinSkor);
                OyunKontrol.oyunkontrol.CanHesapla(canSkor);
                PlayerSkor.skor = skor;
                PlayerSkor.altinSayisi = altinSkor;
                PlayerSkor.canSayisi = canSkor;
            }
            else if(AnamenudenBasla)
            {
                PlayerSkor.skor = 0;
                PlayerSkor.canSayisi = 0;
                PlayerSkor.altinSayisi = 0;
                OyunKontrol.oyunkontrol.SkorHesapla(0);
                OyunKontrol.oyunkontrol.AltinHesapla(0);
                OyunKontrol.oyunkontrol.CanHesapla(2);
            }
        }
    }

    public void OyunDurumuKontrol(int skor, int canSkor, int altinSkor)
    {
        if(canSkor<0)
        {
            if (OyunTercihleri.GetirKolayZorlukDurumu() == 1)
            {
                int yuksekskor = OyunTercihleri.GetirKolayZorlukYuksekSkor();
                int yuksekAltinSkor = OyunTercihleri.GetirKolayZorlukAltinSkor();
                if (yuksekskor < skor)
                {
                    OyunTercihleri.AyarlaKolayZorlukYuksekSkor(skor);
                }
                if(yuksekAltinSkor<altinSkor)
                {
                    OyunTercihleri.AyarlaKolayZorlukAltinSkor(altinSkor);
                }
            }
            if (OyunTercihleri.GetirNormalZorlukDurumu() == 1)
            {
                int yuksekskor = OyunTercihleri.GetirNormalZorlukYuksekSkor();
                int yuksekAltinSkor = OyunTercihleri.GetirNormalZorlukAltinSkor();
                if (yuksekskor < skor)
                {
                    OyunTercihleri.AyarlaNormalZorlukYuksekSkor(skor);
                }
                if (yuksekAltinSkor < altinSkor)
                {
                    OyunTercihleri.AyarlaNormalZorlukAltinSkor(altinSkor);
                }
            }
            if (OyunTercihleri.GetirYuksekZorlukDurumu() == 1)
            {
                int yuksekskor = OyunTercihleri.GetirYuksekZorlukYuksekSkor();
                int yuksekAltinSkor = OyunTercihleri.GetirYuksekZorlukAltinSkor();
                if (yuksekskor < skor)
                {
                    OyunTercihleri.AyarlaYuksekZorlukYuksekSkor(skor);
                }
                if (yuksekAltinSkor < altinSkor)
                {
                    OyunTercihleri.AyarlaYuksekZorlukAltinSkor(altinSkor);
                }
            }

            AnamenudenBasla = false;
            oluncaBaslat = false;
            OyunKontrol.oyunkontrol.OyunSonuPanelAc(skor, altinSkor);
        }
        else
        {
            this.skor = skor;
            this.altinSkor = altinSkor;
            this.canSkor = canSkor;

            AnamenudenBasla = false;
            oluncaBaslat = true;
            OyunKontrol.oyunkontrol.KarakterOlunceBaslat();
        }
    }
}
