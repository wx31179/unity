using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Xml;

public class MenuScript : MonoBehaviour
{
    private AudioSource audio;
    void Awake()
    {
        string filePath = Application.dataPath + @"/configs/GlobalSetting.xml";
        if (File.Exists(filePath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            XmlNodeList node = xmlDoc.SelectSingleNode("setting").ChildNodes;
            foreach (XmlElement nodeList in node)
            {
                if (nodeList.Name == "music")
                {
                    if (nodeList.InnerXml == "1")
                    {
                        
                    }
                    else
                    {
                        GameObject sound = GameObject.Find("backgroundmusic-menu");
                        audio = sound.GetComponent<AudioSource>();
                        audio.enabled = false;
                    }
                }
            }
        }

    }
    public void StartGame()
    {
        SceneManager.LoadScene("Stage1");
        // "Stage1" is the name of the first scene we created.
        //Application.LoadLevel("Stage1");

    }

    public void Config()
    {
        SceneManager.LoadScene("config");
    }
}