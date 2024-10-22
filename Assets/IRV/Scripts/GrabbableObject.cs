using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabbableObject : MonoBehaviour, IWrabbable
{
    public void Wrap()
    {
        
    }
    
    private void OnMouseUpAsButton()
    {
        HandController.Instance.OnHandWrap(this);
    }
}
