using UnityEngine;
public class ShipMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    float moveInput;
    float turnInput;
    float rotationAngle;
    [Range(1f, 100f)] public float moveSpeed = 50.0f;
    [Range(1f, 100f)] public float turnSpeed = 75.0f;
    [Range(0f, 10f)] public float drag = 1.0f;
    public ShipMovement(float moveSpeed, float turnSpeed, float drag)
    {
        this.moveSpeed = moveSpeed;
        this.turnSpeed = turnSpeed;
        this.drag = drag;
    }

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }
    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical") * moveSpeed;
        turnInput = Input.GetAxisRaw("Horizontal") * turnSpeed;
    }
    void FixedUpdate()
    {
        Thrust();
        Steering();
    }
    void Thrust()
    {
        if (moveInput == 0)
        {
            rb.drag = Mathf.Lerp(rb.drag, drag, Time.deltaTime * 3);
        }
        Vector3 thrustVector = transform.right * moveInput * moveSpeed;
        rb.AddForce(thrustVector, ForceMode.Force);
    }
    void Steering()
    {
        rotationAngle += turnInput * turnSpeed * Time.deltaTime;
        rb.MoveRotation(Quaternion.Euler(new Vector3(0f, rotationAngle, 0f)));
    }
}