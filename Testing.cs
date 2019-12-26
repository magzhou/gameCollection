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

    private void Start()
    {
        grid = new Grid(5,5);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0f;

            GetXY(vec, out h, out v);

            grid.SetValue(vec, 1);
		}
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0f;

            grid.SetValue(vec, 3);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0f;

            GetXY(vec, out ch, out cv);

            if (isLinear(h, v, ch, cv)) {
                grid.SetValue(vec, 2);
                MonoBehaviour.print("Linear");
            }
        }
    }

    private bool isLinear(int x1, int y1, int x2, int y2) {
        if (Math.Abs(x1 - x2) == Math.Abs(y1 - y2))
        {
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
