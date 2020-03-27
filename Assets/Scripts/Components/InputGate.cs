using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGate : LogicGate
{
    public bool State = false;

    public SpriteRenderer Indicator;

    public InputGate():base(0,1)
    {
        Outputs = new bool[1];
    }

    public void OnMouseDown()
    {
        State = !State;
        UpdateOutputs();
    }

    public override void UpdateOutputs()
    {
        if (State) Indicator.color = Color.green;
        else Indicator.color = Color.red;
        Outputs[0] = State;
    }

    public static InputGate[] inputGates
    {
        get { return FindObjectsOfType<InputGate>(); }
    }
}
