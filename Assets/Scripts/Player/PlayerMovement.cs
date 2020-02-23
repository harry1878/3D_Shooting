using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    private Vector3 movement;
    private Animator anim;
    private Rigidbody rigid;
    private int floorMask;
    private float camRayLength = 100f;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }

    private void Move(float h, float v)
    {
        //  movement = new Vector3(h, 0f, v);
        movement.Set(h, 0f, v);

        movement = movement.normalized * speed * Time.deltaTime;
        rigid.MovePosition(transform.position + movement);
    }

    private void Turning()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion q = Quaternion.LookRotation(playerToMouse);
            rigid.MoveRotation(q);
        }
    }

    private void Animating(float h, float v)
    {
        bool isWalking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", isWalking);
    }

}
