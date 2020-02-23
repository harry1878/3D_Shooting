using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1, 0, 0, 0.1f);

    private Animator anim;
    private AudioSource playerAudio;
    private PlayerMovement playerMovement;
    private bool isDeath;
    private bool isDamage;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = startingHealth;
    }

    private void Update()
    {
        if (isDamage) damageImage.color = flashColor;
        else
        {
            damageImage.color = Color.Lerp(
                damageImage.color,
                Color.clear,
                flashSpeed * Time.deltaTime);
        }
        isDamage = false;
    }

    public void TakeDamage(int amount)
    {
        isDamage = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        playerAudio.Play();

        if (currentHealth <= 0 && !isDeath)
            Death();
    }

    private void Death()
    {
        isDeath = true;
        anim.SetTrigger("Death");
        playerAudio.clip = deathClip;
        playerAudio.Play();
        playerMovement.enabled = false;
    }

}
