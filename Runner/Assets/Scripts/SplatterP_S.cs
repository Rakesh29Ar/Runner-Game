using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatterP_S : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem splatterparticles;
    public SplatDecalPool dropletdecalpool;
    List<ParticleCollisionEvent> collisionevents;
    
    void Start()
    {
        collisionevents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {
       int numcollisionevent= ParticlePhysicsExtensions.GetCollisionEvents(splatterparticles, other, collisionevents);
        for(int i=0;i<numcollisionevent;i++)
        {
            dropletdecalpool.particlehit(collisionevents[i]);
        }
    }


}
