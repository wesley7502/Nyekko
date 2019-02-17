using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawn : MonoBehaviour
{
	public GameObject spawn;
	public float spawn_time = 0.0f;
	Vector3 position;
	int movement;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawn_time > 0.50f){
			//horizontal
			if(Random.value < 0.5f){
				if(Random.value < 0.5f){
					position = new Vector3(Random.Range(-6.0f, 6.0f), -5f, 0);
					movement = 1;
				}
				else{
					position = new Vector3(Random.Range(-6.0f, 6.0f), 5f, 0);
					movement = 2;
				}
			}
			
			//vertical
			else{
				if(Random.value < 0.5f){
					position = new Vector3(-8.0f,Random.Range(-3.0f, 3.0f), 0);
					movement = 3;
				}
				else{
					position = new Vector3(8.0f,Random.Range(-3.0f, 3.0f), 0);
					movement = 4;
				}
			}
			
			GameObject instance = Instantiate(spawn, position, Quaternion.identity);
			instance.GetComponent<Spike>().movement = movement;
			spawn_time = 0.0f;
		}
		else{
				spawn_time += Time.deltaTime;
		}
    }
}
