The [answer](https://stackoverflow.com/a/74927399/5438626) by Klaus Gütter is one of the more optimal ways to go about this. To expand on that excellent post, this code shows in detail how to create and consume the sound file. 

Here's a simple player that I tested and works on my end.

***
Create the embedded resource from the sound file:

[![designate embedded resource][1]][1]

***
Obtain the file stream and attach it to the player.

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


  [1]: https://i.stack.imgur.com/x39DS.png