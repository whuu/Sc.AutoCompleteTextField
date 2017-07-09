using System;
using System.Linq;

namespace SmartSitecore.AutoCompleteTextField.Fields
{
    /// <summary>
    /// Autocomplete Sitecore Single-line Text Field
    /// Usage:
    /// 1) Inherit from this type and implement GetServiceUrl method: 
    /// - it should return url to ajax web method.
    /// - method should return list of string as json object, like:
    /// {
    ///     "suggestions": [
    ///         { "value": "United Kingdom",       "data": "UK" },
    ///         { "value": "United States",        "data": "US" }
    ///     ]
    ///}
    /// For details check https://github.com/devbridge/jQuery-Autocomplete
    /// 2) Create new field type in Sitecore core database, poiting to your class and use it in the templates 
    /// </summary>
    public abstract class AutoCompleteTextField : Sitecore.Shell.Applications.ContentEditor.Text
    {
        protected abstract string GetDatasourceUrl();

        protected override void DoRender(System.Web.UI.HtmlTextWriter output)
        {
            string id = FindID(base.ControlAttributes);
            output.Write(@"<script>
                        $sc(document).ready(function() {
                            $sc('#" + id + @"').autocomplete({
                                serviceUrl: '" + GetDatasourceUrl() + @"'
                            })
                        });
                    </script>");
            base.DoRender(output);
        }

        private string FindID(string attrs)
        {
            var parts = attrs.Split(' ');
            var part = parts.Where(p => p.StartsWith("id=", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            if (part == null)
            {
                return null;
            }
            string[] segments = part.Split('=');
            return segments[1].Replace("\"", "");
        }
    }
}