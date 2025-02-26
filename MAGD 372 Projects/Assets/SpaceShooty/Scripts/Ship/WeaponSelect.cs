using UnityEngine;
public class WeaponSelect : MonoBehaviour
{
    [SerializeField] private GameObject[] armory;
    private int weaponNum = 0;
    void Start()
    {
        for (int i = 0; i < armory.Length; i++)
        {
            armory[i].gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (weaponNum >= armory.Length)
        {
            weaponNum = 0;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            weaponNum++;
        }
        for (int i = 0; i < armory.Length; i++)
        {
            if (weaponNum == i)
            {
                armory[i].gameObject.SetActive(true);
            }
            else
            {
                armory[i].gameObject.SetActive(false);
            }
        }
    }
    public int SelectedWeapon()
    {
        return weaponNum;
    }
}