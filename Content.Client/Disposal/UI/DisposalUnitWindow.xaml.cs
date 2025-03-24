using Content.Shared.Disposal.Components;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Timing;
using static Content.Shared.Disposal.Components.SharedDisposalUnitComponent;

namespace Content.Client.Disposal.UI
{
    /// <summary>
    /// Client-side UI used to control a <see cref="SharedDisposalUnitComponent"/>
    /// </summary>
    [GenerateTypedNameReferences]
    public sealed partial class DisposalUnitWindow : DefaultWindow
    {
        public TimeSpan FullPressure;

        public DisposalUnitWindow()
        {
            IoCManager.InjectDependencies(this);
            RobustXamlLoader.Load(this);
        }

        /// <summary>
        /// Update the interface state for the disposals window.
        /// </summary>
        /// <returns>true if we should stop updating every frame.</returns>
        public void UpdateState(DisposalUnitBoundUserInterfaceState state)
        {
            Title = state.UnitName;
            UnitState.Text = state.UnitState;
            Power.Pressed = state.Powered;
            Engage.Pressed = state.Engaged;
            FullPressure = state.FullPressureTime;
        }

        protected override void FrameUpdate(FrameEventArgs args)
        {
            base.FrameUpdate(args);
            PressureBar.UpdatePressure(FullPressure);
        }
    }
}
