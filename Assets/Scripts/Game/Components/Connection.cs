using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Connection : MonoBehaviour
{
    public LogicGate source, destination;
    public int sourcePort, destPort;

    public SpriteRenderer sprite;

    public bool State
    {
        get { return source.Outputs[sourcePort]; }
    }

    public bool IsProper
    {
        get { return source && destination; }
    }

    public void OnMouseDown()
    {
        Destroy(gameObject);
    }

    public void Draw()
    {
        Vector3 source_conn_pos = source.gateTexture.Conn_Out_Points[sourcePort].transform.position,
            dest_conn_pos = destination.gateTexture.Conn_In_Points[destPort].transform.position,
            this_pos = (source_conn_pos + dest_conn_pos) / 2;

        float Rot = Mathf.Atan2(dest_conn_pos.y - source_conn_pos.y, dest_conn_pos.x - source_conn_pos.x) * 180 / Mathf.PI,
            Dist = Vector3.Distance(source_conn_pos,dest_conn_pos);

        transform.position = this_pos;
        transform.eulerAngles = new Vector3(0,0,Rot);

        sprite.size = new Vector2(Dist,sprite.size.y);
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