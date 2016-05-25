using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public float speed = 0.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // Move in boundaries
        // boundaries -6 and 6
        // DangerousCube.cs Spawn function
        if(transform.position.x < 6 && transform.position.x > -6)
            transform.position += new Vector3(Input.GetAxis("Horizontal")*speed,0,0);
        if (transform.position.x >= 6)
            transform.position = new Vector3(5.9f, transform.position.y, 0);
        if (transform.position.x <= -6)
            transform.position = new Vector3(-5.9f, transform.position.y, 0);
    }

    // Destroy player if he collide with cube
    // if round not won
    void OnCollisionEnter()
    {
        if (!DangerousCube.GameWon())
            Destroy(gameObject);
    }

}
