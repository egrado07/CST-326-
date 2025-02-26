using System.IO;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public TextAsset levelFile; // Assign the level text file in the Inspector
    public GameObject brickPrefab, questionBlockPrefab, groundPrefab, goombaPrefab, waterPrefab, goalPrefab; // Assign prefabs

    private void Start()
    {
        ParseLevel();
    }

    private void ParseLevel()
    {
        if (levelFile == null)
        {
            Debug.LogError("Level file is missing!");
            return;
        }

        string[] lines = levelFile.text.Split('\n');
        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                Vector3 position = new Vector3(x, -y, 0);
                char tile = lines[y][x];

                switch (tile)
                {
                    case '#': // Ground
                        Instantiate(groundPrefab, position, Quaternion.identity);
                        break;
                    case 'B': // Brick block
                        Instantiate(brickPrefab, position, Quaternion.identity);
                        break;
                    case '?': // Mystery block
                        Instantiate(questionBlockPrefab, position, Quaternion.identity);
                        break;
                    case 'G': // Goomba
                        Instantiate(goombaPrefab, position, Quaternion.identity);
                        break;
                     case 'W': // Water (New)
                        Instantiate(waterPrefab, position, Quaternion.identity);
                        break;
                     case 'X': // Goal (New)
                        Instantiate(goalPrefab, position, Quaternion.identity);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
