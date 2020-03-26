using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CircuitProcessor : MonoBehaviour
{
    public void UpdateAll()
    {
        List<LogicGate> pendingGates = new List<LogicGate>(),
            finishedGates = new List<LogicGate>();
        LogicGate tGate;

        foreach (InputGate input in InputGate.inputGates) 
        {
            input.UpdateOutputs();
            finishedGates.Add(input);

            tGate = input.Output_Conns[0].destination;
            if (!pendingGates.Contains(tGate))
                pendingGates.Add(tGate);
        }

        while (pendingGates.Count>0)
        {
            tGate = pendingGates[0];
            pendingGates.Remove(tGate);

            if (tGate.Input_Conns.Count(x => !finishedGates.Contains(x.source)) == 0)
            {
                tGate.UpdateOutputs();

                finishedGates.Add(tGate);
            }
            else
            {
                pendingGates.Add(tGate);
            }

        }
    }

    public void ConnectGates(LogicGate source, int sourcePort, LogicGate dest, int destPort)
    {
        Connection conn = new Connection();
        conn.source = source;
        conn.destination = dest;

        conn.sourcePort = sourcePort;
        conn.destPort = destPort;

        source.Output_Conns[sourcePort] = conn;
        dest.Input_Conns[destPort] = conn;
    }
}
