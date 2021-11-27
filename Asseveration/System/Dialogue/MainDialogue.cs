using Godot;

namespace Asseveration.System.Dialogue
{
    public class MainDialogue : TextureRect
    {
        public Label NameDisplay;

        public void SetNameDisplayText(string name)
        {
            NameDisplay.Text = $"NAME > {name}";
        }
    }
}
