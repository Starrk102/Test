using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragMouse : MonoBehaviour
{

    Vector3 dist;
    Vector3 startPos;
    Vector3 lastPos;
    Vector3 minPos;
    float posX;
    float posZ;
    float posY;

    public GameObject Min;
    public GameObject Max;
    public GameObject Znach;

    public GameObject Cub;
    public GameObject Cub_1;
    public GameObject Cub_M1;
    public GameObject Cub_2;
    public GameObject Cub_M2;
    public GameObject Cub_3;
    public GameObject Cub_M3;
    public GameObject Cylindr;
    public GameObject Brick;
    public GameObject Wood;
    public GameObject Gips;

    bool token = true;

    private void Update()
    {
        float F = Mathf.Abs((Min.transform.position.x - Znach.gameObject.transform.position.x) * 100f);
        float D = Cub.transform.localScale.x * 100f;
    }

    void OnMouseDown()
    {
        startPos = this.transform.position;
        dist = Camera.main.WorldToScreenPoint(this.transform.position);
        posX = Input.mousePosition.x - dist.x;
        posY = Input.mousePosition.y - dist.y;
        posZ = Input.mousePosition.z - dist.z;
    }

    void OnMouseDrag()
    {
        if (Cub == true)
        {
            float disX = Input.mousePosition.x - posX;
            float disY = Input.mousePosition.y - posY;
            float disZ = Input.mousePosition.z - posZ;
            lastPos = Camera.main.ScreenToWorldPoint(new Vector3(disX, disY, disZ));
            
            if (lastPos.x > Min.transform.position.x && lastPos.x < Max.transform.position.x && token == true)
            {
                this.gameObject.GetComponent<Rigidbody>().MovePosition(new Vector3(lastPos.x, startPos.y, startPos.z));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Cub") || other.tag.Equals("Cylindr") || other.tag.Equals("Brick") || other.tag.Equals("Wood") || other.tag.Equals("Gips"))
        {
            token = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Cub") || other.tag.Equals("Cylindr") || other.tag.Equals("Brick") || other.tag.Equals("Wood") || other.tag.Equals("Gips"))
        {
            token = true;
        }
    }
}
