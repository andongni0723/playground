using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class login_gamemanager : MonoBehaviour
{
    public GameObject errorpanel;
    public Text errortext_T;

    public void playerlogin()
    {
        SceneManager.LoadScene("main");
    }

    public void error(string errortext)
    {
        errorpanel.SetActive(true);
        errortext_T.text = errortext;
    }
}
