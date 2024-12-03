using System.Numerics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Vector3 = UnityEngine.Vector3;

public class Placeholder : MonoBehaviour
{
    [SerializeField] private Step myStep;
    
    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.GetComponent<AssemblyComponent>())
        {
            //Check if the step is the correct one
            if (!WorkflowController.Instance.IsMyTurn(myStep)) return;
            if (!WorkflowController.Instance.AllRequiredStepsDone(myStep)) return;

            XRGrabInteractable interactable = other.gameObject.GetComponent<XRGrabInteractable>();
            interactable.enabled = false;
            
            other.transform.SetParent(gameObject.transform);
            other.transform.localEulerAngles = Vector3.zero;
            
            Rigidbody rigidbody = other.GetComponent<Rigidbody>();
            rigidbody.isKinematic = true;
            
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), other);

            WorkflowController.Instance.CheckAndAdvance(myStep);
            
            Debug.Log("The step "+ myStep.description+ " has been completed!");
            
            Destroy(this.GetComponent<SphereCollider>());
            
        }
    }
}
