using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZamanDuzenle : MonoBehaviour
{
    public static IEnumerator GercekZamaniBekle(float zaman)
    {
        float baslangic = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < (baslangic + zaman))
        {
            yield return null;
        }
    }
}
