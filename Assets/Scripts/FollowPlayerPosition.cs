using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerPosition : MonoBehaviour
{
    public bool followXAxis, followYAxis;

    [SerializeField] GameObject player;
    [SerializeField] float size;


    private void Start()
    {
        GetComponent<Camera>().orthographicSize = size;
    }


    private void Update()
    {
        transform.position = new Vector3(
            player.transform.position.x * Convert.ToInt16(followXAxis),
            player.transform.position.y * Convert.ToInt16(followYAxis),
            transform.position.z);
    }
}
