using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Stage1");
        // "Stage1" is the name of the first scene we created.
        //Application.LoadLevel("Stage1");

    }
}