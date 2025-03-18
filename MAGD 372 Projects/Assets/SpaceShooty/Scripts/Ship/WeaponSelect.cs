using UnityEngine;
public class WeaponSelect : MonoBehaviour
{
    [SerializeField] private PlayerShoot[] playerShoot;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            NextWeapon();
        }
    }
    private void NextWeapon()
    {
        foreach (var weapon in playerShoot)
        {
            if (weapon.gameObject.activeSelf)
            {
                weapon.SetProjectilePrefab();
            }
        }
    }
}