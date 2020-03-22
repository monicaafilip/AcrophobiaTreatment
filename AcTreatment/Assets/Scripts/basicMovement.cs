using UnityEngine;

[ExecuteInEditMode]
public class basicMovement : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody rigidBody;

    Vector3 yEulerAngle;
    Vector3 xEulerAngle;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        //rigidBody.isKinematic = true;

        yEulerAngle = new Vector3(0, 100, 0);
        xEulerAngle = new Vector3(100, 0, 0);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S))
            rigidBody.MovePosition(transform.position + transform.TransformDirection(Vector3.forward).normalized * Time.fixedDeltaTime * speed * 2.5f);
        if (Input.GetKey(KeyCode.D))
            rigidBody.MovePosition(transform.position + transform.TransformDirection(Vector3.left).normalized * Time.fixedDeltaTime * speed * 2.5f);
        if (Input.GetKey(KeyCode.W))
            rigidBody.MovePosition(transform.position + transform.TransformDirection(Vector3.back).normalized * Time.fixedDeltaTime * speed * 2.5f);
        if (Input.GetKey(KeyCode.A))
            rigidBody.MovePosition(transform.position + transform.TransformDirection(Vector3.right).normalized * Time.fixedDeltaTime * speed * 2.5f);
        if (Input.GetKey(KeyCode.Q))
        {
            Quaternion deltaRotation = Quaternion.Euler(yEulerAngle * Time.deltaTime);
            rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Quaternion deltaRotation = Quaternion.Euler(-yEulerAngle * Time.deltaTime);
            rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            Quaternion deltaRotation = Quaternion.Euler(xEulerAngle * Time.deltaTime);
            rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        }
        if (Input.GetKey(KeyCode.X))
        {
            Quaternion deltaRotation = Quaternion.Euler(-xEulerAngle * Time.deltaTime);
            rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
       //if (Input.GetKey(KeyCode.T))
       //    transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed * 2.5f;
       //if (Input.GetKey(KeyCode.F))
       //    transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * speed * 2.5f;
       //if (Input.GetKey(KeyCode.G))
       //    transform.position += transform.TransformDirection(Vector3.back) * Time.deltaTime * speed * 2.5f;
       //if (Input.GetKey(KeyCode.H))
       //    transform.position += transform.TransformDirection(Vector3.right) * Time.deltaTime * speed * 2.5f;
       //if (Input.GetKey(KeyCode.R))
       //    transform.Rotate(0f, speed, 0f, Space.Self);
       //if (Input.GetKey(KeyCode.Y))
       //    transform.Rotate(0f, -speed, 0f, Space.Self);
    }
}
