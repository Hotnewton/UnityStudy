using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class Tu : MonoBehaviour {

	 
	SerialPort sp = new SerialPort ("/dev/cu.usbmodem14221", 9600); 

	public float speed = 10; 

	private float amountToMove; 



	void Start () 
	{
		sp.Open ();
		sp.ReadTimeout = 1; 

		int[] myArray = new int[]{1,2,3,4,5}; 
		foreach(int n in myArray) 
			Debug.Log(n); 

	}

	int tmp ;  

	void Update () 
	{
		 
		amountToMove = speed * Time.deltaTime;

		if (sp.IsOpen) {
			try 
			{
				moveObject(sp.ReadByte());
				print(sp.ReadByte()); 
			} catch (System.Exception) {
			
			}


		}

	} 



	void moveObject (int Direction)
	{
		if (Direction == 1) 
		{
			transform.Translate (Vector3.right * amountToMove, Space.World); 
		}

		if (Direction == 2) 
		{
			transform.Translate (Vector3.left * amountToMove, Space.World); 
		}

	}

}
