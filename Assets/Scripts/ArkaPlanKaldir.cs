using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanKaldir : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arkaplan"))
            collision.gameObject.SetActive(false);
    }
}
