/*
namespace CheckWebsite;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();    
        checkLinkButton.Click += CheckLinkButton_Click;
        selectFileButton.Click += SelectFileButton_Click;
    }

    private void CheckLinkButton_Click(object sender, EventArgs e)
    {
        // TODO: Implement link checking logic
        MessageBox.Show("Check Link button clicked!");
    }

    private void SelectFileButton_Click(object sender, EventArgs e)
    {
        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.Title = "Select Output File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputTextBox.Text = saveFileDialog.FileName;
            }
        }
    }
}

*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace CheckWebsite;

public partial class Form1 : Form
{
    private HttpClient _httpClient;

    public Form1()
    {
        InitializeComponent();
        checkLinkButton.Click += CheckLinkButton_Click;
        selectFileButton.Click += SelectFileButton_Click;

        // Initialize HttpClient
        _httpClient = new HttpClient();
    }

    private async void CheckLinkButton_Click(object sender, EventArgs e)
    {
        string url = urlTextBox.Text;

        if (string.IsNullOrEmpty(url))
        {
            MessageBox.Show("Please enter a valid URL.");
            return;
        }

        try
        {
            var brokenLinks = await CheckLinksAsync(url);
            if (brokenLinks.Count > 0)
            {
                MessageBox.Show($"Broken links found:\n{string.Join("\n", brokenLinks)}");
            }
            else
            {
                MessageBox.Show("No broken links found.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error checking links: {ex.Message}");
        }
    }

    private async Task<List<string>> CheckLinksAsync(string url)
    {
        var brokenLinks = new List<string>();
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to retrieve the URL. Status code: {response.StatusCode}");
        }

        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(await response.Content.ReadAsStringAsync());

        var links = htmlDocument.DocumentNode.SelectNodes("//a[@href]");

        if (links != null)
        {
            foreach (var link in links)
            {
                var linkUrl = link.GetAttributeValue("href", string.Empty);

                if (string.IsNullOrEmpty(linkUrl)) continue;

                // Check if the link is absolute or relative
                if (!linkUrl.StartsWith("http"))
                {
                    Uri baseUri = new Uri(url);
                    Uri absoluteUri = new Uri(baseUri, linkUrl);
                    linkUrl = absoluteUri.ToString();
                }

                try
                {
                    var linkResponse = await _httpClient.GetAsync(linkUrl);
                    if (!linkResponse.IsSuccessStatusCode)
                    {
                        brokenLinks.Add(linkUrl);
                    }
                }
                catch
                {
                    brokenLinks.Add(linkUrl);
                }
            }
        }

        return brokenLinks;
    }

    private void SelectFileButton_Click(object sender, EventArgs e)
    {
        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.Title = "Select Output File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputTextBox.Text = saveFileDialog.FileName;
            }
        }
    }
}
