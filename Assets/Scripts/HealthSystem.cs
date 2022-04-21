using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHp = 3;
    [SerializeField] private int hp = 3;

    [SerializeField] private UnityEvent OnDamaged;
    [SerializeField] private UnityEvent OnZero;
    [SerializeField] private UnityEvent XDeathState; //Gibs
    public AudioSource dieSound;
    
    
    public void Damage(int hpAmount)
    {
        hp -= hpAmount;
        Debug.Log("hp amount changed by " + hpAmount + " and is now " + hp);
        
        OnDamaged?.Invoke();

        if (hp <= -maxHp) //gibs?
        {
            XDeathState?.Invoke();
        }
        else if (hp <= 0)
        {
            OnZero?.Invoke();
            dieSound.Play();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
