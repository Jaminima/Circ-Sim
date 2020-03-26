using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Or : LogicGate
{
    public Or() : base(2, 1) { }

    public override void UpdateOutputs()
    {
        Outputs[0] = Input_Conns[0].State || Input_Conns[1].State;
    }
}
