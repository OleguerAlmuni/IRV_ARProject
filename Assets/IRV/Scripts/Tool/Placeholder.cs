using UnityEngine;

public class Placeholder : MonoBehaviour
{
    [SerializeField] private Step myStep;
    private void OnTriggerEnter(Collider other)
    {   
        //Check if the step is the correct one
        if (!WorkflowController.Instance.IsMyTurn(myStep)) return;
        if (!WorkflowController.Instance.AllRequiredStepsDone()) return;
        
        if (other.gameObject.GetComponent<Accessories>())
        {
            other.gameObject.transform.position = gameObject.transform.position;
            WorkflowController.Instance.Next();
        }
    }
}
