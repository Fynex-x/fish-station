using Content.Shared.Overlays;

namespace Content.Client.NightVision;

public sealed partial class NightVisionSystem
{
    // Согласует старое природное зрение с эффектом надетого ПНВ.
    private bool _fishVisionOverride;

    /// <summary>Suspends legacy device rendering and restores natural vision afterwards.</summary>
    public void SetFishVisionOverride(bool active)
    {
        if (_fishVisionOverride == active)
            return;

        _fishVisionOverride = active;
        if (active)
        {
            Deactivate(_player.LocalSession?.AttachedEntity);
        }
        else if (_player.LocalSession?.AttachedEntity is { } viewer)
        {
            RefreshOverlay(viewer);
        }
    }
}
