using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatDecalPool : MonoBehaviour
{
    private int maxdecals = 100;
    private int particledecaldataindex;
    private ParticleDecalData[] particledata;
    private ParticleSystem.Particle[] particles;

    [SerializeField]
    private ParticleSystem decalparticlesystem;
    [SerializeField]
    private float mindecalsize;
    [SerializeField]
    private float maxdecalsize;
    [SerializeField]
    private Color PScolor;


    void Start()
    {
        decalparticlesystem = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[maxdecals];
        particledata = new ParticleDecalData[maxdecals];
        for(int i=0;i<maxdecals;i++)
        {
            particledata[i] = new ParticleDecalData();
        }
    }


    public void particlehit(ParticleCollisionEvent particlecollisionevent)
    {
        SetParticleData(particlecollisionevent);
        displayparticles();
    }
   void SetParticleData(ParticleCollisionEvent particlecollisionevent)
    {
        if(particledecaldataindex>maxdecals)
        {
            particledecaldataindex = 0;
        }
        particledata[particledecaldataindex].position = particlecollisionevent.intersection;
        Vector3 particlerotationeuler = Quaternion.LookRotation(particlecollisionevent.normal).eulerAngles;
        particlerotationeuler.z = Random.Range(0, 360);
        particledata[particledecaldataindex].rotation = particlerotationeuler;
        particledata[particledecaldataindex].size = Random.Range(mindecalsize, maxdecalsize);


        particledecaldataindex++;
    }

    void displayparticles()
    {
        for(int i=0;i<particledata.Length;i++)
        {
            particles[i].position = particledata[i].position;
            particles[i].rotation3D = particledata[i].rotation;
            particles[i].size = particledata[i].size;
            particles[i].startColor = PScolor;
        }
        decalparticlesystem.SetParticles(particles, particles.Length);
    }
   
}
