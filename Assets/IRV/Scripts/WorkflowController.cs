using System;
using IRV.Scripts.Instructions;
using UnityEngine;

public class WorkflowController: MonoBehaviour
{
        public static WorkflowController Instance;

        public Instruction instruction;
        
        private void Awake()
        {
                Instance = this;
        }

        private void Start()
        {
                Initialize(instruction);
        }
        
        public void Initialize(Instruction instruction)
        {
                instruction.Reset();
        }
        
        public bool IsMyTurn(Step step)
        {
                // Check if the provided step is part of the active steps
                return instruction != null && instruction.getCurrentStep().Equals(step);
        }

        public void CheckAndAdvance(Step step)
        {
                // Mark the step as completed and update the active steps
                if (instruction != null && IsMyTurn(step))
                {
                        instruction.CompleteCurrentStep(step);
                }
        }

        public void End()
        {
                instruction = null;
        }

        public bool AllRequiredStepsDone(Step step)
        {
                return step.getPrevious().IsStepDone() || step.getPrevious() == null;
        }
        
}
