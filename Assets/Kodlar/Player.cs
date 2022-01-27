using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float ziplama = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string CurrentColor;

    public Color ColorMor;
    public Color ColorPembe;
    public Color ColorSarı;
    public Color ColorMavi;
    public Text txt,skor,eniyi;
    public int deger,number;
    public GameObject bir,iki,uc,dort,panel;

    void Start()
    {
        RandomColor();
        rb.bodyType = RigidbodyType2D.Static; //oyun başında player statik yapılıyor
        panel.SetActive(false); //panel oyun başında akti değil
        eniyi.text =PlayerPrefs.GetInt("BestScore",0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = deger.ToString("f0");
        if(Input.GetButtonDown ("Jump") || (Input.GetMouseButtonDown (0)))  //Boşluk tuşu ve fare sol tık
        {
            rb.bodyType = RigidbodyType2D.Dynamic; //işlem yapıldığında player dinamik oluyor
            rb.velocity = Vector2.up * ziplama;  //Düzgün bir şekilde hızlanması için
        }
    }
     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "ColorChanger")
        {
            col.gameObject.transform.position = transform.position + new Vector3 (0f,25f,0f);
            bir.transform.position = transform.position + new Vector3 (0f,21f,0f);
            deger +=1;
            number +=1;
            skor.text = number.ToString();
            if(number > PlayerPrefs.GetInt ("BestScore",0))
            {
                PlayerPrefs.SetInt ("BestScore",number);
                eniyi.text = number.ToString();
            }
            RandomColor();
           // Destroy (col.gameObject);
            return;
        }
         if(col.tag == "two")
        {
            col.gameObject.transform.position = transform.position + new Vector3 (0f,25f,0f);
            iki.transform.position = transform.position + new Vector3 (0f,21f,0f);
            deger +=1;
            number +=1;
            skor.text = number.ToString();
            if(number > PlayerPrefs.GetInt ("BestScore",0))
            {
                PlayerPrefs.SetInt ("BestScore",number);
                eniyi.text = number.ToString();
            }
            RandomColor();
           // Destroy (col.gameObject);
            return;
        }
         if(col.tag == "three")
        {
            col.gameObject.transform.position = transform.position + new Vector3 (0f,25f,0f);
            uc.transform.position = transform.position + new Vector3 (0f,21f,0f);
            dort.transform.position = transform.position + new Vector3 (0f,21f,0f);

            deger +=1;
            number +=1;
            skor.text = number.ToString();
            if(number > PlayerPrefs.GetInt ("BestScore",0))
            {
                PlayerPrefs.SetInt ("BestScore",number);
                eniyi.text = number.ToString();
            }
            RandomColor();
           // Destroy (col.gameObject);
            return;
        }
        if(col.tag != CurrentColor)
        {
            //Debug.Log("Oyun Bitti");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            panel.SetActive(true); //panel aktifleştirilir
            Time.timeScale = 0; //oyun alanındaki her şey donar
        }
        if(col.tag == "Respawn")
        {
           //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
           panel.SetActive(true); //panel aktifleştirilir
            Time.timeScale = 0;
        }
    }
    void RandomColor()
    {
        int index = Random.Range (0, 4);

        switch (index){
        case 0:
            CurrentColor = "Mavi";
            sr.color = ColorMavi;
            break;  
        case 1:
            CurrentColor = "Sarı";
            sr.color = ColorSarı;
            break;
        case 2:
            CurrentColor = "Pembe";
            sr.color = ColorPembe;
            break;
        case 3:
            CurrentColor = "Mor";
            sr.color = ColorMor; 
            break;              
        }
        

    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        panel.SetActive(false);
        Time.timeScale =1;
    }
    public void Replay()
    {
        this.transform.position = transform.position + new Vector3 (0f,1.5f,0f);
        panel.SetActive(false);
        Time.timeScale = 1;
        rb.bodyType = RigidbodyType2D.Static;
    }
    public void Stop()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
        
    }
    public void Cıkıs()
    {
        SceneManager.LoadScene(0);
    }
}
