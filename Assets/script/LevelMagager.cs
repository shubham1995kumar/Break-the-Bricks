using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMagager : MonoBehaviour
{
    public GameObject[] brickPrefabs; // an aaray to hold different brick prefabs;
    public int numRow = 5; // number of rows of the bricks;

    public int numCols = 8;// number of columes of bricks
    public Vector2 offset;
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

        for (int row = 0; row < numRow; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                Vector2 brickPosition = new Vector2(col * bricksWidth * offset.x, row * brickHeight * offset.y);
                int bricktype = Random.Range(0, brickPrefabs.Length); 
        Instantiate(brickPrefabs[bricktype], brickPosition, Quaternion.identity, transform);
             }
}

     }
    /* public GameObject brickPrefab;
     public Vector2Int size;
     public Vector2 offset;

     private void Awake()
     {
         for (int row = 0; row < size.x; row++)
         {
             for (int col = 0; col < size.y; col++)   //(col * bricksWidth, row * brickHeight);
             {
                 GameObject newBrick = Instantiate(brickPrefab, transform);
                 newBrick.transform.position = transform.position + new 


             }
         }
     }*/
}
