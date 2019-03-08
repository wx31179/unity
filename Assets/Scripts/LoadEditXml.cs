using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;


public class LoadEditXml : MonoBehaviour
{
    public static LoadEditXml Instance;
    public static XmlNodeList node;
    public string FilePath;
    XmlDocument xmlDoc = new XmlDocument();

    void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of LoadEditXml!");
        }
        Instance = this;

    }


    public Dictionary<string, string> LoadSettingXml()
    {
        string FilePath = Application.dataPath + @"/configs/GlobalSetting.xml";
        Dictionary<string, string> settingxml = new Dictionary<string, string>();
        if (File.Exists(FilePath))
        {
            xmlDoc.Load(FilePath);
            node = xmlDoc.SelectSingleNode("setting").ChildNodes;
            foreach (XmlElement i in node)
            {
                settingxml.Add(i.Name, i.InnerText);
            }

        }
        return settingxml;
    }

    public void EditSettingXml()
    {
        string FilePath = Application.dataPath + @"/configs/GlobalSetting.xml";
        foreach (XmlElement nodeList in node)
        {
            if (nodeList.Name == "music")
            {
                if (nodeList.InnerXml == "1")
                {
                    nodeList.InnerXml = "0";
                    xmlDoc.Save(FilePath);
                    Debug.Log("change 0");
                }
                else
                {
                    nodeList.InnerXml = "1";
                    xmlDoc.Save(FilePath);
                    Debug.Log("change 1");
                }
            }
        }
    }

    public Dictionary<string, string> LoadPlayerXml()
    {
        string FilePath = Application.dataPath + @"/configs/PlayerSetting.xml";
        Dictionary<string, string> playerxml = new Dictionary<string, string>();
        if (File.Exists(FilePath))
        {
            xmlDoc.Load(FilePath);
            node = xmlDoc.SelectSingleNode("player").ChildNodes;
            foreach (XmlElement i in node)
            {
                playerxml.Add(i.Name, i.InnerText);
            }

        }
        return playerxml;

    }
}

