using UnityEngine;
public class ShipSelect : MonoBehaviour
{
    [SerializeField] private GameObject[] hangar;
    private int shipNum = 0;
    void Awake()
    {
        SelectShip();
    }
    void Update()
    {
        int prevShip = shipNum;
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (shipNum >= hangar.Length - 1)
            {
                shipNum = 0;
            }
            else
            {
                shipNum++;
            }
        }
        if (prevShip != shipNum)
        {
            SelectShip();
        }
    }
    private void SelectShip()
    {
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
}