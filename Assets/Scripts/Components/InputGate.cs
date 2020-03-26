using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGate : LogicGate
{
    public InputGate():base(0,1)
    {
        Outputs = new bool[1];
    }

    public static InputGate[] inputGates
    {
        get { return FindObjectsOfType<InputGate>(); }
    }
}
