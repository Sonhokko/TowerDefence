using System.Collections;
using UnityEngine;

public class SimpleTurret : TurretBase
{

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        fireDelay = 1f;
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
