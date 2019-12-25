using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame

    private Grid grid;

    private void Start()
    {
        grid = new Grid(4,2);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0f;

            grid.SetValue(vec, 56);
			MonoBehaviour.print("Mouse Clicked");

		}
    }
}
