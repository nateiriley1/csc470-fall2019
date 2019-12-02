using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour
{
    //mouse sens
    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    //reference character
    GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        // get parent for mouse
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        //get mouse movement
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        //scale to sens
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        //lock mouse to 90 on each y direction
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        //move mouse 
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

        

    }
}
