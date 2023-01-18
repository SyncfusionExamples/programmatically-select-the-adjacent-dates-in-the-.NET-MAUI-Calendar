using Syncfusion.Maui.Calendar;

namespace AdjacentDatesSelection
{
    public class CalendarBehavior : Behavior<ContentPage>
    {
        private SfCalendar sfCalendar;
        private Button backwardButton, forwardButton;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.sfCalendar = bindable.FindByName<SfCalendar>("calendar");
            if (this.sfCalendar.SelectedDate == null)
            {
                this.sfCalendar.SelectedDate = this.sfCalendar.DisplayDate;
            }

            this.sfCalendar.SelectionChanged += SfCalendar_SelectionChanged;
            this.backwardButton = bindable.FindByName<Button>("BackwardSelectButton");
            this.backwardButton.Clicked += BackwardButton_Clicked;
            this.forwardButton = bindable.FindByName<Button>("ForwardSelectButton");
            this.forwardButton.Clicked += ForwardButton_Clicked;
        }

        private void SfCalendar_SelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
        {
            DateTime selectedDate = DateTime.Parse(e.NewValue.ToString());
            if (selectedDate.Month != this.sfCalendar.DisplayDate.Month)
            {
                sfCalendar.DisplayDate = selectedDate;
            }
        }

        private void BackwardButton_Clicked(object sender, EventArgs e)
        {
            if (this.sfCalendar.SelectedDate != null)
            {
                this.sfCalendar.SelectedDate = this.sfCalendar.SelectedDate.Value.AddDays(-1);
            }
        }

        private void ForwardButton_Clicked(object sender, EventArgs e)
        {
            if (this.sfCalendar.SelectedDate != null)
            {
                this.sfCalendar.SelectedDate = this.sfCalendar.SelectedDate.Value.AddDays(1);
            }
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.sfCalendar != null)
            {
                this.sfCalendar.SelectionChanged -= SfCalendar_SelectionChanged;
            }

            if (this.backwardButton != null)
            {
                this.backwardButton.Clicked -= BackwardButton_Clicked;
            }

            if (this.forwardButton != null)
            {
                this.forwardButton.Clicked -= ForwardButton_Clicked;
            }

            this.sfCalendar = null;
            this.backwardButton = null;
            this.forwardButton = null;
        }
    }
}
