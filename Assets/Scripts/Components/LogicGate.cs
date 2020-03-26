using System;
using System.Collections.Generic;
using UnityEngine;

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
}

[Serializable]
public class Connection
{
    public LogicGate source, destination;
    public int sourcePort, destPort;

    public bool State
    {
        get { return source.Outputs[sourcePort]; }
    }
}