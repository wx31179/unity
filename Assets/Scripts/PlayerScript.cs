﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector2 speed = new Vector2(50, 50);
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        movement = new Vector2(speed.x * inputX, speed.y * inputY);
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");
        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                weapon.Attack(false);
            }
        }

        var dist = (transform.position - Camera.main.transform.position).z;
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
                                            Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
                                            transform.position.z);


        
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("test");
        bool damagePlayer = false;
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            if (enemyHealth != null)
            {
                enemyHealth.Damage(enemyHealth.hp);
            }
            damagePlayer = true;
        }

        if (damagePlayer)
        {
            HealthScript playerHealth = this.GetComponent<HealthScript>();
            if (playerHealth != null)
            {
                playerHealth.Damage(1);
                Debug.Log(playerHealth.hp);
            }
        }
    }

    private void OnDestroy()
    {
        HealthScript PlayerHealth = GetComponent<HealthScript>();
        if (PlayerHealth.hp <= 0)
        {
            var gameover = FindObjectOfType<GameOverScript>();
            gameover.ShowButtons();
        }

    }
}
