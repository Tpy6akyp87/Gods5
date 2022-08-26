using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScr : MonoBehaviour
{
    public RaycastHit hit;   //   ���������� ������ �� raycast (����)
    public Ray ray;          //   ���

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //  ������� ��� �� ������ � ������� ����
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);//  ������������ ���

        //      ���� ���� ������������ ���� � ����������
        if (Physics.Raycast(ray, out hit, 100))
        {                     //  ��� �� �������������� hit
                              //print("Hit something");
                              //print("Coordinates of Ray: " + ray);               //  ���������� ������� ����� ����
        }
    }
}
