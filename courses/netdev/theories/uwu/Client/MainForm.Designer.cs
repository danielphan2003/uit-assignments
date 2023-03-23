using System;
using System.Drawing;
using System.Windows.Forms;

namespace uwu.Client;

partial class MainForm
{
    private TextBox externalServerInput;
    private TextBox chatView;
    private TextBox chatInput;

    private void InitializeComponent()
    {
        Text = "Chat with uwu"; 

        AutoScaleMode = AutoScaleMode.Font;

        MinimumSize = new Size(800, 450);

        var panel = new TableLayoutPanel() {
            AutoSize = true,
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            RowCount = 2,
        };
        
        Controls.Add(panel);

        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
        panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
        panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));

        panel.Controls.Add(new Control {
            Dock = DockStyle.Fill,
        });

        var settingPanel = new TableLayoutPanel()
        {
            AutoSize = true,
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            RowCount = 1,
        };

        settingPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
        settingPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
        settingPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        settingPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        panel.Controls.Add(settingPanel);

        var localButton = new RadioButton()
        {
            Text = "Local",
            Checked = true,
        };

        settingPanel.Controls.Add(localButton);

        var externalButton = new RadioButton()
        {
            Text = "External",
        };

        externalButton.CheckedChanged += (o, e) => {
            externalServerInput.Enabled = externalButton.Checked;
        };

        settingPanel.Controls.Add(externalButton);

        externalServerInput = new()
        {
            Dock = DockStyle.Fill,
            // Anchor = AnchorStyles.Left | AnchorStyles.Right,
            Enabled = false,
        };

        settingPanel.Controls.Add(externalServerInput);

        panel.Controls.Add(new Control {
            Dock = DockStyle.Fill,
        });

        panel.Controls.Add(new Control {
            Dock = DockStyle.Fill,
        });
        
        chatView = new()
        {
            PlaceholderText = "It's empty around here ;)",
            ReadOnly = true,
            Multiline = true,
            WordWrap = true,
            ScrollBars = ScrollBars.Vertical,
            Dock = DockStyle.Fill,
        };

        panel.Controls.Add(chatView);

        panel.Controls.Add(new Control {
            Dock = DockStyle.Fill,
        });

        panel.Controls.Add(new Control {
            Dock = DockStyle.Fill,
        });

        var chatInputPanel = new TableLayoutPanel()
        {
            AutoSize = true,
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 1,
        };

        chatInputPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        chatInputPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        chatInputPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        chatInput = new()
        {
            Multiline = true,
            WordWrap = true,
            PlaceholderText = "Start a new conversation (try out /help)...",
            ScrollBars = ScrollBars.Vertical,
            Dock = DockStyle.Fill,
        };

        chatInputPanel.Controls.Add(chatInput);

        var sendMessage = new Button()
        {
            Text = "Send",
            // AutoSize = true,
            Dock = DockStyle.Fill,
        };

        sendMessage.Click += new EventHandler(OnSendMessage);

        chatInputPanel.Controls.Add(sendMessage);

        panel.Controls.Add(chatInputPanel);

        panel.Controls.Add(new Control {
            Dock = DockStyle.Fill,
        });
    }
}
