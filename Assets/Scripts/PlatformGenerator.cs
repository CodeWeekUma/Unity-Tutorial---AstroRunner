using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] Platforms;
    public Transform GenerationPoint;
    
    public float MinDistance;
    public float MaxDistance;
    public float PosY;
    private float _platformY;

    private float _platformWidth;
    private int _randomPlatform;
    
    private void Awake ()
	{
        //this position will be used as reference to calculate the platform Y position
        _platformY = transform.position.y;

	    //getting the width of the first platform in scene (make sure it's the same as Platforms[0])
	    _platformWidth = Platforms[0].GetComponent<BoxCollider2D>().size.x * 0.5f;
    }

    private void Update ()
    {
        if (transform.position.x < GenerationPoint.position.x)
        {
            //set random platform
            _randomPlatform = Random.Range(0, Platforms.Length);

            //calculates both platform half width
            _platformWidth = _platformWidth + (Platforms[_randomPlatform].GetComponent<BoxCollider2D>().size.x * 0.5f);

            //set random values for the distance and Y position
            var randomX = Random.Range(MinDistance, MaxDistance);
            var randomY = Random.Range(- PosY, PosY);

            //set this object to a new position
            transform.position = new Vector3(transform.position.x + _platformWidth + randomX, _platformY + randomY, transform.position.z);
            
            //instantiates a new platforms at the same position as this object
            var newPlatform = Instantiate(Platforms[_randomPlatform], transform.position, transform.rotation);

            //set the _platformWidth with the half width of the current platform 
            _platformWidth = Platforms[_randomPlatform].GetComponent<BoxCollider2D>().size.x * 0.5f;

            //set the platform as a child of the Platforms object just to keep things organized in scene
            newPlatform.transform.SetParent(GameObject.Find("Platforms").transform);
        }
	}
}
