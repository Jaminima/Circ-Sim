using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : InputGate
{
    public bool State = false;

    public override void UpdateOutputs()
    {
        Outputs[0] = State;
    }
}