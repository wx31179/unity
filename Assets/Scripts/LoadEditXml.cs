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
    static XmlDocument xmlDoc = new XmlDocument();
    

    public static Dictionary<string, string> LoadSettingXml()
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

    public static Dictionary<string,string> LoadPlayerSettingXml()
    {
        string FilePath = Application.dataPath + @"/configs/PlayerSetting.xml";
        Dictionary<string, string> playersettingxml = new Dictionary<string, string>();
        if (File.Exists(FilePath))
        {
            xmlDoc.Load(FilePath);
            node = xmlDoc.SelectSingleNode("Player").ChildNodes;
            foreach(XmlElement i in node)
            {
                playersettingxml.Add(i.Name, i.InnerText);
            }

        }

        return playersettingxml;
    }

    public static void EditSettingXml()
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
}

