using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void ButtonRetry()
    {
        SceneManager.LoadScene("Title");
        Debug.Log("ìÆçÏÇµÇΩ2");
    }
}
