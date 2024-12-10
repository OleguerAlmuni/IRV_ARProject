using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace IRV.Scripts.Instructions
{
    [CreateAssetMenu(menuName = "Instructions/New Instruction")]
    public class Instruction : ScriptableObject
    {
        
        [SerializeField]
        private Step currentStep;
        
        public Step getCurrentStep()
        {
            return currentStep;
        }

        public void Reset()
        {
            while (true)
            {
                currentStep.Reset();

                if (currentStep.getPrevious() != null)
                {
                    return;
                }

                currentStep = currentStep.getPrevious();
            }
        }

        public void CompleteCurrentStep(Step step)
        {
            if (!currentStep.Equals(step) || step.IsStepDone()) return;
            
            currentStep.StepCompleted();
                
            if (currentStep.getNext() != null)
            {
                currentStep = currentStep.getNext();
                return;
            }
                
            WorkflowController.Instance.End();
        }
    }
}