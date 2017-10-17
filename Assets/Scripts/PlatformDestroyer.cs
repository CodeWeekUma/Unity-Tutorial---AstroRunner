using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    private Transform _destructionPoint;

    private void Start()
    {
        //find game object by name
        _destructionPoint = GameObject.Find("PlatformDestructionPoint").transform;
    }
	
	private void Update ()
	{
        //destroying platform if it's beyond destruction point
	    if (transform.position.x < _destructionPoint.position.x)
	        Destroy(gameObject);
	}
}
