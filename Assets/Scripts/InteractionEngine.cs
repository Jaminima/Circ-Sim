using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class InteractionEngine
{
    public static CircuitProcessor circuitProcessor
    {
        get { return GameObject.FindObjectOfType<CircuitProcessor>(); }
    }

    public static Connector Source, Dest;

    public static Connector target
    {
        set {
            if (Source) { Dest = value; CreateConnection(); }
            else Source = value;
        }
    }

    private static void CreateConnection()
    {
        circuitProcessor.ConnectGates(Source.logicGate,
            Source.gateTextureData.Conn_Out_Points.ToList().IndexOf(Source),
            Dest.logicGate,
            Dest.gateTextureData.Conn_In_Points.ToList().IndexOf(Dest)
            );
        Clear();
    }

    public static void Clear()
    {
        Source = null;
        Dest = null;
    }
}
