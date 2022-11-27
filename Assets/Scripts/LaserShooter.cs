using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    private Transform target;

    private float speed = 20f;
    private int damageAmt = 40;

    [SerializeField] private GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //Find direction laser needs to point
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);

        Destroy(gameObject);
        Damage(target);
    }

    void Damage(Transform enemy)
    {
        Enemy _enemy = enemy.GetComponent<Enemy>();

        _enemy.TakeDamage(damageAmt);
    }
}
