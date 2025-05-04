using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 2.5f;
    public float rotation_speed = 2.5f;
    [HideInInspector]
    public Rigidbody rb;

    public bool allow_arrow_movement = true;


    private float currentForwardAmount = 0f;
    private float currentRotationAmount = 0f;
    private float velocityForward = 0f; // For SmoothDamp
    private float velocityRotation = 0f; // For SmoothDamp
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float smoothingTime = 0.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (allow_arrow_movement)
        {
            Forward(Input.GetAxis("Vertical"));
            Rotate(Input.GetAxis("Horizontal"));
        }
    }
    public void Forward(float amount)
    {
        amount *= 2;
        //transform.Translate(0f, 0f, amount * speed * Time.deltaTime);
        currentForwardAmount = Mathf.SmoothDamp(currentForwardAmount, amount, ref velocityForward, smoothingTime);
        transform.Translate(0f, 0f, currentForwardAmount * speed * Time.deltaTime);
    }
    public void Rotate(float amount)
    {
        amount *= 2;
        //transform.Rotate(0f, amount * rotation_speed * Time.deltaTime, 0f);
        currentRotationAmount = Mathf.SmoothDamp(currentRotationAmount, amount, ref velocityRotation, smoothingTime);
        transform.Rotate(0f, currentRotationAmount * rotation_speed * Time.deltaTime, 0f);
    }
}
