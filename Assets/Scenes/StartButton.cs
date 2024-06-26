using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] GameObject panel;
    private void Start()
    {
        
    }
    public void OnClickStart()
    {
        SceneManager.LoadScene("MainScene");
        Debug.Log("ìÆçÏÇµÇΩ");
    } 

    public void SousaSetumeiOn()
    {
        panel.SetActive(true);
        Debug.Log("dousasita ");
    }

    public void SousaSetumeiOff()
    {
        panel.SetActive(false);
        Debug.Log("dousasita ");

    }
}
