using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Xml;

public class MenuScript : MonoBehaviour
{
    private ConfigScript configscript;
    public static MenuScript Instance;
    private SpecialEffectsHelper effectscript;
    private SoundEffectsHelper soundscript;
    private new AudioSource audio;
    private Dictionary<string, string> settingxml;
    private Dictionary<string, string> playersettingxml;
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } else if (Instance != null)
        {
            Destroy(gameObject);
        }
        settingxml = LoadEditXml.LoadSettingXml();
        if (settingxml["music"] == "0")
        {
            GameObject sound = GameObject.Find("script");
            audio = sound.GetComponent<AudioSource>();
            audio.enabled = false;

        }
        else
        {
            GameObject sound = GameObject.Find("script");
            audio = sound.GetComponent<AudioSource>();
            audio.enabled = true;

        }
        playersettingxml = LoadEditXml.LoadPlayerSettingXml();
        foreach (string i in playersettingxml.Keys)
        {
            Debug.Log(i + ":" + playersettingxml[i]);
        }

    }
    public void StartGame()
    {
        GameObject config = GameObject.Find("script");
        effectscript = config.GetComponent<SpecialEffectsHelper>();
        soundscript = config.GetComponent<SoundEffectsHelper>();
        effectscript.enabled = true;
        soundscript.enabled = true;
        SceneManager.LoadScene("Stage1");
        // "Stage1" is the name of the first scene we created.
        //Application.LoadLevel("Stage1");

    }

    public void Config()
    {
        GameObject config = GameObject.Find("script");
        configscript = config.GetComponent<ConfigScript>();
        configscript.enabled = true;
        SceneManager.LoadScene("config");
        Debug.Log("test");
        
    }
}