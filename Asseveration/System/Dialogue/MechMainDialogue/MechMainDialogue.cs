using Asseveration.System.Dialogue;
using Godot;

public class MechMainDialogue : MainDialogue
{
    public override void _Ready()
    {
        NameDisplay = GetNode<Label>("TextureRect/NameDisplay");
        SetNameDisplayText("NULL");
    }
}
