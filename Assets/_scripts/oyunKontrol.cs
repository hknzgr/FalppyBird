using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyunKontrol : MonoBehaviour {

    public GameObject gokyuzuBir;
    public GameObject gokyuzuİki;
    public float arkaplanHiz=-1.5f;

    Rigidbody2D fizikBir;
    Rigidbody2D fizikİki;

    float uzunluk = 0;

    public GameObject engel;
    public int engelSayisi=5;
    GameObject[] engeller;

    float degisimZamani=0;
    int sayac = 0;

    bool oyunBitti = true;


	void Start ()
    {
        fizikBir = gokyuzuBir.GetComponent<Rigidbody2D>();
        fizikİki = gokyuzuİki.GetComponent<Rigidbody2D>();

        fizikBir.velocity=new Vector2(arkaplanHiz, 0);
        fizikİki.velocity = new Vector2(arkaplanHiz, 0);

        uzunluk = gokyuzuBir.GetComponent<BoxCollider2D>().size.x;

        engeller = new GameObject[engelSayisi];

        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i] = Instantiate(engel,new Vector2(-20,-20),Quaternion.identity);
            Rigidbody2D fizikEngel= engeller[i].AddComponent<Rigidbody2D>();
            fizikEngel.gravityScale = 0;
            fizikEngel.velocity = new Vector2(arkaplanHiz, 0);
        }
    }
	
	
	void Update ()
    {
        if (oyunBitti)
        {
            if (gokyuzuBir.transform.position.x <= -uzunluk)
            {
                gokyuzuBir.transform.position += new Vector3(uzunluk * 2, 0);
            }
            if (gokyuzuİki.transform.position.x <= -uzunluk)
            {
                gokyuzuİki.transform.position += new Vector3(uzunluk * 2, 0);
            }

            //--------------------------------------------------------------------------

            degisimZamani += Time.deltaTime;
            if (degisimZamani > 2f)
            {
                degisimZamani = 0;
                float Yeksenim = Random.Range(-0.20f, 1.5f);
                engeller[sayac].transform.position = new Vector3(17, Yeksenim);
                sayac++;
                if (sayac >= engeller.Length)
                {
                    sayac = 0;
                }
            }
        }

		
    }

    public void oyunbitti()
    {
        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            fizikBir.velocity = Vector2.zero;
            fizikİki.velocity = Vector2.zero;
        }
        oyunBitti = false;
    }
}
