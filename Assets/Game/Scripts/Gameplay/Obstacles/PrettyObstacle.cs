using UnityEngine;

public class PrettyObstacle : Obstacle
{
    [SerializeField]
    private ParticleSystem _triggerParticle;
    
    public override void OnTriggerEnter(Collider other)
    {
        _triggerParticle.Play();
        
        base.OnTriggerEnter(other);
    }
}