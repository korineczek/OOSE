using UnityEngine;
using System.Collections;

public class generateBOXESlol : MonoBehaviour {
	
	public Transform ragingboner;
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
	void Start () {
		
		spawnnumber = Random.Range(0,4);
		camera.transform.position = new Vector3(maxh/2,maxh+5,maxw/2);
		x = new int [maxh,maxw];
		for(int i= 0; i<=maxh-1; i++)
			for(int k= 0; k<=maxw-1; k++){
			 	if(i==0||k==0||i==maxh-1||k==maxw-1){
					x[i,k] = 1;
				}
				else{
					x[i,k] = 0;
				}
				
				
			
			
		}
		for(int i= 2; i<maxh-2; i=i+2)
			for(int k= 2; k<maxw-2; k=k+2){
				if(y==0){
					x[i,k] = 1;
					y = 1;
			}
			else{
				y--;
			}
			
		}
		for(int i= 0; i<=maxh-1; i++)
			for(int k= 0; k<=maxw-1; k++){
				if(x[i,k] != 0 && x[i,k] !=1){
				if(Random.Range(0,2)==1){
					x[i,k] = 2;
				}
				
					
			}
					
			
			
		}
		for(int i= 0; i<=maxh-1; i++)
			for(int k= 0; k<=maxw-1; k++){
		
		switch (x[i,k]){
			
		case 0:
			Instantiate(ragingboner,new Vector3(i,0,k),Quaternion.identity);
				if(((k == 1 && i == 1)||(k == 2 && i == 1)||(k == 1 && i == 2))||((k == maxw-2 && i == maxh-2)||(k == maxw-3 && i == maxh-2)||(k == maxw-2 && i == maxh-3))||((k == maxw-2 && i == 1)||(k == maxw-3 && i == 1)||(k == maxw-2 && i == 2))||((k == 1 && i == maxh-2)||(k == 2 && i == maxh-2)||(k == 1 && i == maxh-3))){
					break;
				}else{
				if(Random.Range(0,3)>=1){
				Instantiate(crate,new Vector3(i,1,k),Quaternion.identity);	
					}	
				}
			break;
		case 1:
			Instantiate(wall,new Vector3(i,1,k),Quaternion.identity);
			break;
		case 2:
			Instantiate(crate,new Vector3(i,1,k),Quaternion.identity);
			break;
		default:
			break;
			
			
			
			}
		switch (spawnnumber){
			case 0:
				Instantiate(player1,new Vector3(1,1,1),Quaternion.identity);
				Instantiate(player2,new Vector3(maxh-2,1,maxw-2),Quaternion.identity);
				break;
			case 1:
				Instantiate(player1,new Vector3(maxh-2,1,1),Quaternion.identity);
				Instantiate(player2,new Vector3(1,1,maxw-2),Quaternion.identity);
				break;
			case 2:
				Instantiate(player1,new Vector3(1,1,maxw-2),Quaternion.identity);
				Instantiate(player2,new Vector3(maxh-2,1,1),Quaternion.identity);
				break;
			case 3:
				Instantiate(player2,new Vector3(1,1,1),Quaternion.identity);
				Instantiate(player1,new Vector3(maxh-2,1,maxw-2),Quaternion.identity);
				break;
			default:
				break;				
			}
				
				
			
		}
		
		
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
