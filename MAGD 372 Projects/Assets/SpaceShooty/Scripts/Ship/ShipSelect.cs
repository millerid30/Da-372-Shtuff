using UnityEngine;
public class ShipSelect : MonoBehaviour
{
    [SerializeField] private GameObject[] hangar;
    private int shipNum = 0;
    void Start()
    {
        for (int i = 0; i < hangar.Length; i++)
        {
            hangar[i].gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (shipNum >= hangar.Length)
        {
            shipNum = 0;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            shipNum++;
        }
        for (int i = 0; i < hangar.Length; i++)
        {
            if (shipNum == i)
            {
                hangar[i].gameObject.SetActive(true);
            }
            else
            {
                hangar[i].gameObject.SetActive(false);
            }
        }
    }
    public int SelectedShip()
    {
        return shipNum;
    }
}