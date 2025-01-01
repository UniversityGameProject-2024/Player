using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dragging : MonoBehaviour
{
    //[SerializeField]
    //public Material materialRed;
    
    //[SerializeField]
    //public Material materialBlue;
    
    [SerializeField]
    public Camera myCamera;

    private float distanceFromCamera;
    private bool draggingByTouch = false;
    private bool draggingByMouse = false;
    private Vector3 offset;
    private Transform toDrag;
    private GameObject draggedGameObect;


    // Update is called once per frame
    void Update()
    {
        // These methods allow to grab the object which has the tag "Cube"
        // either by touch or by the mouse
        //GrabByTouch();
        GrabByMouse();
    }

    public void GrabByMouse()
    {
        Vector3 v3;

        Vector3 mousePos = Input.mousePosition;

        //if (Input.GetMouseButtonDown(1))
        if (Input.GetKeyDown(KeyCode.G))
        {
            Ray ray = myCamera.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Enemy")
                {
                    draggedGameObect = hit.collider.gameObject;

                    //draggedGameObect.GetComponent<MeshRenderer>().material = materialBlue;

                    toDrag = hit.transform;
                    distanceFromCamera = hit.transform.position.z - myCamera.transform.position.z;
                    v3 = new Vector3(mousePos.x, mousePos.y, distanceFromCamera);

                    //v3 = Camera.main.ScreenToWorldPoint(v3);
                    v3 = myCamera.ScreenToWorldPoint(v3);

                    offset = toDrag.position - v3;
                    draggingByMouse = true;
                }
            }
        }

        if (draggingByMouse)
        {
            v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera);

            //v3 = Camera.main.ScreenToWorldPoint(v3);
            v3 = myCamera.ScreenToWorldPoint(v3);

            Vector3 newPos = v3 + offset;

            // Move only if not going to be below the ground plane
            //if (newPos.y - toDrag.lossyScale.y / 2 >= 1f)
            //{
                toDrag.position = newPos;
            //}
        }
        
        //if (Input.GetMouseButtonUp(1))
        if (Input.GetKeyUp(KeyCode.G))
        {
            draggingByMouse = false;
            //draggedGameObect.GetComponent<MeshRenderer>().material = materialRed;
        }



    }


    public void GrabByTouch()
    {
        Vector3 vectorTouchPos;
        if (Input.touchCount != 1)
        {
            draggingByTouch = false;
            return;
        }
        Touch touch = Input.touches[0];

        Vector3 touchPos = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = myCamera.ScreenPointToRay(touchPos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Enemy")
                {
                    draggedGameObect = hit.collider.gameObject;

                    //draggedGameObect.GetComponent<MeshRenderer>().material = materialBlue;

                    toDrag = hit.transform;
                    distanceFromCamera = hit.transform.position.z - myCamera.transform.position.z;
                    vectorTouchPos = new Vector3(touchPos.x, touchPos.y, distanceFromCamera);

                    //v3 = Camera.main.ScreenToWorldPoint(v3);
                    vectorTouchPos = myCamera.ScreenToWorldPoint(vectorTouchPos);

                    offset = toDrag.position - vectorTouchPos;
                    draggingByTouch = true;
                }
            }
        }
        if (draggingByTouch && touch.phase == TouchPhase.Moved)
        {
            vectorTouchPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera);

            //v3 = Camera.main.ScreenToWorldPoint(v3);
            vectorTouchPos = myCamera.ScreenToWorldPoint(vectorTouchPos);

            // Move only if not going to be below the ground plane
            if ((vectorTouchPos + offset).y - toDrag.lossyScale.y / 2 >= 1)
            {
                toDrag.position = vectorTouchPos + offset;
            }
        }
        if (draggingByTouch && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            draggingByTouch = false;
            //draggedGameObect.GetComponent<MeshRenderer>().material = materialRed;
        }

    }
}

