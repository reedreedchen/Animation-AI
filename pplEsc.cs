using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class pplEsc : MonoBehaviour {
	public GameObject way1;
	public GameObject way2;
	public GameObject way3;
	public GameObject way4;
	public State state;
    bool activeThis = false;
	public float time;
	public float rotationSpeed;
	public float moveSpeed;
	public int randomNumber;
	public enum State{
		Idle,
		Way1,
		Way2,
		Way3,
		Way4

	}

	void Update()
    {
        if (SceneManager.GetActiveScene().name == "environmental" && GameManager.MainCamera.GetComponent<CameraController>().currentRoom.Equals("Kitchen")) activeThis = true;
        else if (SceneManager.GetActiveScene().name == "accessment" && GameManager.MainCamera.GetComponent<CameraController>().currentRoom.Equals("Living Room")) activeThis = true;
        else activeThis = false;
        if (activeThis)
        {
            {
                if (randomNumber == 1)
                {
                    if (state == State.Way1)
                    {
                        state = State.Way2;
                    }
                    else
                    {
                        state = State.Way4;
                    }
                }
                if (randomNumber == 2)
                {
                    if (state == State.Way2)
                    {
                        state = State.Way3;
                    }
                    else
                    {
                        state = State.Way1;
                    }
                }
                if (randomNumber == 3)
                {
                    if (state == State.Way3)
                    {
                        state = State.Way4;
                    }
                    else
                    {
                        state = State.Way2;
                    }
                }
                if (randomNumber == 4)
                {
                    if (state == State.Way4)
                    {
                        state = State.Way1;
                    }
                    else
                    {
                        state = State.Way3;
                    }
                }
                switch (state)
                {
                    case State.Idle:
                        Idle();
                        break;
                    case State.Way1:
                        Way1();
                        break;
                    case State.Way2:
                        Way2();
                        break;
                    case State.Way3:
                        Way3();
                        break;
                    case State.Way4:
                        Way4();
                        break;
                }
            }
        }
	}

	public void Idle()
	{
		randomNumber = Random.Range (1, 5);

	}

	public void Way1(){
		float distance = Vector3.Distance (way1.transform.position, transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(way1.transform.position-transform.position),1f);
		Debug.DrawLine (way1.transform.position, transform.position, Color.green);
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
		if (distance < 0.1f)
			randomNumber = Random.Range (1, 5);
	}
	public void Way2(){
		float distance = Vector3.Distance (way2.transform.position, transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(way2.transform.position-transform.position),1f);
		Debug.DrawLine (way2.transform.position, transform.position, Color.green);
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
		if (distance < 0.1f)
			randomNumber = Random.Range (1, 5);
	}
	public void Way3(){
		float distance = Vector3.Distance (way3.transform.position, transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(way3.transform.position-transform.position),1f);
		Debug.DrawLine (way3.transform.position, transform.position, Color.green);
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
		if (distance < 0.1f)
			randomNumber = Random.Range (1, 5);
	}
	public void Way4(){
		float distance = Vector3.Distance(way4.transform.position, transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(way4.transform.position-transform.position),1f);
		Debug.DrawLine (way4.transform.position, transform.position, Color.green);
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
		if (distance < 0.1f)
			randomNumber = Random.Range (1, 5);
	}				
}

