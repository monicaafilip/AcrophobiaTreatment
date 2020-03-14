using UnityEngine;

[ExecuteInEditMode]
public class basicMovement : MonoBehaviour
{
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed * 2.5f;
        if (Input.GetKey(KeyCode.F))
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * speed * 2.5f;
        if (Input.GetKey(KeyCode.G))
            transform.position += transform.TransformDirection(Vector3.back) * Time.deltaTime * speed * 2.5f;
        if (Input.GetKey(KeyCode.H))
            transform.position += transform.TransformDirection(Vector3.right) * Time.deltaTime * speed * 2.5f;
        if (Input.GetKey(KeyCode.R))
            transform.Rotate(0f, speed, 0f, Space.Self);
        if (Input.GetKey(KeyCode.Y))
            transform.Rotate(0f, -speed, 0f, Space.Self);
    }
}
