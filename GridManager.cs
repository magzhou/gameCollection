using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Sprite sprite;
    public float[,] Grid;
    int V, H, C, R;
    // Start is called before the first frame update
    void Start()
    {
        V = (int)Camera.main.orthographicSize;
        H = V * (Screen.width / Screen.height);
        C = H * 2;
        R = V * 2;
        Grid = new float[C, R];
        for (int i = 0; i < C; i++) {
            for (int j = 0; j < R; j++) {
                Grid[i, j] = Random.Range(0.0f, 1.0f);
                SpawnTile(i, j, Grid[i, j]);
            }
        }
    }

    // Update is called once per frame
    private void SpawnTile(int x, int y, float value) {
        GameObject obj = new GameObject("X: " + x + " Y: " + y);
        obj.transform.position = new Vector3(x - (H - 0.5f), y - (V - 0.5f));
        var s = obj.AddComponent<SpriteRenderer>();
        s.sprite = sprite;
        s.color = new Color(value, value, value);
    }
}
