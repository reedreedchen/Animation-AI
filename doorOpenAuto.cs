using UnityEngine;
using System.Collections;

public class doorOpenAuto : MonoBehaviour {

    float lastTimeEnter = 0;
    bool hasbeenOpened = false;
    bool hasbeenClosed = false;
    public float doorCloseTime =4;
    float speed = 2f;

    Quaternion initialRot;
    Quaternion targetRot;
    float deltaRot;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "tourCam" && !hasbeenOpened)
        {
            lastTimeEnter = Time.time;
            {
                deltaRot = 0;
                initialRot = transform.rotation;
 
                if (tag.Equals("SelectToOpenRight"))
                {
                    targetRot = transform.rotation * Quaternion.Euler(0, -90, 0);
                }
                else if (tag.Equals("SelectToOpenLeft"))
                {
                    targetRot = transform.rotation * Quaternion.Euler(0, 90, 0);
                }
                playSound.playTheSoundForCamera(playSound.FridgeDoor, playSound.soundVol);
                hasbeenOpened = true;
            }
        }
    }


    void Update()
    {
        if (hasbeenOpened && Time.time - lastTimeEnter >= doorCloseTime && !hasbeenClosed)
        {
            deltaRot = 0;
            initialRot = transform.rotation;
            if (gameObject.tag.Equals("SelectToOpenRight"))
            {
                targetRot = transform.rotation * Quaternion.Euler(0, 90, 0);
            }
            else if (tag.Equals("SelectToOpenLeft"))
            {
                targetRot = this.transform.rotation * Quaternion.Euler(0, -90, 0);
            }
            playSound.playTheSoundForCamera(playSound.FridgeDoor, playSound.soundVol);
            hasbeenClosed = true;
        }
           if(hasbeenOpened)
           {
                deltaRot += Time.deltaTime * speed;
                transform.rotation = Quaternion.Slerp(initialRot, targetRot, Mathf.Min(deltaRot, 1));
           }
     }
    
}



        


