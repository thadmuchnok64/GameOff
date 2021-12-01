using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuriyNode : DialogueBranch
{
    [SerializeField] int purity;

    public override int PurityStored()
    {
        return purity;
    }
}
