using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    public bool IsInput;

    public Color color
    {
        get { return GetComponent<SpriteRenderer>().color; }
        set { GetComponent<SpriteRenderer>().color = value; }
    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsInput) InteractionEngine.Source = this;
            else InteractionEngine.Dest = this;

            InteractionEngine.DoAction();
        }
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
