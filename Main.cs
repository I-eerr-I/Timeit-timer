using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Toolkit.Uwp.Notifications;
using Windows.Security.Authentication.OnlineId;

namespace Timeit
{
    public partial class Main : Form
    {
        #region Constants

        const String FORMAT_TIME = "{0:d2}";
        const String FORMAT_STOPWATCH = "{0:d2}:{1:d2}:{2:d2}";
        const String TOOLTIP_OPACITY_FORMAT_CAPTION = "Current opacity {0}%";
        const String TOOLTIP_TIMEOUTS_FORMAT_CAPTION = "Maximum timeouts: {0}";


        const char CHECKED_RESET_COUNTER = 'x';
        const char EMPTY_RESET_COUNTER = 'o';
        
        const uint MAX_MAX_TIMEOUTS = 18;

        const float FADING_OUT_SPEED = 0.05f;
        const float FADING_IN_SPEED = 0.25f;

        enum FadingState { FADING_OUT, FADING_IN };

        #endregion

        #region Properties

        /// <summary>
        /// Current seconds shown on the timer
        /// </summary>
        private uint __current_seconds = 0;
        protected uint CurrentSeconds
        {
            get { return __current_seconds; }
            set
            {
                __current_seconds = value;
                textBoxSeconds.Text = String.Format(FORMAT_TIME, value);
            }
        }

        /// <summary>
        /// Current minutes shown on the timer
        /// </summary>
        private uint __current_minutes = 0;
        protected uint CurrentMinutes
        {
            get { return __current_minutes; }
            set
            {
                __current_minutes = value;
                textBoxMinutes.Text = String.Format(FORMAT_TIME, value);
            }
        }

        private uint __stopwatch_seconds = 0;
        protected uint StopwatchSeconds
        {
            get { return __stopwatch_seconds; }
            set
            {
                if (__stopwatch_seconds == value) return;
                
                __stopwatch_seconds = value;
                updateStopwatchTextTime();
            }
        }

        private uint __stopwatch_minutes = 0;
        protected uint StopwatchMinutes
        {
            get { return __stopwatch_minutes; }
            set
            {
                if (__stopwatch_minutes == value) return;

                __stopwatch_minutes = value;
                updateStopwatchTextTime();
            }
        }

        private uint __stopwatch_hours = 0;
        protected uint StopwatchHours
        {
            get { return __stopwatch_hours; }
            set
            {
                if (__stopwatch_hours == value) return;

                __stopwatch_hours = value;
                updateStopwatchTextTime();
            }
        }

        private bool __is_stopwatch_on = false;
        protected bool IsStopwatchOn
        {
            get { return __is_stopwatch_on; } 
            set
            {
                if (__is_stopwatch_on == value) return;
                
                bool was_on = __is_stopwatch_on;
                
                __is_stopwatch_on = value;

                if (!was_on)
                {
                    StopwatchSeconds = 0;
                    StopwatchMinutes = 0;
                    StopwatchHours = 0;
                }
            }
        }


        /// <summary>
        /// Whether the timer is counting down
        /// </summary>
        private bool __is_playing = false;
        protected bool IsPlaying
        {
            get { return __is_playing; }
            set
            {
                if (__is_playing == value) return;

                bool is_done = CurrentMinutes == 0 && CurrentSeconds == 0;
                bool was_playing = __is_playing;
                __is_playing = value;
                updatePlayButton();

                if (was_playing)
                {
                    if (CurrentTimeouts == MaxTimeouts)
                        IsStopwatchOn = false;
                }
                else
                {
                    if (!IsStopwatchOn)
                        IsStopwatchOn = true;
                    
                    if (timerTimeoutAnimation.Enabled)
                        stopTimeoutAnimation();
                    
                    if (CurrentTimeouts == MaxTimeouts)
                        CurrentTimeouts = 0;
                    
                    if (is_done)
                    {
                        CurrentMinutes = _set_minutes;
                        CurrentSeconds = _set_seconds;
                    }
                }
            }
        }

        /// <summary>
        /// Is editing on. While editing, you can change start time and timeouts.
        /// </summary>
        private bool __is_editing = false;
        protected bool IsEditing
        {
            get { return __is_editing; }
            set
            {
                if (__is_editing == value) return;
                
                bool was_editing = __is_editing;
                __is_editing = value;
                
                if (was_editing)
                {
                    saveSettings();
                    buttonEdit.BackColor = BackColor;
                }
                else
                {
                    if (IsPlaying) IsPlaying = false;
                    if (IsStopwatchOn)
                    {
                        StopwatchSeconds = StopwatchMinutes = StopwatchHours = 0;
                        IsStopwatchOn = false;
                    }

                    if (timerTimeoutAnimation.Enabled)
                        stopTimeoutAnimation();
                    textBoxMinutes.Focus();
                    ActiveControl = textBoxMinutes;
                    buttonEdit.BackColor = buttonEdit.FlatAppearance.MouseDownBackColor;
                }
                
                CurrentMinutes = _set_minutes;
                CurrentSeconds = _set_seconds;
                updateControlsEnabled();
            }
        }

