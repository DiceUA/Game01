using UnityEngine;
using System.Collections;

public class DestroyCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // Destroy clones when they left screen
        if (transform.position.y < -8)
        {
            Destroy(gameObject);
            if (GameObject.Find("Sphere") && !DangerousCube.GameWon())
            {
                DangerousCube.Score();
            }
        }
            
	}
}
