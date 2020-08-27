using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public GameObject Talkanat;
    public GameObject ElementMovement;
    public GameObject StartPoint;
    public GameObject Cvecha;
    public GameObject CvechaC;
    public GameObject CvechaGameObject;
    public GameObject lebedka;

    List<GameObject> CvechaList = new List<GameObject>();
    int i = 0;

    GameObject CvechaCreate;
    bool cvechabool = false;
    bool token_sound = false;
    Vector3 vectorCreate;

    public float speed = 1f;

    public GameObject Max;
    public GameObject Max_1;
    public GameObject Min;
    public GameObject Min_1;
    public GameObject AKB;
    public GameObject AKB_1;

    // Start is called before the first frame update
    void Start()
    {
        vectorCreate = new Vector3(0f, 2.28f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Min.transform.position.y + " : " + ElementMovement.transform.position.y);

        if (ManagerInput_tumbler.j == 0)
        {
            Talkanat.transform.position = Talkanat.transform.position;
            ElementMovement.transform.position = ElementMovement.transform.position;
            StartPoint.transform.position = StartPoint.transform.position;
            Cvecha.transform.position = Cvecha.transform.position;
            token_sound = false;
        }
        else if(ManagerInput_tumbler.j == 1 && ElementMovement.transform.position.y < Max.transform.position.y)
        {
            Talkanat.transform.position = Talkanat.transform.position + speed * new Vector3(0, 0.0005f, 0);
            ElementMovement.transform.position = ElementMovement.transform.position + speed * new Vector3(0, 0.0005f, 0);
            StartPoint.transform.position = StartPoint.transform.position + speed * new Vector3(0, 0.0005f, 0);
            Cvecha.transform.position = Cvecha.transform.position + speed * new Vector3(0, 0.0005f, 0);
            token_sound = true;
        }
        else if(ManagerInput_tumbler.j == -1 && ElementMovement.transform.position.y > Min.transform.position.y)
        {
            Talkanat.transform.position = Talkanat.transform.position - speed * new Vector3(0, 0.0005f, 0);
            ElementMovement.transform.position = ElementMovement.transform.position - speed * new Vector3(0, 0.0005f, 0);
            StartPoint.transform.position = StartPoint.transform.position - speed * new Vector3(0, 0.0005f, 0);
            Cvecha.transform.position = Cvecha.transform.position - speed * new Vector3(0, 0.0005f, 0);
            token_sound = true;
        }

        if(ElementMovement.transform.position.y > Min.transform.position.y && ElementMovement.transform.position.y < Min_1.transform.position.y)
        {
            ManagerInput_tumbler.MIN_ElemntMovement = true;
        }
        else
        {
            ManagerInput_tumbler.MIN_ElemntMovement = false;
        }

        if (ElementMovement.transform.position.y < AKB.transform.position.y && ElementMovement.transform.position.y > AKB_1.transform.position.y)
        {
            ManagerInput_tumbler.AKB_ElemntMovement = true;
        }
        else
        {
            ManagerInput_tumbler.AKB_ElemntMovement = false;
        }

        if (ElementMovement.transform.position.y < Max.transform.position.y && ElementMovement.transform.position.y > Max_1.transform.position .y)
        {
            ManagerInput_tumbler.MAX_ElemntMovement = true;
        }
        else
        {
            ManagerInput_tumbler.MAX_ElemntMovement = false;
        }

    }

    void ForList()
    {
        for(int j = 0; j < CvechaList.Count - 1; j++)
        {
            CvechaList[j].transform.position = CvechaList[j].transform.position - vectorCreate;
        }
    }

    public void CreateCvesha()
    {
        GameObject go;
        if (cvechabool == false)
        {
            CvechaCreate = CvechaC;
            go = Instantiate(CvechaCreate, Cvecha.transform);
            CvechaList.Add(go);
            CvechaC.SetActive(false);
            Cvecha = CvechaC;
            go = null;
            cvechabool = true;
        }
        else
        {
            CvechaCreate = CvechaC;
            go = Instantiate(CvechaCreate, Cvecha.transform);
            CvechaList.Add(go);
            i++;
            //CvechaList[i - 1].transform.position = CvechaList[i - 1].transform.position - vectorCreate;
            CvechaC.SetActive(false);
            Cvecha = CvechaC;
            go = null;
            ForList();
        }
    }

    public void AKB_Create()
    {
        Cvecha = CvechaGameObject;
    }

}