        /// <summary>
        /// Maximum amount of timeouts before restart
        /// </summary>
        private uint __max_timeouts = 0;
        protected uint MaxTimeouts
        {
            get { return __max_timeouts;  }
            set
            {
                if (__max_timeouts == value) return;

                __max_timeouts = value;
                CurrentTimeouts = Math.Min(CurrentTimeouts, value);
                updateTimeoutsText();

                updateMaxTimeoutsTooltip();

                Properties.Settings.Default.MaxTimeouts = value;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Current amount of checked timeout slots.
        /// </summary>
        private uint __current_timeouts = 0;
        protected uint CurrentTimeouts
        {
            get { return __current_timeouts; }
            set
            {
                if (__current_timeouts == value) return;
                __current_timeouts = Math.Min(value, __max_timeouts);
                updateTimeoutsText();
            }
        }

        #endregion

        #region Private fields

        private bool _is_active = false;

        private bool _is_mouse_over_play = false;

        private FadingState _current_fading_state = FadingState.FADING_OUT;
        private float _min_window_opacity = 0.25f;

        private uint _set_seconds = 0;
        private uint _set_minutes = 0;
        
        private bool _is_dragging_window = false;
        private Point _last_window_dragging_location;

        #endregion

        public Main()
        {
            InitializeComponent();

            CurrentSeconds = _set_seconds = Properties.Settings.Default.Seconds;
            CurrentMinutes = _set_minutes = Properties.Settings.Default.Minutes;

            MaxTimeouts = Properties.Settings.Default.MaxTimeouts;

            _min_window_opacity = Properties.Settings.Default.MinOpacity;

            toolTipOpacity.SetToolTip(trackBarMinOpacity, String.Format(TOOLTIP_OPACITY_FORMAT_CAPTION, trackBarMinOpacity.Value));

            updateMaxTimeoutsTooltip();
            updatePlayButton();
            updateControlsEnabled();

            timer.Start();
        }

        #region Utils

        private void updateMaxTimeoutsTooltip()
        {
            String maximumTimeoutsTooltipCaption = String.Format(TOOLTIP_TIMEOUTS_FORMAT_CAPTION, MaxTimeouts);
            toolTipMaxTimeouts.SetToolTip(labelTimeoutsCounter, maximumTimeoutsTooltipCaption);
            toolTipMaxTimeouts.SetToolTip(buttonTimeoutsLess, maximumTimeoutsTooltipCaption);
            toolTipMaxTimeouts.SetToolTip(buttonTimeoutsMore, maximumTimeoutsTooltipCaption);
        }

        /// <summary>
        /// Updates play button icon. 
        /// From play to pause, from unselected to selected and vice versa.
        /// </summary>
        private void updatePlayButton()
        {
            if (_is_mouse_over_play)
                buttonPlay.BackgroundImage = (IsPlaying) ? Properties.Resources.pause_selected : Properties.Resources.play_selected;
            else
                buttonPlay.BackgroundImage = (IsPlaying) ? Properties.Resources.pause : Properties.Resources.play;
            buttonPlay.Refresh();
        }

        /// <summary>
        /// Updates aviability of minutes/seconds text box for play/pause states.
        /// </summary>
        private void updateControlsEnabled()
        {
            textBoxMinutes.Enabled = textBoxSeconds.Enabled = IsEditing;

            trackBarMinOpacity.Visible = buttonTimeoutsMore.Visible = buttonTimeoutsLess.Visible = IsEditing;
        }

        /// <summary>
        /// Update timeouts label with current timeouts out of maximum timeouts.
        /// </summary>
        private void updateTimeoutsText()
        {
            labelTimeoutsCounter.ResetText();
            for (uint i = 0; i < CurrentTimeouts; i++)
            {
                if (i != 0)
                    labelTimeoutsCounter.Text += " ";
                labelTimeoutsCounter.Text += CHECKED_RESET_COUNTER;
            }

            if (CurrentTimeouts > 0)
                labelTimeoutsCounter.Text += " ";

            for (uint i = 0; i < MaxTimeouts - CurrentTimeouts; i++)
            {
                if (i != 0)
                    labelTimeoutsCounter.Text += " ";
                labelTimeoutsCounter.Text += EMPTY_RESET_COUNTER;
            }
            labelTimeoutsCounter.Text = labelTimeoutsCounter.Text.Trim();
        }

        /// <summary>
        /// Saves timer start time to user settings from text boxes.
        /// </summary>
        private void saveSettings()
        {
            Properties.Settings.Default.Minutes = _set_minutes = uint.Parse(textBoxMinutes.Text);
            Properties.Settings.Default.Seconds = _set_seconds = uint.Parse(textBoxSeconds.Text);
            Properties.Settings.Default.Save();
        }

        private void onTimeout()
        {
            CurrentTimeouts++;
            IsPlaying = false;
            if (!_is_active)
            {
                new ToastContentBuilder()
                .AddText("Time is up!")
                .AddButton(new ToastButton()
                    .SetContent("Dismiss")
                    .SetBackgroundActivation())
                .SetToastScenario(ToastScenario.Reminder)
                .Show();
                timerTimeoutAnimation.Start();
            }
        }

        private void stopTimeoutAnimation()
        {
            timerTimeoutAnimation.Stop();
            textBoxMinutes.Visible = textBoxSeconds.Visible = true;
        }

        private void updateStopwatchTextTime()
        {
            labelStopwatch.Text = String.Format(FORMAT_STOPWATCH, StopwatchHours, StopwatchMinutes, StopwatchSeconds);
        }

        private void updateTimerTime()
        {
            uint seconds = CurrentSeconds;
            uint minutes = CurrentMinutes;
            if (seconds == 1 && minutes == 0)
            {
                seconds--;
                onTimeout();
            }
            else if (seconds == 0)
            {
                seconds = 59;
                minutes--;
            }
            else
            {
                seconds--;
            }

            CurrentMinutes = minutes;
            CurrentSeconds = seconds;
        }

        private void updateStopwatchTime()
        {
            uint seconds = StopwatchSeconds;
            uint minutes = StopwatchMinutes;
            uint hours = StopwatchHours;

            seconds++;
            if (seconds >= 60)
            {
                seconds = 0;
                minutes++;
                if (minutes >= 60)
                {
                    hours++;
                }
            }

            StopwatchHours = hours;
            StopwatchMinutes = minutes;
            StopwatchSeconds = seconds;
        }

        #endregion

        #region Callbacks

        #region Main window callbacks

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (IsEditing)
            {
                if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
                    IsEditing = false;
            }
            else
            {
                if (e.KeyCode == Keys.Space && !IsEditing)
                    IsPlaying = !IsPlaying;
            }

            e.Handled = true;
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            _is_active = true;
            timerFadingAnimation.Start();
            _current_fading_state = FadingState.FADING_IN;
            if (timerTimeoutAnimation.Enabled)
                stopTimeoutAnimation();
        }

        private void Main_Deactivate(object sender, EventArgs e)
        {
            _is_active = false;
            timerFadingAnimation.Start();
            _current_fading_state = FadingState.FADING_OUT;
        }

        #endregion

        #region Timers ticks

        /// <summary>
        /// Timer's countdown update.
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (IsPlaying)
                updateTimerTime();

            if (IsStopwatchOn)
                updateStopwatchTime();
        }

