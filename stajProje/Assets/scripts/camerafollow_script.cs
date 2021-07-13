using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow_script : MonoBehaviour
{
    [SerializeField]  //unity çalýþýrken bu deðerler üzerinde oynama yapmamýzý saðlar, bi daha geri dönemeize gerek kalmaz
    GameObject hero;
    [SerializeField]
    float timeoffset;
    [SerializeField]
    Vector2 posOffset;
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float topLimit;

    private Vector3 velocity;


    void Start()
    {

    }

    void Update()
    {
        //cameras current position
        Vector3 startPos = transform.position;

        //players current position
        Vector3 endPos = hero.transform.position;

        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z += -10;

        //smoothly move the camera towards the players position
        transform.position = Vector3.Lerp(startPos, endPos, timeoffset * Time.deltaTime);

        transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
                transform.position.z
            );

    }

    void OnDrawGizmos()
    {
        //draw a box around our camera boundry
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));
    }

    private void FixedUpdate()
    {

    }
}
