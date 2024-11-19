using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Instructions/New Instruction")]
public class Instruction : ScriptableObject
{
    public List<Step> activeSteps = new List<Step>();
    [SerializeField] private List<Step> stepsToFollow = new List<Step>();

    public void Reset()
    {
        activeSteps.Clear();

        // Reset all steps in the sequence
        foreach (var step in stepsToFollow)
        {
            step.isDone = false;
        }

        // Initialize active steps with steps that have no prerequisites or have all prerequisites done
        UpdateActiveSteps();
    }

    public void CheckThisStep(Step step)
    {
        if (activeSteps.Contains(step) && !step.isDone)
        {
            step.StepCompleted();
            UpdateActiveSteps();
        }
    }

    private void UpdateActiveSteps()
    {
        activeSteps.Clear();

        foreach (var step in stepsToFollow)
        {
            // Check if the step is already done
            if (step.isDone) continue;

            // Check if all prerequisite steps are completed
            if (step.CheckPreRequierments())
            {
                activeSteps.Add(step);
            }
        }

        if (AllStepsCompleted())
        {
            WorkflowController.Instance.End();
        }
    }

    private bool AllStepsCompleted()
    {
        foreach (var step in stepsToFollow)
        {
            if (!step.isDone)
                return false;
        }
        return true;
    }
}