using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
	public float current_time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((current_time) > 2.5){
			Destroy(this.gameObject);
		}
		else{
			current_time += Time.deltaTime;
		}
    }
}
