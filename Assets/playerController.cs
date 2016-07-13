using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    public Touch mostRecentTouch;
    public Vector2 initalTouchPosition;
    public bool devMouseControl = false;
    public Vector3 mousePosOld;
    public bool inAir;

    public GameObject weapon;

	// Update is called once per frame
	void Update () {

        if ((transform.position.y < -2.9)&&(gameObject.GetComponent<Rigidbody2D>().velocity.y<=0))
        {
            inAir = false;
        }

        if (!devMouseControl) {
            if (Input.touchCount > 0)
            {
                mostRecentTouch = Input.touches[0];
                weapon.SetActive(true);
                if (mostRecentTouch.phase == TouchPhase.Began)
                {
                    initalTouchPosition = Camera.main.ScreenToWorldPoint(mostRecentTouch.position);
                }
                else if (mostRecentTouch.phase == TouchPhase.Moved)
                {
                    if (mostRecentTouch.deltaPosition.y > 30)
                    {
                        AttemptJump();
                    }
                    Vector2 totalDelta = Camera.main.ScreenToWorldPoint(mostRecentTouch.position);
                    totalDelta -= initalTouchPosition; //On a seperate line because apparently previous output must be type cast first
                    if (totalDelta.x >= 0)//(mostRecentTouch.deltaPosition.x >= 0)
                    {
                        //weapon.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan(mostRecentTouch.deltaPosition.y / mostRecentTouch.deltaPosition.x) * 180 / Mathf.PI);
                        weapon.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan(totalDelta.y / totalDelta.x) * 180 / Mathf.PI);
                    }
                    else
                    {
                        //weapon.transform.localEulerAngles = new Vector3(0f, 0f, 180 + Mathf.Atan(mostRecentTouch.deltaPosition.y / mostRecentTouch.deltaPosition.x) * 180 / Mathf.PI);
                        weapon.transform.localEulerAngles = new Vector3(0f, 0f, 180 + Mathf.Atan(totalDelta.y / totalDelta.x) * 180 / Mathf.PI);
                    }
                }
            } else
            {
                weapon.SetActive(false);
            }
        } else
        {
            if (Input.GetMouseButtonDown(0))
            {
                initalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosOld = Input.mousePosition;
            } else if (Input.GetMouseButton(0))
            {
                if ((Input.mousePosition-mousePosOld).y>60)
                {
                    AttemptJump();
                }
            }
        }
    }

    void AttemptJump()
    {
        //Debug.Log("Jumping"); 
        if (!inAir)
        {
                inAir = true;
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000));
        }


    }
}
