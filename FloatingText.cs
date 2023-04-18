
using Sandbox.UI;

namespace Jake;

[StyleSheet("FloatingText.scss")]
public class FloatingText : Panel
{

    public FloatingTextLabel Create(Vector3 position)
    {
        var panel = AddChild<FloatingTextLabel>();
        panel.WorldPosition = position;
        return panel;
    }

}
