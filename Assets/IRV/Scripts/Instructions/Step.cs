using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Instructions/New Step")]
public class Step: ScriptableObject
{
        public string description;
        
        [SerializeField]
        public GameObject[] objectPrefabs;
        
        [SerializeField]
        private Step _previousStep;
        
        [SerializeField]
        private Step _nextStep;
        
        private bool _isDone;
        
        public void StepCompleted()
        {
                _isDone = true;
        }

        public void Reset()
        {
                _isDone = false;
        }

        public bool IsStepDone()
        {
                return _isDone;
        }

        public bool IsPreviousStepDone()
        {
                if (_previousStep == null)
                {
                        return true;
                }
                return _previousStep.IsStepDone();
        }

        public Step getPrevious()
        {
                return _previousStep;
        }
        
        public Step getNext()
        {
                return _nextStep;
        }
}
