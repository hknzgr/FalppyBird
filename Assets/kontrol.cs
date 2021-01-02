using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kontrol : MonoBehaviour {

    public Sprite[] kusSprite;
    SpriteRenderer spriteRenderer;
    bool ileriGeriKontrol = true;
    int kusSayac = 0;
    float kanatHiz = 0;
    public float kusForce = 220f;

    Rigidbody2D fizik;

    int puan = 0;
    public Text puanText;
    bool oyunbitti = true;

    oyunKontrol oyunControl;

    AudioSource []sesler;

    int highScore = 0;

    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        oyunControl = GameObject.FindGameObjectWithTag("oyunControl").GetComponent<oyunKontrol>();
        sesler = GetComponents<AudioSource>();
        highScore = PlayerPrefs.GetInt("enyuksekpuan");
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && oyunbitti)
        {
            fizik.velocity = new Vector2(0, 0);
            fizik.AddForce(new Vector2(0, kusForce));
            sesler[0].Play();
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
            sesler[1].Play();
		}
        if (col.gameObject.tag=="Engel")
        {
            oyunbitti = false;
            sesler[2].Play();
            oyunControl.oyunbitti();
            GetComponent<CircleCollider2D>().enabled = false;

            if (puan>highScore)
            {
                highScore = puan;
                PlayerPrefs.SetInt("enyuksekpuan", highScore);
            }
            Invoke("anaMenuyeDon", 3);
        }
        
	}

    void anaMenuyeDon()
    {
        PlayerPrefs.SetInt("alinanPuan", puan);
        SceneManager.LoadScene("mainScreen");
    }
}