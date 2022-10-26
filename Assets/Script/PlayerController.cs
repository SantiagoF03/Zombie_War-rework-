using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private List<Gun> _gunPrefabs;
    [SerializeField] private Gun _gun;
    private int WeaponIndex;
    private bool isGunFire = true;

    private void Start()
    {
        ChangeWeapon(0);
    }

    public void Attack()
    {
        if (isGunFire)
        {
            StartCoroutine(WeaponFireRate());

        }
        
    
    }
    public void Reload() => _gun?.Reload();
    public bool isAoutamttickGun()
    {
        return _gun.AuttomatickGun;


    }
    public void ChangeWeapon(int index)
    {
        WeaponIndex = index;
        Destroy(_gun?.gameObject);
        _gun = Instantiate(_gunPrefabs[index], transform);
        _gun.Reload();
    }
    IEnumerator WeaponFireRate()
    {
        _gun?.Attack();
        isGunFire = false;
        yield return new WaitForSeconds(_gun._fireRate);
        isGunFire = true;
    }
}
