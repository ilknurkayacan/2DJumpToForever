using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunTercihleri : MonoBehaviour
{
    public static string KolayZorluk = "KolayZorluk";
    public static string NormalZorluk = "NormalZorluk";
    public static string YuksekZorluk = "YuksekZorluk";

    public static string KolayZorlukYuksekSkor = "KolayZorlukYuksekSkor";
    public static string NormalZorlukYuksekSkor = "NormalZorlukYuksekSkor";
    public static string YuksekZorlukYuksekSkor = "YuksekZorlukYuksekSkor";

    public static string KolayZorlukAltinSkor = "KolayZorlukAltinSkor";
    public static string NormalZorlukAltinSkor = "NormalZorlukAltinSkor";
    public static string YuksekZorlukAltinSkor = "YuksekzorlukAltinSkor";

    public static string MuzikAcik = "MuzikAcik";

    public static int GetirMuzikDurum()
    {
        return PlayerPrefs.GetInt(OyunTercihleri.MuzikAcik);
    }

    public static void AyarlaMuzikDurum(int durum)
    {

        PlayerPrefs.SetInt(OyunTercihleri.MuzikAcik, durum);
    }
    public static int GetirKolayZorlukDurumu()
    {
        return PlayerPrefs.GetInt(OyunTercihleri.KolayZorluk);
    }
    public static void AyarlaKolayZorlukDurumu(int durum)
    {
        PlayerPrefs.SetInt(OyunTercihleri.KolayZorluk, durum);
    }

    public static int GetirNormalZorlukDurumu()
    {
        return PlayerPrefs.GetInt(OyunTercihleri.NormalZorluk);
    }

    public static void AyarlaNormalZorlukDurumu(int durum)
    {
        PlayerPrefs.SetInt(OyunTercihleri.NormalZorluk, durum);
    }

    public static int GetirYuksekZorlukDurumu()
    {
        return PlayerPrefs.GetInt(OyunTercihleri.YuksekZorluk);
    }

    public static void AyarlaYuksekZorlukDurumu(int durum)
    {
        PlayerPrefs.SetInt(OyunTercihleri.YuksekZorluk,durum);
    }

    public static int GetirKolayZorlukYuksekSkor()
    {
        return PlayerPrefs.GetInt(OyunTercihleri.KolayZorlukYuksekSkor);
    }

    public static void AyarlaKolayZorlukYuksekSkor(int skor)
    {
        PlayerPrefs.SetInt(OyunTercihleri.KolayZorlukYuksekSkor, skor);
    }

    public static int GetirNormalZorlukYuksekSkor()
    {
        return PlayerPrefs.GetInt(OyunTercihleri.NormalZorlukYuksekSkor);
    }
    public static void AyarlaNormalZorlukYuksekSkor(int skor)
    {
        PlayerPrefs.SetInt(OyunTercihleri.NormalZorlukYuksekSkor,skor);
    }

    public static int GetirYuksekZorlukYuksekSkor()
    {
        return PlayerPrefs.GetInt(OyunTercihleri.YuksekZorlukYuksekSkor);
    }

    public static void AyarlaYuksekZorlukYuksekSkor(int skor)
    {
        PlayerPrefs.SetInt(OyunTercihleri.YuksekZorlukYuksekSkor, skor);
    }

    public static int GetirKolayZorlukAltinSkor()
    {
        return PlayerPrefs.GetInt(OyunTercihleri.KolayZorlukAltinSkor);
    }
    public static void AyarlaKolayZorlukAltinSkor(int skor)
    {
        PlayerPrefs.SetInt(OyunTercihleri.KolayZorlukAltinSkor, skor);
    }
    public static int GetirNormalZorlukAltinSkor()
    {
        return PlayerPrefs.GetInt(OyunTercihleri.NormalZorlukAltinSkor);
    }

    public static void AyarlaNormalZorlukAltinSkor(int skor)
    {
        PlayerPrefs.SetInt(OyunTercihleri.NormalZorlukAltinSkor, skor);
    }

    public static int GetirYuksekZorlukAltinSkor()
    {
        return PlayerPrefs.GetInt(OyunTercihleri.YuksekZorlukAltinSkor);
    }
    public static void AyarlaYuksekZorlukAltinSkor(int skor)
    {
        PlayerPrefs.SetInt(OyunTercihleri.YuksekZorlukAltinSkor, skor);
    }
    
}
