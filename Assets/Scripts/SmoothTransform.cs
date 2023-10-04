using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothTransform : MonoBehaviour
{
    public Vector2 targetPosition;
    public float smoothFactor = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<RectTransform>().localPosition = Vector3.Lerp(this.GetComponent<RectTransform>().localPosition, targetPosition, Time.deltaTime * smoothFactor);
    }

    public void SetTargetX(float x)
    {
        targetPosition.x = x;
    }

    public void SetTargetY(float y)
    {
        targetPosition.y = y;
    }
}
