using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        circuitProcessor.ConnectGates(Source,);
    }
}
