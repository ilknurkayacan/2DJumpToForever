using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneGecis : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject fadePanel;

    [SerializeField]
    private Animator fadeanim;

    public static SahneGecis sahneGecis;
    private void Awake()
    {
        NesneSahne();
    }
    void NesneSahne()
    {
        if (sahneGecis != null)
            Destroy(gameObject);
        else
        {
            sahneGecis = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void LoadLevel(string bolum)
    {
        StartCoroutine(FadeInOut(bolum));
    }

    IEnumerator FadeInOut(string bolum)
    {
        fadePanel.SetActive(true);
        fadeanim.Play("FadeIn");
        yield return StartCoroutine(ZamanDuzenle.GercekZamaniBekle(1f));
        SceneManager.LoadScene(bolum);
        fadeanim.Play("FadeOut");
        yield return StartCoroutine(ZamanDuzenle.GercekZamaniBekle(.7f));
        fadePanel.SetActive(false);
    }
}
