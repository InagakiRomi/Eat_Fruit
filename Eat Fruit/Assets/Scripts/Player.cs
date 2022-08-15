using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float MoveSpeed=10;
    public float JumpImpulse = 7f;
    public ContactFilter2D ContactFilter;
    private float m_SideSpeed;
    public bool IsGrounded => myRbody.IsTouching(ContactFilter);
    public float AgainstGravityScale = 1f;
    public float FallGravityScale = 2f;
    public GameObject PS1;
    private Rigidbody2D myRbody;
    private GM GM;

    void Start(){
        myRbody = GetComponent<Rigidbody2D>();
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GM>();
    }

    void FixedUpdate()
    {
        if(GM.ClearBool == false){
            Walk();
        }
        else
        {
            myRbody.velocity = new Vector2(0 * MoveSpeed, myRbody.velocity.y);
        }
        Jump();
    }

    private void Walk()
    {
        float H = Input.GetAxis("Horizontal");
        myRbody.velocity = new Vector2(H * MoveSpeed, myRbody.velocity.y);
        if (H > 0)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, -0.5f));
        }
        if (H < 0)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 0.5f));
        }
    }
    private void Jump()
    {
        if (IsGrounded)
        {
            myRbody.AddForce(Vector2.up * JumpImpulse, ForceMode2D.Impulse);
            myRbody.velocity = new Vector2(m_SideSpeed, myRbody.velocity.y);
            m_SideSpeed = 0f;
        }
        var direction = Vector2.Dot(myRbody.velocity, Physics2D.gravity);
        myRbody.gravityScale = direction > 0f ? FallGravityScale : AgainstGravityScale;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "DEADZONE")
        {
            if (GM.ClearBool == false)
            {
                PlayerDead();
            }
        }
    }

    void PlayerDead()
    {
        Instantiate(PS1, transform.position, transform.rotation);
        GM.GO();
    }
}
