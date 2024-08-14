using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanAyar : MonoBehaviour
{
  
    void Start()
    {
        //ekran görünüm ayarlarý
        SpriteRenderer mysprite = GetComponent<SpriteRenderer>();
        Vector3 skala = transform.localScale;

        float width = mysprite.sprite.bounds.size.x;
        float dunyayukseklik = Camera.main.orthographicSize * 2f;
        float dunyageniþlik = dunyayukseklik / Screen.height * Screen.width;

        skala.x = dunyageniþlik / width;
        transform.localScale = skala;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
