using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunKontrol : MonoBehaviour
{
    [SerializeField]
    private GameObject durdurPanel,oyunsonuPanel, hazirBtn;

    public static OyunKontrol oyunkontrol;
    [SerializeField]
    private Text skorText, altinText, canText, oyunsonuskorText, oyunsonualtinText;
    private void Awake()
    {
        Kontrol();
    }

    private void Start()
    {
        Time.timeScale = 0f;
    }


    void Kontrol()
    {
        if (oyunkontrol == null)
            oyunkontrol = this;
    }

    public void OyunuBaslat()
    {
        Time.timeScale = 1f;
        hazirBtn.SetActive(false);
    }
    public void OyunuDurdur()
    {
        Time.timeScale = 0f;
        durdurPanel.SetActive(true);
    }

    public void OyunuDevemEttir()
    {
        Time.timeScale = 1f;
        durdurPanel.SetActive(false);
    }
    public void OyunuKapat()
    {
        Time.timeScale = 1f;
        SahneGecis.sahneGecis.LoadLevel("MainMenu");
    }

    public void SkorHesapla(int skor)
    {
        skorText.text = "x" + skor;
    }

    public void AltinHesapla(int altinSkor)
    {
        altinText.text = "x" + altinSkor;
    }

    public void CanHesapla(int canSkor)
    {
        canText.text = "x" + canSkor;
    }

    public void OyunSonuPanelAc(int sonSkor, int sonAltinSkor)
    {
        oyunsonuPanel.SetActive(true);
        oyunsonuskorText.text = sonSkor.ToString();
        oyunsonualtinText.text = sonAltinSkor.ToString();
        StartCoroutine(OyunSonuPanelYukle());

    }

    IEnumerator OyunSonuPanelYukle()
    {
        yield return new WaitForSeconds(3f);
        SahneGecis.sahneGecis.LoadLevel("MainMenu");
    }

    public void KarakterOlunceBaslat()
    {
        StartCoroutine(KarakterOlunceYenidenBaslat());
    }

    IEnumerator KarakterOlunceYenidenBaslat()
    {
        yield return new WaitForSeconds(1f);
        SahneGecis.sahneGecis.LoadLevel("Oyun");
    }
   
}
