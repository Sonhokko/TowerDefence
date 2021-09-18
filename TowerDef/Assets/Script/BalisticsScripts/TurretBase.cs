using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretBase : MonoBehaviour
{
    [Header("Params for childs")]
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected Transform partToRotate;
    [SerializeField] protected GameObject bulletPref;
    [SerializeField] protected float range;
    [SerializeField] protected float turnSpeed;
    [SerializeField] protected float fireDelay;
    private IEnumerator fireDelayIE = null;

    protected Transform target;
    protected Enemy targetEnemy;
    private const string enemyTag = "Enemy";


    protected virtual void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    protected virtual void Update()
    {
        if (target == null)
            return;
        else
            Shoot();

        TurretRotate();
    }

    protected virtual void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }


        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    protected virtual void Shoot()
    {
        if (fireDelayIE == null)
        {
            GameObject bulletGO = Instantiate(bulletPref, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();

            if (bullet != null)
                bullet.Seek(target);

            fireDelayIE = FireDelay();
            StartCoroutine(fireDelayIE);
        }
    }

    private IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(fireDelay);
        fireDelayIE = null;
    }

    protected void TurretRotate()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}

