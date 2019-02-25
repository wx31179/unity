using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private bool hasSpawn;
    private MoveScript moveScript;
    private WeaponScript weapon;
    void Awake()
    {
        weapon = GetComponent<WeaponScript>();
        moveScript = GetComponent<MoveScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        hasSpawn = false;
        GetComponent<Collider2D>().enabled = false;
        moveScript.enabled = false;
        weapon.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (hasSpawn == false)
        {
            if (transform.GetComponent<Renderer>().IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            if (weapon != null && weapon.CanAttack)
            {
                weapon.Attack(true);
            }
            if (transform.GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
        
    }
    private void Spawn()
    {
        hasSpawn = true;
        GetComponent<Collider2D>().enabled = true;
        moveScript.enabled = true;
        weapon.enabled = true;
    }
}
