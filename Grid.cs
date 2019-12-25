using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int V, H, C, R;
    private int width;
    private int height;
    private int[,] gridArray;
	private TextMesh[,] debugTextArray;

    GameObject gameObject;
    Transform transform;
    TextMesh textMesh;

    public Grid(int width, int height) {
        this.width = width;
        this.height = height;

        V = (int)Camera.main.orthographicSize;
        H = V * (Screen.width / Screen.height);
        C = H * 2;
        R = V * 2;

        gridArray = new int[width, height];
		debugTextArray = new TextMesh[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++) {
            for (int y = 0; y < gridArray.GetLength(1); y++) {
                SpawnTile(x, y);
                Debug.DrawLine(GetworldPosition(x, y), GetworldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetworldPosition(x, y), GetworldPosition(x + 1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetworldPosition(0, height), GetworldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetworldPosition(width, 0), GetworldPosition(width, height), Color.white, 100f);
    }

    private void SpawnTile(int x, int y){
        gameObject = new GameObject("World_Text", typeof(TextMesh));
        transform = gameObject.transform;
        transform.localPosition = GetworldPosition(x, y) + new Vector3(10f, 10f) * .5f;
        textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.fontSize = 12;
        textMesh.text = gridArray[x, y].ToString();
		debugTextArray[x, y] = textMesh;
	}

    private Vector3 GetworldPosition(int x, int y) {
        return new Vector3(x, y) * 10f;
    }

    private void GetXY(Vector3 worldPosistion, out int x, out int y) {
        x = Mathf.FloorToInt(worldPosistion.x / 10f);
        y = Mathf.FloorToInt(worldPosistion.y / 10f);
    }

    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
			debugTextArray[x, y].text = gridArray[x,y].ToString();
			Debug.Log(value);
        }
    }

    public void SetValue(Vector3 worldPosition, int value) {
        int x, y;
        GetXY(worldPosition, out x, out y);
		Debug.Log(x + " " + y);
        SetValue(x, y, value);
    }

	public int GetValue(int x, int y) {
		if (x >= 0 && y >= 0 && x < width && y < height)
		{
			return gridArray[x, y];
		}
		else {
			return -1;
        }
	}

	public void SetValue(Vector3 worldPosition)
	{
		int x, y;
		GetXY(worldPosition, out x, out y);
		Debug.Log(x + " " + y);
		return GetValue(x, y);
	}
}
