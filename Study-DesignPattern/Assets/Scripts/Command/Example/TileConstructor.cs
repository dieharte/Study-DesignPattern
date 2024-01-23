using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileConstructor : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;

    [SerializeField] private Vector2Int boardSize = new Vector2Int(3,3);

    private void Awake()
    {
        int maxX = (boardSize.x % 2) == 0 ? (boardSize.x / 2) + 1 : (boardSize.x / 2) + 1;
        int maxY = (boardSize.y % 2) == 0 ? (boardSize.y / 2) + 1 : (boardSize.y / 2) + 1;
        bool evenNumberX = (boardSize.x % 2) == 0;
        bool evenNumberY = (boardSize.y % 2) == 0;

        for (int i = 0; i < maxX; i++)
        {
            for(int j = 0; j < maxY; j++)
            {
                Vector3 pos = new Vector3(i, j, 0);
                Instantiate(tilePrefab, pos, Quaternion.identity);

                if(i > 0 && ((evenNumberX && i < maxX -1 ) || !evenNumberX) )
                {
                    pos = new Vector3(-i, j, 0);
                    Instantiate(tilePrefab, pos, Quaternion.identity);
                }

                if(j > 0 && ((evenNumberY && j < maxY -1 ) || !evenNumberY))
                {
                    pos = new Vector3(i, -j, 0);
                    Instantiate(tilePrefab, pos, Quaternion.identity);

                    if (i > 0 && ((evenNumberX && i < maxX - 1) || !evenNumberX))
                    {
                        pos = new Vector3(-i, -j, 0);
                        Instantiate(tilePrefab, pos, Quaternion.identity);
                    }
                }
            }
        }
    }
}
