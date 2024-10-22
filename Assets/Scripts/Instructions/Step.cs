using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Instructions/New Step")]
public class Step: ScriptableObject
{
        public string description;
        public List<int> stepsRequired;
        public int index;
        public bool isDone;
        
        public void CheckStep()
        {
                isDone = true;
        }

        public bool IsStepDone()
        {
                return isDone;
        }
        
}
