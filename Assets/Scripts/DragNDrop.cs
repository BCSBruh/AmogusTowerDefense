using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DragNDrop : MonoBehaviour
{
    Vector3 mousePositionOffset;
    private bool isDone = false;
    private bool onRoad;
    public bool onTower = false;

    public GameObject radius;
    public GameObject uiCanvas;

    public void Start()
    {
        radius.SetActive(false);
        uiCanvas.SetActive(false);
    }

    public static Vector3 GetMouseWorldPosition()
    {
        //Capture mouse postion and return that point in thbe world
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        radius.SetActive(true);
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();

        if (isDone && onTower)
            StartCoroutine(closeUI());
    }

    private void OnMouseDrag()
    {
        if (!isDone)
        {
            transform.position = GetMouseWorldPosition() + mousePositionOffset;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            onRoad = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Road"))
        {
            onRoad = false;
        }
    }

    private void OnMouseUp()
    {
        if (!onRoad)
        {
            onTower = false;
            isDone = true;
        }

        radius.SetActive(false);
    }

    private void OnMouseOver()
    {
        onTower = true;
    }

    private void OnMouseExit()
    {
        onTower = false;
    }

    IEnumerator closeUI()
    {
        uiCanvas.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        uiCanvas.SetActive(false);
    }

}