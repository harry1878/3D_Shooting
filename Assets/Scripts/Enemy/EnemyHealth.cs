using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;

    private Animator anim;
    private AudioSource enemyAudio;
    private ParticleSystem hitParticle;
    private ParticleSystem deathParticle;
    private CapsuleCollider capsuleCollider;
    private bool isDeath;
    private bool isSinking;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticle = transform.GetChild(0).GetComponent<ParticleSystem>();
        deathParticle = transform.GetChild(2).GetComponent<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;
    }

    private void Update()
    {
        if (isSinking)
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDeath) return;

        enemyAudio.Play();
        currentHealth -= amount;

        hitParticle.transform.position = hitPoint;
        hitParticle.Play();

        if (currentHealth <= 0)
            Death();
    }

    private void Death()
    {
        isDeath = true;
        capsuleCollider.isTrigger = true;

        deathParticle.Play();

        anim.SetTrigger("IsDeath");
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }

    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;

        ScoreManager.Get.Score = scoreValue;
        Destroy(gameObject, 2f);
    }

}
