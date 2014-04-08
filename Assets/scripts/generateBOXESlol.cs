using UnityEngine;
using System.Collections;

public class generateBOXESlol : MonoBehaviour
{
    //Variables
    public Transform floor;
    public Transform camera;
    public Transform crate;
    public Transform wall;
    public Transform player1;
    public Transform player2;
    public int maxw = 10;
    public int maxh = 10;
    private int[,] x;
    private int y = 0;
    public int numbercrate = 10;
    private int number, spawnnumber;



    // Use this for initialization
    void Awake()
    {
        //Spawn Floor
        Transform Floor = (Transform)Instantiate(floor, new Vector3(maxw / 2, 0, maxh / 2), Quaternion.identity);
        Floor.transform.localScale = new Vector3(maxw, 1, maxh);
        Floor.renderer.material.mainTextureScale = new Vector2(maxh, maxw);

        //Spawn Walls
        Transform Wall1 = (Transform)Instantiate(wall, new Vector3(maxw, 1, maxh / 2), Quaternion.identity);
        Transform Wall2 = (Transform)Instantiate(wall, new Vector3(0, 1, maxh / 2), Quaternion.identity);
        Transform Wall3 = (Transform)Instantiate(wall, new Vector3(maxw/2, 1, maxh), Quaternion.identity);
        Transform Wall4 = (Transform)Instantiate(wall, new Vector3(maxw / 2, 1, 0), Quaternion.identity);

        Wall1.transform.localScale = new Vector3(1, 1, maxh-1);
        Wall2.transform.localScale = new Vector3(1, 1, maxh-1);
        Wall3.transform.localScale = new Vector3(maxw+1, 1, 1);
        Wall4.transform.localScale = new Vector3(maxw+1, 1, 1);

        Wall1.renderer.material.mainTextureScale = new Vector2(1, maxh-1);
        Wall2.renderer.material.mainTextureScale = new Vector2(1, maxh-1);
        Wall3.renderer.material.mainTextureScale = new Vector2(maxw-1, 1);
        Wall4.renderer.material.mainTextureScale = new Vector2(maxw-1, 1);

        //Generate seed value to determine the spawn of the players
        spawnnumber = Random.Range(0, 4);

        switch (spawnnumber)
        {
            case 0:
                Instantiate(player1, new Vector3(1, 1, 1), Quaternion.identity);
                Instantiate(player2, new Vector3(maxh - 2, 1, maxw - 2), Quaternion.identity);
                break;
            case 1:
                Instantiate(player1, new Vector3(maxh - 2, 1, 1), Quaternion.identity);
                Instantiate(player2, new Vector3(1, 1, maxw - 2), Quaternion.identity);
                break;
            case 2:
                Instantiate(player1, new Vector3(1, 1, maxw - 2), Quaternion.identity);
                Instantiate(player2, new Vector3(maxh - 2, 1, 1), Quaternion.identity);
                break;
            case 3:
                Instantiate(player2, new Vector3(1, 1, 1), Quaternion.identity);
                Instantiate(player1, new Vector3(maxh - 2, 1, maxw - 2), Quaternion.identity);
                break;
            default:
                break;
        }

        //Camera moves accordingly with field size to compensate for bigger areas
        camera.transform.position = new Vector3(maxh / 2, maxh + 5, maxw / 2);


        //LEVEL GENERATION
        x = new int[maxh, maxw];
        for (int i = 0; i <= maxh - 1; i++)
            for (int k = 0; k <= maxw - 1; k++)
            {
                if (i == 0 || k == 0 || i == maxh - 1 || k == maxw - 1)
                {
                    //x[i, k] = 1;
                }
                else
                {
                    x[i, k] = 0;
                }




            }
        for (int i = 2; i < maxh - 2; i = i + 2)
            for (int k = 2; k < maxw - 2; k = k + 2)
            {
                if (y == 0)
                {
                    x[i, k] = 1;
                    y = 1;
                }
                else
                {
                    y--;
                }

            }
        for (int i = 0; i <= maxh - 1; i++)
            for (int k = 0; k <= maxw - 1; k++)
            {
                if (x[i, k] != 0 && x[i, k] != 1)
                {
                    if (Random.Range(0, 2) == 1)
                    {
                        x[i, k] = 2;
                    }


                }



            }
        //Spawn boxes loop
        for (int i = 0; i <= maxh - 1; i++)
            for (int k = 0; k <= maxw - 1; k++)
            {


                switch (x[i, k])
                {

                    case 0:
                        if (((k == 1 && i == 1) || (k == 2 && i == 1) || (k == 1 && i == 2)) || ((k == maxw - 2 && i == maxh - 2) || (k == maxw - 3 && i == maxh - 2) || (k == maxw - 2 && i == maxh - 3)) || ((k == maxw - 2 && i == 1) || (k == maxw - 3 && i == 1) || (k == maxw - 2 && i == 2)) || ((k == 1 && i == maxh - 2) || (k == 2 && i == maxh - 2) || (k == 1 && i == maxh - 3)))
                        {
                            break;
                        }
                        else
                        {
                            //30% chance to spawn a destructible block on top of the floor 
                            if (Random.Range(0, 3) >= 1)
                            {
                                Instantiate(crate, new Vector3(i, 1, k), Quaternion.identity);
                            }
                        }
                        break;
                    case 1:
                        Instantiate(wall, new Vector3(i, 1, k), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(crate, new Vector3(i, 1, k), Quaternion.identity);
                        break;
                    default:
                        break;
                }
            }
    }
}

	
