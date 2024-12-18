﻿using System;
using IRV.Scripts.Audio;
using UnityEngine;

//Should implement wrap
public class AssemblyComponent: GrabbableObject
{
    [SerializeField] private Step myStep;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    
    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.GetComponent<Tool>())
        {
            //Check if the step is the correct one
            if (!WorkflowController.Instance.IsMyTurn(myStep)) return;
            if (!WorkflowController.Instance.AllRequiredStepsDone(myStep)) return;
            
            WorkflowController.Instance.CheckAndAdvance(myStep);
            
            AudioManager.Instance.PlaySound("Hammer");

            this.transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z);
            
            Debug.Log("The step "+ myStep.description+ " has been completed!");
            
            Destroy(this.GetComponent<SphereCollider>());
        }
    }

    public void Wrap()
    {

    }
    
    public Step getStep()
    {
        return myStep;
    }
}
