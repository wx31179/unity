﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScrollingScript : MonoBehaviour
{
    #region
    public Vector2 speed = new Vector2(2, 2);
    public Vector2 direction = new Vector2(-1, 0);
    public bool isLinkedToCamera = false;
    public bool isLoop = false;
    private List<Transform> backgroundpart;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        if (isLoop)
        {
            backgroundpart = new List<Transform>();


            //Debug.Log(transform);

            //Debug.Log(transform.childCount);

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);

                if (child.GetComponent<Renderer>() != null)
                {
                    backgroundpart.Add(child);
                }
                    
            }
            //Debug.Log(transform);

            //Debug.Log(transform.childCount);

            backgroundpart = backgroundpart.OrderBy(t=> t.position.x).ToList();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);

        }
        if (isLoop)
        {
            Transform firstChild = backgroundpart.FirstOrDefault();
            if (firstChild != null)
            {

                ////Debug.Log("first:"+firstChild.position.x);
                ////Debug.Log("camera:"+Camera.main.transform.position.x);
                if (firstChild.position.x < Camera.main.transform.position.x)
                {
                    if (firstChild.GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
                    {
                        Transform lastChild = backgroundpart.LastOrDefault();
                        Vector3 lastPostion = lastChild.transform.position;
                        Vector3 lastSize = (lastChild.GetComponent<Renderer>().bounds.max - lastChild.GetComponent<Renderer>().bounds.min);

                        firstChild.position = new Vector3(lastPostion.x + lastSize.x, firstChild.position.y, firstChild.position.z);
                        backgroundpart.Remove(firstChild);
                        backgroundpart.Add(firstChild);
                    }
                }

            }
        }
    }
}
