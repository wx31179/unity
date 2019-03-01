using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigScript : MonoBehaviour
{
    public bool music = true;
    private static bool haveConfig = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!haveConfig)
        {
            GameObject config = GameObject.Find("script");
            Debug.Log(config.GetComponent<ConfigScript>().music);
            haveConfig = true;
            GameOverScript.DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            music = true;
            Debug.Log(music);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TurnOffMusic()
    {
        if (music)
        {
            music = false;
        }
        else
        {
            music = true;
        }
        

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");

    }

}
