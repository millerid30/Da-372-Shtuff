using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform shipPos;
    [SerializeField] private float offset = 50f;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 yPos = new Vector3(0f, offset, 0f);
        transform.position = shipPos.position + yPos;
    }
}