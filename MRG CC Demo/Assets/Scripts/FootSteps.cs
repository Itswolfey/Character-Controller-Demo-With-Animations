using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public AudioClip[] footSteps;

    public void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }


    public void WalkSound()
    {
        audioSource.clip = footSteps[Random.Range(0, footSteps.Length)];
        audioSource.Play();
    }
}
