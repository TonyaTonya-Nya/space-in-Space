﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAudioManager : MonoBehaviour
{
    public AudioClip fireBag;
    public AudioClip fallIntoBlackHole;
    public AudioClip error;
    public AudioClip gameOver;

    private AudioSource audioSource;
    private PlayerMovement movement;
    private PlayerLifeSystem lifeSystem;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        movement = GetComponent<PlayerMovement>();
        lifeSystem = GetComponent<PlayerLifeSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        movement.OnFireBag += (Vector2 direction) => audioSource.PlayOneShot(fireBag);
        movement.OnFallIntoBlackHole += () => audioSource.PlayOneShot(fallIntoBlackHole);
        movement.OnError += () => audioSource.PlayOneShot(error);
        lifeSystem.OnDie += () => audioSource.PlayOneShot(gameOver);
    }
}
