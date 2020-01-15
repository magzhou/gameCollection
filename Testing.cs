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

    private int flag;
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

            MonoBehaviour.print("Mouse Down at " + h + v);

            grid.SetValue(vec, 2);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0f;

            GetXY(vec, out ch, out cv);

            MonoBehaviour.print("Mouse Released at " + ch + cv);

            if ( IsHorizontal(h, v, ch, cv) ){
                flag = Math.Abs(ch - h);
                for (int i = 0; i < flag; i++, h++)
                {
                    grid.SetValue(h, v, 2);
                }
            }
            else if ( IsDiagonal(h, v, ch, cv) ){
                flag = Math.Abs(cv - v);
                for (int i = 0; i <= flag; i++, v++, h++)
                {
                    grid.SetValue(h, v, 2);
                }
            }
            else if ( IsVertical(h, v, ch, cv) ) {
                flag = Math.Abs(cv - v);
                for (int i = 0; i < flag; i++, v++)
                {
                    grid.SetValue(h, v, 2);
                }
            }
        }
    }

    private bool IsHorizontal(int x1, int y1, int x2, int y2)
    {
        if ( y1 == y2 ){ return true; }
        return false;
    }

    private bool IsVertical(int x1, int y1, int x2, int y2)
    {
        if ( (x1 == x2) ){ return true; }
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