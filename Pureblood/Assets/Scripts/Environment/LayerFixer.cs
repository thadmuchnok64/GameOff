using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerFixer : MonoBehaviour
{
    [Tooltip("Keep this disabled for best performance. Probably best to keep this off for non-entities or anything that can't move.")]
    [SerializeField] bool updateConstantly = false;
    [SerializeField] bool changeChildren = false;
    [Tooltip("Increase or decrease this if your layer doesn't seem quite right. It's also best to increment this in 3's")]
    [SerializeField] int layerOffset = 0;
    private SpriteRenderer sr;
    private SpriteRenderer[] children;
    private int[] childOffsets;

    private void Start()
    {
        List<int> childoff = new List<int>();
        List<SpriteRenderer> childRens = new List<SpriteRenderer>();

        sr = GetComponent<SpriteRenderer>();

        if (changeChildren)
        {
            foreach(SpriteRenderer s in GetComponentsInChildren<SpriteRenderer>())
            {
                childoff.Add(s.sortingOrder);
                childRens.Add(s);
            }
            childOffsets = childoff.ToArray();
            children = childRens.ToArray();
        }

        UpdateSortingLayer();

        if (updateConstantly)
        {
            InvokeRepeating("UpdateSortingLayer", .2f, .1f);
        }

    }


    private void UpdateSortingLayer()
    {
        ChangeLayer(sr);
        if (changeChildren)
        {
            for(int x = 0; x < children.Length; x++)
            {
                ChangeLayer(children[x],childOffsets[x]);
            }
        }
    }

    private void ChangeLayer(SpriteRenderer s)
    {
        s.sortingOrder = Mathf.RoundToInt(transform.position.y * -3f)*3;
        if (!updateConstantly)
            s.sortingOrder +=2;
        s.sortingOrder += layerOffset;
    }

    private void ChangeLayer(SpriteRenderer s,int offset)
    {
        s.sortingOrder = (Mathf.RoundToInt(transform.position.y * -3f)*3)+offset;
        if (!updateConstantly)
            s.sortingOrder += 2;
        s.sortingOrder += layerOffset;

    }
}
