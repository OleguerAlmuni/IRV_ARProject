using System;
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
                return instruction != null && instruction.activeSteps.Contains(step);
        }

        public void CheckAndAdvance(Step step)
        {
                // Mark the step as completed and update the active steps
                if (instruction != null && IsMyTurn(step))
                {
                        instruction.CheckThisStep(step);
                }
        }

        public void End()
        {
                instruction = null;
        }

        public bool AllRequiredStepsDone(Step step)
        {
                // Verify all prerequisites for the given step are completed
                if (step.stepsRequired.Count == 0) return true;

                foreach (var requiredStep in step.stepsRequired)
                {
                        if (!requiredStep.isDone)
                        {
                                return false;
                        }
                }

                return true;
        }
        
}
