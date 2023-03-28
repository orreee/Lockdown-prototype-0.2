using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] int moveSpeed;
    [SerializeField] Vector3 velocity;
    public Vector3 Velocity { get { return velocity; } set { } }

    //[SerializeField] GameObject upCheck;
    //[SerializeField] GameObject downCheck;
    //[SerializeField] GameObject leftCheck;
    //[SerializeField] GameObject rightCheck;

    //[SerializeField] bool colidedUp;
    //[SerializeField] bool colidedDown;
    //[SerializeField] bool colidedLeft;
    //[SerializeField] bool colidedRight;
    //[SerializeField] LayerMask groundMask;
    [SerializeField] CharacterController cc;
    bool[] boolArray;
    GameObject[] gameObjectArray;
    //List<bool> collisionBools = new List<bool>();

    // Update is called once per frame

    private void Start()
    {
        //boolArray = new bool[4]{ colidedUp , colidedDown, colidedLeft, colidedRight };
        //gameObjectArray = new GameObject[4] {upCheck, downCheck, leftCheck, rightCheck};
        // assign the vector value to Script B's public variable
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        //for(int i = 0; i < 4; i++)
        //{
        //    boolArray[i] = Physics.CheckBox(
        //    gameObjectArray[i].transform.position,
        //    gameObjectArray[i].GetComponent<Collider>().bounds.size,
        //    Quaternion.identity,
        //    groundMask
        //    );
        //}

        // update the reference to Script B if the child object changes

        //colidedUp = Physics.CheckBox(
        //    upCheck.transform.position,
        //    upCheck.GetComponent<Collider>().bounds.size,
        //    Quaternion.identity,
        //    groundMask
        //    );
        //colidedDown = Physics.CheckBox(
        //    downCheck.transform.position,
        //    downCheck.GetComponent<Collider>().bounds.size,
        //    Quaternion.identity,
        //    groundMask
        //    );
        //colidedLeft = Physics.CheckBox(
        //    leftCheck.transform.position,
        //    leftCheck.GetComponent<Collider>().bounds.size,
        //    Quaternion.identity,
        //    groundMask
        //    );
        //colidedRight = Physics.CheckBox(
        //    rightCheck.transform.position,
        //    rightCheck.GetComponent<Collider>().bounds.size,
        //    Quaternion.identity,
        //    groundMask
        //    );

        velocity = new Vector3(Input.GetAxis("Horizontal"), -0.1f, Input.GetAxis("Vertical"));

        if (velocity.magnitude > 0.1f)
        {
            transform.LookAt(transform.position + new Vector3(velocity.x, 0, velocity.z));
        }

        //if (velocity.z>0 && colidedUp)
        //{
        //    velocity.z = 0;
        //}
        //if (velocity.z < 0 && colidedDown)
        //{
        //    velocity.z = 0;
        //}
        //if (velocity.x > 0 && colidedLeft)
        //{
        //    velocity.x = 0;
        //}
        //if (velocity.x < 0 && colidedRight)
        //{
        //    velocity.x = 0;
        //}

        //transform.position += velocity * moveSpeed * Time.deltaTime;
        cc.Move(velocity * moveSpeed * Time.deltaTime);
    }
}