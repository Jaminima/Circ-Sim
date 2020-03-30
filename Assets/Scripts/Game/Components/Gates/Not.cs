using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Not : LogicGate
{
    public Not() : base(1, 1) { }

    public override void UpdateOutputs()
    {
        Outputs[0] = !Input_Conns[0].State;
    }
}