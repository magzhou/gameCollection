using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame

    private Grid grid;
    private int h, v;
    private int ch, cv;
    private float mouseX, mouseY;

    private Vector3 vec;

    private void Start()
    {
        grid = new Grid(5,5);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0f;
            GetXY(vec, out h, out v);
		}
        else if (Input.GetMouseButtonUp(0))
        {
            vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0f;

            grid.SetValue(vec, 3);
        }

        if (Input.GetMouseButton(0)) {
            vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0f;
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");

            if (mouseX > 0 || mouseY > 0) { GetXY(vec, out ch, out cv); }

            if (IsHorizontal(h, v, ch, cv) && mouseY <= 0.05 && mouseX > 0){
                grid.SetValue(vec, 5);
                MonoBehaviour.print("Mouse X: " + mouseX);
                MonoBehaviour.print("Mouse Y: " + mouseY);
                MonoBehaviour.print("Horizontal: ");
            }

            if (IsDiagonal(h, v, ch, cv) && mouseY > 0.1 && mouseX > 0.1){ grid.SetValue(vec, 2);}
        }
    }

    private bool IsHorizontal(int x1, int y1, int x2, int y2)
    {
        if ((Math.Abs(y1 - y2)==0)&& (Math.Abs(x1 - x2) == 1))
        {
            return true;
        }
        return false;
    }

    private bool IsDiagonal(int x1, int y1, int x2, int y2) {
        if (Math.Abs(x1 - x2) == Math.Abs(y1 - y2)){
            return true;
        }
        return false;
    }

    private void GetXY(Vector3 worldPosistion, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosistion.x / 10f);
        y = Mathf.FloorToInt(worldPosistion.y / 10f);
    }
}
