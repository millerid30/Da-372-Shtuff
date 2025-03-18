using UnityEngine;
using UnityEngine.WSA;
public class ScatterProjectile : MonoBehaviour
{
    [Header("Shell Stats")]
    [SerializeField] private float projectileAmount = 5f;
    [SerializeField] private float spread = 45f;
    [SerializeField] private float destroyTime = 1f;
    [SerializeField] private GameObject projectilePrefab;
    private GameObject projectileInst;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Release();
        SetDestroyTime();
    }
    private void Release()
    {
        // fire middle bullet
        projectileInst = Instantiate(projectilePrefab, transform.position, transform.parent.rotation);
        // calculate spread using number of bullets and spread range
        float angle = 0f;
        
        for (int i = 0; i < Mathf.Floor(projectileAmount/2); i++)
        {
            angle = ((spread*(i+1))/projectileAmount);
            // positive side
            projectileInst = Instantiate(projectilePrefab, transform.position, transform.parent.rotation * Quaternion.Euler(transform.rotation.x,transform.rotation.y + angle,transform.rotation.z));
            // negative side
            projectileInst = Instantiate(projectilePrefab, transform.position, transform.parent.rotation * Quaternion.Euler(transform.rotation.x, transform.rotation.y - angle, transform.rotation.z));
        }
        // add random backwards force and spin to 'spent' shell
        rb.AddForce(transform.parent.rotation * new Vector3(-Random.Range(3,10), Random.Range(0, 10), Random.Range(-10, 10)));
        rb.AddTorque(new Vector3(Random.Range(-1000, 1000), Random.Range(-1000, 1000), Random.Range(-1000, 1000)));
    }
    private void SetDestroyTime()
    {
        Destroy(transform.parent.gameObject, destroyTime);
    }
}