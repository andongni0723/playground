using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playground_gamemanager : MonoBehaviour
{
    public Text applebestpoint_T;

    private void Awake()
    {
        haskey("applebestpoint", applebestpoint_T);
    }

    public void applemachine()
    {
        SceneManager.LoadScene("game01");
    }

    public void haskey(string key,Text text)
    {
        if (PlayerPrefs.HasKey(key))
        {
            text.text = PlayerPrefs.GetFloat(key).ToString();
        }
        else
        {
            text.text = "0";
        }
    }

    public void changescene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
