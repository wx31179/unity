using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Xml;
using UnityEngine.UI;

public class ConfigScript : MonoBehaviour
{
    private static bool music;
    private new AudioSource audio;
    private Dictionary<string, string> settingxml;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        settingxml = LoadEditXml.Instance.LoadSettingXml();       
            if (settingxml["music"] == "0")
            {
                GameObject sound = GameObject.Find("backgroundmusic-config");
                audio = sound.GetComponent<AudioSource>();
                audio.enabled = false;
                Text text = GameObject.FindGameObjectWithTag("text").GetComponent<Text>();
                text.text = "打开声音";

            }
            else
            {
                GameObject sound = GameObject.Find("backgroundmusic-config");
                audio = sound.GetComponent<AudioSource>();
                audio.enabled = true;
                Text text = GameObject.FindGameObjectWithTag("text").GetComponent<Text>();
                text.text = "关闭声音";

            }     
    }
    public void TurnOffMusic()
    {
        LoadEditXml.Instance.EditSettingXml();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log(music);

    }
}
    

