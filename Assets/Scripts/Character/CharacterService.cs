using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterService
{
    private CharacterSO characterSO;
    private CharacterView characterView1;
    public CharacterService(CharacterSO characterSO, CharacterView characterView)
    {
        this.characterSO = characterSO;
        characterView1 = characterView;
        CharacterController characterController1 = new CharacterController(this.characterView1, characterSO);
        characterView1.SetCharacterController(characterController1);
    }

    //public void ConfigureCharacters()
    //{

    //}
}
