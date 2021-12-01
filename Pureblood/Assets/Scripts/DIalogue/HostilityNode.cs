using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostilityNode : DialogueBranch
{
    [SerializeField] int[] indexesToMakeHostile;

    public override int[] GetHostileID()
    {
        return indexesToMakeHostile;
    }
}
