using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SFX
{
    SHRINKSFX,
    GROWSFX
}
public class ShrinkingPlatform : MonoBehaviour
{
    
    public AudioSource[] sfx;
    public bool isActive;
    public bool floating;
    public float maxHeight, minHeight;
    public float shrinkSpeed;
    public float platformSpeed;
    public float yPos;
    
    private void Start()
    {
        sfx = GetComponents<AudioSource>();
        isActive = false;
        
    }
    void Update()
    {
        _Move();
       platformActivated();
    }

    private void platformActivated()
    {
        sfx[(int)SFX.SHRINKSFX].Play();
        if (isActive)
        {
            if (gameObject.transform.localScale.x < 0.0f)
            {
                gameObject.transform.localScale = new Vector2(0.0f, transform.localScale.y);
            }else
            {
                gameObject.transform.localScale = new Vector2(transform.localScale.x - 5 * Time.deltaTime, transform.localScale.y);
            }
        }else
        {
           if (gameObject.transform.localScale.x != 9.0f)
            {
                sfx[(int)SFX.GROWSFX].Play();
                StartCoroutine("ResetPlatform");
            }
        }
    }

    private IEnumerator ResetPlatform()
    {
        yield return new WaitForSeconds(2.0f);
        gameObject.transform.localScale = new Vector2(15, 5);
    }

    private void _Move()
    {
        _Movement();
        if (floating)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + platformSpeed * Time.deltaTime);
        }
        else if (floating)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - platformSpeed * Time.deltaTime);
        }
    }

    private void _Movement()
    {
        if ((isActive))
        {
            sfx[(int)SFX.SHRINKSFX].Play();
            if (transform.position.y > maxHeight)
            {
                floating = false;
            }
            else if (transform.position.y < minHeight)
            {
                floating = true;
            }
        }
       

    }
}
    

    

