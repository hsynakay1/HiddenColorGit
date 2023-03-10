 using System;
 using System.Collections;
using System.Collections.Generic;
 using DG.Tweening;
 using Unity.VisualScripting;
 using UnityEngine;
 using UnityEngine.AI;

 public class LaserDieObs : MonoBehaviour
{
 public Animator animator;
 [SerializeField] private ParticleSystem shockParticle;
 [SerializeField] private ParticleSystem soulParticle;

   private void OnCollisionEnter(Collision other)
   {
       if (other.gameObject.CompareTag("Player"))
       {
        shockParticle.Play();
        soulParticle.Play();
        animator.SetBool("Dead", true);
        other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        other.gameObject.transform.DOScale(0.01f, 5f).SetEase(Ease.InCubic).SetDelay(0.3f);

       }
   }
}
