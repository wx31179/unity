using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private WeaponScript weapon;
    void Awake()
    {
        weapon = GetComponent<WeaponScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weapon != null && weapon.CanAttack)
        {
            weapon.Attack(true);
        }
    }
}
