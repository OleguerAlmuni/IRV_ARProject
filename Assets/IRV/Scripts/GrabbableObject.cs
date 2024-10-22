using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;

    private Transform handOcupada;
    void Start()
    {
        
    }

    
    
    private void OnMouseUpAsButton()
    {   
        if(leftHand.GetComponentInChildren<GrabbableObject>() == null)
        {
            this.transform.SetParent(leftHand.transform);
            this.transform.localPosition = Vector3.zero;

            this.handOcupada = leftHand.transform;
            return;
        }
        if(rightHand.GetComponentInChildren<GrabbableObject>() == null)
        {
            this.transform.SetParent(rightHand.transform);
            this.transform.localPosition = Vector3.zero;

            this.handOcupada = rightHand.transform;
            return;
        }

    }

    public void OnTriggerEnter()
    {
        Debug.Log("M'he caigut");
    }

    private bool IsGrabbed(Transform hand)
    {
       return hand == handOcupada;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (IsGrabbed(leftHand.transform))
            {
                Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
                rb.useGravity = true;
                this.transform.SetParent(null);
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if (IsGrabbed(rightHand.transform))
            {
                Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
                rb.useGravity = true;
                this.transform.SetParent(null);
            }
        }
    }
}
