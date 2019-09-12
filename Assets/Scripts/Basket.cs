using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
  

    // Update is called once per frame
    void Update()
    {
        //Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        //The Camera's position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert the point from 2D screen space into 3D game world space
        Vector3 mousePod3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move the x positionn of this Basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePod3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision coll)
    {
        //Find out what hit his basket
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
        }
    }
}
