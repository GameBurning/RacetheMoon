using UnityEngine;
using System.Collections;

public class BodyCollider : MonoBehaviour {

    MyPlaneControl planeControl;
    public GameObject[] basicQuads;
	// Use this for initialization
	void Start () {
        planeControl = GameObject.Find("Plane").GetComponent<MyPlaneControl>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision coll)
    {
        Debug.Log("I am here");
        planeControl.GameOver();
    }


    void OnTriggerEnter(Collider coll)
    {
        Instantiate(basicQuads[Random.Range(0, basicQuads.Length)], coll.transform.parent.position + new Vector3(-500, 0, 0), Quaternion.Euler(90,0,0));
        Instantiate(basicQuads[Random.Range(0, basicQuads.Length)], coll.transform.parent.position + new Vector3(500, 0, 0), Quaternion.Euler(90,0,0));
        Instantiate(basicQuads[Random.Range(0, basicQuads.Length)], coll.transform.parent.position + new Vector3(0, 0, 500), Quaternion.Euler(90,0,0));
    }
}
