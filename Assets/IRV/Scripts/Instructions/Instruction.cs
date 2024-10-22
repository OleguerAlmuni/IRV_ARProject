using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Instructions/New Instruction")]
public class Instruction: ScriptableObject
{
        public Step actualStep;
        [SerializeField] public List<Step> stepsToFollow;

        public void Reset()
        {
                actualStep = stepsToFollow[0];
                foreach (var step in stepsToFollow)
                {
                        step.isDone = false;
                }
        }
        public void NextStep()
        {
                actualStep.isDone = true;
                if (actualStep.index != stepsToFollow.Count - 1)
                {
                        actualStep = stepsToFollow[actualStep.index + 1];
                }
                else
                {
                        WorkflowController.Instance.End();
                }
                
        }
}
