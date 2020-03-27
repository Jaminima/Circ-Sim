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

    public Connection() { }

    public Connection(Connector source, Connector dest)
    {
        GateTextureData sourceGate = source.GetComponentInParent<GateTextureData>(),
            destGate = dest.GetComponentInParent<GateTextureData>();

        int sourcePort = sourceGate.Conn_Out_Points.ToList().IndexOf(source),
            destPort = destGate.Conn_In_Points.ToList().IndexOf(dest);

        this.source = sourceGate.logicGate;
        this.destination = destGate.logicGate;

        this.sourcePort = sourcePort;
        this.destPort = destPort;

        this.source.Output_Conns[sourcePort] = this;
        this.destination.Input_Conns[destPort] = this;
    }
}