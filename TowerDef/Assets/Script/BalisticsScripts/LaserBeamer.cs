using UnityEngine;

public class LaserBeamer : TurretBase
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private ParticleSystem impactEffect;
    [SerializeField] private Light impactLight;

    private int damageOverTime = 30;
    private float slowPercent = .5f;


    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if (target == null)
        {
            lineRenderer.enabled = false;
            impactEffect.Stop();
            impactLight.enabled = false;
            return;
        }
        else
        {
            Shoot();
        }

        TurretRotate();
    }

    protected override void Shoot()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPercent);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.position = target.position;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

}
