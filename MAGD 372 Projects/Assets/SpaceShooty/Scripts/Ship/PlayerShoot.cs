using UnityEngine;
public class PlayerShoot : MonoBehaviour
{
    [Header("Spawn Point(s)")]
    [Tooltip("Spawn location of projectile prefab.")]
    [SerializeField] private Transform[] spawnPoint;
    [Header("Armory")]
    [Tooltip("List of available projectile prefabs.")]
    [SerializeField] private GameObject[] projectilePrefab;
    private GameObject projectileInst;
    private int weaponNum;
    [Header("Ship Stats")]
    [Tooltip("Projectiles per second.")]
    [SerializeField] private float attackSpeed = 1f;
    private float minAttackSpeed = 0.01f;
    float timeUntilAttack;
    private void Awake()
    {
        attackSpeed = Mathf.Max(attackSpeed, minAttackSpeed);
    }
    private void Update()
    {
        if (timeUntilAttack > 0)
        {
            timeUntilAttack -= Time.deltaTime;
        }
        else if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if (timeUntilAttack <= 0)
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                projectileInst = Instantiate(projectilePrefab[weaponNum], spawnPoint[i].position, transform.parent.rotation);
            }
            timeUntilAttack = 1 / attackSpeed;
        }
    }
    public void SetProjectilePrefab()
    {
        if (weaponNum >= projectilePrefab.Length - 1)
        {
            weaponNum = 0;
        }
        else
        {
            weaponNum++;
        }
    }
}