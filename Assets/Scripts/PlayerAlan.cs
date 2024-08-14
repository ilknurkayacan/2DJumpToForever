using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlan : MonoBehaviour
{
    // Start is called before the first frame update
    private float xmax, xmin;
    void Start()
    {
        MaxMinAyarla();
    }

    // Update is called once per frame
    void Update()
    {
        SinirBelirle();   
    }
    void MaxMinAyarla()
    {
        Vector3 alan = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        xmax = alan.x - 0.5f;
        xmin = -alan.x + 0.5f;
    }

    void SinirBelirle()
    {
        if (transform.position.x > xmax)
        {
            Vector3 depo = transform.position;
            depo.x = xmax;
            transform.position = depo;
        }
        if (transform.position.x < xmin)
        {
            Vector3 depo = transform.position;
            depo.x = xmin;
            transform.position = depo;
        }
    }
}
