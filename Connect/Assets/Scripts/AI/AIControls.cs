
public class AIControls
{
    public bool up;
    public bool down;
    public bool left;
    public bool right;

    public bool run;

    public bool basic_attack;

    public void ResetKeyInputs()
    {
        up = false;
        down = false;
        left = false;
        right = false;

        run = false;

        basic_attack = false;
    }
}
