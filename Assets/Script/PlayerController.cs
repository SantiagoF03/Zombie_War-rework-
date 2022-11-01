using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private List<Gun> _gunPrefabs;
    [SerializeField] private Gun _gun;
    private int WeaponIndex;
    private bool isGunFire = true;
    public float LifeTime;
    public float PowerTime;
    public float _currentPowerTime;
    public GameObject Barrier;

    private float _currentLifeTime;
    private void Start()
    {
        _currentPowerTime = PowerTime;
        ChangeWeapon(0);
    }
    private void Update()
    {
        _currentPowerTime -= Time.deltaTime;
        if (_currentPowerTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {


                SpecialAttack();
               
                _currentPowerTime = PowerTime;
            }

        }

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

    public void SpecialAttack ()
    {

        Instantiate(Barrier, transform.position, transform.rotation);

    }
    IEnumerator WeaponFireRate()
    {
        _gun?.Attack();
        isGunFire = false;
        yield return new WaitForSeconds(_gun._fireRate);
        isGunFire = true;
    }
}
