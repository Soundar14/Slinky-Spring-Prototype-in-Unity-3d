using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlinkyManager : Singleton<SlinkyManager>
{
    public SlinkySpringMovement HeadRef;
    public SlinkySpringMovement TailRef;

    public void ToggleSlinkyParts()
    {
        SlinkySpringMovement tempRef = HeadRef;
        HeadRef = TailRef;
        TailRef = tempRef;

        HeadRef.headOrTail = HeadOrTail.Head;
        TailRef.headOrTail = HeadOrTail.Tail;
    }

}
