using System;
using UnityEngine;

//Should implement wrap
public class AssemblyComponent: MonoBehaviour, IWrabbable
{
    [SerializeField] private Step myStep;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.GetComponent<Tool>())
        {
            //Check if the step is the correct one
            if (!WorkflowController.Instance.IsMyTurn(myStep)) return;
            if (!WorkflowController.Instance.AllRequiredStepsDone()) return;
            
            WorkflowController.Instance.Next();
            
            Debug.Log("The step "+ myStep.description+ " has been completed!");
            
            Destroy(this.GetComponent<SphereCollider>());
        }
    }

    public void Wrap()
    {

    }
}
