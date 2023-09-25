using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GarbageManager : Tools
{

    public GlassManager gm;

    private void OnMouseDown()
    {
        gm.Clear();
    }
    public override void Clear()
    {
        base.Clear();
    }
}
