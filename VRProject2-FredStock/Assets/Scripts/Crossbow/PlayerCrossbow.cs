using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerCrossbow : Crossbow
{

    public override void LoadCrossbow()
    {
        base.LoadCrossbow();
        curBolt.GetComponent<Bolt>().playerBolt = true;
    }
}
