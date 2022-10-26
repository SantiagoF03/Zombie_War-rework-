using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public int maxLife { get; }
    public void TakeDamage(int Damage);

    public void Health(int Cure);

    public void Death();
    
}
