using System.Diagnostics;
using System.Media;

namespace sound_player_00
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            buttonPlay.Click += onPlay;
        }
        private SoundPlayer _player = new SoundPlayer();
        private void onPlay(object sender, EventArgs e)
        {
            var resource =
                GetType()
                .Assembly
                .GetManifestResourceNames()
                .FirstOrDefault(_ => _.Contains("hello-world.wav"));

            if (resource == null)
            {
                Debug.Assert(false, "Resource not found.");
            }
            else
            {
                using (var stream = 
                    GetType()
                    .Assembly
                    .GetManifestResourceStream(resource))
                {
                    _player.Stream = stream;
                    _player.Play();
                }
            }
        }
    }
}