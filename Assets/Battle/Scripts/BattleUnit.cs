using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleUnit : MonoBehaviour
{
    //public Camera camera;//       Камера из которой получим данные луча (добавить в Инспекторе)
    //private bool isDraging = false;//     При клике на объекте разрешаем перемещение
    //                                 // Use this for initialization
    //void Start()
    //{
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (isDraging)
    //    {       //      Если разрешено перемещение объекта
    //        Vector3 point = new Vector3(camera.GetComponent<CameraScr>().hit.point.x, camera.GetComponent<CameraScr>().hit.point.y, 0);                                                     //      Запрещаю перемещение по z
    //        this.transform.position = point;                                //      Передаю новые координаты объекту
    //    }
    //}
    ////      Идентифицирует зажатие клика
    //void OnMouseDown()
    //{
    //    isDraging = true;             // Разрешает перемещение
    //}
    ////      Идентифицирует отпускание зажатого клика
    //void OnMouseUp()
    //{
    //    isDraging = false;            //      Запрещает перемещение
    //}

}
