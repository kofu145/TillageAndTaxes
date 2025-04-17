using System.Numerics;
using GramEngine.Core;
using GramEngine.ECS;
using GramEngine.ECS.Components;
using TillageAndTaxes.Components;

namespace TillageAndTaxes.Scenes;

public class MainTest : GameState
{
    public override void Initialize()
    {
        base.Initialize();
        
        Entity player = new Entity();
        player.Transform.Scale = new Vector2(5, 5);
        player.AddComponent(new Sprite("./Content/Sprites/pcrogue/pcrogue.png"));
        player.Transform.Position = new Vector3(0, 0, 100);
        
        var anim = player.AddComponent(new Animation());
        anim.LoadTextureAtlas("./Content/Sprites/pcrogue/idle.png", "idle", .1f, (32, 32));
        anim.LoadTextureAtlas("./Content/Sprites/pcrogue/run.png", "run", .1f, (32, 32));
        
        anim.SetState("idle");
        
        player.AddComponent(new MovePlayer(400f, anim));

        
        AddEntity(player);
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
}