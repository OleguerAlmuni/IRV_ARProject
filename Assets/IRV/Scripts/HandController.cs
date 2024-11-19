using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public static HandController Instance;
    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;
    
    private Transform handOcupada;
    private void Start()
    {
        Instance = this;
    }
    
    public void OnHandWrap(GrabbableObject grabbableObject)
    {   
        if(leftHand.GetComponentInChildren<GrabbableObject>() == null)
        {
            grabbableObject.transform.SetParent(leftHand.transform);
            grabbableObject.transform.localPosition = Vector3.zero;

            handOcupada = leftHand.transform;
            return;
        }
        if(rightHand.GetComponentInChildren<GrabbableObject>() == null)
        {
            grabbableObject.transform.SetParent(rightHand.transform);
            grabbableObject.transform.localPosition = Vector3.zero;

            handOcupada = rightHand.transform;
        }

    }
    
    private bool IsGrabbed(Transform hand)
    {
        return hand == handOcupada;
    }
    
    void Update()
    {
        
    }
}
