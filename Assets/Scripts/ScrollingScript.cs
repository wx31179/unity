using System.Collections;
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
<<<<<<< HEAD
            //Debug.Log(transform);
=======
            //Debug.Log(transform.childCount);
>>>>>>> cbb6aaa8c5ea203e62d1934b51d3c4974a2de610
            for (int i = 0;i < transform.childCount;i++)
            {
                Transform child = transform.GetChild(i);
                
<<<<<<< HEAD
                if (child.GetComponent<Renderer>() != null)
=======
                if (GetComponent<Renderer>() != null)
>>>>>>> cbb6aaa8c5ea203e62d1934b51d3c4974a2de610
                {
                    //Debug.Log(GetComponent<Renderer>());
                    backgroundpart.Add(child);
                }
            }
            backgroundpart = backgroundpart.OrderBy(t=> t.position.x).ToList();
            for (int i =0;i < backgroundpart.Count;i++)
            {
                Debug.Log(backgroundpart[i]);
            }
            
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
<<<<<<< HEAD
            //Debug.Log(movement);
=======
            //Debug.Log(transform);
>>>>>>> cbb6aaa8c5ea203e62d1934b51d3c4974a2de610
        }
        if (isLoop)
        {
            Transform firstChild = backgroundpart.FirstOrDefault();
            if (firstChild != null)
            {
<<<<<<< HEAD
                ////Debug.Log("first:"+firstChild.position.x);
                ////Debug.Log("camera:"+Camera.main.transform.position.x);
                if (firstChild.position.x < Camera.main.transform.position.x)
                {
                    if (firstChild.GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
                    {
                        Transform lastChild = backgroundpart.LastOrDefault();
                        Vector3 lastPostion = lastChild.transform.position;
                        Vector3 lastSize = (lastChild.GetComponent<Renderer>().bounds.max - lastChild.GetComponent<Renderer>().bounds.min);
=======
                if (firstChild.position.x < Camera.main.transform.position.x)
                {
                    if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
                    {
                        Transform lastChild = backgroundpart.LastOrDefault();
                        Vector3 lastPostion = lastChild.transform.position;
                        Vector3 lastSize = (GetComponent<Renderer>().bounds.max - GetComponent<Renderer>().bounds.min);
>>>>>>> cbb6aaa8c5ea203e62d1934b51d3c4974a2de610
                        firstChild.position = new Vector3(lastPostion.x + lastSize.x, firstChild.position.y, firstChild.position.z);
                        backgroundpart.Remove(firstChild);
                        backgroundpart.Add(firstChild);
                    }
                }

            }
        }
    }
}
