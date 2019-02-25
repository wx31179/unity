using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffectsHelper : MonoBehaviour
{
    public static SpecialEffectsHelper Instance;
    public ParticleSystem smokeEffect;
    public ParticleSystem fireEffect;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }
        Instance = this;
    }
    // Start is called before the first frame update

    public void Explosion(Vector3 position)
    {
        instantiate(smokeEffect, position);
        instantiate(fireEffect, position);
    }
    private ParticleSystem instantiate(ParticleSystem perfab,Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(perfab, position, Quaternion.identity) as ParticleSystem;
        Destroy(newParticleSystem.gameObject, newParticleSystem.startLifetime);
        return newParticleSystem;

    }
}
