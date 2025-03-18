using System.Collections;
using UnityEngine;
using UnityEngine.WSA;
public class BombProjectile : MonoBehaviour
{
    [Header("Bomb Stats")]
    [SerializeField] private float projectileAmount = 5f;
    [SerializeField] private float projectileSpeed = 50f;
    [SerializeField] private float bombDamage = 50f;
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private LayerMask whatDetonates;
    private GameObject projectileInst;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetVelocity();
        StartCoroutine(detonateTime());
    }
    private void OnTriggerEnter(Collider collision)
    {
        if ((whatDetonates.value & (1 << collision.gameObject.layer)) > 0)
        {
            IDamageable iDamageable = collision.gameObject.GetComponent<IDamageable>();
            if (iDamageable != null)
            {
                iDamageable.Damage(bombDamage);
            }
            Detonate();
        }
    }
    private void SetVelocity()
    {
        rb.velocity = transform.forward * projectileSpeed;
    }
    private void Detonate()
    {
        float angle = 0f;

        for (int i = 0; i < projectileAmount; i++)
        {
            angle = (360 * i / projectileAmount);
            projectileInst = Instantiate(projectilePrefab, transform.position, transform.parent.rotation * Quaternion.Euler(transform.rotation.x, transform.rotation.y + angle, transform.rotation.z));
        }
        Destroy(transform.parent.gameObject);
    }
    private IEnumerator detonateTime()
    {
        yield return new WaitForSeconds(destroyTime);
        Detonate();
    }
}