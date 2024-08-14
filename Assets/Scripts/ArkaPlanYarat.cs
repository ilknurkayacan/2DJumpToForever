using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanYarat : MonoBehaviour
{
    private GameObject[] arkaplan;
    private float sonY;

    void Start()
    {
        SonArkaPlan();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SonArkaPlan()
    {
        arkaplan = GameObject.FindGameObjectsWithTag("Arkaplan");
        sonY = arkaplan[0].transform.position.y;
        for(int i = 1; i < arkaplan.Length; i++)
        {
            if (sonY > arkaplan[i].transform.position.y)
                sonY = arkaplan[i].transform.position.y;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arkaplan"))
        {
            if (collision.gameObject.transform.position.y == sonY)
            {
                Vector3 depo = collision.gameObject.transform.position;
                float yukseklik = ((BoxCollider2D)collision).size.y;
                for(int i = 0; i < arkaplan.Length; i++)
                {
                    if (!arkaplan[i].activeInHierarchy)
                    {
                        depo.y -= yukseklik;
                        sonY = depo.y;
                        arkaplan[i].transform.position = depo;
                        arkaplan[i].SetActive(true);
                    }
                }
            }
        }
    }
}
