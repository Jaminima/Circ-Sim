﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CircuitProcessor : MonoBehaviour
{
    public Connection default_Connection;

    public void FixedUpdate()
    {
        UpdateAll();
    }

    public void UpdateAll()
    {
        List<LogicGate> pendingGates = new List<LogicGate>(),
            finishedGates = new List<LogicGate>();
        LogicGate tGate;

        foreach (InputGate input in InputGate.inputGates) 
        {
            input.UpdateOutputs();
            finishedGates.Add(input);

            tGate = input.Output_Conns[0]?.destination;
            if (!pendingGates.Contains(tGate) && tGate)
                pendingGates.Add(tGate);
        }

        while (pendingGates.Count>0)
        {
            tGate = pendingGates[0];
            pendingGates.Remove(tGate);

            if (tGate.Input_Conns.Count(x => !finishedGates.Contains(x?.source)) == 0)
            {
                tGate.UpdateOutputs();

                finishedGates.Add(tGate);
            }
            else if (tGate.Input_Conns.Count(x => !x || !x.IsProper) == 0)
            {
                pendingGates.Add(tGate);
            }

            foreach (Connection conn in tGate.Output_Conns.Where(x=>x)) {
                if (!pendingGates.Contains(conn.destination) && !finishedGates.Contains(conn.destination)) 
                    pendingGates.Add(conn.destination); }
        }

        GateTextureData.gateTextureDatas.ToList().ForEach(x => x.UpdateIndicators());
    }

    public void ConnectGates(LogicGate source, int sourcePort, LogicGate dest, int destPort)
    {
        if (sourcePort != -1 && destPort != -1)
        {
            Connection conn = GameObject.Instantiate(default_Connection);
            conn.source = source;
            conn.destination = dest;

            conn.sourcePort = sourcePort;
            conn.destPort = destPort;

            source.Output_Conns[sourcePort] = conn;
            dest.Input_Conns[destPort] = conn;

            conn.Draw();
        }
    }
}
