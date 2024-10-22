using System;
using UnityEngine;

public class WorkflowController:MonoBehaviour
{
        public static WorkflowController Instance;

        public Instruction instruction;

        public void Initialize(Instruction instruction)
        {
                this.instruction = instruction;
                
        }

        private void Awake()
        {
                Instance = this;
        }

        public bool IsMyTurn(Step step)
        {
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

        public bool AllRequiredStepsDone()
        {
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
