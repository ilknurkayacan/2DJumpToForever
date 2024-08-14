using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKontrol : MonoBehaviour
{
    public float karakterhizi = 8f, maxSurat = 4f;
    private Rigidbody2D myrigi;
    private Animator myanim;

    private bool solaGit, sagagit;

    private void Awake()
    {
        myrigi = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (solaGit)
        {
            SolaGit();
        }

        if (sagagit)
        {
            SagaGit();
        }
    }

    public void AyarlaSolaGit(bool solaGit)
    {
        this.solaGit = solaGit;
        this.sagagit = !solaGit;
    }

    public void HareketiDurdur()
    {
        solaGit = sagagit = false;
        myanim.SetBool("run",false);
    }

    void SolaGit()
    {
        float xhiz = 0f;
        float hiz = Mathf.Abs(myrigi.velocity.x);

        if (hiz < maxSurat)
            xhiz = -karakterhizi;

        Vector3 yon = transform.localScale;
        yon.x = -0.3f;
        transform.localScale = yon;

        myanim.SetBool("run", true);
        myrigi.AddForce(new Vector2(xhiz, 0));
    }

    void SagaGit()
    {
        float xhiz = 0f;
        float hiz = Mathf.Abs(myrigi.velocity.x);

        if (hiz < maxSurat)
            xhiz = karakterhizi;

        Vector3 yon = transform.localScale;
        yon.x = 0.3f;
        transform.localScale = yon;

        myanim.SetBool("run", true);
        myrigi.AddForce(new Vector2(xhiz, 0));
    }
}

