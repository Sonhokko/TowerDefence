using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletEffectPref;
    [SerializeField] private float speed = 90f;
    [SerializeField] private int damage = 50;
    [SerializeField] private float explosionRadius = 15f;
    private Transform target;

    public void Seek(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        GameObject effectIns = Instantiate(bulletEffectPref, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
            Explode();
        else
            Damage(target);

        Destroy(gameObject);
    }

    private void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
            e.TakeDamage(damage);
    }

    private void Explode()
    {
         Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

                foreach (Collider collider in colliders)
                {
                    if (collider.GetComponent<Enemy>())
                    {
                        Damage(collider.transform);
                    }
                }
    }

}
