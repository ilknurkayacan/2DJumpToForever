using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanAyar : MonoBehaviour
{
  
    void Start()
    {
        //ekran g�r�n�m ayarlar�
        SpriteRenderer mysprite = GetComponent<SpriteRenderer>();
        Vector3 skala = transform.localScale;

        float width = mysprite.sprite.bounds.size.x;
        float dunyayukseklik = Camera.main.orthographicSize * 2f;
        float dunyageni�lik = dunyayukseklik / Screen.height * Screen.width;

        skala.x = dunyageni�lik / width;
        transform.localScale = skala;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
