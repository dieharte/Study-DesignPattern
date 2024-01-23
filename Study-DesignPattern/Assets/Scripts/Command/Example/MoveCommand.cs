using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveCommand : ICommand
{
    private PlayerMove playerMover;
    private Vector3 movement;
    public MoveCommand(PlayerMove player, Vector3 moveVector)
    {
        this.playerMover = player;
        this.movement = moveVector;
    }
    public void Execute()
    {
        playerMover.Move(movement);
    }
    public void Undo()
    {
        playerMover.Move(-movement);
    }
}