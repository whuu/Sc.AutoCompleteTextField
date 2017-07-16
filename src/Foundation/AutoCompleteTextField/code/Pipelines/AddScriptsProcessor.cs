using System.Collections.Generic;
using System.Web.UI;
using Sitecore;
using Sitecore.Pipelines;

namespace SmartSitecore.AutoCompleteTextField.Pipelines
{
    /// <summary>
    /// Add scripts and styles to page header
    /// </summary>
    public class AddScriptsProcessor
    {
        private const string scriptResourceTag = @"<script src=""{0}""></script>";

        private const string stylesResourceTag = @"<link href=""{0}"" rel=""stylesheet""/>";

        private readonly List<string> _scripts = new List<string>();

        private readonly List<string> _styles = new List<string>();

        [UsedImplicitly]
        public void AddScript(string resource)
        {
            _scripts.Add(resource);
        }

        [UsedImplicitly]
        public void AddStyle(string resource)
        {
            _styles.Add(resource);
        }

        [UsedImplicitly]
        public void Process(PipelineArgs args)
        {
            foreach (string script in this._scripts)
            {
                Context.Page.Page.Header.Controls.Add(new LiteralControl(string.Format(scriptResourceTag, script)));
            }

            foreach (string style in this._styles)
            {
                Context.Page.Page.Header.Controls.Add(new LiteralControl(string.Format(stylesResourceTag, style)));
            }
        }
    }
}