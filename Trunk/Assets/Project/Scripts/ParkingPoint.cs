using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingPoint : MonoBehaviour 
{
    public Material mat;
    public float speed;

    private float x, y;

    private void Start()
    {
        x = mat.mainTextureOffset.x;
        y = mat.mainTextureOffset.y;
    }


    private void Update()
    {
        x += (speed * Time.deltaTime);

        mat.mainTextureOffset = new Vector2(x, y);

        if(x >= 1)
        {
            x = 0;
        }
    }
}
