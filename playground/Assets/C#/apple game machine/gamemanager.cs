using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;

    AudioSource aso;
    public Text score_T;
    public SpriteRenderer hp_I;
    public GameObject gameoverpanel;
    public float score;
    public int hpnum = 2;
    public Text upxp_T;
    public int upxp;
    public List<Sprite> hp = new List<Sprite>();
    public List<AudioClip> sound = new List<AudioClip>();

    private void Awake()
    {
        instance = this;

        Time.timeScale = 1;

        aso = GetComponent<AudioSource>();

        upxp = 10;
    }
    private void Update()
    {
        score_T.text = score.ToString();

        
    }

    public void addpoint()
    {
        score++;

        if (score % 10 == 0 && score != 0)
            upxp += 5;
    }

    public void missapple()
    {
        hpnum--;

        if(hpnum == -1)
        {
            hpnum = 0;

            gameover();
        }
        else
        {
            hp_I.sprite = hp[hpnum];
        }
    }

    public void playsound(int index)
    {
        aso.clip = sound[index];

        aso.Play();
    }

    public void gameover()
    {
        gameoverpanel.SetActive(true);
        Time.timeScale = 0;

        //up xp
        upxp_T.text = "+" + upxp.ToString();

        PlayerPrefs.SetFloat("latexp", PlayerPrefs.GetFloat("latexp") + upxp);

        //highest point
        if(PlayerPrefs.GetFloat("applebestpoint") < score)
        {
            PlayerPrefs.SetFloat("applebestpoint", score);
        }
        PlayerPrefs.SetFloat("applelastpoint",score);
    }

    public void again()
    {
        SceneManager.LoadScene("game01");
    }
    public void quit()
    {
        SceneManager.LoadScene("playground");
    }
}
