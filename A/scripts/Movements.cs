using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    private Vector3 Point;
    public float moveSpeed = 5f;
    public GameObject PointP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Point = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0f);

            GameObject Point2 = Instantiate(PointP,Point,Quaternion.identity);

            Destroy(Point2, 2f);

            transform.up = Point - transform.position;


        }
        transform.position = Vector3.MoveTowards(transform.position, Point, moveSpeed * Time.deltaTime);
    }
}
