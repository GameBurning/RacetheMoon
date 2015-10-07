using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyPlaneControl : MonoBehaviour
{
    Rigidbody rig;
    Vector3 velocity;
    public GameObject[] basicQuads;
    
    float speed = 50;
    float tilt = 5f;
    public Vector3 boundary;
     public Text gameoverText;
    int mostRotation = 0;
    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        velocity = new Vector3(0, 0, speed);
        //rig.velocity = velocity;
        gameoverText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    float changeVelocity;
    float changeVelocityZ;
    float changeVelocityRotation;
    float changeVelocity3;
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (h > 0.5f || h < -0.5f)
        {
            if (h * rig.velocity.x >= 0)
                rig.AddForce(Vector3.right * h * 25);
            else
                rig.AddForce(Vector3.right * h * 50);
            rig.velocity = new Vector3
                (
                    //Mathf.Clamp(rig.velocity.x, -boundary.z / tilt, boundary.z / tilt),
                    rig.velocity.x,
                    rig.velocity.y,
                    Mathf.SmoothDamp(rig.velocity.z, speed, ref changeVelocityZ, 1.3f)
                );

            if (mostRotation == 1 && h < -0.5f)
            {
                rig.AddTorque(Vector3.forward * 20);
            }
            else if(mostRotation == -1 && h > 0.5f)
            {
                rig.AddTorque(Vector3.forward * -20);
            }
            else
            {
                Debug.Log(rig.rotation.eulerAngles.z);
                mostRotation = 0;
                if (rig.rotation.eulerAngles.z > boundary.z / 1.1f && rig.rotation.eulerAngles.z < 90)
                {
                    mostRotation = -1;
                    Debug.Log("most = -1");
                }
                else if (rig.rotation.eulerAngles.z > (360 - boundary.z / 1.1f) && (rig.rotation.eulerAngles.z < 360))
                {
                    mostRotation = 1;
                    Debug.Log("most = 1");
                }
                rig.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(rig.velocity.x * -tilt, -boundary.z, boundary.z));
            }
            

        }

        else
        {
            //if (Mathf.Abs(rig.velocity.x * tilt) < boundary.z / 1.1f)
            //{
                mostRotation = 0;
                Debug.Log("most = 0");
            //}
            rig.velocity = new Vector3
                (
                Mathf.SmoothDamp(rig.velocity.x, 0, ref changeVelocity, 0.3f),
                rig.velocity.y,
                Mathf.SmoothDamp(rig.velocity.z, speed, ref changeVelocityZ, 1.3f)
                );
            //rig.rotation = Quaternion.Euler
            //    (
            //    0,
            //    0,
            //    Mathf.SmoothDamp(rig.rotation.x, 0, ref changeVelocityRotation, 3f)
            //    );
            rig.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(rig.velocity.x * -tilt, -boundary.z, boundary.z));
            //rig.rotation = Quaternion.Euler(0, 0, rig.velocity.x * -tilt);
            //if (rig.rotation.eulerAngles.z > 180)
            //{
            //    rig.rotation = Quaternion.Euler(0, 0, Mathf.SmoothDamp(rig.rotation.eulerAngles.z, 360, ref changeVelocity3, 0.8f));
            //}
            //else
            //{
            //    rig.rotation = Quaternion.Euler(0, 0, Mathf.SmoothDamp(rig.rotation.eulerAngles.z, 0, ref changeVelocity3, 0.8f));
            //}
        }

        //Debug.Log("rig volocity" + rig.velocity);
        

        
        rig.position = new Vector3
            (
                Mathf.Clamp(rig.position.x, -boundary.x, boundary.x),
                Mathf.Clamp(rig.position.y, boundary.y, 500),
                rig.position.z
            );
    }

    public void GenerateQuad()
    {

    }

    public void GameOver()
    {
        gameoverText.text = "GameOver";
    }

    //void OnTriggerExit(Collider coll)
    //{
    //    Instantiate(basicQuads[Random.Range(0, basicQuads.Length -1)], coll.transform.parent.position + new Vector3(-500, 0, 0), Quaternion.Euler(90,0,0));
    //    Instantiate(basicQuads[Random.Range(0, basicQuads.Length -1)], coll.transform.parent.position + new Vector3(500, 0, 0), Quaternion.Euler(90,0,0));
    //    Instantiate(basicQuads[Random.Range(0, basicQuads.Length -1)], coll.transform.parent.position + new Vector3(0, 0, 500), Quaternion.Euler(90,0,0));
    //}


}
