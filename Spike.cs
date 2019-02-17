using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
	public int movement;
	public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 6.0f;
		Debug.Log("YEET");
    }

    // Update is called once per frame
    void Update()
    {
        if(movement == 1){
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		else if(movement == 2){
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
		else if(movement == 3){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		else{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if(transform.position.x < -10.0f || transform.position.x > 10.0f 
			|| transform.position.y > 8.0f || transform.position.y < -8.0f){
				Destroy(this.gameObject);	
		}
		
    }
}
