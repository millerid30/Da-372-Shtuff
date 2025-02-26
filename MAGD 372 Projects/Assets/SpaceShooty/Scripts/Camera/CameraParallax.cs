using UnityEngine;

public class CameraParallax : MonoBehaviour
{
    private float lengthX;
    private float lengthZ;
    private float startX;
    private float startZ;
    [SerializeField] private GameObject cam;
    [SerializeField] private float parallaxEffect;
    void Start()
    {
        startX = transform.position.x;
        startZ = transform.position.z;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthZ = GetComponent<SpriteRenderer>().bounds.size.z;
    }
    void FixedUpdate()
    {
        Vector3 temp = new Vector3(cam.transform.position.x, 0f, cam.transform.position.z) * (1 - parallaxEffect);
        Vector3 dist = new Vector3(cam.transform.position.x, 0f, cam.transform.position.z) * parallaxEffect;

        transform.position = new Vector3(startX + dist.x, transform.position.y, startZ + dist.z);

        if (temp.x > startX + lengthX)
        {
            startX += lengthX;
        }
        else if (temp.x < startX - lengthX)
        {
            startX -= lengthX;
        }
        else if (temp.z > startZ + lengthZ)
        {
            startZ += lengthZ;
        }
        else if (temp.z < startZ - lengthZ)
        {
            startZ -= lengthZ;
        }
    }
}