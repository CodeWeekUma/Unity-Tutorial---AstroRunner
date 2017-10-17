using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    private float _offSet;

    private void Start()
    {
        //finding the existing offset
        _offSet = transform.position.x - Player.position.x;
    }
    
	private void Update ()
	{
        //the camera position is set to the player position + the offset
        transform.position = new Vector3(Player.transform.position.x + _offSet, transform.position.y, transform.position.z);
    }
}
