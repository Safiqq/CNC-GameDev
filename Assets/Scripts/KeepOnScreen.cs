using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOnScreen : MonoBehaviour
{
    public Camera MainCamera; //be sure to assign this in the inspector to your main camera
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Use this for initialization
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 - objectWidth + 1, screenBounds.x + objectWidth - 1);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 - objectHeight + 1, screenBounds.y + objectHeight - 1);
        transform.position = viewPos;
    }
}
