using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myrigi;
    private Animator myanim;
    private float karakterhizi = 8f, maxhiz = 4f;
    void Start()
    {
        myrigi = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        KlavyeHareketleri();
    }

    void KlavyeHareketleri()
    {
        float xhiz = 0;
        float konum = Input.GetAxis("Horizontal");
        float guncelhiz = Mathf.Abs(myrigi.velocity.x);

        if (konum < 0)
        {
            if (guncelhiz < maxhiz)
                xhiz = -karakterhizi;

            Vector3 yon = transform.localScale;
            yon.x = -0.4f;
            transform.localScale = yon;

            myanim.SetBool("run", true);
        }
        else if (konum > 0)
        {
            if (guncelhiz < maxhiz)
                xhiz = karakterhizi;

            Vector3 yon = transform.localScale;
            yon.x = 0.4f;
            transform.localScale = yon;

            myanim.SetBool("run", true);
        }
        else
        {
            myanim.SetBool("run", false);
            myrigi.velocity = Vector2.zero;
        }

        myrigi.AddForce(new Vector2(xhiz, 0));
    }
}
