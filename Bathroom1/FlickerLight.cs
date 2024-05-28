using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public bool isFLickering = false;
    public Light lamplight;
    [SerializeField]
    private ParticleSystem particle;
    public float Timedelay;

    // Start is called before the first frame update
    void Start()
    {
        lamplight = GetComponent<Light>();
        StartCoroutine(flickering());
    }

    public IEnumerator flickering()
    {
        do
        {
            Timedelay = Random.Range(0.05f, 0.3f);
            yield return new WaitForSeconds(Timedelay);
            lamplight.enabled = false;
            Timedelay = Random.Range(0.1f, 1f);
            yield return new WaitForSeconds(Timedelay);
            Sparkle();
            lamplight.enabled = true;


        } while (true);
        

    }

    public void Sparkle()
    {
        if (particle != null)
        {
            particle.Play();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
