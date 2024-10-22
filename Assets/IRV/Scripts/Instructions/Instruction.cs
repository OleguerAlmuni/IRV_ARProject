using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Instructions/New Instruction")]
public class Instruction: ScriptableObject
{
        public Step actualStep;
        [SerializeField] public List<Step> stepsToFollow;
        public void NextStep()
        {
                actualStep.isDone = true;
                actualStep = stepsToFollow[actualStep.index + 1];
        }
}
