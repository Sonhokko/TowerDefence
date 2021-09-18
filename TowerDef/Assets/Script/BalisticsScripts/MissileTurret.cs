using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTurret : TurretBase
{

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        fireDelay = 3f;
    }

    protected override void UpdateTarget()
    {
        base.UpdateTarget();
    }

    private void Update()
    {
        if (target == null)
            return;
        else
            Shoot();

        TurretRotate();
    }


}
