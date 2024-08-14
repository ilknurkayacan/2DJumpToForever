using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzikKontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public static MuzikKontrol muzikKontrol;
    private AudioSource sesKaynagi;
    private void Awake()
    {
        NesneMuzik();
        sesKaynagi = GetComponent<AudioSource>();
    }

    void NesneMuzik()
    {
        if (muzikKontrol != null)
            Destroy(gameObject);
        else
        {
            muzikKontrol = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void OynatMuzik(bool oynat)
    {
        if(oynat)
        {
            if (!sesKaynagi.isPlaying)
            {
                sesKaynagi.Play();
            }
            else
            {
                if (sesKaynagi.isPlaying)
                {
                    sesKaynagi.Stop();
                }
            }
        }
    }
}
