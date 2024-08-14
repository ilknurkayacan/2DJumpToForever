using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkor : MonoBehaviour
{
    [SerializeField]
    private AudioClip altinses, canses;

    private Kamera kameraScript;
    private Vector3 oncekiKonum;
    private bool skorDurum;

    public static int skor;
    public static int canSayisi;
    public static int altinSayisi;
    private void Awake()
    {
        kameraScript = Camera.main.GetComponent<Kamera>();
    }
    void Start()
    {
        oncekiKonum = transform.position;
        skorDurum = true;
    }

    // Update is called once per frame
    void Update()
    {
        Skor();   
    }

    void Skor()
    {
        if (skorDurum)
        {
            if (transform.position.y < oncekiKonum.y)
                skor++;
            oncekiKonum = transform.position;
            OyunKontrol.oyunkontrol.SkorHesapla(skor);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Altin"))
        {
            altinSayisi++;
            skor += 200;
            OyunKontrol.oyunkontrol.SkorHesapla(skor);
            OyunKontrol.oyunkontrol.AltinHesapla(altinSayisi);
            AudioSource.PlayClipAtPoint(altinses, transform.position);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Can"))
        {
            canSayisi++;
            skor += 300;
            OyunKontrol.oyunkontrol.SkorHesapla(skor);
            OyunKontrol.oyunkontrol.CanHesapla(canSayisi);
            AudioSource.PlayClipAtPoint(canses, transform.position);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Sinir"))
        {
            kameraScript.hareketliKamera = false;
            skorDurum = false;

            OyunKontrol.oyunkontrol.OyunSonuPanelAc(skor, altinSayisi);
            canSayisi--;
            transform.position = new Vector3(500, 500, 0);
        }

        if (other.gameObject.CompareTag("Engel"))
        {
            kameraScript.hareketliKamera = false;
            skorDurum = false;
            OyunKontrol.oyunkontrol.OyunSonuPanelAc(skor, altinSayisi);
            canSayisi--;
            transform.position = new Vector3(500, 500, 0);
        }
    }
}
