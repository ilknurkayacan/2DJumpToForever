using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NesneToplama : MonoBehaviour
{
    void Aktif()
    {
        Invoke(nameof(PasifYap), 6f);
    }
    void PasifYap()
    {
        gameObject.SetActive(false);
    }
}
