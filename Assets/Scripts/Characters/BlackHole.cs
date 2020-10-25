﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [Tooltip("For debug.")]
    public bool drawArea;
    // 範圍半徑
    public float radius;
    // 節奏類型
    public TempoActionType tempoType;
    // 吸人時的速度
    public float impactSpeed;
    // 吸人時人的旋轉速度
    public float impactRotationSpeed;

    private Animator animator;
    private bool isActive;

    private LayerMask layerMask;

    private readonly int activateTrigger = Animator.StringToHash("Activate");

    private void Awake()
    {
        isActive = false;
        layerMask = LayerMask.GetMask("Player");
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        ObjectTempoControl.Singleton.AddToBeatAction(Activate, tempoType);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, 90.0f * Time.deltaTime);
        if (isActive)
        {
            if (Physics2D.OverlapCircle(transform.position, radius, layerMask))
                Player.Singleton.movement.FallIntoBlackHole(this);
        }
    }

    private void Activate()
    {
        //Debug.Log("Black Hole activate");
        animator.SetTrigger(activateTrigger);
        isActive = true;
    }

    private void Deactivate()
    {
        //Debug.Log("Black Hole dectivate");
        isActive = false;
    }

    private void OnDrawGizmos()
    {
        if (drawArea)
            Gizmos.DrawWireSphere(transform.position, radius);
    }
}
