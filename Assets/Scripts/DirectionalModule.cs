using System.Collections;
using UnityEngine;

public class DirectionalModule : MonoBehaviour
{
    private Color morningColor;
    public Color nightColor;
    public float changeTime = 1f;
    public float crossTime = 5f;

    public Light backgroundLight;

    
    private float timer = 0f;
    private bool isMorning = false;

    private void Awake()
    {
        morningColor = backgroundLight.color;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= crossTime)
        {
            isMorning = !isMorning;
            if(isMorning)
            {
                StartCoroutine(UpdateMorning());
            }
            else
            {
                StartCoroutine(UpdateNight());
            }

            timer = 0;
        }
    }
    private IEnumerator UpdateMorning()
    {
        float currTime = Time.time;
        while (Time.time - currTime <= changeTime)
        {
            backgroundLight.color =
                Color.Lerp( morningColor, nightColor,
                (Time.time - currTime) / changeTime);
            yield return null;
        }

        backgroundLight.color = nightColor;
        yield break;
    }

    private IEnumerator UpdateNight()
    {
        float currTime = Time.time;
        while (Time.time - currTime <= changeTime)
        {
            backgroundLight.color =
                Color.Lerp(nightColor, morningColor,
                (Time.time - currTime) / changeTime);
            yield return null;
        }

        backgroundLight.color = morningColor;
        yield break;
    }
}

