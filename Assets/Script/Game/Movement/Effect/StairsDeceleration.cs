
public class StairsDeceleration : MovementEffect
{
    private float m_deceleartion;

    public StairsDeceleration(float deceleration)
    {
        m_deceleartion = deceleration;
    }

    public override float GetDeceleration() {
        return m_deceleartion;
    }
}
