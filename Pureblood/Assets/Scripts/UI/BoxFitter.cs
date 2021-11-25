using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFitter : MonoBehaviour
{
    [SerializeField] RectTransform boxToFit;
    [SerializeField] RectTransform thisBox;
    // Update is called once per frame
    void Update()
    {
        thisBox.sizeDelta = boxToFit.sizeDelta+new Vector2(100, 100);
    }
}
