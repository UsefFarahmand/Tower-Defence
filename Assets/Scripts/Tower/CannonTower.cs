﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : Tower
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private List<Transform> firePoints;

    Action fire;
    CannonAnimatorController cannonAnimator;

    protected override void Start()
    {
        base.Start();

        cannonAnimator = GetComponentInChildren<CannonAnimatorController>();
    }


    protected override void Shoot(Transform target)
    {
        if (target == null) return;

        cannonAnimator.FireAnimation();

        fire = () =>
        {
            firePoints.ForEach(firePoint =>
            {
                var newProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.localRotation);
                newProjectile.Seek(target);
            });
        };
    }

    public void SpawnProjectile()
    {
        fire?.Invoke();
    }

}
