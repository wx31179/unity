﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int hp = 10;
    public bool isEnemy = true;
    // Start is called before the first frame update
    public void Damage(int damageCount)
    {
        if (isEnemy)
        {
            hp = 1;
            hp -= damageCount;
            if (hp <= 0)
            {
                SpecialEffectsHelper.Instance.Explosion(transform.position);
                SoundEffectsHelper.Instance.MakeExplosionSound();
                Destroy(gameObject);
            }
        }
        else
        {
            hp -= damageCount;
            if (hp <= 0)
            {
                SpecialEffectsHelper.Instance.Explosion(transform.position);
                SoundEffectsHelper.Instance.MakeExplosionSound();
                Destroy(gameObject);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            if (shot.isEnemyshot != isEnemy)
            {
                
                Damage(shot.damage);
                Destroy(shot.gameObject);
            }
        }
        
    }
}
