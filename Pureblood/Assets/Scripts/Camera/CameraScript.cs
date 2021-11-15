using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraScript : MonoBehaviour
{

    public static CameraScript instance;

    private List<Transform> pointsOfFocus;

    private void Start()
    {
        pointsOfFocus = new List<Transform>();
        AddPointOfFocus(Player.instance.gameObject.transform);

        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Debug.Log("Multiple instances of camera script!!!");
            Destroy(this);
        }

    }


    public void AddPointOfFocus(Transform t)
    {
        pointsOfFocus.Add(t);
    }

    public void RemovePointOfFocus()
    {
        pointsOfFocus.RemoveAt(pointsOfFocus.Count-1);
    }

    private Vector3 GetAveragedPosition()
    {
        Vector3 pos = new Vector3(0, 0, 0);


        foreach (Transform v in pointsOfFocus)
        {
            pos += v.position;
        }

        pos = pos / pointsOfFocus.Count;

        return pos;

    }

    private void FixedUpdate()
    {
        Vector3 newPos = (GetAveragedPosition()*4 + Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) + transform.position*20) / 25f;
    transform.position = new Vector3(newPos.x, newPos.y, -10);
}
}
