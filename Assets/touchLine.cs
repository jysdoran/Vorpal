using UnityEngine;
using System.Collections;

public class touchLine : MonoBehaviour {

    public int myTouch;
    LineRenderer lineRenderer;
    public Vector3 initialPoint;
    Vector3 endPoint;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetWidth(0.1f,0.1f);
        lineRenderer.SetColors(Color.red,Color.black);
        endPoint = Camera.main.ScreenToWorldPoint(Input.touches[myTouch].position);
    }

	// Update is called once per frame
	void Update () {
        if (Input.touchCount >= myTouch + 1)
        {
            if (Input.touches[myTouch].phase == TouchPhase.Moved)
            {
                endPoint = Camera.main.ScreenToWorldPoint(Input.touches[myTouch].position);
            }
            else if (Input.touches[myTouch].phase == TouchPhase.Ended || Input.touches[myTouch].phase == TouchPhase.Canceled)
            {
                Destroy(gameObject);
            }
            lineRenderer.SetPosition(0, new Vector3(initialPoint.x, initialPoint.y, 0));
            lineRenderer.SetPosition(1, new Vector3(endPoint.x, endPoint.y, 0));
        } else
        {
            Destroy(gameObject);
        }
       // Debug.Log(endPoint);
    }
}
