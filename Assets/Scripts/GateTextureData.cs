using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTextureData : MonoBehaviour
{
    public static GateTextureData[] gateTextureDatas
    {
        get { return FindObjectsOfType<GateTextureData>(); }
    }

    public LogicGate logicGate;

    public Connector[] Conn_In_Points, Conn_Out_Points;

    public void UpdateIndicators()
    {
        for (int i = 0; i < Conn_In_Points.Length; i++)
        {
            if (logicGate.Input_Conns[i].IsProper)
            {
                if (logicGate.Input_Conns[i].State) Conn_In_Points[i].color = Color.green;
                else Conn_In_Points[i].color = Color.red;
            }
        }

        for (int i = 0; i < Conn_Out_Points.Length; i++)
        {
            if (logicGate.Outputs[i]) Conn_Out_Points[i].color = Color.green;
            else Conn_Out_Points[i].color = Color.red;
        }
    }

    Vector3 mPos, gPos;
    public void OnMouseDown()
    {
        mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gPos = transform.position;
    }

    public void OnMouseDrag()
    {
        Vector3 mChange = mPos - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = gPos - mChange;
    }

    public void ConnectionClicked()
    {

    }
}
