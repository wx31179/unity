using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Xml;

public class MenuScript : MonoBehaviour
{
    private ConfigScript configscript;
    private LoadEditXml loadeditxml;
    public static MenuScript Instance;
    private SpecialEffectsHelper effectscript;
    private SoundEffectsHelper soundscript;
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
        //string filePath = Application.dataPath + @"/configs/GlobalSetting.xml";
        //if (File.Exists(filePath))
        //{
        //    XmlDocument xmlDoc = new XmlDocument();
        //    xmlDoc.Load(filePath);
        //    XmlNodeList node = xmlDoc.SelectSingleNode("setting").ChildNodes;
        //    foreach (XmlElement nodeList in node)
        //    {
        //        if (nodeList.Name == "music")
        //        {
        //            if (nodeList.InnerXml == "1")
        //            {
                        
        //            }
        //            else
        //            {
        //                GameObject sound = GameObject.Find("script");
        //                audio = sound.GetComponent<AudioSource>();
        //                audio.enabled = false;
        //            }
        //        }
        //    }
        //}

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
        loadeditxml = config.GetComponent<LoadEditXml>();
        loadeditxml.enabled = true;
        configscript.enabled = true;
        SceneManager.LoadScene("config");
        Debug.Log("test");
        
    }
}