using UnityEngine;
public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileDamage = 10f;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float destroyTime = 1f;
    [SerializeField] private LayerMask whatDestroysProjectile;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetVelocity();
        SetDestroyTime();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if ((whatDestroysProjectile.value & (1 << collision.gameObject.layer)) > 0)
        {
            IDamageable iDamageable = collision.gameObject.GetComponent<IDamageable>();
            if (iDamageable != null)
            {
                iDamageable.Damage(projectileDamage);
            }
            Destroy(transform.parent.gameObject);
        }
    }
    private void SetVelocity()
    {
        rb.velocity = transform.forward * projectileSpeed;
    }
    private void SetDestroyTime()
    {
        Destroy(transform.parent.gameObject, destroyTime);
    }
}