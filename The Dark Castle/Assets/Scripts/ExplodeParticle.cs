using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeParticle : Singleton<ExplodeParticle>
{
    public ParticleSystem ExplodeEffect;

    private ParticleSystem SpawnParticle (ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(prefab, position, Quaternion.identity) as ParticleSystem;
        return newParticleSystem;
    }
    public void Explode (Vector3 position)
    {
        SpawnParticle(ExplodeEffect, position);
    }
}
