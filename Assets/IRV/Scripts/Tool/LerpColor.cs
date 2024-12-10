using System;
using UnityEngine;

namespace IRV.Scripts.Tool
{
    public class LerpColor : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;
        private AssemblyComponent _assemblyComponent;
        
        [SerializeField] 
        [Range(0.5f, 5f)] 
        private float lerpSpeed;
        
        [SerializeField] 
        private Color lerpColor;

        private Color _startColor;

        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _assemblyComponent = GetComponent<AssemblyComponent>();
            _startColor = _meshRenderer.material.color;
        }
        
        private void Update()
        {
            if (WorkflowController.Instance.IsMyTurn(_assemblyComponent.getStep()))
            {
                _meshRenderer.material.color = Color.Lerp(_startColor, lerpColor, Mathf.PingPong(Time.time * lerpSpeed, 1));
            }
        }
    }
}