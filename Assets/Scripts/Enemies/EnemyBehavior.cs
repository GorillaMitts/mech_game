using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int moveSpeed;
    Animator enemyAnimator;
    Rigidbody2D enemyRigidBody;
    SpriteRenderer enemySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        enemyAnimator = GetComponent<Animator>();



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyRigidBody.velocity.y == 0)
        {
            enemyAnimator.Play("Idle");
        }
    }
}
