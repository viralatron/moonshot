using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MonsterScript : CharacterScript
{
    private GameMode game;

    private void Start()
    {
        game = GameObject.Find("GameMode").GetComponent<GameMode>();
    }

    private void FixedUpdate()
    {
        Vector3 target = GameObject.Find("Player").transform.position;

        LookAtPosition(target);
    }
    private void OnDestroy()
    {
        game.AddScore(100);
    }

    public override void LookAtPosition(Vector3 position)
    {
        transform.LookAt(position);
    }
}
