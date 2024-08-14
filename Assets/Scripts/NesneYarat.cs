using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NesneYarat : MonoBehaviour
{
    [SerializeField]
    private GameObject[] nesneler;
    private float nesneMesafesi = 5f;
    private float xMax, xMin;
    private float enSonNesneKonumY;
    private float duzenleyici;
    private GameObject karakter;
    [SerializeField]
    private GameObject[] toplayicilar;

    
    void Awake()
    {
        duzenleyici = 0;
        MaxMinAyarla();
        NesneOlustur();
        karakter = GameObject.Find("Player");

        for (int i = 0; i < toplayicilar.Length; i++)
            toplayicilar[i].SetActive(false);
    }

    
    void Start()
    {
        KarakterKonumu(); 
    }

    void MaxMinAyarla()
    {
        Vector3 alan = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        xMin = -alan.x + 1f;
        xMax = alan.x - 1f;
    }

    void NesneleriKaristir(GameObject[] nesneler)
    {
        for(int i = 0; i < nesneler.Length; i++)
        {
            GameObject depo = nesneler[i];
            int rasgele = Random.Range(i, nesneler.Length);
            nesneler[i] = nesneler[rasgele];
            nesneler[rasgele] = depo;
        }
    }

    void NesneOlustur()
    {
        NesneleriKaristir(nesneler);
        NesneleriKaristir(toplayicilar);
        float konumY = 0;

        for(int i = 0; i < nesneler.Length; i++)
        {
            Vector3 depo = nesneler[i].transform.position;
            depo.y = konumY;

            if (duzenleyici == 0)
            {
                depo.x = Random.Range(0, xMax);
                duzenleyici = 1;
            }
            else if (duzenleyici == 1)
            {
                depo.x = Random.Range(0, xMin);
                duzenleyici = 2;
            }
            else if (duzenleyici == 2)
            {
                depo.x = Random.Range(1, xMax);
                duzenleyici = 3;
            }
            else if (duzenleyici == 3)
            {
                depo.x = Random.Range(-1, xMin);
                duzenleyici = 0;
            }
            enSonNesneKonumY = konumY;
            nesneler[i].transform.position = depo;
            konumY -= nesneMesafesi;
        }
    }

    void KarakterKonumu()
    {
        GameObject[] engeller = GameObject.FindGameObjectsWithTag("Engel");
        GameObject[] destekler = GameObject.FindGameObjectsWithTag("Destek");

        for(int i = 0; i < engeller.Length; i++)
        {
            if (engeller[i].transform.position.y == 0)
            {
                Vector3 t = engeller[i].transform.position;
                engeller[i].transform.position = new Vector3(destekler[0].transform.position.x, destekler[0].transform.position.y, destekler[0].transform.position.z);
                destekler[0].transform.position = t;
            }
        }
        Vector3 depo = destekler[0].transform.position;
        for(int i = 0; i < destekler.Length; i++)
        {
            if (destekler[i].transform.position.y > depo.y)
                depo = destekler[i].transform.position;
        }
        depo.y += 1f;
        karakter.transform.position = depo;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Destek") || collision.gameObject.CompareTag("Engel"))
        {
            if (collision.transform.position.y == enSonNesneKonumY)
            {
                NesneleriKaristir(nesneler);
                NesneleriKaristir(toplayicilar);

                Vector3 depo = collision.gameObject.transform.position;
                for(int i = 0; i < nesneler.Length; i++)
                {
                    if(!nesneler[i].activeInHierarchy)
                    {
                        if (duzenleyici == 0)
                        {
                            depo.x = Random.Range(0, xMax);
                            duzenleyici = 1;
                        }
                        else if (duzenleyici == 1)
                        {
                            depo.x = Random.Range(0, xMin);
                            duzenleyici = 2;
                        }
                        else if (duzenleyici == 2)
                        {
                            depo.x = Random.Range(1, xMax);
                            duzenleyici = 3;
                        }
                        else if (duzenleyici == 3)
                        {
                            depo.x = Random.Range(-1, xMin);
                            duzenleyici = 0;
                        }

                        depo.y -= nesneMesafesi;
                        enSonNesneKonumY = depo.y;
                        nesneler[i].transform.position = depo;
                        nesneler[i].SetActive(true);

                        int rasgele = Random.Range(0, toplayicilar.Length);

                        if (nesneler[i].tag != "Engel")
                        {
                            if (!toplayicilar[rasgele].activeInHierarchy)
                            {
                                Vector3 depotop = nesneler[i].transform.position;
                                depotop.y += 0.7f;

                                if (toplayicilar[rasgele].tag == "Can")
                                {
                                    if (PlayerSkor.canSayisi < 2)
                                    {
                                        toplayicilar[rasgele].transform.position = depotop;
                                        toplayicilar[rasgele].SetActive(true);
                                    }
                                }
                                else
                                {
                                    toplayicilar[rasgele].transform.position = depotop;
                                    toplayicilar[rasgele].SetActive(true);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
