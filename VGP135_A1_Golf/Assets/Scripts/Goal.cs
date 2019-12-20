using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public ParticleSystem winningEffect;
    public AudioClip winningClip;
    public AudioSource audioSource;
    void Start()
    {
        if(audioSource && winningClip)
            audioSource.clip = winningClip;
    }

    public virtual void OnHit()
    {
        FindObjectOfType<GoalMenu>().SetGoalMenu(true);
        if (winningEffect)
        {
            //Playing particles
            var  particles = Instantiate<ParticleSystem>(winningEffect, gameObject.transform);
            particles.Play();
            //Playing music
            if (audioSource.clip)
            {
                audioSource.Play();
            }
        }
    }
}
