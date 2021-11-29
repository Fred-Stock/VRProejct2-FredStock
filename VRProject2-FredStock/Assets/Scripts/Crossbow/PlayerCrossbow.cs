using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerCrossbow : Crossbow
{
    public bool activeCable;
    private GameObject curCable;

    public override void LoadCrossbow()
    {
        base.LoadCrossbow();
        curBolt.GetComponent<Bolt>().playerBolt = true;
        curBolt.GetComponent<Bolt>().activeCable = activeCable;
        curBolt.GetComponent<Bolt>().playerXBow = gameObject;

        if (curCable != null) { curBolt.GetComponent<Bolt>().curCable = curCable; }
    }

    public void SetCable(GameObject cable)
    {

        activeCable = cable != null;
        curCable = cable;
    }
}
