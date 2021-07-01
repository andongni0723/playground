using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lobby_gamegamager : MonoBehaviour
{
    [Header("клеє")]
    public Text grade_T;
    public Text XP_T;
    public Slider XP_S;

    public Text coin_T;
    public Text diamond_T;

    public GameObject gradeuppanel;
    public Text aboutgrade_T;
    public Text getcoin_T;
    public Text getdiamond_T;
   
    int grade;
    float XP;
    float maxXP;

    int coin;
    int diamond;

    int getcoin;
    int getdiamond;

    private void Awake()
    {

        //PlayerPrefs.DeleteKey("grade");
        //PlayerPrefs.DeleteKey("xp");
        //PlayerPrefs.DeleteKey("maxxp");

        if (PlayerPrefs.GetInt("grade") == 0)
        {
            //XP
            grade = 1;           
            XP = 0;
            maxXP = 10;

            XP_S.minValue = 0;
            XP_S.maxValue = 10;

            //money
            coin = 50;
            diamond = 10;
        }
        else
        {
            grade = PlayerPrefs.GetInt("grade");
            XP = PlayerPrefs.GetFloat("xp");
            maxXP = PlayerPrefs.GetFloat("maxxp");

            XP_S.minValue = maxXP - grade * 10;
            XP_S.maxValue = maxXP;
            XP_S.value = XP;
        }

        XP += PlayerPrefs.GetFloat("latexp");
        //PlayerPrefs.SetFloat("xp", PlayerPrefs.GetFloat("xp") + PlayerPrefs.GetFloat("latexp"));
        //Debug.Log(PlayerPrefs.GetFloat("latexp"));
        PlayerPrefs.SetFloat("latexp", 0);
    }
    private void Update()
    {   
        //save data
        xp();
        money();

        
        if (gradeuppanel.activeInHierarchy)
        {
            //Debug.Log("d");
            if (Input.GetMouseButtonDown(0))
                gradeuppanel.SetActive(false);
        }
    }

    public void xp()
    {
        //save
        PlayerPrefs.SetInt("grade", grade);
        PlayerPrefs.SetFloat("xp", XP);
        PlayerPrefs.SetFloat("maxxp", maxXP);

        grade_T.text = grade.ToString();
        XP_T.text = XP.ToString("0") + "/" + maxXP.ToString("0");
        XP_S.value = XP;

        if(XP >= maxXP)
        {
            gradeup();
        }
    }

    public void money()
    {
        //save
        PlayerPrefs.SetInt("coin", coin);
        PlayerPrefs.SetInt("diamond", diamond);

        coin_T.text = coin.ToString();
        diamond_T.text = diamond.ToString();
    }

    public void gradeup()
    {    
        //updata data
        grade++;

        XP_S.minValue = maxXP;

        maxXP += grade * 10;
        XP_S.maxValue = maxXP;

        //show panel
        gradeuppanel.SetActive(true);

        aboutgrade_T.text = (grade-1).ToString() + " <b><color='#FF9D00'>>>></color></b> " + grade.ToString();

        getcoin = 20;

        if (grade % 5 == 0 && grade != 0)
            getdiamond = 5;
        else
            getdiamond = 0;

        getcoin_T.text ="+" + getcoin.ToString();
        getdiamond_T.text = "+" + getdiamond.ToString();

        //getmoey add to money
        coin += getcoin;
        diamond += getdiamond;
    }

    public void upxp()
    {
        XP += 10;
    }

    public void d()
    {
       
        PlayerPrefs.DeleteKey("grade");
        PlayerPrefs.DeleteKey("xp");
        PlayerPrefs.DeleteKey("maxxp");
    }

    public void changescene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
