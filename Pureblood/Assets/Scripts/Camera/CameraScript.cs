using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraScript : MonoBehaviour
{

    public static CameraScript instance;

    private List<Transform> pointsOfFocus;
    private int[] pofWeights;

    private Vector3 avg;
    private float rumble;
    Vector3 mPos = new Vector3(0, 0, 0);


    private void Start()
{
    rumble = 0;
    pointsOfFocus = new List<Transform>();
    pofWeights = new int[15];
    AddPointOfFocus(Player.instance.gameObject.transform);

    if (instance == null)
    {
        instance = this;
    } else if (instance != this)
    {
        Debug.Log("Multiple instances of camera script!!!");
        Destroy(this);
    }

    avg = GetAveragedPosition();
}
    
public void AddRumble(float force)
{
rumble = force;
}

public void AddPointOfFocus(Transform t)
{
pointsOfFocus.Add(t);
pofWeights[pointsOfFocus.Count-1]=1;
}

public void RemovePointOfFocus()
{
pointsOfFocus.RemoveAt(pointsOfFocus.Count-1);
pofWeights[pointsOfFocus.Count]=0;
}
    
private Vector3 GetAveragedPosition()
{
Vector3 pos = new Vector3(0, 0, 0);
int weight = 0;
Transform[] pof = pointsOfFocus.ToArray();


for(int x = 0; x < pof.Length; x++)
{
if(pof[x] is RectTransform)
{
    if(!IsFullyVisibleFrom(pof[x] as RectTransform, Camera.main))
    {
        pofWeights[x]++;
    }
}
pos += pof[x].position * pofWeights[x];
weight += pofWeights[x];
}

pos = pos / weight;


return pos;

}
    
private Vector3 GetRandomizedRumble()
{
Vector3 r = new Vector3(Random.Range(-rumble,rumble), Random.Range(-rumble, rumble));
rumble = rumble / 1.15f;
return r;
}
private Vector3 GetDelayedAverage()
{
avg = (GetAveragedPosition() + avg * 7) / 8;
return avg;
}

    
//Thanks KGC for the code
private  int CountCornersVisibleFrom( RectTransform rectTransform, Camera camera)
{
Rect screenBounds = new Rect(0f, 400f, Screen.width, Screen.height*.6667f); // Screen space bounds (assumes camera renders across the entire screen)
Vector3[] objectCorners = new Vector3[4];
rectTransform.GetWorldCorners(objectCorners);

int visibleCorners = 0;
Vector3 tempScreenSpaceCorner; // Cached
for (var i = 0; i < objectCorners.Length; i++) // For each corner in rectTransform
{
tempScreenSpaceCorner = camera.WorldToScreenPoint(objectCorners[i]); // Transform world space position of corner to screen space
if (screenBounds.Contains(tempScreenSpaceCorner)) // If the corner is inside the screen
{
visibleCorners++;
}
}
return visibleCorners;
}

public bool IsFullyVisibleFrom( RectTransform rectTransform, Camera camera)
{
return CountCornersVisibleFrom(rectTransform, camera) == 4; // True if all 4 corners are visible
}
    


private void FixedUpdate()
{
        if (Player.instance.currentState != Entity.EntityStates.TALKING)
        {
            mPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        }

        Vector3 newPos = (((GetDelayedAverage() * 4 + mPos) + transform.position * 20) / 25f) +GetRandomizedRumble();
transform.position = new Vector3(newPos.x, newPos.y, -10);
}

}
