namespace Zebble
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class CheckBox : Stack, FormField.IControl
    {
        bool @checked, IsToggling;
        public readonly AsyncEvent CheckedChanged = new AsyncEvent(ConcurrentEventRaisePolicy.Queue);
        public readonly ImageView CheckedImage = new ImageView().Id("CheckedImage").Hide();
        public Alignment Alignment { get; set; } = Alignment.Right;

        public CheckBox()
        {
            CheckedChanged.Handle(UpdateCheckedState);
        }

        public override async Task OnInitializing()
        {
            await base.OnInitializing();

            Tapped.Handle(ToggleChanged);
            Swiped.Handle(ToggleChanged);
            PanFinished.Handle(ToggleChanged);

            await Add(CheckedImage);
        }

        public override async Task OnPreRender()
        {
            if (IsDisposing) return;
            await base.OnPreRender();

            if (Alignment == Alignment.Right)
            {
                var left = parent.ActualWidth - ActualWidth - Margin.Left() - parent.Padding.Left();

                if ((parent as Stack)?.Direction == RepeatDirection.Horizontal)
                    left -= CurrentSiblings.Except(x => x.Absolute).Sum(c => c.CalculateTotalWidth());

                Css.Margin.Left = left.LimitMin(0);
            }
        }

        object FormField.IControl.Value { get => Checked; set => Checked = (bool)value; }

        public bool Checked
        {
            get => @checked;
            set
            {
                if (@checked == value) return;
                @checked = value;
                CheckedChanged.Raise();
            }
        }

        public async Task ToggleChanged()
        {
            if (IsToggling) return;
            else IsToggling = true;
            try
            {
                @checked = !@checked;
                await CheckedChanged.Raise();
            }
            finally
            {
                IsToggling = false;
            }
        }

        Task UpdateCheckedState()
        {
            CheckedImage.Visible(Checked);
            return SetPseudoCssState("checked", Checked);
        }

        public override void Dispose()
        {
            CheckedChanged?.Dispose();
            base.Dispose();
        }
    }
}