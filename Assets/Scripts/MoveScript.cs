using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);
    private Vector2 movement;
    private GameObject background;
    [SerializeField]
    Sprite mySprite;


    // Start is called before the first frame update
    void Start()
    {
        //background = GameObject.FindGameObjectWithTag("background");
        //SpriteRenderer sr = background.GetComponent<SpriteRenderer>();
        //sr.sprite = Resources.Load("background", typeof(Sprite)) as Sprite;
        //Debug.Log(sr);
        
    }   

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
 


    }
}
