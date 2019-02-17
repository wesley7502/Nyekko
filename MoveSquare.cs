using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSquare : MonoBehaviour
{
	private Rigidbody2D myRigidbody;
	public float speed;
	
	public float current_time = 0.0f;
	public float update_time = 0.0f;
	
	public int health;
	public int score = 0;
	
	public bool can_move = false;
	
	public GameObject shadow;
	public GameObject instance;
	
	public Vector3 recent_pos;
	private Queue<Vector3> old_pos;
	
	public Text health_text;
	public Text score_text;
	
	
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
		
		old_pos = new Queue<Vector3>();
		speed = 6.0f;
		health = 5;
		
		recent_pos = transform.position;
		old_pos.Enqueue(transform.position);
		instance = Instantiate(shadow,transform.position, transform.rotation) as GameObject;
		
		health_text.text = "HP: " + health.ToString();
		
    }

    // Update is called once per frame
    void Update()
    {
		//Debug.Log(Time.deltaTime);
		Move_Square();
		Teleport();
		Check_Current_Time();
		Check_Update_Time();
    }
	
	
	
	
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.name == "star(Clone)")
		{
			Destroy(coll.gameObject);
			score += 1;
			score_text.text = score.ToString();
			
		}
		if (coll.gameObject.name == "spike(Clone)")
		{
			Destroy(coll.gameObject);
			health -= 1;
			if(health == 0){
					Destroy(this.gameObject);
			}
			health_text.text = "HP: " + health.ToString();
		}
	}
	
	
	void Teleport(){
		if (Input.GetKey("space") && can_move){
			transform.position = recent_pos;
			can_move = false;
			old_pos.Clear();
		}
		
	}
	
	//display previous positions
	void Check_Update_Time(){
		if((update_time > 0.05f)){
			old_pos.Enqueue(transform.position);
			update_time = 0.0f;
			if (old_pos.Count > 60){
				recent_pos = old_pos.Dequeue();
				Destroy(instance);
				instance = Instantiate(shadow,recent_pos, transform.rotation) as GameObject;
			}
		}
		else{
			update_time += Time.deltaTime;
		}
		
		
	}
	
	
	void Check_Current_Time(){
		if((current_time) > 3.0){
			can_move = true;
			current_time = 0.0f;
		}
		else{
			current_time += Time.deltaTime;
		}
	}
	
	void Move_Square(){
		if (Input.GetKey(KeyCode.A) && transform.position.x > -7.0f)
         {
             transform.position += Vector3.left * speed * Time.deltaTime;
         }
         if (Input.GetKey(KeyCode.D) && transform.position.x < 7.0f )
         {
             transform.position += Vector3.right * speed * Time.deltaTime;
         }
         if (Input.GetKey(KeyCode.W) && transform.position.y < 5.0f)
         {
             transform.position += Vector3.up * speed * Time.deltaTime;
         }
         if (Input.GetKey(KeyCode.S) && transform.position.y > -5.0f )
         {
             transform.position += Vector3.down * speed * Time.deltaTime;
         }
	}
}
