using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
   
    private PlayerController _character;

    // BINDING KEYS - WEAPONS
    [SerializeField] private KeyCode _weapon1 = KeyCode.Alpha1;
    [SerializeField] private KeyCode _weapon2 = KeyCode.Alpha2;
    //[SerializeField] private KeyCode _weapon3 = KeyCode.Alpha3;

    // BINDING KEYS - ACTIONS
    [SerializeField] private KeyCode _attack = KeyCode.Mouse0;
    [SerializeField] private KeyCode _reload = KeyCode.R;


    private void Start()
    {
        _character = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_weapon1)) _character.ChangeWeapon(0);
        if (Input.GetKeyDown(_weapon2)) _character.ChangeWeapon(1);
        //if (Input.GetKeyDown(_weapon3)) _character.ChangeWeapon(2);
        if (_character.isAoutamttickGun ())
        {
            if (Input.GetKey(_attack)) _character.Attack();

        }
        else
        {
            if (Input.GetKeyDown(_attack)) _character.Attack();
        }
  
        if (Input.GetKeyDown(_reload)) _character.Reload();
    }

    

}
