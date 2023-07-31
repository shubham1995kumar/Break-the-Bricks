using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMagager : MonoBehaviour
{
    public GameObject[] brickPrefabs; // an aaray to hold different brick prefabs;
    public int numRow = 5; // number of rows of the bricks;

    public int numCols = 8;// number of columes of bricks

    // Start is called before the first frame update
    void Start()
    {
        GenerateBricks();

    }

    // Update is called once per frame
    void GenerateBricks()
    {
        float bricksWidth = brickPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.x;
        float brickHeight = brickPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.y;

        for (int row= 0; row<numRow; row++)
        {
            for(int col=0; col<numCols; col++)
            {
                Vector2 brickPosition = new Vector2(col * bricksWidth, row * brickHeight);
                int bricktype = Random.Range(0, brickPrefabs.Length);
                Instantiate(brickPrefabs[bricktype], brickPosition, Quaternion.identity, transform);
            }
        }

    }
}
