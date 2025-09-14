using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingTileScroller : MonoBehaviour
{
    public Transform tileGroup;       // 타일을 포함하는 부모 Transform
    public Transform[] tiles;
    public float tileWidth;
    public float scrollSpeed;
    public float recycleX;

    void Update()
    {
        if(GameManager.instance.paradox)
        // 부모 그룹 자체를 이동
        tileGroup.position += Vector3.left * scrollSpeed * Time.deltaTime;

        foreach (Transform tile in tiles)
        {
            // 왼쪽 기준
            if (tile.position.x < recycleX)
            {
                Transform rightMost = GetRightMostTile();
                tile.position = new Vector3(rightMost.position.x + tileWidth, tile.position.y, tile.position.z);
            }
        }
    }

    Transform GetRightMostTile()
    {
        Transform rightMost = tiles[0];
        for (int i = 1; i < tiles.Length; i++)
        {
            if (tiles[i].position.x > rightMost.position.x)
                rightMost = tiles[i];
        }
        return rightMost;
    }
}
