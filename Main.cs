﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Toolkit.Uwp.Notifications;


namespace Timeit
{
    public partial class Main : Form
    {
        #region Constants

        const String FORMAT_TIME = "{0:d2}";
        
        const char CHECKED_RESET_COUNTER = 'x';
        const char EMPTY_RESET_COUNTER = 'o';
        
        const uint MAX_MAX_TIMEOUTS = 7;

        const float MIN_OPACITY = 0.25f;
        const float MAX_OPACITY = 1.0f;
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

                if (was_playing)
                {
                    timer.Stop();
                }
                else
                {
                    timer.Start();
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
                updatePlayButton();
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
                
                if (!was_editing && IsPlaying)
                    IsPlaying = false;

                if (was_editing)
                {
                    saveSetTime();
                    buttonEdit.BackColor = BackColor;
                }
                else
                {
                    if (timerTimeoutAnimation.Enabled)
                        stopTimeoutAnimation();
                    textBoxMinutes.Focus();
                    ActiveControl = textBoxMinutes;
                    buttonEdit.BackColor = buttonEdit.FlatAppearance.MouseDownBackColor;
                }
                
                __is_editing = value;

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
            
            updatePlayButton();
            updateControlsEnabled();
        }

        #region Utils

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
            buttonPlay.Enabled = buttonReset.Enabled = !IsEditing;
            textBoxMinutes.Enabled = textBoxSeconds.Enabled = IsEditing;

            buttonTimeoutsMore.Visible = buttonTimeoutsLess.Visible = IsEditing;
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
        private void saveSetTime()
        {
            Properties.Settings.Default.Minutes = _set_minutes = uint.Parse(textBoxMinutes.Text);
            Properties.Settings.Default.Seconds = _set_seconds = uint.Parse(textBoxSeconds.Text);
            Properties.Settings.Default.Save();
        }

        private void onTimeout()
        {
            IsPlaying = false;
            CurrentTimeouts++;
            new ToastContentBuilder()
                .AddText("Time is up!")
                .AddButton(new ToastButton()
                    .SetContent("Dismiss")
                    .SetBackgroundActivation())
                .SetToastScenario(ToastScenario.Reminder)
                .Show();
            if (!_is_active)
                timerTimeoutAnimation.Start();
        }

        private void stopTimeoutAnimation()
        {
            timerTimeoutAnimation.Stop();
            textBoxMinutes.Visible = textBoxSeconds.Visible = true;
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
                if (e.KeyCode == Keys.Left)
                    MaxTimeouts--;
                if (e.KeyCode == Keys.Right)
                    MaxTimeouts++;
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

        private void timerTimeoutAnimation_Tick(object sender, EventArgs e)
        {
            textBoxMinutes.Visible = textBoxSeconds.Visible = !textBoxMinutes.Visible;
        }

        private void timerFadingAnimation_Tick(object sender, EventArgs e)
        {
            Opacity += (_current_fading_state == FadingState.FADING_OUT) ? -FADING_OUT_SPEED : FADING_IN_SPEED;
            if (Opacity < MIN_OPACITY || Opacity > MAX_OPACITY)
            {
                Opacity = Math.Min(Math.Max(MIN_OPACITY, Opacity), MAX_OPACITY);
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
            IsPlaying = false;
            CurrentMinutes = _set_minutes;
            CurrentSeconds = _set_seconds;
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

        #endregion

        private void tableLayoutTimeouts_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}