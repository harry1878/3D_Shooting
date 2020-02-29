using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    private Animator anim;
    private GameObject player;
    private PlayerHealth playerHealth;

    private bool isPlayerInRange;
    private float timer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
    }

    // 내 트리거 콜라이더 안에 어떤 물체가 들어왔을 때
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            isPlayerInRange = true;
    }

    //이미 들어 왔고 나갈 때
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            isPlayerInRange = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks && isPlayerInRange)
            Attack();

        if (playerHealth.currentHealth <= 0)
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            anim.SetTrigger("IsPlayerDeath");
        }
    }

    private void Attack()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
            playerHealth.TakeDamage(attackDamage);
    }
}
