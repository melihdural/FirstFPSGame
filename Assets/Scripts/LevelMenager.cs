using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;
using UnityEngine;

public class LevelMenager : MonoBehaviour
{
	//Player Enter Exit
	public bool player_enter, player_exit;
	
	//Drone Spawn
	private bool spawned = false;
	public Transform[] drone_spawners;
	public GameObject drone;

	//Level Spawn
	public GameObject level;
	public GameObject destroy_level;
	

	private void Awake()
	{
		player_enter = false;
		spawned = false;
	}

	private void Update()
	{
		
		
		if (!spawned)
		{
			if (player_enter)
			{
				//Level Spawn	
				SpawnLevel();
				
				//Drone Spawn
				for (int i = 0; i < drone_spawners.Length; i++)
				{
					Instantiate(drone, drone_spawners[i].position, quaternion.identity);
				}
				
				//Set Spawn
				spawned = true;
			}
		}

		if (player_exit)
		{
			if (destroy_level!= null)
			{
				DestroyLevel();

			}
		}
	}

	private void SpawnLevel()
	{
		Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z+100);
		GameObject obj = Instantiate(level, pos, Quaternion.identity);
		obj.GetComponent<LevelMenager>().destroy_level = this.gameObject;
		
	}

	private void DestroyLevel()
	{
		Destroy(destroy_level);
	}
}