using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Instructions/New Step")]
public class Step: ScriptableObject
{
        public string description;
        [SerializeField] public List<Step> stepsRequired = new List<Step>();
        public bool isDone;
        
        public void StepCompleted()
        {
                isDone = true;
        }

        public bool IsStepDone()
        {
                return isDone;
        }

        public bool CheckPreRequierments()
        {
                bool prerequisitesDone = true;
                foreach (var prerequisite in stepsRequired)
                {
                        if (!prerequisite.isDone)
                        {
                                prerequisitesDone = false;
                                break;
                        }
                }

                return prerequisitesDone;
        }
}
