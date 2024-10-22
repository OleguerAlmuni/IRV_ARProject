using UnityEngine;

public class Placeholder : MonoBehaviour
{
    [SerializeField] private Step myStep;
    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.GetComponent<AssemblyComponent>())
        {
            //Check if the step is the correct one
            if (!WorkflowController.Instance.IsMyTurn(myStep)) return;
            if (!WorkflowController.Instance.AllRequiredStepsDone()) return;
            
            other.gameObject.transform.position = gameObject.transform.position;
            WorkflowController.Instance.Next();
            
            Debug.Log("The step "+ myStep.description+ " has been completed!");
            
            Destroy(this.GetComponent<SphereCollider>());
            
        }
    }
}
