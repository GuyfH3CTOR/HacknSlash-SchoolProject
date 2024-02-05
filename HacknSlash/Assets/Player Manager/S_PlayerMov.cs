using UnityEngine;

public class S_PlayerMov : MonoBehaviour
{
    [SerializeField] private float f_MovSpeed = 5;
    Rigidbody rb_Rigidbody;

    void Start()
    {
        Camera.main.transform.LookAt(transform);
        rb_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb_Rigidbody.MovePosition(transform.position + new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * f_MovSpeed);
    }
}