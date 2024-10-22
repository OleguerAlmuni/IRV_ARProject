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
                if (instruction == null) return false;
                if (step.index == instruction.actualStep.index)
                {
                        return true;
                }

                return false;
        }

        public void Next()
        {
                //verify if al the previous steps are done
                instruction.NextStep();
        }

        public void End()
        {
                instruction = null;
        }

        public bool AllRequiredStepsDone()
        {
                if (instruction.actualStep.stepsRequired.Count == 0) return true;
                
                foreach (int step in instruction.actualStep.stepsRequired)
                {
                        if (!instruction.stepsToFollow[step].isDone)
                        {
                                return false;
                        }
                }

                return true;
        }
        

}
