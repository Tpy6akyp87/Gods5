using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScr : MonoBehaviour
{
    public RaycastHit hit;   //   Вытягивает данные из raycast (луча)
    public Ray ray;          //   Луч

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //  Создает луч из камеры в позицию мыши
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);//  Отрисовывает луч

        //      Если есть столкновение луча с колайдером
        if (Physics.Raycast(ray, out hit, 100))
        {                     //  так же инициализирует hit
                              //print("Hit something");
                              //print("Coordinates of Ray: " + ray);               //  Координаты дальней точки луча
        }
    }
}
