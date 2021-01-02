using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KusKontroll : MonoBehaviour {

    public Sprite[] kusSprite;
    SpriteRenderer spriteRenderer;
    bool ileriGeriKontrol = true;
    int kusSayac = 0;
    float kanatHiz = 0;

    Rigidbody2D fizik;

    int puan = 0;
    public Text puanText;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fizik.velocity = new Vector2(0, 0);
            fizik.AddForce(new Vector2(0, 200));
        }
        if (fizik.velocity.y > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 45);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -45);
        }


        Animasyon();

    }
    void Animasyon()
    {
        kanatHiz += Time.deltaTime;
        if (kanatHiz > 0.2f)
        {
            kanatHiz = 0;
            if (ileriGeriKontrol)
            {
                spriteRenderer.sprite = kusSprite[kusSayac];
                kusSayac++;
                if (kusSayac == kusSprite.Length)
                {
                    kusSayac--;
                    ileriGeriKontrol = false;
                }
            }
            else
            {
                kusSayac--;
                spriteRenderer.sprite = kusSprite[kusSayac];
                if (kusSayac == 0)
                {
                    kusSayac++;
                    ileriGeriKontrol = true;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Puan")
        {
            puan++;
            puanText.text = "Score: " + puan;
            Debug.Log(puan);
        }
    }
}
