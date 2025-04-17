using System.Numerics;
using GramEngine.Core;
using GramEngine.Core.Input;
using GramEngine.ECS;
using GramEngine.ECS.Components;

namespace TillageAndTaxes.Components;

public class MovePlayer : Component
{
    private float speed;
    private Keys[] moveInputs = {Keys.W, Keys.A, Keys.S, Keys.D};
    public const float PlayerSize = 5f;
    private Animation animation;

    public MovePlayer(float speed, Animation animation)
    {
        this.speed = speed;
        this.animation = animation;
    }
    public override void Initialize()
    {
        base.Initialize();
        
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        Vector3 direction = Vector3.Zero;

        if (InputManager.GetKeyPressed(moveInputs[0])) //if W is pressed, move up
            direction.Y = -speed;
        if (InputManager.GetKeyPressed(moveInputs[2])) //if S is pressed, move down
            direction.Y = speed;
        if (InputManager.GetKeyPressed(moveInputs[1])) //if A is pressed, move left
            direction.X = -speed;
        if (InputManager.GetKeyPressed(moveInputs[3])) //if D is pressed, move right
            direction.X = speed;

        if (direction != Vector3.Zero)
        {
            direction = Vector3.Normalize(direction);
            animation.SetState("run");
        }
        else
        {
            animation.SetState("idle");
        }
        
        if (direction.X < 0)
            ParentEntity.Transform.Scale.X = PlayerSize;
        else if (direction.X > 0)
            ParentEntity.Transform.Scale.X = -PlayerSize;

        Transform.Position += direction * speed * gameTime.DeltaTime;
    }
}