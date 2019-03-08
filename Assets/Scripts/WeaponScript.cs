using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform shotPrefab;
    public float shootingRate = 0.75f;
    private float shootCooldown;
    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        shootCooldown -= Time.deltaTime; 
    }

    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            if (isEnemy)
            {
                SoundEffectsHelper.Instance.MakeEnemyShotSound();
                
            }
            else
            {
                SoundEffectsHelper.Instance.MakePlayerShotSound();
                
            }
            shootCooldown = shootingRate;
            var shotTransform = Instantiate(shotPrefab) as Transform;
            shotTransform.position = transform.position;
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyshot = isEnemy;
            }
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                if (shot.isEnemyshot)
                {
                    move.direction.x = -1f;


                    move.speed = new Vector2(10, 10);




                }
                else
                {
                    move.direction.x = 1f;
                    move.speed = new Vector2(10, 10);
                }
            }
        }
    }

    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}
