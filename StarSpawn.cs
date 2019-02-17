using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawn : MonoBehaviour
{
	public GameObject star;
	
	public float spawn_time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawn_time > 5.0f){
				Vector3 position = new Vector3(Random.Range(-6.0f, 6.0f), Random.Range(-3.0f, 3.0f), 0);
				Instantiate(star, position, Quaternion.identity);
				
				spawn_time = 0.0f;
		}
		else{
				spawn_time += Time.deltaTime;
		}
    }
}
