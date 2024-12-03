using System;
using UnityEngine;

namespace IRV.Scripts.Tool
{
    public class LerpColor : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;
        private AssemblyComponent _assemblyComponent;
        
        [SerializeField] 
        [Range(0f, 0.5f)] 
        private float lerpSpeed;
        
        [SerializeField] 
        private Color lerpColor;

        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _assemblyComponent = GetComponent<AssemblyComponent>();
        }
        
        private void Update()
        {
            if (WorkflowController.Instance.IsMyTurn(_assemblyComponent.getStep()))
            {
                _meshRenderer.material.color = Color.Lerp(_meshRenderer.material.color, lerpColor, lerpSpeed);
            }
        }
    }
}