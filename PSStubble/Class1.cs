using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Management;
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


        protected override void ProcessRecord()
        {
            var stubble = new StubbleBuilder().Build();
            var serializer = new JavaScriptSerializer();
            object data = serializer.Deserialize<IDictionary<string, object>>(json);
            string output = stubble.Render(template, data);
            output = CustomWhiteSpaceCleaner(output);
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
