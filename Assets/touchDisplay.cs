using UnityEngine;
using System.Collections;

public class touchDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        for (int i=0;i<Input.touchCount;i++) {
            Touch touch = Input.touches[i];
            if (touch.phase==TouchPhase.Began)
            {
               GameObject touchObj = new GameObject("TouchLine",typeof(touchLine),typeof(LineRenderer)) ;               
               touchObj.GetComponent<touchLine>().myTouch = i;
               touchObj.GetComponent<touchLine>().initialPoint = Camera.main.ScreenToWorldPoint(touch.position);
               touchObj.transform.parent = transform;
            }
        }
    }
}
