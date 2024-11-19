using UnityEngine;
public class Tool: GrabbableObject
{
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
        
    }
    public void Wrap()
    {

    }
}
