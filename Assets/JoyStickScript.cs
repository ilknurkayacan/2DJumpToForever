using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    private PlayerKontrol playerKontrol;

    private void Start()
    {
        playerKontrol = GameObject.Find("Player").GetComponent<PlayerKontrol>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "SolBtn")
        {
            playerKontrol.AyarlaSolaGit(true);

        }
        else
        {
            playerKontrol.AyarlaSolaGit(false);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerKontrol.HareketiDurdur();
    }
}
