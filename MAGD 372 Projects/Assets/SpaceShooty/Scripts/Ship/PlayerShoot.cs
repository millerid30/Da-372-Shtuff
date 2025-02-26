using UnityEngine;
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject launcher;
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private GameObject projectilePrefab;
    private GameObject projectileInst;
    [SerializeField] private float attackSpeed = 0.5f;
    float timeUntilAttack;
    private void Start()
    {

    }
    private void Update()
    {
        if (timeUntilAttack > 0)
        {
            timeUntilAttack -= Time.deltaTime;
        }
        else if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space))
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
                projectileInst = Instantiate(projectilePrefab, spawnPoint[i].position, launcher.transform.rotation);
            }
            timeUntilAttack = attackSpeed;
        }
    }
}