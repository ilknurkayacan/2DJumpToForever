using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NesneKaldir : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Engel") || collision.gameObject.CompareTag("Destek"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
