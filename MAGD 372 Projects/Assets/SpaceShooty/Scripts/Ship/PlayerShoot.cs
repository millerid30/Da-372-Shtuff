using System;
using UnityEngine;
public class PlayerShoot : MonoBehaviour
{
    [Header("Spawn Point(s)")]
    [SerializeField] private GameObject launcher;
    [SerializeField] private Transform[] spawnPoint;
    [Header("Armory")]
    [SerializeField] private GameObject[] projectilePrefab;
    [Header("Ship Stats")]
    [SerializeField] private float attackSpeed = 0.5f;
    private GameObject projectileInst;
    int weaponNum;
    float timeUntilAttack;
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
                projectileInst = Instantiate(projectilePrefab[weaponNum], spawnPoint[i].position, launcher.transform.rotation);
            }
            timeUntilAttack = attackSpeed;
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