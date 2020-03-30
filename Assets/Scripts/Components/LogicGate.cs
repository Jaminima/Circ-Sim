using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LogicGate : MonoBehaviour
{
    public Connection[] Input_Conns, Output_Conns;
    public bool[] Outputs;

    public LogicGate(int Input_Count=2, int Output_Count=1)
    {
        Input_Conns = new Connection[Input_Count];

        Output_Conns = new Connection[Output_Count];
        Outputs = new bool[Output_Count];
    }

    public virtual void UpdateOutputs()
    {
        //Placeholder Function
    }

    public static LogicGate[] logicGates
    {
        get { return FindObjectsOfType<LogicGate>(); }
    }

    public GateTextureData gateTexture
    {
        get { return GetComponent<GateTextureData>(); }
    }
}