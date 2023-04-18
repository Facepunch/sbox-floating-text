
using Sandbox;
using Sandbox.UI;

public class FloatingText : Panel
{

    static FloatingText instance;
    internal static FloatingText Instance
    {
        get
        {
            if (Game.RootPanel == null && instance == null)
            {
                throw new System.Exception("Couldn't create a FloatingText instance, add one to your hud");
            }

            instance ??= Game.RootPanel.AddChild<FloatingText>();

            return instance;
        }
    }

    public FloatingText()
    {
        instance = this;

        StyleSheet.Parse("FloatingText { color:white; position: absolute; width: 100%; height: 100%; top: 0; left: 0; }");
    }

    public FloatingTextLabel Create(Vector3 position) => AddChild<FloatingTextLabel>().WithPosition(position);
    public FloatingTextLabel Create() => AddChild<FloatingTextLabel>();
    public static FloatingTextLabel CreateNew() => Instance.Create();

}
