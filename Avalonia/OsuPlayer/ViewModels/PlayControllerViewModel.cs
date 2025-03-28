using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Media.Imaging;

namespace Milki.OsuPlayer.ViewModels
{
    public class PlayControllerViewModel : INotifyPropertyChanged
    {
        private string _title = "示例歌曲标题";
        private string _artist = "示例艺术家";
        private TimeSpan _currentPosition = TimeSpan.Zero;
        private TimeSpan _totalDuration = TimeSpan.FromMinutes(3.5);
        private double _progress = 0;
        private bool _isPlaying = false;
        private bool _isFavorite = false;
        private Bitmap _thumbnail = null;
        private int _playMode = 0; // 0: 顺序播放, 1: 单曲循环, 2: 随机播放

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Artist
        {
            get => _artist;
            set
            {
                if (_artist != value)
                {
                    _artist = value;
                    OnPropertyChanged();
                }
            }
        }

        public TimeSpan CurrentPosition
        {
            get => _currentPosition;
            set
            {
                if (_currentPosition != value)
                {
                    _currentPosition = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(CurrentPositionString));
                }
            }
        }

        public string CurrentPositionString => _currentPosition.ToString(@"mm\:ss");

        public TimeSpan TotalDuration
        {
            get => _totalDuration;
            set
            {
                if (_totalDuration != value)
                {
                    _totalDuration = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalDurationString));
                }
            }
        }

        public string TotalDurationString => _totalDuration.ToString(@"mm\:ss");

        public double Progress
        {
            get => _progress;
            set
            {
                if (_progress != value)
                {
                    _progress = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsPlaying
        {
            get => _isPlaying;
            set
            {
                if (_isPlaying != value)
                {
                    _isPlaying = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsFavorite
        {
            get => _isFavorite;
            set
            {
                if (_isFavorite != value)
                {
                    _isFavorite = value;
                    OnPropertyChanged();
                }
            }
        }

        public Bitmap Thumbnail
        {
            get => _thumbnail;
            set
            {
                if (_thumbnail != value)
                {
                    _thumbnail = value;
                    OnPropertyChanged();
                }
            }
        }

        public int PlayMode
        {
            get => _playMode;
            set
            {
                if (_playMode != value)
                {
                    _playMode = value;
                    OnPropertyChanged();
                }
            }
        }

        // 命令和方法将在后续实现
        public void PlayPause()
        {
            IsPlaying = !IsPlaying;
        }

        public void PlayNext()
        {
            // 示例实现
            Title = "下一首歌曲";
            Artist = "下一位艺术家";
        }

        public void PlayPrevious()
        {
            // 示例实现
            Title = "上一首歌曲";
            Artist = "上一位艺术家";
        }

        public void ToggleFavorite()
        {
            IsFavorite = !IsFavorite;
        }

        public void ChangePlayMode()
        {
            PlayMode = (PlayMode + 1) % 3;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}