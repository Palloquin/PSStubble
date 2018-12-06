using System.Collections.Generic;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Stubble.Core.Builders;
using System.Web.Script.Serialization;

namespace ClassLibrary1
{
    [Cmdlet("Invoke", "Stubble")]
    [OutputType(typeof(string))]

    public class InvokeStubbleCmdlet : Cmdlet
    {
        [Parameter]
        public string template { get; set; }
        [Parameter]
        public string json { get; set; }

        [Parameter]
        public SwitchParameter useCustomWhiteSpaceClearner { get; set; }


        protected override void ProcessRecord()
        {
            var stubble = new StubbleBuilder().Build();
            var serializer = new JavaScriptSerializer();
            object data = serializer.Deserialize<IDictionary<string, object>>(json);
            string output = stubble.Render(template, data);
            if (useCustomWhiteSpaceClearner)
            {
                output = CustomWhiteSpaceCleaner(output);
            }
            WriteObject(output);

        }

        internal string CustomWhiteSpaceCleaner( string input)
        {

            string output = Regex.Replace(input, "{\\|\\s*\\|}((\\r\\n)|\\r|\\n)", "");
            output = Regex.Replace(output, "({\\|)|(\\|})", "");
            //output = Regex.Replace(output, "\\r\\n", "");

            return output;
        }

    }

    
    
}