        private void timerTimeoutAnimation_Tick(object sender, EventArgs e)
        {
            textBoxMinutes.Visible = textBoxSeconds.Visible = !textBoxMinutes.Visible;
        }

        private void timerFadingAnimation_Tick(object sender, EventArgs e)
        {
            Opacity += (_current_fading_state == FadingState.FADING_OUT) ? -FADING_OUT_SPEED : FADING_IN_SPEED;
            if (Opacity < _min_window_opacity || Opacity > 1.0f)
            {
                Opacity = Math.Min(Math.Max(_min_window_opacity, Opacity), 1.0f);
                timerFadingAnimation.Stop();
            }
            Update();
        }

        #endregion

        #region Close button

        private void buttonClose_Click(object sender, EventArgs e) { Application.Exit(); }
        
        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            buttonClose.BackgroundImage = Properties.Resources.close_selected;
            buttonClose.Refresh();
        }

        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            buttonClose.BackgroundImage = Properties.Resources.close;
            buttonClose.Refresh();
        }

        #endregion

        #region Edit button

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            IsEditing = !IsEditing;
        }

        private void buttonEdit_MouseEnter(object sender, EventArgs e)
        {
            buttonEdit.BackgroundImage = Properties.Resources.edit_selected;
            buttonEdit.Refresh();
        }
        private void buttonEdit_MouseLeave(object sender, EventArgs e)
        {
            buttonEdit.BackgroundImage = Properties.Resources.edit;
            buttonEdit.Refresh();
        }

        #endregion

        #region Play button

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            IsPlaying = !IsPlaying;
            IsEditing = false;
        }

        private void buttonPlay_MouseEnter(object sender, EventArgs e)
        {
            _is_mouse_over_play = true;
            updatePlayButton();
        }

        private void buttonPlay_MouseLeave(object sender, EventArgs e)
        {
            _is_mouse_over_play = false;
            updatePlayButton();
        }

        #endregion

        #region Reset button

        private void buttonReset_MouseEnter(object sender, EventArgs e)
        {
            buttonReset.BackgroundImage = Properties.Resources.reset_selected;
            buttonReset.Refresh();
        }

        private void buttonReset_MouseLeave(object sender, EventArgs e)
        {
            buttonReset.BackgroundImage= Properties.Resources.reset;
            buttonReset.Refresh();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            CurrentTimeouts = 0;
            IsEditing = IsPlaying = IsStopwatchOn = false;
            CurrentMinutes = _set_minutes;
            CurrentSeconds = _set_seconds;
            StopwatchHours = StopwatchMinutes = StopwatchSeconds = 0;
        }

        #endregion

        #region Timeouts less/more buttons

        private void buttonTimeoutsLess_Click(object sender, EventArgs e)
        {
            if (MaxTimeouts <= 1) return;
            MaxTimeouts--;
        }


        private void buttonTimeoutsMore_Click(object sender, EventArgs e)
        {
            if (MaxTimeouts == MAX_MAX_TIMEOUTS) return;
            MaxTimeouts++;
        }


        private void buttonTimeoutsLess_MouseEnter(object sender, EventArgs e)
        {
            buttonTimeoutsLess.BackgroundImage = Properties.Resources.arrow_left_selected;
            buttonTimeoutsLess.Refresh();
        }


        private void buttonTimeoutsLess_MouseLeave(object sender, EventArgs e)
        {
            buttonTimeoutsLess.BackgroundImage = Properties.Resources.arrow_left;
            buttonTimeoutsLess.Refresh();
        }

        private void buttonTimeoutsMore_MouseEnter(object sender, EventArgs e)
        {
            buttonTimeoutsMore.BackgroundImage = Properties.Resources.arrow_right_selected;
            buttonTimeoutsMore.Refresh();
        }


        private void buttonTimeoutsMore_MouseLeave(object sender, EventArgs e)
        {
            buttonTimeoutsMore.BackgroundImage = Properties.Resources.arrow_right;
            buttonTimeoutsMore.Refresh();
        }

        #endregion

        #region Minutes/seconds text boxes

        private void textBoxMinutes_Validated(object sender, EventArgs e)
        {
            uint minutes;
            try
            {
                minutes = uint.Parse(textBoxMinutes.Text);
            }
            catch (Exception)
            {
                minutes = 0;
            }
            CurrentMinutes = minutes;
        }

        private void textBoxSeconds_Validated(object sender, EventArgs e)
        {
            uint seconds;
            try
            {
                seconds = uint.Parse(textBoxSeconds.Text);
            }
            catch (Exception)
            {
                seconds = 0;
            }
            CurrentSeconds = seconds;
        }

        private void validateKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        #endregion

        #region Window drag

        private void onWindowDragMouseDown(object sender, MouseEventArgs e)
        {
            _is_dragging_window = true;
            _last_window_dragging_location = e.Location;
        }

        private void onWindowDragMouseUp(object sender, MouseEventArgs e)
        {
            _is_dragging_window = false;
        }


        private void onWindowDragMouseMove(object sender, MouseEventArgs e)
        {
            if (_is_dragging_window)
            {
                Location = new Point(
                    (Location.X - _last_window_dragging_location.X) + e.X,
                    (Location.Y - _last_window_dragging_location.Y) + e.Y
                );
                Update();
            }
        }

        #endregion

        #region Track bar opacity

        private void trackBarMinOpacity_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MinOpacity = _min_window_opacity = (float)trackBarMinOpacity.Value / 100.0f;
            toolTipOpacity.SetToolTip(trackBarMinOpacity, String.Format(TOOLTIP_OPACITY_FORMAT_CAPTION, trackBarMinOpacity.Value));
        }

        #endregion

        #endregion

    }
}
