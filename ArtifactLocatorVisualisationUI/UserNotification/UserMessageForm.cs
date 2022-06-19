namespace ArtifactLocatorVisualisationUI.UserNotification
{
    public partial class UserMessageForm : Form
    {
        public UserMessageForm(MessageType messageType, string messageText)
        {
            InitializeComponent();

            this.Text = messageType.ToString();
            messageLabel.Text = messageText;

            this.ShowDialog();
        }

        public static void Error(string messageText) => new UserMessageForm(MessageType.Error, messageText);
        public static void Warn(string messageText) => new UserMessageForm(MessageType.Warning, messageText);
        public static void Info(string messageText) => new UserMessageForm(MessageType.Info, messageText);

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
