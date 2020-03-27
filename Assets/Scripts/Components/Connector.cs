using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    public Color color
    {
        get { return GetComponent<SpriteRenderer>().color; }
        set { GetComponent<SpriteRenderer>().color = value; }
    }

    public void OnMouseDown()
    {
        InteractionEngine.target = this;
    }

    public GateTextureData gateTextureData
    {
        get { return GetComponentInParent<GateTextureData>(); }
    }

    public LogicGate logicGate
    {
        get { return GetComponentInParent<LogicGate>(); }
    }
}
