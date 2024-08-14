using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    private float hiz = 1f;
    private float hizlanma = 0.2f;
    private float maxhiz = 3.2f;

    private float kolayHiz = 3.4f;
    private float normalHiz = 3.8f;
    private float zorHiz = 4.2f;

    [HideInInspector]
    public bool hareketliKamera;
    void Start()
    {

        if (OyunTercihleri.GetirNormalZorlukDurumu() == 1)
            maxhiz = normalHiz;
        if (OyunTercihleri.GetirKolayZorlukDurumu() == 1)
            maxhiz = kolayHiz;
        if (OyunTercihleri.GetirYuksekZorlukDurumu() == 1)
            maxhiz = zorHiz;
        hareketliKamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hareketliKamera)
            HareketliKamera();
    }

    void HareketliKamera()
    {
        Vector3 depo = transform.position;
        float oncekiY = depo.y;
        float yeniY = depo.y - (hiz * Time.deltaTime);
        depo.y = Mathf.Clamp(depo.y, oncekiY, yeniY);
        transform.position = depo;
        hiz += hizlanma * Time.deltaTime;
        if (hiz > maxhiz)
            hiz = maxhiz;
    }
}
